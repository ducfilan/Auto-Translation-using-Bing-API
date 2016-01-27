using System.Data;
using System.Data.SqlClient;

namespace UpdateDataForLocalizedTables
{
    public class ConnectionManager
    {
        private static ConnectionManager _instance;
        public static ConnectionManager Instance
        {
            get { return _instance ?? (_instance = new ConnectionManager()); }
        }

        private ConnectionManager() { }

        public void GetConnection(ref SqlConnection connection)
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                connection = new SqlConnection();
                const string connectionString = "Data Source={0};Initial Catalog={1};User Id={2};Password={3}; Persist Security Info={4}; Workstation ID={5};MultipleActiveResultSets=True;";

                connection.ConnectionString = string.Format(connectionString, Properties.Settings.Default.DataSource,
                                                    Properties.Settings.Default.InitialCatalog,
                                                    Properties.Settings.Default.UserID,
                                                    Properties.Settings.Default.Password,
                                                    Properties.Settings.Default.PersistSecurityInfor,
                                                    Properties.Settings.Default.WorkStationID);
                try
                {
                    connection.Open();
                    if (connection.State != ConnectionState.Open)
                    {
                        connection = null;
                    }
                }
                catch
                {
                    connection = null;
                }
            }
        }

        public void CloseConnection(ref SqlConnection connection)
        {
            if (connection != null)
            {
                try
                {
                    connection.Close();
                    connection = null;
                }
                catch
                {
                    connection = null;
                }
            }
        }
    }
}
