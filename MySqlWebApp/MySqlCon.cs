using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace MySqlWebApp
{
    public class MySqlCon
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string userId;
        private string password;

        public string info = "not";

        public MySqlCon()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "building-manager";
            userId = "root";
            password = "moi600";

            string conTest = "Server=localhost;Database=building-manager;Uid=root;Pwd=moi600;";
            string connectionString = "Server=" + server + ";" + "Database=" +
            database + ";" + "Uid=" + userId + ";" + "Pwd=" +
            password + ";"; 

            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
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
                        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Cannot connect to Server" + "');", true);

                        break;

                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        break;

                    default:
                        //MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Insert()
        {
            string querry = "INSERT INTO building (bName, bTotalspace, bLocation) VALUES ('Büro Gebäude Kreuzplatz', '470', '2')";
            
            if(this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(querry, connection);

                cmd.ExecuteNonQuery();

                info = "sexy";

                //this.CloseConnection();
            }
        }

        public void Update()
        {
            string querry = "UPDATE building SET bname='Büro Gebäude am Kreuzplatz', bTotalspace='550', bLocation='3'WHERE bName='Büro Gebäude Kreuzplatz'";
            
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(querry, connection);

                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public void Delete()
        {
            string querry = "DELETE FROM building WHERE bName='Büro Gebäude Kreuzplatz'";
            
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(querry, connection);

                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public void Select()
        {
            string query = "SELECT * FROM building";
            this.OpenConnection();
            DataTable table = new DataTable();

            if (this.OpenConnection() == true)
            {
                

                try
                {
                    
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                    dataAdapter.SelectCommand = new MySqlCommand(query, connection);
                    
                    dataAdapter.Fill(table);
                    
                }

                finally
                {
                    foreach (DataRow row in table.Rows)
                    {
                        /*string ID = row["ColumnID"].ToString();
                        string Name = row["columnName"].ToString();
                        string FamilyName = row["ColumnFamilyName"].ToString();*/
                    }
                }
                this.CloseConnection();
              
            }
            else
            {
                
            }
        }
    }
}
