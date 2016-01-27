using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateDataForLocalizedTables
{
    public partial class UpdateDataForLocalizedTables : Form
    {
        private List<string> _localizedTableList = new List<string>();
        private List<string> _noContentTableList = new List<string>();
        SqlConnection _connection = new SqlConnection();

        public UpdateDataForLocalizedTables()
        {
            InitializeComponent();
        }

        private void CreateConnection(object sender, EventArgs e)
        {
            var connectionForm = new Connection();
            connectionForm.Show();
        }

        private void UpdateLocalizedTables_Click(object sender, EventArgs e)
        {
            ConnectionManager.Instance.GetConnection(ref _connection);

            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _localizedTableList = GetTableList(_connection);
                if (_noContentTableList.Count > 0)
                {
                    foreach (var item in _noContentTableList)
                    {
                        var lvi = new ListViewItem(item);
                        listView1.Items.Add(lvi);
                    }
                }

            }

            ConnectionManager.Instance.CloseConnection(ref _connection);
        }

        private List<string> GetTableList(SqlConnection connection)
        {
            string query = "SELECT name FROM sys.tables WHERE name LIKE '%_LOCALIZED'";
            List<string> returnList = null;
            try
            {
                var command = new SqlCommand(query, connection);
                var nameListTable = new DataTable("TableList");
                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(nameListTable);

                returnList = new List<string>();
                if (nameListTable != null && nameListTable.Rows != null && nameListTable.Rows.Count > 0)
                {
                    foreach (DataRow row in nameListTable.Rows)
                    {
                        returnList.Add(row.ItemArray[0].ToString().ToUpperInvariant());
                    }
                }

            }
            catch (Exception)
            {
                return null;
            }

            if (returnList != null && returnList.Count > 0)
            {
                query = "SELECT * FROM dbo.{0}";
                var nonDataList = new List<string>();
                try
                {
                    foreach (var item in returnList)
                    {
                        var command = new SqlCommand(string.Format(query, item), connection);
                        var nameListTable = new DataTable("TableList");
                        var dataAdapter = new SqlDataAdapter(command);
                        dataAdapter.Fill(nameListTable);

                        if (nameListTable != null && nameListTable.Rows != null && nameListTable.Rows.Count <= 0)
                        {
                            nonDataList.Add(item);
                        }
                    }
                }
                catch (Exception)
                {
                    return null;
                }

                returnList = new List<string>(nonDataList);
            }

            if (returnList != null && returnList.Count > 0)
            {
                foreach (var item in returnList)
                {
                    var isError = UpdateAndGetError(item, ref connection);
                    if (isError)
                    {
                        _noContentTableList.Add(item);
                    }
                }
            }

            return returnList;
        }

        private bool UpdateAndGetError(string item, ref SqlConnection connection)
        {
            var originalTableName = item.Substring(0, item.Length - "_LOCALIZED".Length);
            var localizedColumns = new List<string>();
            var columnList = new List<string>();

            var query = string.Format(@"USE [{1}]
                                        
                                        SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='{0}'
                                         AND COLUMN_NAME NOT IN (SELECT column_name FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
                                         WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1 AND table_name = '{0}')
                                        SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='{0}'", item, Properties.Settings.Default.InitialCatalog);

            var command = new SqlCommand(string.Format(query, item), connection);
            var dataSet = new DataSet();
            var dataAdapter = new SqlDataAdapter(command);
            try
            {
                dataAdapter.Fill(dataSet);
            }
            catch (Exception)
            {
                MessageBox.Show("Error when read schema of table " + item, "Cannot read database");
                return true;
            }

            if (dataSet != null && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    localizedColumns.Add(row.ItemArray[0].ToString());
                }
            }

            if (dataSet != null && dataSet.Tables[1].Rows != null && dataSet.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    columnList.Add(row.ItemArray[0].ToString());
                }

                query = "SELECT ";
                var insertQuery = string.Format("INSERT INTO dbo.{0} (", item);
                foreach (var column in columnList)
                {
                    if (!column.ToUpperInvariant().Contains("OU_CULTURE_KEY"))
                    {
                        query += column + ", ";
                        insertQuery += column + ", ";
                    }
                }

                insertQuery += "OU_CULTURE_KEY) VALUES ";

                query = query.Substring(0, query.Length - ", ".Length);
                query = query + " FROM dbo." + originalTableName;
                command = new SqlCommand(query, connection);
                var originContent = new DataTable("OldContent");
                dataAdapter = new SqlDataAdapter(command);
                try
                {
                    dataAdapter.Fill(originContent);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error when read table " + originalTableName, "Cannot read database");
                    return true;
                }

                query = insertQuery;

                if (originContent != null && originContent.Rows != null && originContent.Rows.Count > 0)
                {
                    foreach (DataRow row in originContent.Rows)
                    {
                        insertQuery = query;
                        var auValue = "(";
                        var br1Value = "(";
                        var br2Value = "(";
                        foreach (var column in columnList)
                        {
                            if (localizedColumns.Contains(column))
                            {
                                auValue += "'[en-AU] " + row[column].ToString().Replace("'", "''") + "', ";
                                br1Value += "'[pt-BR] " + row[column].ToString().Replace("'", "''") + "', ";
                                br2Value += "'[pt-BR] " + row[column].ToString().Replace("'", "''") + "', ";
                            }
                            else if (!column.ToUpperInvariant().Contains("OU_CULTURE_KEY"))
                            {
                                auValue += row[column].ToString() + ", ";
                                br1Value += row[column].ToString() + ", ";
                                br2Value += row[column].ToString() + ", ";
                            }
                        }

                        auValue += "'444'), ";
                        br1Value += "'5555'), ";
                        br2Value += "'5556'), ";

                        insertQuery += auValue + br1Value + br2Value;

                        insertQuery = insertQuery.Substring(0, insertQuery.Length - 2);

                        command = new SqlCommand(insertQuery, connection);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            //return true;
                        }
                    }


                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }

            return false;
        }

        private void AddCultureButton_Click(object sender, EventArgs e)
        {
            new NewCultureProp().ShowDialog();
        }

        private void btnTranslateData_Click(object sender, EventArgs e)
        {
            new FormTranslateData().ShowDialog();
        }
    }
}
