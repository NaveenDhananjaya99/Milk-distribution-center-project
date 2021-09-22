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
    public partial class AddVeterinarion : Form
    {
        public AddVeterinarion()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();


            string InsertQuery = @"INSERT INTO `veterinarian` (`V_NIC`, `V_NAME`, `MOBILE_NO`, `TP_NO`, `ADDRESS`, `Email`)" + 
                " VALUES ('"+txtNIC.Text+"', '"+txtName.Text+"', '"+txtMobileNo.Text+"', '"+txtTP.Text+"', '"+txtAddress.Text+"', '"+txtEmail.Text+"')";

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.InsertCommand = new MySqlCommand(InsertQuery, con);
            if (adapter.InsertCommand.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("inserted");
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMobileNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNIC_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ZFormControls.ForMouseDown(this);

        }

        private void PanelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            ZFormControls.ForMouseMove(this);

        }

        private void PanelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            ZFormControls.ForMouseUp();

        }
    }
}
