using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySqlWebApp
{
    public class MySqlCon
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string userId;
        private string password;

        public MySqlCon()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "gebäudeManager";
            userId = "root";
            password = "moi600";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "USERID=" + userId + ";" + "PASSWORD" + 
            password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch(MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Cannot connect to Server" + "');", true);

                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;

                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
