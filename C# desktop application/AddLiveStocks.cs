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
    public partial class AddLiveStocks : Form
    {
        public AddLiveStocks()
        {
            InitializeComponent();
        }

        private void AddLiveStocks_Load(object sender, EventArgs e)
        {
            ZAutocomplete.GetFarmersIdAndName(txtIDorName);
        }


        public void SetOwnership(string FarmerID)
        {
            txtIDorName.Text = FarmerID;
        }

        private void txtIDorName_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
            connection.Open();

            string SelectQuey = @"SELECT `F_ID` , `F_NAME` , `F_ADDRESS` , `MOBILE_NO` ,`TP_NO` , `F_NIC` FROM `dairy farmer` WHERE `F_ID` LIKE '"+txtIDorName.Text+ "%' OR `F_NAME` LIKE '" + txtIDorName.Text + "%'";

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(SelectQuey, connection);
            MySqlDataReader reader = adapter.SelectCommand.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    lblID.Text = reader.GetString(0);
                    lblName.Text = reader.GetString(1);
                    lblAddress.Text = reader.GetString(2);
                    lblContact.Text = reader.GetString(3) + " / " + reader.GetString(4);
                    lblNIC.Text = reader.GetString(5);
                }
            }

           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Father = "Unknown";
            string Mother = "Unknown";
            if (txtFather.Text!="")
            {
                Father = txtFather.Text;
            }
            if (txtMother.Text != "")
            {
                Mother = txtMother.Text;
            }

            MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
            connection.Open();

            string InsertQuery = @"INSERT INTO `animals` (`A_ID`, `F_ID`, `REG_DATE`, `RECEIVED_MODE`, `BIRTHDAY`, `GENERICS`, `CATEGORY`, `SPECIAL_NOTE`)" +
                                  " VALUES ('" + txtID.Text + "', '" + lblID.Text + "', '" +DateTime.Now.ToString("yyyy-MM-dd") + "', '" + txtReceivedMode.Text + "', '" + dtpBirthday.Text + "', '" + Father+ "," + Mother + "', '" + cmbCategory.Text + "', '" + txtSpecialNote.Text + "')";

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.InsertCommand = new MySqlCommand(InsertQuery, connection);
            if(adapter.InsertCommand.ExecuteNonQuery()>0)
            {
                MessageBox.Show("Inserted");
            }
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
