using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ProjectZ
{
    public partial class AddSellingReport : Form
    {
        public AddSellingReport(string DPID, string DPName)
        {
            InitializeComponent();
            this.lblID.Text = DPID;
            this.lblName.Text = DPName;
        }

        decimal UnitPrice = 0;
        private void AddSellingReport_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            

            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string sql1 = @"SELECT * FROM `daily selling report` where `R_DATE`='"+lblDate.Text+"' AND `DP_ID`='"+lblID.Text+"' ";
            MySqlCommand command1 = new MySqlCommand(sql1, con);
            MySqlDataReader reader = command1.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lblReportID.Text = reader.GetString(0);
                    lblDate.Text = reader.GetDateTime(2).ToString("yyyy-MM-dd");
                    txtReceivedVolume.Text = reader.GetDecimal(3).ToString();
                    txtReturnedVolume.Text = reader.GetDecimal(4).ToString();
                    lblEarning.Text = reader.GetDecimal(5).ToString();
                    
                }
                lblNote.Text = lblName.Text + " alredy has selling report for " + lblDate.Text + " . \n Report ID is " + lblReportID.Text + " You only can edit this details! ";

            }
            else if(!reader.HasRows)
            {
                lblReportID.Text = ZAutoGenarate.GenarateNextID("daily selling report", "R_ID");
            }
            reader.Close();
            

            string sql = @"SELECT PRICE FROM `prices` where `CATEGORY`='Selling' ";
            MySqlCommand command = new MySqlCommand(sql, con);
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UnitPrice = reader.GetDecimal(0);
                }

            }
            reader.Close();
            con.Close();
        }

        private void CalcSelledVolume()
        {
            decimal ReceivedVolume=0;
            decimal ReturedVolume =0;

            if(txtReceivedVolume.Text!="")
            {
                ReceivedVolume = Convert.ToDecimal(txtReceivedVolume.Text);
                if (txtReturnedVolume.Text != "")
                {
                    ReturedVolume = Convert.ToDecimal(txtReturnedVolume.Text);
                }
            }
           

            decimal SelledVolume = (ReceivedVolume - ReturedVolume);
            lblSelledVolume.Text = SelledVolume.ToString();

            lblEarning.Text = Math.Round(SelledVolume * UnitPrice,2).ToString();


        }

        private void txtReceivedVolume_TextChanged(object sender, EventArgs e)
        {
            CalcSelledVolume();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            

            decimal ReceivedVolume = 0;
            decimal ReturnedVolume = 0;
            decimal Earnings = 0;
            if (txtReceivedVolume.Text!="")
            {
                ReceivedVolume = Convert.ToDecimal(txtReceivedVolume.Text);
                if (txtReturnedVolume.Text != "")
                {
                    ReturnedVolume = Convert.ToDecimal(txtReturnedVolume.Text);
                    
                }

                Earnings =Convert.ToDecimal(lblEarning.Text);


                MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
                connection.Open();

                if(lblNote.Text=="")
                {
                    string Sql = @"INSERT INTO `daily selling report` (`R_ID`, `DP_ID`, `R_DATE`, `RECEIVED_VOLUME`, `RETURNED_VOLUME`, `EARNING`) VALUES ('" + lblReportID.Text + "', '" + lblID.Text + "', '" + lblDate.Text + "', '" + ReceivedVolume + "', '" + ReturnedVolume + "', '" + Earnings + "')";
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.InsertCommand = new MySqlCommand(Sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("inserted");
                    connection.Close();
                    this.Close();
                }
                else if(lblNote.Text != "")
                {
                    string Sql = @"UPDATE `daily selling report` SET  `RECEIVED_VOLUME` = '" + ReceivedVolume + "', `RETURNED_VOLUME` = '" + ReturnedVolume + "', `EARNING` = '" + Earnings + "' WHERE `daily selling report`.`R_ID` = '" + lblReportID.Text + "'";
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.UpdateCommand = new MySqlCommand(Sql, connection);
                    adapter.UpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Updated");
                    connection.Close();
                    this.Close();
                }
                


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
