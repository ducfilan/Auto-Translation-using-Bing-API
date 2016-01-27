using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using WPFOnlineTranslator;

namespace UpdateDataForLocalizedTables
{
    public partial class FormTranslateData : Form
    {
        SqlConnection _connection = new SqlConnection();
        AdmAuthentication _auth;
        ConfirmedLocalizedTable _currentWorkingTable;
        List<BingClient> _clientsList = new List<BingClient>();

        public FormTranslateData()
        {
            InitializeComponent();
            try
            {
                //_auth = new AdmAuthentication(@"DucFilan", @"2DexPC6LB8AuqXJtxPuTlP4PzYKW3gHCz60uocTo4Fs=");
                _auth = new AdmAuthentication(@"duchn2", @"Z+8Y35jaVhqPoHWvskoLC/ED7+E8NVCoABLwfoaGgjI=");
                lblCurentClientID.Text = _auth.GetClientID();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + @"Er 1");
            }
        }

        private void BrowseFileExcelButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            tbXLSFilePath.Text = openFileDialog1.FileName;
            if (txtAccTxt.Text.Equals(string.Empty)) return;
            btnTranslate.Enabled = true;
        }

        private List<string> GetSupportedLaguages()
        {
            ConnectionManager.Instance.GetConnection(ref _connection);

            var languageNameList = new List<string>();

            if (_connection == null || _connection.State != ConnectionState.Open) return languageNameList;
            try
            {
                const string query = @"SELECT DISTINCT CultureName
                                  FROM
                                    (SELECT *
                                     FROM AH_MASTER_CULTURE) AMC
                                  INNER JOIN
                                    (SELECT *
                                     FROM AH_MASTER_CULTURE_OUCultureKey_XREF) AMCOX 
                                  ON AMC.Culture_ID = AMCOX.Culture_ID";

                var command = new SqlCommand(query, _connection);
                var cultureNameTable = new DataTable("CultureName");
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(cultureNameTable);

                if (cultureNameTable.Rows != null && cultureNameTable.Rows.Count > 0)
                {
                    foreach (DataRow row in cultureNameTable.Rows)
                    {
                        languageNameList.Add(row.ItemArray[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + @" Er 2 - FormTranslateData");
            }

            return languageNameList;
        }

        delegate void UpdateTranslatedDataDelegate();

        private void DisbleButtonsDuringTranslation()
        {
            btnCancel.Enabled = false;
            btnTranslate.Enabled = false;
            btnAccBrowse.Enabled = false;
            btnBrowseFileExcel.Enabled = false;
            listFail.Items.Clear();
        }

        private void TranslationCompletes(IAsyncResult iAResult)
        {
            var del = (UpdateTranslatedDataDelegate)((AsyncResult)iAResult).AsyncDelegate;
            del.EndInvoke(iAResult);
            lblCurentTb.Invoke(new MethodInvoker(
              delegate
              {
                  btnCancel.Enabled = true;
                  btnTranslate.Enabled = true;
                  btnAccBrowse.Enabled = true;
                  btnBrowseFileExcel.Enabled = true;

                  MessageBox.Show(@"Translation completed! Check for fail tables!");
              }
              ));
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            DisbleButtonsDuringTranslation();
            GetClientInfoList(ref _clientsList);

            ConnectionManager.Instance.GetConnection(ref _connection);

            var updateTranslatedData = new UpdateTranslatedDataDelegate(UpdateTranslatedData);
            updateTranslatedData.BeginInvoke(TranslationCompletes, null);
        }

        private void UpdateTranslatedData()
        {
            var confirmedLocalizedTablesList = GetConfirmedLocalizedTablesList(tbXLSFilePath.Text);

            if (_connection == null || _connection.State != ConnectionState.Open) return;
            try
            {
                foreach (var itemTablesList in confirmedLocalizedTablesList)
                {
                    _currentWorkingTable = itemTablesList;

                    var dataEnEuList = getEN_AUData(itemTablesList);
                    var tablePrimaryKey = GetColumnPrimaryKeyName(itemTablesList.TableName);

                    List<string> supportedLanguage = GetSupportedLaguages();

                    foreach (var itemSupportedLanguage in supportedLanguage)
                    {
                        var query = string.Format(@"UPDATE {0}_LOCALIZED SET ", itemTablesList.TableName);

                        foreach (var itemColumnsToLocalize in itemTablesList.ColumnsToLocalize)
                        {
                            //Avoid backspace in Column name
                            query += string.Format(@"[{0}] = @{1}, ", itemColumnsToLocalize, itemColumnsToLocalize.Replace(' ', '.'));
                        } 

                        query = query.Substring(0, query.Length - 2) + " WHERE ";

                        query += string.Format(@"[{0}] = @{1} ", tablePrimaryKey[0], tablePrimaryKey[0].Replace(' ', '.'));
                        for (int i = 1; i < tablePrimaryKey.Length; i++)
                        {
                            query += string.Format(@"AND [{0}] = @{1}", tablePrimaryKey[i], tablePrimaryKey[i].Replace(' ', '.'));
                        }

                        query += @" AND (";
                        int[] ouCultureKeyArray = getOU_CULTURE_KEYByCultureName(itemSupportedLanguage);
                        foreach (var itemOuCultureKeyArray in ouCultureKeyArray)
                        {
                            query += string.Format(" OU_CULTURE_KEY = {0} OR ", itemOuCultureKeyArray);
                        }

                        query = query.Substring(0, query.Length - 3) + " )";

                        foreach (var itemDataEnEuList in dataEnEuList)
                        {
                            var cmd = new SqlCommand(query, _connection);

                            int i = 0;
                            foreach (var itemColumnsToLocalize in itemTablesList.ColumnsToLocalize)
                            {
                                var value = itemDataEnEuList.ElementAt(i++);
                                if (value.Equals(string.Empty))
                                {
                                    cmd.Parameters.AddWithValue(itemColumnsToLocalize, DBNull.Value);
                                }
                                else
                                {
                                    if (itemSupportedLanguage.Substring(0, 2).Equals("en", StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        cmd.Parameters.AddWithValue(itemColumnsToLocalize, value);
                                    }
                                    else
                                    {
                                        var translatedText = "";
                                        var charactersCount = value.Length;
                                        var end = 0;
                                        var hasPostionOfEndChange = false;

                                        if (charactersCount > 2000)
                                        {
                                            string translatedPart;

                                            for (int ic = 0; ic < charactersCount / 2000; ic++)
                                            {
                                                int start = 2000 * ic;
                                                if (hasPostionOfEndChange)
                                                {
                                                    start = end;
                                                    hasPostionOfEndChange = false;
                                                }
                                                end = 2000 * (ic + 1);
                                                const int maxWordLeng = 50;
                                                int changePositionToBackspace = 0;
                                                while (changePositionToBackspace++ < maxWordLeng && end < value.Length && value[end] != ' ')
                                                {
                                                    end++;
                                                    hasPostionOfEndChange = true;
                                                }

                                                translatedPart =
                                                    TranslateText(value.Substring(start, end - start), "en",
                                                        itemSupportedLanguage.Substring(0, 2));
                                                if (translatedPart.Equals(string.Empty))
                                                {
                                                    SetText(listFail, _currentWorkingTable.TableName);
                                                    return;
                                                }
                                                translatedText += translatedPart;
                                            }
                                            translatedPart = TranslateText(value.Substring(end, value.Length - end), "en", itemSupportedLanguage.Substring(0, 2));
                                            if (translatedPart.Equals(string.Empty))
                                            {
                                                SetText(listFail, _currentWorkingTable.TableName);
                                                return;
                                            }
                                            translatedText += translatedPart;
                                        }
                                        else
                                        {
                                            translatedText = TranslateText(value, "en", itemSupportedLanguage.Substring(0, 2));
                                            if (translatedText.Equals(string.Empty))
                                            {
                                                SetText(listFail, _currentWorkingTable.TableName);
                                                return;
                                            }
                                        }

                                        cmd.Parameters.AddWithValue(itemColumnsToLocalize, translatedText);
                                    }
                                }
                            }

                            foreach (string itemTablePrimaryKey in tablePrimaryKey)
                            {
                                cmd.Parameters.AddWithValue(itemTablePrimaryKey, itemDataEnEuList.ElementAt(i++));
                            }
                            cmd.ExecuteNonQuery();

                            SetText(lblCurentTb, _currentWorkingTable.TableName);
                        }
                    }
                }

                ConnectionManager.Instance.CloseConnection(ref _connection);
            }
            catch (Exception)
            {
                SetText(listFail, _currentWorkingTable.TableName);
            }
        }

        delegate void SetTextDelegate(Object obj, string text);

        private void SetText(Object obj, string text)
        {
            string type = obj.GetType().Name;
            if (type.Equals("ListBox"))
            {
                if (((ListBox)obj).InvokeRequired)
                {
                    var d = new SetTextDelegate(SetText);
                    Invoke(d, new object[] { obj, text });
                }
                else
                {
                    ((ListBox)obj).Items.Add(text);
                }
            }
            else if (type.Equals("Label"))
            {
                if (((Label)obj).InvokeRequired)
                {
                    var d = new SetTextDelegate(SetText);
                    Invoke(d, new object[] { obj, text });
                }
                else
                {
                    ((Label)obj).Text = text;
                }
            }
        }

        private int[] getOU_CULTURE_KEYByCultureName(string cultureName)
        {
            ConnectionManager.Instance.GetConnection(ref _connection);

            var cultureNameList = new List<int>();
            try
            {
                if (_connection != null && _connection.State == ConnectionState.Open)
                {
                    var query = string.Format(@"SELECT OU_CULTURE_KEY FROM 
                                    (SELECT * from AH_MASTER_CULTURE) AMC
                                        inner join 
                                    (SELECT * FROM AH_MASTER_CULTURE_OUCultureKey_XREF) AMCOX
                                        ON AMC.Culture_ID = AMCOX.Culture_ID
                                    WHERE CultureName = '{0}'", cultureName);

                    var cmd = new SqlCommand(query, _connection);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cultureNameList.Add(int.Parse(reader["OU_CULTURE_KEY"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + @" Er 3 - FormTranslateData");
            }

            return cultureNameList.ToArray();
        }

        private List<List<string>> getEN_AUData(ConfirmedLocalizedTable confirmedLocalizedTable)
        {
            string query = @"SELECT ";
            foreach (var item in confirmedLocalizedTable.ColumnsToLocalize)
            {
                query += string.Format(@"{0}, ", item);
            }

            var tablePrimaryKey = GetColumnPrimaryKeyName(confirmedLocalizedTable.TableName);
            foreach (var item in tablePrimaryKey)
            {
                query += item + ", ";
            }

            query = query.Substring(0, query.Length - 2)
                + string.Format(@" FROM {0}", confirmedLocalizedTable.TableName); //Old: {0}_LOCALIZED WHERE 

            var command = new SqlCommand(query, _connection);
            var tableListTable = new DataTable("TableList");
            var dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(tableListTable);

            var dataEnEuList = new List<List<string>>();
            if (tableListTable.Rows != null && tableListTable.Rows.Count > 0)
            {
                foreach (DataRow row in tableListTable.Rows)
                {
                    var columnData = new List<string>();
                    for (int i = 0; i < tableListTable.Columns.Count; i++)
                    {
                        columnData.Add(row.ItemArray[i].ToString());
                    }
                    dataEnEuList.Add(columnData);
                }
            }

            return dataEnEuList;
        }

        private string[] GetColumnPrimaryKeyName(string tableName)
        {
            if (tableName == null) throw new ArgumentNullException("tableName");

            var columnIdName = new List<string>();

            var query = string.Format(@"SELECT COLUMN_NAME
                                    FROM INFORMATION_SCHEMA.COLUMNS
                                    WHERE TABLE_NAME = '{0}' INTERSECT
                                        SELECT COLUMN_NAME
                                        FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS [TC]
                                        JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE [KU] ON TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
                                        AND TC.CONSTRAINT_TYPE = 'PRIMARY KEY'
                                        AND KU.TABLE_NAME = '{0}'", tableName.Trim());

            var cmd = new SqlCommand(query) { Connection = _connection };

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                columnIdName.Add(reader["COLUMN_NAME"].ToString().Trim());
            }

            reader.Close();
            return columnIdName.ToArray();
        }

        /*
         * Old Bing 2.0 - Use App ID
         * 
        private string translateText(string textToTranslate, string from, string to)
        {
            string strTranslatedText = string.Empty;
            try
            {
                TranslatorService.LanguageServiceClient client = new TranslatorService.LanguageServiceClient();
                client = new TranslatorService.LanguageServiceClient();
                strTranslatedText = client.Translate("6CE9C85A41571C050C379F60DA173D286384E0F2", textToTranslate, from, to);
            }
            catch (Exception){}

            return strTranslatedText;
        }
        */

        private string TranslateText(string text, string from, string to)
        {
            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + System.Web.HttpUtility.UrlEncode(text) + "&from=" + from + "&to=" + to;
            string authToken = "Bearer" + " " + _auth.GetAccessToken().access_token;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Headers.Add("Authorization", authToken);

            try
            {
                var response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    var dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
                    var translation = (string)dcs.ReadObject(stream);
                    return translation;
                }
            }
            catch (Exception)
            {
                var firstOrDefault = _clientsList.FirstOrDefault();
                if (firstOrDefault != null)
                {
                    Console.WriteLine(@"[DUCHN] Current ClientID: " + (firstOrDefault.ClientId));
                    ChangeBingClient();
                    return TranslateText(text, from, to);
                }
                MessageBox.Show(@"There are no more Bing account to translate!");
                return string.Empty;
            }
        }

        private void ChangeBingClient()
        {
            _auth = new AdmAuthentication(_clientsList.First().ClientId, _clientsList.First().ClientSecret);
            SetText(lblCurentClientID, _clientsList.First().ClientId);
            _clientsList.RemoveAt(0);
        }

        private void GetClientInfoList(ref List<BingClient> clientList)
        {
            var streamReader = new StreamReader(new FileStream(txtAccTxt.Text, FileMode.Open));

            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                if (line == null) break;
                var info = line.Split(';');
                clientList.Add(new BingClient(info.ElementAt(0), info.ElementAt(1)));
            }

            streamReader.Dispose();
        }

        private static List<ConfirmedLocalizedTable> GetConfirmedLocalizedTablesList(string pathToXls)
        {
            DataTable confirmedDataTable = ExcelManipulation.ExcelToDataTable(pathToXls, "Confirmed");

            var confirmedLocalizedTablesList = new List<ConfirmedLocalizedTable>();

            foreach (DataRow row in confirmedDataTable.Rows)
            {
                var confirmedLocalizedTable = new ConfirmedLocalizedTable { TableName = row["Table Name"].ToString().Trim() };

                var columnsToLocalize = new List<string>();
                if (string.Equals(row["Note"].ToString().Trim(), "Localize", StringComparison.CurrentCultureIgnoreCase))
                {
                    for (var i = 1; i <= 8; i++)
                    {
                        string columnName = "Column " + i;
                        if (!string.IsNullOrWhiteSpace(row[columnName].ToString()))
                        {
                            columnsToLocalize.Add(row[columnName].ToString().Trim());
                        }
                        else
                        {
                            break;
                        }
                    }

                    confirmedLocalizedTable.ColumnsToLocalize = columnsToLocalize;
                    confirmedLocalizedTablesList.Add(confirmedLocalizedTable);
                }
            }

            return confirmedLocalizedTablesList;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAccBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                txtAccTxt.Text = openFileDialog2.FileName;
                if (tbXLSFilePath.Text.Equals(string.Empty)) return;
                btnTranslate.Enabled = true;
            }
        }

        private void btCopyCurentTb_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblCurentTb.Text);
        }

        private void btCopyClientID_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblCurentClientID.Text);
        }

        private void listFail_Click(object sender, EventArgs e)
        {
            if (listFail.SelectedItem == null) return;
            Clipboard.SetText(listFail.SelectedItem.ToString());
        }
    }
}
