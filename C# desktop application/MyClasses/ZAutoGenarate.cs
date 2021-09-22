using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectZ
{
    class ZAutoGenarate
    {

        public static string GenarateNextID(string TableName,String ColumnName)
        {
            string Result = "";
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string sql = @"SELECT `"+ColumnName+"` FROM `"+TableName+ "`  where `" + ColumnName + "`=(select max(`" + ColumnName + "`) from `" + TableName + "`)";
            MySqlCommand objectcom = new MySqlCommand(sql, con);

            MySqlDataReader reader = objectcom.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Result = reader.GetString(0);
                }

                string[] array = Result.Split('-');
                string StringPart = "";
                int IntPart = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if(i==0)
                    {
                        StringPart = array[i];
                    }
                    else
                    {
                        IntPart = Convert.ToInt32(array[i]);
                    }
                }

                if(StringPart!="" && IntPart>0)
                {
                    Result = StringPart + "-" + (IntPart + 1);
                }
            }

            return Result;
        }


       
    }
}
