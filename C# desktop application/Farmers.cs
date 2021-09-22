using MySql.Data.MySqlClient;
using ProjectZ.MyClasses;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace ProjectZ
{
    public partial class Farmers : Form
    {
        public Farmers()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Normal;
        }

        public void GetbasicData()
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string SelectQuery1 = @"SELECT * FROM `dairy farmer` where F_ID='" + lblID.Text + "'";
            MySqlCommand command1 = new MySqlCommand(SelectQuery1, con);
            MySqlDataReader reader1 = command1.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    
                    string Name = reader1.GetString(1).ToUpper();
                    String[] arr = Name.Split(' ');
                   
                    txtAddress.Text = reader1.GetString(2);
                    txtMobileNo.Text = reader1.GetString(3);
                    txtTPNO.Text = reader1.GetString(4);
                    txtNIC.Text = reader1.GetString(5);
                    txtRegdate.Text = reader1.GetDateTime(6).ToString("yyyy-MM-dd");
                    byte[] image = (byte[])reader1.GetValue(7);
                    MemoryStream ms = new MemoryStream(image);
                    PictureBoxPhoto.Image = Image.FromStream(ms);
                }
            }
            command1.Dispose();
            reader1.Dispose();
            



        }

        private void GetLivestockData()
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string SelectQuery2 = @"SELECT `A_ID` , `REG_DATE` , `RECEIVED_MODE` , `CATEGORY` , `SPECIAL_NOTE` FROM `animals` where F_ID='" + lblID.Text + "'";

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(SelectQuery2, con);
            DataTable table = new DataTable();
            adapter.Fill(table);

           
            int MilkingCows = 0;
            int Pregnant = 0;
            int Bulls = 0;
            int Heifers = 0;
            int BullCalves = 0;
            int HeiferCalves = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                

                if (table.Rows[i][3].ToString() == "Milking Cows")
                {
                    MilkingCows++;

                }
                else if (table.Rows[i][3].ToString() == "Pregnant")
                {
                    Pregnant++;

                }
                else if (table.Rows[i][3].ToString() == "Bulls")
                {
                    Bulls++;

                }
                else if (table.Rows[i][3].ToString() == "Heifers")
                {
                    Heifers++;

                }
                else if (table.Rows[i][3].ToString() == "Bull Calves")
                {
                    BullCalves++;

                }
                else if (table.Rows[i][3].ToString() == "Heifer Calves")
                {
                    HeiferCalves++;

                }
                lblMilkingCows.Text = MilkingCows.ToString();
                lblPregnantCows.Text = Pregnant.ToString();
                lblBulls.Text = Bulls.ToString();
                lblHeifers.Text = Heifers.ToString();
                lblBullCalves.Text = BullCalves.ToString();
                lblHeiferCalves.Text = HeiferCalves.ToString();



            }
            

            dgvLiveStocks.DataSource = table;

            dgvLiveStocks.Columns[0].HeaderText = "ID";
            dgvLiveStocks.Columns[1].HeaderText = "Registared Date";
            dgvLiveStocks.Columns[2].HeaderText = "Received Mode";
            dgvLiveStocks.Columns[3].HeaderText = "Category";
            dgvLiveStocks.Columns[4].HeaderText = "Speceal Note";
        }

       

        public void FillDT()
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string SelectQuery = @"SELECT `F_ID` , `F_NAME` FROM `dairy farmer` WHERE F_ID  LIKE '" + txtSearch.Text + "%' OR F_NAME  LIKE '%" + txtSearch.Text + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            adapter.SelectCommand = new MySqlCommand(SelectQuery, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvFarmers.DataSource = dt;
        }

        private void Farmers_Load(object sender, EventArgs e)
        {
            FillDT();

            ZAutocomplete.GetFarmersIdAndName(txtSearch);
            
            dtpRegDate.Visible = false;
           


        }


        private void dgvFarmers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex >= 0)
            {
                

                DataGridViewRow viwerow = dgvFarmers.Rows[dgvFarmers.SelectedRows[0].Index];
                if (viwerow != null)
                {
                    
                    lblID.Text = viwerow.Cells[0].Value.ToString();
                }
                GetbasicData();
  
            }
        }

        private void panelProfileHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddFarmer frm = new AddFarmer();
            frm.ShowDialog();
            FillDT();
            ZAutocomplete.GetFarmersIdAndName(txtSearch);


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ZFormControls.ForCloseButtonClick(this);
        }

        private void btnRestoreDown_Click(object sender, EventArgs e)
        {
            ZFormControls.ForRestoreDownButtonClick(this,btnRestoreDown);
            if(btnRestoreDown.Text=="1")
            {
                panelDynamic.Width = 700;
            }
            else if(btnRestoreDown.Text == "2")
            {
                panelDynamic.Width = 1000;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            ZFormControls.ForMinimizeButtonClick(this);
        }

        private void btnBasicDetails_Click(object sender, EventArgs e)
        {
            panelBasicData.Focus();
        }

        private void btnEditSave_Click(object sender, EventArgs e)
        {
            if(btnEditSave.Text== "Edit Details")
            {
                
                dgvFarmers.Enabled = false;

                txtAddress.ReadOnly = false;
                txtAddress.BorderStyle = BorderStyle.FixedSingle;
                txtAddress.BackColor = Color.White;
                txtAddress.Focus();

                txtMobileNo.ReadOnly = false;
                txtMobileNo.BorderStyle = BorderStyle.FixedSingle;
                txtMobileNo.BackColor = Color.White;


                txtTPNO.ReadOnly = false;
                txtTPNO.BorderStyle = BorderStyle.FixedSingle;
                txtTPNO.BackColor = Color.White;


                txtNIC.ReadOnly = false;
                txtNIC.BorderStyle = BorderStyle.FixedSingle;
                txtNIC.BackColor = Color.White;


                txtRegdate.ReadOnly = true;
                txtRegdate.BorderStyle = BorderStyle.FixedSingle;
                dtpRegDate.Visible = true;

                lblChooseImage.Visible = true;

                btnEditSave.Text = "Save";
                btnCreateID.Visible = false;

            }
            else if(btnEditSave.Text == "Save")
            {

                MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                con.Open();

                string UpdateQuery = @"UPDATE `dairy farmer` SET `F_ADDRESS` = '" + txtAddress.Text + "', `MOBILE_NO` = '" + txtMobileNo.Text + "', `TP_NO` = '" + txtTPNO.Text + "', `F_NIC` = '" + txtNIC.Text + "', `REG_DATE` = '" + txtRegdate.Text + "',`PHOTO`=@Pic WHERE `dairy farmer`.`F_ID` = '" + lblID.Text + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                adapter.UpdateCommand = new MySqlCommand(UpdateQuery, con);
                MemoryStream ms = new MemoryStream();
                PictureBoxPhoto.Image.Save(ms, PictureBoxPhoto.Image.RawFormat);
                byte[] imgArraySav = ms.ToArray();
                adapter.UpdateCommand.Parameters.Add("@Pic", MySqlDbType.LongBlob).Value = imgArraySav;

                if (adapter.UpdateCommand.ExecuteNonQuery()>0)
                {
                    dgvFarmers.Enabled = true;

                    txtAddress.ReadOnly = true;
                    txtAddress.BorderStyle = BorderStyle.None;
                    txtAddress.BackColor = Color.FromArgb(0, 68, 173);

                    txtMobileNo.ReadOnly = true;
                    txtMobileNo.BorderStyle = BorderStyle.None;
                    txtMobileNo.BackColor = Color.FromArgb(0, 68, 173);


                    txtTPNO.ReadOnly = true;
                    txtTPNO.BorderStyle = BorderStyle.None;
                    txtTPNO.BackColor = Color.FromArgb(0, 68, 173);


                    txtNIC.ReadOnly = true;
                    txtNIC.BorderStyle = BorderStyle.None;
                    txtNIC.BackColor = Color.FromArgb(0, 68, 173);

                    txtRegdate.ReadOnly = true;
                    txtRegdate.BorderStyle = BorderStyle.None;
                    dtpRegDate.Visible = false;

                    lblChooseImage.Visible = false;

                    GetbasicData();

                    btnEditSave.Text = "Edit Details";
                    btnCreateID.Visible = true;

                }



            }
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

        private void dgvFarmers_SelectionChanged(object sender, EventArgs e)
        {

            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                if (row != null)
                {
                    lblID.Text = row.Cells[0].Value.ToString();
                    lblFName.Text = row.Cells[1].Value.ToString();
                    GetbasicData();
                    GetLivestockData();
                    
                }
            }

        }


        

        private void txtSearchID_TextChanged(object sender, EventArgs e)
        {
            FillDT();
        }

        private void dtpRegDate_ValueChanged(object sender, EventArgs e)
        {
            txtRegdate.Text = dtpRegDate.Value.ToString("yyyy-MM-dd");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
                string filename = open.FileName;

                //FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                //BinaryReader br = new BinaryReader(fs);
                //ImageData = br.ReadBytes((int)fs.Length);
                //br.Close();
                //fs.Close();
            }
        }

        private void dgvFarmers_MouseClick(object sender, MouseEventArgs e)
        {
            if(dgvFarmers.Enabled==false)
            {
                MessageBox.Show("changes tika save karanakan dgv eka access krnna denne na");
            }
            
        }

        private void btnLiveStock_Click(object sender, EventArgs e)
        {
            
            panelLiveStocks.Focus();
        }

        private void btnAddLiveStock_Click(object sender, EventArgs e)
        {
            AddLiveStocks frm = new AddLiveStocks();
            frm.SetOwnership(lblID.Text);
            frm.ShowDialog();
            GetLivestockData();
            
        }

        

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string SelectQuery = @"SELECT * FROM `dairy farmer` WHERE F_ID  LIKE '" + txtSearch.Text + "%' OR F_NAME  LIKE '%" + txtSearch.Text + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            adapter.SelectCommand = new MySqlCommand(SelectQuery, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            ZExport.AsExcel(dt);

        }

        private void btnCreateID_Click(object sender, EventArgs e)
        {
            ZCreateID.ForFarmer(lblID.Text, lblFName.Text, txtRegdate.Text,txtAddress.Text, PictureBoxPhoto.Image);
        }

      
    }
}
