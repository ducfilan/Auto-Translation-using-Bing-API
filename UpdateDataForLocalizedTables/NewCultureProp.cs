using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace UpdateDataForLocalizedTables
{
    public partial class NewCultureProp : Form
    {
        SqlConnection _connection = new SqlConnection();
        public NewCultureProp()
        {
            InitializeComponent();
        }

        private void BrowseFileExcelButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XLSFilePathTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddCultureButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Get information from User
                var pathToXls = XLSFilePathTextBox.Text;

                ConnectionManager.Instance.GetConnection(ref _connection);

                //Add to Related tables
                if (InsertToRelatedTables() == -1) return;

                var confirmedLocalizedTablesList = GetConfirmedLocalizedTablesList(pathToXls);

                if (_connection != null && _connection.State == ConnectionState.Open)
                {
                    foreach (var confirmedLocalizedTable in confirmedLocalizedTablesList)
                    {
                        CopyValueToLocalizedTable(confirmedLocalizedTable);
                    }
                }

                //Close Connection
                ConnectionManager.Instance.CloseConnection(ref _connection);

                MessageBox.Show(@"New Culture is added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + @" Er 4");
            }
        }

        private void CopyValueToLocalizedTable(ConfirmedLocalizedTable confirmedLocalizedTable)
        {
            List<string> columnsToLocalize = confirmedLocalizedTable.ColumnsToLocalize;

            try
            {
                var localizedColumnPrimaryKeyName = get_LOCALIZEDColumnPrimaryKeyName(confirmedLocalizedTable.TableName);

                columnsToLocalize.Add(localizedColumnPrimaryKeyName); //Add coresponding ID Column

                //Add data to %_LOCALIZED Table
                if (!AddDataTo_LocalizedTable(confirmedLocalizedTable))
                {
                    listViewFailTables.Items.Add(confirmedLocalizedTable.TableName);
                    return;
                }
                //}

                listViewSuccessTables.Items.Add(confirmedLocalizedTable.TableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + @" Er 1");
                listViewFailTables.Items.Add(confirmedLocalizedTable.TableName);
            }
        }

        private bool AddDataTo_LocalizedTable(ConfirmedLocalizedTable confirmedLocalizedTable)
        {
            //Get Data from Text boxes
            var newCultureName = NewCultureNameTextBox.Text;
            var newOU_CULTURE_KEY = OUCultureKeyTextbox.Text;

            var localizedColumnPrimaryKeyName = get_LOCALIZEDColumnPrimaryKeyName(confirmedLocalizedTable.TableName);

            if (_connection == null || _connection.State != ConnectionState.Open) return false;
            try
            {
                var columnsToLocalize = confirmedLocalizedTable.ColumnsToLocalize;

                var tableName = confirmedLocalizedTable.TableName + "_LOCALIZED";
                string query = string.Format("INSERT INTO [{0}] (", tableName);

                query = columnsToLocalize.Aggregate(query, (current, coumnToLocalize) => current + string.Format(@"[{0}], ", coumnToLocalize));

                query += "[OU_CULTURE_KEY]) SELECT ";

                foreach (string column in columnsToLocalize)
                {
                    if (!column.Equals(localizedColumnPrimaryKeyName))
                    {
                        query += string.Format("'{0}' + cast([{1}] as nvarchar(max)) as [{1}], ", newCultureName, column);
                    }
                    else
                    {
                        query += string.Format("[{0}], ", column);
                    }
                }

                query += string.Format("{0} as [OU_CULTURE_KEY]", newOU_CULTURE_KEY);

                query += string.Format(" FROM {0}", confirmedLocalizedTable.TableName);
                var cmd = new SqlCommand(query, _connection);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private int InsertToRelatedTables()
        {
            var returnStatus = -1;
            try
            {
                //Add record to AH_MASTER_CULTURE_KEY and AH_MASTER_SUPPORTED_CULTURES
                var queryAddNewSuportCulture = new SqlCommand(@"INSERT INTO AH_MASTER_CULTURE_KEY 
                                                            VALUES (@OU_CULTURE_KEY, '', CONVERT(VARCHAR(20), GETDATE()), 
                                                            GETDATE(),CONVERT(VARCHAR(20), GETDATE()), 
                                                            GETDATE(), newid());

                                                            INSERT INTO AH_MASTER_SUPPORTED_CULTURES 
                                                            VALUES (@Culture_ID, 1, @CultureName,
                                                            @Description, CONVERT(VARCHAR(20), GETDATE()),
                                                            GETDATE(), CONVERT(VARCHAR(20), GETDATE()),
                                                            GETDATE(), newid())", _connection);
                queryAddNewSuportCulture.Parameters.AddWithValue("@OU_CULTURE_KEY", OUCultureKeyTextbox.Text);
                queryAddNewSuportCulture.Parameters.AddWithValue("@Culture_ID", textBoxCultureID.Text);
                queryAddNewSuportCulture.Parameters.AddWithValue("@CultureName", NewCultureNameTextBox.Text);
                queryAddNewSuportCulture.Parameters.AddWithValue("@Description", textBoxCultureDescription.Text);
                queryAddNewSuportCulture.ExecuteNonQuery();
                returnStatus = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + @" Er 3");
            }
            return returnStatus;
        }

        private string get_LOCALIZEDColumnPrimaryKeyName(string localizedTableName)
        {
            if (localizedTableName == null) throw new ArgumentNullException("localizedTableName");

            var localizedColumnIdName = "-1";
            /*
            var query = string.Format(@"SELECT Y.COLUMN_NAME
                                           FROM
                                             (SELECT COLUMN_NAME
                                              FROM INFORMATION_SCHEMA.COLUMNS
                                              WHERE TABLE_NAME = '{0}') X
                                           LEFT JOIN
                                             (SELECT COLUMN_NAME
                                              FROM INFORMATION_SCHEMA.COLUMNS
                                              WHERE TABLE_NAME = '{0}_LOCALIZED') Y ON X.COLUMN_NAME = Y.COLUMN_NAME
                                           WHERE Y.COLUMN_NAME IS NOT NULL
                                             AND y.COLUMN_NAME LIKE '%ID'", localizedTableName.Trim());
            */
            var query = string.Format(@"SELECT COLUMN_NAME
                                    FROM INFORMATION_SCHEMA.COLUMNS
                                    WHERE TABLE_NAME = '{0}' INTERSECT
                                        SELECT COLUMN_NAME
                                        FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS [TC]
                                        JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE [KU] ON TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
                                        AND TC.CONSTRAINT_TYPE = 'PRIMARY KEY'
                                        AND KU.TABLE_NAME = '{0}'", localizedTableName.Trim());

            var cmd = new SqlCommand(query) { Connection = _connection };

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                localizedColumnIdName = reader["COLUMN_NAME"].ToString();
            }
            reader.Close();

            return localizedColumnIdName.Trim();
        }

        private IEnumerable<ConfirmedLocalizedTable> GetConfirmedLocalizedTablesList(string pathToXls)
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

        private void textBoxCultureDescription_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxCultureDescription.SelectAll();
        }

        private void textBoxCultureID_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxCultureID.SelectAll();
        }

        private void OUCultureKeyTextbox_MouseDown(object sender, MouseEventArgs e)
        {
            OUCultureKeyTextbox.SelectAll();
        }

        private void NewCultureNameTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            NewCultureNameTextBox.SelectAll();
        }
    }
}
