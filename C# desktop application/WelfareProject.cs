using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ProjectZ
{
    public partial class WelfareProject : Form
    {
        public WelfareProject()
        {
            InitializeComponent();
        }
        string Year = "";
        string Status = "";
        public void FillDT()
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string SelectQuery = @"SELECT `W_ID` , `W_NAME` , `STATUS` FROM `welfare project` WHERE YEAR(STARTED_DATE) LIKE '"+Year+"%' AND `STATUS` LIKE '"+Status+"%' AND  (`W_ID` LIKE '"+txtSearch.Text+"%' OR `W_NAME` LIKE '"+txtSearch.Text+"%')";
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            adapter.SelectCommand = new MySqlCommand(SelectQuery, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvWelfareProjects.DataSource = dt;
        }

        private void WelfareProject_Load(object sender, EventArgs e)
        {
            FillDT();

            cmbYearFilter.Items.Add("--All--");
            for (int year = 2000; year < DateTime.UtcNow.Year + 1; ++year)
            {
                cmbYearFilter.Items.Add(year.ToString());
            }
            cmbYearFilter.SelectedIndex = 0;
            cmbStatusFilter.SelectedIndex = 0;

        }

        public void GetbasicData()
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string SelectQuery = @"SELECT * FROM `welfare project` WHERE `W_ID`='"+lblID.Text+"'";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(SelectQuery, con);
            MySqlDataReader reader = adapter.SelectCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lblID.Text = reader.GetString(0);
                    lblName.Text = reader.GetString(1);
                    txtDescription.Text = reader.GetString(2);
                    txtStartededate.Text = reader.GetDateTime(3).ToString("yyyy-MM-dd");
                    txtBenidiciaryType.Text = reader.GetString(4);
                    txtStatus.Text = reader.GetString(5);

                }
            }
        }

        private void dgvWelfareProjects_SelectionChanged(object sender, EventArgs e)
        {

            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                if (row != null)
                {
                    lblID.Text = row.Cells[0].Value.ToString();
                    GetbasicData();
                }
            }

           
            
        }

        private void btnEditSave_Click(object sender, EventArgs e)
        {
            if (btnEditSave.Text == "Edit")
            {
                dgvWelfareProjects.Enabled = false;

                dtpStartedDate.Visible = true;

                txtDescription.ReadOnly = false;
                txtDescription.BackColor = Color.White;
                txtDescription.ForeColor = Color.Black;

                txtBenidiciaryType.ReadOnly = false;
                txtBenidiciaryType.BackColor = Color.White;
                txtBenidiciaryType.ForeColor = Color.Black;

                cmbStatus.Text = txtStatus.Text;
                txtStatus.Visible = false;
                cmbStatus.Visible = true;

                btnEditSave.Text = "Save";
            }
            else if (btnEditSave.Text == "Save")
            {


                MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                con.Open();

                string UpdateQuery = @"UPDATE `welfare project` SET `W_DESCRIPTION` = '" + txtDescription.Text + "', `STARTED_DATE` = '" + txtStartededate.Text + "', `BENEFICIARY_TYPE` = '" + txtBenidiciaryType.Text + "', `STATUS` = '" + txtStatus.Text + "'  WHERE `welfare project`.`W_ID` = '" + lblID.Text + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                adapter.UpdateCommand = new MySqlCommand(UpdateQuery, con);
                if(adapter.UpdateCommand.ExecuteNonQuery()>0)
                {
                    MessageBox.Show("Updated");
                }

                dtpStartedDate.Visible = false;

                txtDescription.ReadOnly = true;
                txtDescription.BackColor = Color.Navy;
                txtDescription.ForeColor = Color.White;

                txtDescription.ReadOnly = true;
                txtDescription.BackColor = Color.Navy;
                txtDescription.ForeColor = Color.White;

                txtBenidiciaryType.ReadOnly = true;
                txtBenidiciaryType.BackColor = Color.Navy;
                txtBenidiciaryType.ForeColor = Color.White;

                
                txtStatus.Visible = true;
                cmbStatus.Visible = false;

                btnEditSave.Text = "Edit";
                dgvWelfareProjects.Enabled = true;
                FillDT();
            }
        }

        private void dtpStartedDate_ValueChanged(object sender, EventArgs e)
        {
            txtStartededate.Text = dtpStartedDate.Text;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddWelfareProject frm = new AddWelfareProject();
            frm.ShowDialog();
            FillDT();

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStatus.Text = cmbStatus.Text;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillDT();
        }

        

        private void cmbYearFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbYearFilter.SelectedIndex==0)
            {
                Year = "";
            }
            else if (cmbYearFilter.SelectedIndex > 0)
            {
                Year = cmbYearFilter.Text;
            }
            FillDT();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatusFilter.SelectedIndex == 0)
            {
                Status = "";
            }
            else if (cmbStatusFilter.SelectedIndex > 0)
            {
                Status = cmbStatusFilter.Text;
            }
            FillDT();

        }
    }
}
