using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;


namespace ProjectZ
{
    static class ZAutocomplete
    {
       




        public static void GetFarmersIdAndName(TextBox txtbx)
        {
            try
            {
                string list = "";

                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                con.Open();
                string sqlID = @"SELECT `F_ID` FROM `dairy farmer`";
                MySqlCommand comobj = new MySqlCommand(sqlID, con);
                MySqlDataReader reader = comobj.ExecuteReader();
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list = "";
                        list = list + reader.GetString(0);
                        collection.Add(list);

                    }
                    
                }
                comobj.Dispose();
                reader.Dispose();
                string sqlName = @"SELECT `F_NAME` FROM `dairy farmer`";
                MySqlCommand com = new MySqlCommand(sqlName, con);
                MySqlDataReader reader2 = com.ExecuteReader();
                if (reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                        list = "";
                        list = list + reader2.GetString(0);
                        collection.Add(list);

                    }
                }


                txtbx.AutoCompleteCustomSource = collection;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        public static void GetVeteriIdAndName(TextBox txtbx)
        {
            try
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                con.Open();
                string SQLID = @"SELECT `V_NIC` FROM `veterinarian`";
                MySqlCommand command1 = new MySqlCommand(SQLID, con);
                MySqlDataReader reader1 = command1.ExecuteReader();
                if(reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        string list = "";
                        list = list + reader1.GetString(0);
                        collection.Add(list);
                    }
                }
                command1.Dispose();
                reader1.Dispose();
                string SQLName = @"SELECT `V_Name` FROM `veterinarian`";
                MySqlCommand command2 = new MySqlCommand(SQLName, con);
                MySqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    string list = "";
                    list = list + reader2.GetString(0);
                    collection.Add(list);
                }

                txtbx.AutoCompleteCustomSource = collection;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        public static void GetSalesRepIdAndName(TextBox txtbx)
        {
            try
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                con.Open();
                string SQLID = @"SELECT `DP_ID` FROM `delivery person`";
                MySqlCommand command1 = new MySqlCommand(SQLID, con);
                MySqlDataReader reader1 = command1.ExecuteReader();
                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        string list = "";
                        list = list + reader1.GetString(0);
                        collection.Add(list);
                    }
                }
                command1.Dispose();
                reader1.Dispose();
                string SQLName = @"SELECT `DP_NAME` FROM `delivery person`";
                MySqlCommand command2 = new MySqlCommand(SQLName, con);
                MySqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    string list = "";
                    list = list + reader2.GetString(0);
                    collection.Add(list);
                }

                txtbx.AutoCompleteCustomSource = collection;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
