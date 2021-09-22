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
    public partial class LiveStock : Form
    {
        
        public LiveStock()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Normal;
        }

        string Category = "";
        string ReceivedMode = "";
        string FID = "";
        string FName = "";
        DataTable dt = new DataTable();
        private void FillDT()
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string sql = @"SELECT `animals`.`A_ID` , `animals`.`REG_DATE` , `animals`.`RECEIVED_MODE` , `animals`.`BIRTHDAY` , `animals`.`CATEGORY` , `animals`.`SPECIAL_NOTE` FROM `animals` INNER JOIN `dairy farmer` on `animals`.`F_ID`=`dairy farmer`.`F_ID` WHERE `animals`.`F_ID` LIKE '" + FID+ "%' AND `dairy farmer`.`F_NAME` LIKE '%"+FName+ "%' AND  `animals`.`CATEGORY` LIKE '" + Category+ "%'  AND `animals`.`RECEIVED_MODE` LIKE '" + ReceivedMode + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(sql, con);
            dt.Clear();
            adapter.Fill(dt);
            dgvLiveStocks.DataSource = dt;

            con.Close();
            con.Dispose();
            adapter.SelectCommand.Dispose();
            adapter.Dispose();
            dt.Dispose();
            dgvLiveStocks.Columns[0].HeaderText = "ID";
            dgvLiveStocks.Columns[1].HeaderText = "Registared Date";
            dgvLiveStocks.Columns[2].HeaderText = "Received Mode";
            dgvLiveStocks.Columns[3].HeaderText = "Birthday";
            dgvLiveStocks.Columns[4].HeaderText = "Category";
            dgvLiveStocks.Columns[5].HeaderText = "Special Note";

        }

        private void LiveStock_Load(object sender, EventArgs e)
        {
            FillDT();
            btnAllCategories.PerformClick();
            btnAllReceivedModes.PerformClick();
            radioOwnerID.Checked = true;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddLiveStocks frm = new AddLiveStocks();
            frm.ShowDialog();
            FillDT();
        }

        private void btnExportAsExcel_Click(object sender, EventArgs e)
        {
            ZExport.AsExcel(dt);   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ZFormControls.ForCloseButtonClick(this);
        }

        private void btnRestoreDown_Click(object sender, EventArgs e)
        {
            ZFormControls.ForRestoreDownButtonClick(this,btnRestoreDown);
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

        private void dgvLiveStocks_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                if (row != null)
                {
                    string ID = row.Cells[0].Value.ToString();

                    MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                    con.Open();

                    string sql = @"SELECT * FROM `animals` INNER JOIN `dairy farmer` on `animals`.`F_ID`=`dairy farmer`.`F_ID` WHERE `A_ID`='" + ID + "'";
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = new MySqlCommand(sql,con);
                    MySqlDataReader reader = adapter.SelectCommand.ExecuteReader();

                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            lblID.Text = reader.GetString(0);
                            lblRegDate.Text = reader.GetDateTime(2).ToString("yyyy-MM-dd");
                            lblReceivedMode.Text = reader.GetString(3);
                            lblBirthday.Text = reader.GetDateTime(4).ToString("yyyy-MM-dd");
                            if(!string.IsNullOrEmpty(lblBirthday.Text))
                            {
                                lblIntro.Text = (DateTime.Now.Year - reader.GetDateTime(4).Year).ToString() + " years old " + reader.GetString(6) + ".";
                            }
                            

                            string Generics =reader.GetString(5);
                            string[] arr = Generics.Split(',');
                            for(int i=0;arr.Length>i;i++)
                            {
                                if(i==0)
                                {
                                    lblFather.Text = arr[i];
                                }
                                else if(i==1)
                                {
                                    lblMother.Text = arr[i];
                                }
                                
                            }

                            lblNote.Text = reader.GetString(7);
                            lblOwnerID.Text = reader.GetString(8);
                            lblOwnerName.Text = reader.GetString(9);
                            lblAddress.Text = reader.GetString(10);
                            lblMobile.Text = reader.GetString(11);
                            lblTP.Text = reader.GetString(12);





                        }
                    }
                    adapter.Dispose();
                    reader.Close();
                    con.Close();
                }
            }
        }

        private void btnEditDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hadanna oona");
        }
        
        //private void btnAllCategories_Click(object sender, EventArgs e)
        //{
        //    PanelUnderline1.Visible = true;
        //    PanelUnderline2.Visible = false;
        //    PanelUnderline3.Visible = false;
        //    PanelUnderline4.Visible = false;

        //    Category = "";
        //    FillDT();
        //}

        //private void btnCattle_Click(object sender, EventArgs e)
        //{
        //    PanelUnderline1.Visible = false;
        //    PanelUnderline2.Visible = true;
        //    PanelUnderline3.Visible = false;
        //    PanelUnderline4.Visible = false;

        //    Category = "Cows in milk";
        //    FillDT();
        //}

        //private void btnHeifer_Click(object sender, EventArgs e)
        //{
        //    PanelUnderline1.Visible = false;
        //    PanelUnderline2.Visible = false;
        //    PanelUnderline3.Visible = true;
        //    PanelUnderline4.Visible = false;

        //    Category = "Pregnant";
        //    FillDT();
        //}

        //private void btnBull_Click(object sender, EventArgs e)
        //{
        //    PanelUnderline1.Visible = false;
        //    PanelUnderline2.Visible = false;
        //    PanelUnderline3.Visible = false;
        //    PanelUnderline4.Visible = true;

        //    Category = "Bull";
        //    FillDT();
        //}

        //private void btnAllModes_Click(object sender, EventArgs e)
        //{
        //    PanelUnderline5.Visible = true;
        //    PanelUnderline6.Visible = false;
        //    PanelUnderline7.Visible = false;
        //    PanelUnderline8.Visible = false;

        //    ReceivedMode = "";
        //    FillDT();
        //}

        //private void btnRegionalBirth_Click(object sender, EventArgs e)
        //{
        //    PanelUnderline5.Visible = false;
        //    PanelUnderline6.Visible = true;
        //    PanelUnderline7.Visible = false;
        //    PanelUnderline8.Visible = false;

        //    ReceivedMode = "Regional";
        //    FillDT();
        //}

        //private void btnPurchased_Click(object sender, EventArgs e)
        //{
        //    PanelUnderline5.Visible = false;
        //    PanelUnderline6.Visible = false;
        //    PanelUnderline7.Visible = true;
        //    PanelUnderline8.Visible = false;

        //    ReceivedMode = "Purchased";
        //    FillDT();
        //}

        //private void btnDonated_Click(object sender, EventArgs e)
        //{
        //    PanelUnderline5.Visible = false;
        //    PanelUnderline6.Visible = false;
        //    PanelUnderline7.Visible = false;
        //    PanelUnderline8.Visible = true;

        //    ReceivedMode = "Donated";
        //    FillDT();
        //}

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(radioOwnerID.Checked==true)
            {
                FID = txtSearch.Text;
                FillDT();
            }
            else if(radioOwnerName.Checked==true)
            {
                FName = txtSearch.Text;
                FillDT();
            }

        }

        private void btnMedicalIsuue_Click(object sender, EventArgs e)
        {
            AddMedicalIsuue addMedicalIsuue = new AddMedicalIsuue(lblOwnerID.Text,lblOwnerName.Text, lblAddress.Text, lblMobile.Text, lblID.Text,lblIntro.Text);
            addMedicalIsuue.ShowDialog();
        }

        private void UnderlineCategory(Panel panel)
        {
            PanelUnderline1.BackColor = Color.FromArgb(0, 22, 66);
            PanelUnderline1.BackColor = Color.FromArgb(0, 22, 66);
            PanelUnderline2.BackColor = Color.FromArgb(0, 22, 66);
            PanelUnderline3.BackColor = Color.FromArgb(0, 22, 66);
            PanelUnderline4.BackColor = Color.FromArgb(0, 22, 66);
            PanelUnderline5.BackColor = Color.FromArgb(0, 22, 66);
            PanelUnderline6.BackColor = Color.FromArgb(0, 22, 66);
            PanelUnderline7.BackColor = Color.FromArgb(0, 22, 66);

            panel.BackColor = Color.FromArgb(0, 147, 255);

        }

        private void UnderlineReceivedMode(Panel panel)
        {
            PanelUnderline8.BackColor = Color.FromArgb(0, 22, 66);
            PanelUnderline9.BackColor = Color.FromArgb(0, 22, 66);
            PanelUnderline10.BackColor = Color.FromArgb(0, 22, 66);
            PanelUnderline11.BackColor = Color.FromArgb(0, 22, 66);

            panel.BackColor = Color.FromArgb(0, 147, 255);
        }

        private void btnAllCategories_Click(object sender, EventArgs e)
        {
           
            UnderlineCategory(PanelUnderline1);

            Category = "";
            FillDT();
        }

       

        private void btnCowsInMilk_Click(object sender, EventArgs e)
        {
            UnderlineCategory(PanelUnderline2);
            PanelUnderline2.Visible = true;

            Category = (sender as Button).Text;
            FillDT();
        }

        private void btnPregnant_Click(object sender, EventArgs e)
        {
            UnderlineCategory(PanelUnderline3);

            Category = (sender as Button).Text;
            FillDT();
        }

        private void btnBulls_Click(object sender, EventArgs e)
        {
            UnderlineCategory(PanelUnderline4);

            Category = (sender as Button).Text;
            FillDT();
        }

        private void btnHeifers_Click(object sender, EventArgs e)
        {
            UnderlineCategory(PanelUnderline5);

            Category = (sender as Button).Text;
            FillDT();
        }

        private void btnBullCalves_Click(object sender, EventArgs e)
        {
            UnderlineCategory(PanelUnderline6);

            Category = (sender as Button).Text;
            FillDT();
        }

        private void btnHeiferCalves_Click(object sender, EventArgs e)
        {
            UnderlineCategory(PanelUnderline7);

            Category = (sender as Button).Text;
            FillDT();
        }

        private void btnAllReceivedModes_Click(object sender, EventArgs e)
        {
            UnderlineReceivedMode(PanelUnderline8);

            ReceivedMode = "";
            FillDT();
        }

        private void btnRegionalBirth_Click(object sender, EventArgs e)
        {
            UnderlineReceivedMode(PanelUnderline9);

            ReceivedMode = (sender as Button).Text;
            FillDT();
        }

        private void btnDonation_Click(object sender, EventArgs e)
        {
            UnderlineReceivedMode(PanelUnderline10);

            ReceivedMode = (sender as Button).Text;
            FillDT();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UnderlineReceivedMode(PanelUnderline11);

            ReceivedMode = (sender as Button).Text;
            FillDT();
        }
    }
}
