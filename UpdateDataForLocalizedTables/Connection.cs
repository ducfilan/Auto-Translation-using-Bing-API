using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UpdateDataForLocalizedTables
{
    public partial class Connection : Form
    {
        public Connection()
        {
            InitializeComponent();
            txtDataSource.Text = Properties.Settings.Default.DataSource;
            txtInitialCatalog.Text = Properties.Settings.Default.InitialCatalog;
            txtUserId.Text = Properties.Settings.Default.UserID;
            txtPassword.PasswordChar = '*';
            txtPassword.Text = Properties.Settings.Default.Password;
            txtPersistSecurityInfor.Text = Properties.Settings.Default.PersistSecurityInfor.ToString();
            txtWorkStationId.Text = Properties.Settings.Default.WorkStationID;
        }

        private bool TestConnection()
        {
            string connectionString = "Data Source={0};Initial Catalog={1};User Id={2};Password={3}; Persist Security Info={4}; Workstation ID={5}";
            var connection = new SqlConnection
            {
                ConnectionString = string.Format(connectionString, txtDataSource.Text,
                                                 txtInitialCatalog.Text,
                                                 txtUserId.Text,
                                                 txtPassword.Text,
                                                 txtPersistSecurityInfor.Text,
                                                 txtWorkStationId.Text)
            };
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    return true;
                }
            }
            catch (Exception)
            {
            }

            return false;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            var result = TestConnection();

            if (result)
            {
                Properties.Settings.Default.DataSource = txtDataSource.Text;
                Properties.Settings.Default.InitialCatalog = txtInitialCatalog.Text;
                Properties.Settings.Default.UserID = txtUserId.Text;
                Properties.Settings.Default.Password = txtPassword.Text;
                var persistInfor = false;
                bool.TryParse(txtPersistSecurityInfor.Text, out persistInfor);
                Properties.Settings.Default.PersistSecurityInfor = persistInfor;
                Properties.Settings.Default.WorkStationID = txtWorkStationId.Text;
                Properties.Settings.Default.Save();

                MessageBox.Show("Connect to database successfully!", "Embrace Portal Database Manager");
            }
            else
            {
                MessageBox.Show("Cannot connect to the database!", "Embrace Portal Database Manager");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
