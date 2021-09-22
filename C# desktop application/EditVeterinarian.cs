using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjectZ
{
    public partial class EditVeterinarian : Form
    {
        string VID = "";
        public EditVeterinarian( string VID)
        {
            InitializeComponent();
            this.VID = VID;
        }

        private void EditVeterinarian_Load(object sender, EventArgs e)
        {
           if(!string.IsNullOrEmpty(VID))
            {
                MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                con.Open();

                string Sql = @"SELECT * FROM `veterinarian` WHERE `V_NIC`='" + VID + "'";
                MySqlCommand command = new MySqlCommand(Sql, con);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtNIC.Text = VID;
                        txtName.Text = reader.GetString(1);
                        txtMobileNo.Text = reader.GetString(2);
                        txtTP.Text = reader.GetString(3);
                        txtAddress.Text = reader.GetString(4);
                        txtEmail.Text = reader.GetString(5);
                    }
                }

                command.Dispose();
                reader.Dispose();
                con.Close();
                con.Dispose();
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string SQLUpdate = @"UPDATE `veterinarian` SET `V_NIC` = '" + txtNIC.Text + "', `V_NAME` = '" + txtName.Text + "', `MOBILE_NO` = '" + txtMobileNo.Text + "', `TP_NO` = '" + txtTP.Text + "', `ADDRESS` = '" + txtAddress.Text + "', `Email` = '" + txtEmail.Text + "' WHERE `veterinarian`.`V_NIC` = '" + txtNIC.Text + "'";

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.UpdateCommand = new MySqlCommand(SQLUpdate, con);
            if(adapter.UpdateCommand.ExecuteNonQuery()>0)
            {
                MessageBox.Show("Successfully Updated");
                this.Close();

            }
        }
    }
}
