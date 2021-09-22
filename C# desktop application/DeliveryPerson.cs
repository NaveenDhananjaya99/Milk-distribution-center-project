using MySql.Data.MySqlClient;
using ProjectZ.MyClasses;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjectZ
{
    public partial class DeliveryPerson : Form
    {
        public DeliveryPerson()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Normal;
        }

        public void FillDT()
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string SelectQuery = @"SELECT `DP_ID` , `DP_NAME` FROM `delivery person` WHERE `DP_ID`  LIKE '" + txtSearch.Text + "%' OR `DP_NAME`  LIKE '" + txtSearch.Text + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            adapter.SelectCommand = new MySqlCommand(SelectQuery, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvDeleveryPerson.DataSource = dt;
        }

        private void SalesRep_Load(object sender, EventArgs e)
        {
            ZAutocomplete.GetSalesRepIdAndName(txtSearch);
            FillDT();
            dtpRegDate.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ZFormControls.ForCloseButtonClick(this);
        }

        private void btnRestoreDown_Click(object sender, EventArgs e)
        {
            
            ZFormControls.ForRestoreDownButtonClick(this,btnRestoreDown);
            if (btnRestoreDown.Text == "1")
            {
                panelDynamic.Width = 700;
            }
            else if (btnRestoreDown.Text == "2")
            {
                panelDynamic.Width = 1000;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            ZFormControls.ForMinimizeButtonClick(this);
        }

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ZFormControls.ForMouseDown(this);
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            ZFormControls.ForMouseMove(this);
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            ZFormControls.ForMouseUp();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillDT();
        }

       

        private void dgvDeleveryPerson_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                if (row != null)
                {
                    lblID.Text = row.Cells[0].Value.ToString();
                    lblDPName.Text = row.Cells[1].Value.ToString();
                    GetbasicData();
                    GetSalesData();
                    GetLoanData();
                }
            }
        }

        public void GetSalesData()
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string SelectQuery = @"SELECT `R_DATE`, `RECEIVED_VOLUME`, `RETURNED_VOLUME`,(`RECEIVED_VOLUME`-`RETURNED_VOLUME`) AS SELLED_VOLUME, `EARNING` FROM `center`.`daily selling report` where `DP_ID` ='" + lblID.Text + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(SelectQuery, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvSellingReports.DataSource = dt;


        }

        public void GetbasicData()
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string SelectQuery = @"SELECT * FROM `delivery person` where `DP_ID` ='" + lblID.Text + "'";
            MySqlCommand command = new MySqlCommand(SelectQuery, con);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    lblDPName.Text = reader.GetString(1);
                    txtMobileNo.Text = reader.GetString(2);
                    txtTPNO.Text = reader.GetString(3);
                    txtAddress.Text = reader.GetString(4);
                    txtNIC.Text = reader.GetString(5);
                    txtVehicleNo.Text = reader.GetString(6);
                    txtArea.Text = reader.GetString(7);
                    txtBasicSalary.Text = reader.GetDecimal(8).ToString();
                    txtRegdate.Text = reader.GetDateTime(9).ToString("yyyy-MM-dd");

                    byte[] image = (byte[])reader.GetValue(10);
                    MemoryStream ms = new MemoryStream(image);
                    PictureBoxPhoto.Image = Image.FromStream(ms);

                }
            }
        }

        private void GetLoanData()
        {
            MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
            connection.Open();

            string sql = @"SELECT * FROM `loan request` INNER JOIN `loan report` ON `loan request`.`RQ_ID` = `loan report`.`RQ_ID` WHERE `loan request`.`APPICANT_ID`= '" + lblID.Text + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(sql, connection);
            MySqlDataReader reader = adapter.SelectCommand.ExecuteReader();
            if (reader.HasRows)
            {
                panelLoanCover.Visible = false;
                while (reader.Read())
                {
                    lblLoanName.Text = reader.GetString(2);
                    lblReceivedDate.Text = reader.GetDateTime(3).ToString("yyyy-MM-dd");
                    lblDueDate.Text = reader.GetDateTime(9).ToString("yyyy-MM-dd");
                    lblReceivedvalue.Text = reader.GetDecimal(5).ToString();
                    lblInstallmentValue.Text = reader.GetDecimal(6).ToString();
                    lblCurrentLoanvalue.Text = reader.GetDecimal(11).ToString();
                    lblNoOfInstallments.Text = reader.GetDecimal(10).ToString();
                }
            }
            else if (!reader.HasRows)
            {
                panelLoanCover.Visible = true;
            }
        }

        private void btnCreateID_Click(object sender, EventArgs e)
        {
            ZCreateID.ForDeliveryPerson(lblID.Text, lblDPName.Text,txtVehicleNo.Text, txtRegdate.Text,txtAddress.Text, PictureBoxPhoto.Image);
        }

        private void btnEditSave_Click(object sender, EventArgs e)
        {
            if (btnEditSave.Text == "Edit Details")
            {
                dgvDeleveryPerson.Enabled = false;

                txtMobileNo.ReadOnly = false;
                txtMobileNo.BorderStyle = BorderStyle.FixedSingle;
                txtMobileNo.BackColor = Color.White;


                txtTPNO.ReadOnly = false;
                txtTPNO.BorderStyle = BorderStyle.FixedSingle;
                txtTPNO.BackColor = Color.White;

                txtAddress.ReadOnly = false;
                txtAddress.BorderStyle = BorderStyle.FixedSingle;
                txtAddress.BackColor = Color.White;
                txtAddress.Focus();

                txtNIC.ReadOnly = false;
                txtNIC.BorderStyle = BorderStyle.FixedSingle;
                txtNIC.BackColor = Color.White;

                txtVehicleNo.ReadOnly = false;
                txtVehicleNo.BorderStyle = BorderStyle.FixedSingle;
                txtVehicleNo.BackColor = Color.White;

                txtArea.ReadOnly = false;
                txtArea.BorderStyle = BorderStyle.FixedSingle;
                txtArea.BackColor = Color.White;

                txtBasicSalary.ReadOnly = false;
                txtBasicSalary.BorderStyle = BorderStyle.FixedSingle;
                txtBasicSalary.BackColor = Color.White;


                txtRegdate.ReadOnly = true;
                txtRegdate.BorderStyle = BorderStyle.FixedSingle;
                dtpRegDate.Visible = true;

                lblChooseImage.Visible = true;

                btnEditSave.Text = "Save";
                btnCreateID.Visible = false;
            }
            else if (btnEditSave.Text == "Save")
            {
                MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                con.Open();

                string UpdateQuery = @"UPDATE `delivery person` SET  `MOBILE_NO` = '" + txtMobileNo.Text + "', `TP_NO` = '" + txtTPNO.Text + "', `ADDRESS` = '" + txtAddress.Text + "', `NIC` = '" + txtNIC.Text + "', `VEHICLE_NO` = '" + txtVehicleNo.Text + "', `AREA` = '" + txtArea.Text + "', `BASIC_SALARY` = '" + Convert.ToDecimal(txtBasicSalary.Text) + "', `REG_DATE` = '" + txtRegdate.Text + "' , `PHOTO`=@Pic WHERE `delivery person`.`DP_ID` = '" + lblID.Text + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                adapter.UpdateCommand = new MySqlCommand(UpdateQuery, con);
                MemoryStream ms = new MemoryStream();
                PictureBoxPhoto.Image.Save(ms, PictureBoxPhoto.Image.RawFormat);
                byte[] imgArraySav = ms.ToArray();
                adapter.UpdateCommand.Parameters.Add("@Pic", MySqlDbType.LongBlob).Value = imgArraySav;
                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    dgvDeleveryPerson.Enabled = true;

                    txtMobileNo.ReadOnly = true;
                    txtMobileNo.BorderStyle = BorderStyle.None;
                    txtMobileNo.BackColor = Color.FromArgb(0, 68, 173);


                    txtTPNO.ReadOnly = true;
                    txtTPNO.BorderStyle = BorderStyle.None;
                    txtTPNO.BackColor = Color.FromArgb(0, 68, 173);

                    txtAddress.ReadOnly = true;
                    txtAddress.BorderStyle = BorderStyle.None;
                    txtAddress.BackColor = Color.FromArgb(0, 68, 173);

                    txtNIC.ReadOnly = true;
                    txtNIC.BorderStyle = BorderStyle.None;
                    txtNIC.BackColor = Color.FromArgb(0, 68, 173);

                   

                    txtVehicleNo.ReadOnly = true;
                    txtVehicleNo.BorderStyle = BorderStyle.None;
                    txtVehicleNo.BackColor = Color.FromArgb(0, 68, 173);

                    txtArea.ReadOnly = true;
                    txtArea.BorderStyle = BorderStyle.None;
                    txtArea.BackColor = Color.FromArgb(0, 68, 173);

                    txtBasicSalary.ReadOnly = true;
                    txtBasicSalary.BorderStyle = BorderStyle.None;
                    txtBasicSalary.BackColor = Color.FromArgb(0, 68, 173);

                    txtRegdate.ReadOnly = true;
                    txtRegdate.BorderStyle = BorderStyle.None;
                    dtpRegDate.Visible = false;

                    lblChooseImage.Visible = false;

                    GetbasicData();

                    btnEditSave.Text = "Edit Details";
                    btnCreateID.Visible = true;

                }

                con.Close();
                con.Dispose();
                adapter.Dispose();



            }
        }

        private void dtpRegDate_ValueChanged(object sender, EventArgs e)
        {
            txtRegdate.Text = dtpRegDate.Text;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddDeliveryPerson frm = new AddDeliveryPerson();
            frm.ShowDialog();
            FillDT();
        }

        private void lblChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                PictureBoxPhoto.Image = new Bitmap(open.FileName);
                // image file path  
                //string filename = open.FileName;

                //FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                //BinaryReader br = new BinaryReader(fs);
                //ImageData = br.ReadBytes((int)fs.Length);
                //br.Close();
                //fs.Close();
            }
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSelling_Click(object sender, EventArgs e)
        {
            panelSelling.Focus();
        }

        private void btnAddDailySellingReport_Click(object sender, EventArgs e)
        {
            AddSellingReport frms = new AddSellingReport(lblID.Text, lblDPName.Text);
            frms.ShowDialog();
            GetSalesData();
        }

        private void btnLoans_Click(object sender, EventArgs e)
        {
            panelLoans.Focus();
        }

        private void btnBasicDetails_Click(object sender, EventArgs e)
        {
            panelBasicData.Focus();
        }

        
    }
}
