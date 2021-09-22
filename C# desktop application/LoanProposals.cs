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
    public partial class LoanProposals : Form
    {
        public LoanProposals()
        {
            InitializeComponent();
        }
        string Year = "";
        string Status = "";
        public void FillDT()
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string SelectQuery = @"SELECT `LP_ID` , `LP_NAME` FROM `loan proposal` WHERE YEAR(STARTED_DATE) LIKE '" + Year + "%' AND `CURRENT_STATUS` LIKE '" + Status + "%' AND  (`LP_ID` LIKE '" + txtSearch.Text + "%' OR `LP_NAME` LIKE '" + txtSearch.Text + "%')";
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            adapter.SelectCommand = new MySqlCommand(SelectQuery, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvLoanProposal.DataSource = dt;
        }
        private void LoanProposals_Load(object sender, EventArgs e)
        {
            FillDT();
            cmbApplicantType.Visible = false;
            cmbCurrentStatus.Visible = false;
            dtpStartedDate.Visible = false;

            cmbYearFilter.Items.Add("--All--");
            for (int year = 2000; year < DateTime.UtcNow.Year + 1; ++year)
            {
                cmbYearFilter.Items.Add(year.ToString());
            }
            cmbYearFilter.SelectedIndex = 0;
            cmbStatusFilter.SelectedIndex = 0;


        }

       

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddLoanProposal frm = new AddLoanProposal();
            frm.ShowDialog();
            MessageBox.Show("add new proposal and refresh dgv");
            FillDT();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void cmbCurrentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEditSave_Click(object sender, EventArgs e)
        {
            if(btnEditSave.Text=="Edit")
            {
                dgvLoanProposal.Enabled = false;

                txtvalue.ReadOnly = false;
                txtvalue.BackColor = Color.White;
                txtvalue.ForeColor = Color.Black;

                txtRepaymentPeriod.ReadOnly = false;
                txtRepaymentPeriod.BackColor = Color.White;
                txtRepaymentPeriod.ForeColor = Color.Black;

                txtInterestRate.ReadOnly = false;
                txtInterestRate.BackColor = Color.White;
                txtInterestRate.ForeColor = Color.Black;

                txtInterestMode.ReadOnly = false;
                txtInterestMode.BackColor = Color.White;
                txtInterestMode.ForeColor = Color.Black;

                cmbApplicantType.Text = txtApplicantType.Text;
                txtApplicantType.Visible = false;
                cmbApplicantType.Visible = true;


                dtpStartedDate.Visible = true;

                txtDescription.ReadOnly = false;
                txtDescription.BackColor = Color.White;
                txtDescription.ForeColor = Color.Black;

                cmbCurrentStatus.Text = txtCurrentStatus.Text;
                txtCurrentStatus.Visible = false;
                cmbCurrentStatus.Visible = true;

                btnEditSave.Text = "Save";
            }
            else if (btnEditSave.Text == "Save")
            {


                MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                con.Open();

                string UpdateQuery = @"UPDATE `loan proposal` SET  `STARTED_DATE` = '"+txtStartededate.Text+"' , `REPAYMERNT_PERIOD` = '"+txtRepaymentPeriod.Text+"' , `INTEREST_RATE` = '"+txtInterestRate.Text+"', `INTEREST_MODE` = '"+txtInterestMode.Text+"', `LP_DESCRIPTION` = '"+txtDescription.Text+"', `APPLICANT_TYPE` = '"+txtApplicantType.Text+"', `CURRENT_STATUS` = '"+txtCurrentStatus.Text+"' WHERE `loan proposal`.`LP_ID` = '"+lblID.Text+"'";
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                adapter.UpdateCommand = new MySqlCommand(UpdateQuery, con);
                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Updated");
                }

                txtvalue.ReadOnly = true;
                txtvalue.BackColor = Color.Navy;
                txtvalue.ForeColor = Color.White;

                txtRepaymentPeriod.ReadOnly = true;
                txtRepaymentPeriod.BackColor = Color.Navy;
                txtRepaymentPeriod.ForeColor = Color.White;

                txtInterestRate.ReadOnly = true;
                txtInterestRate.BackColor = Color.Navy;
                txtInterestRate.ForeColor = Color.White;

                txtInterestMode.ReadOnly = true;
                txtInterestMode.BackColor = Color.Navy;
                txtInterestMode.ForeColor = Color.White;


                txtApplicantType.Visible = true;
                cmbApplicantType.Visible = false;

                
                dtpStartedDate.Visible = false;

                txtDescription.ReadOnly = true;
                txtDescription.BackColor = Color.Navy;
                txtDescription.ForeColor = Color.White;


                txtCurrentStatus.Visible = true;
                cmbCurrentStatus.Visible = false;



                btnEditSave.Text = "Edit";
                dgvLoanProposal.Enabled = true;
            }
        }

        private void cmbApplicantType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtApplicantType.Text= cmbApplicantType.Text;
        }

        private void dtpStartedDate_ValueChanged(object sender, EventArgs e)
        {
            txtStartededate.Text= dtpStartedDate.Text;
        }

        private void cmbCurrentStatus_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtCurrentStatus.Text= cmbCurrentStatus.Text;
        }

        private void dgvLoanProposal_SelectionChanged(object sender, EventArgs e)
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

        public void GetbasicData()
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string SelectQuery = @"SELECT * FROM `loan proposal` WHERE `LP_ID`='" + lblID.Text + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(SelectQuery, con);
            MySqlDataReader reader = adapter.SelectCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lblID.Text = reader.GetString(0);
                    txtStartededate.Text = reader.GetDateTime(1).ToString("yyyy-MM-dd");
                    lblName.Text = reader.GetString(2);
                    txtvalue.Text = reader.GetDecimal(3).ToString();
                    txtRepaymentPeriod.Text = reader.GetString(4);
                    txtNoOfInstallments.Text = reader.GetDecimal(5).ToString();
                    txtInterestRate.Text = reader.GetDecimal(6).ToString();
                    txtInterestMode.Text = reader.GetString(7);
                    txtDescription.Text = reader.GetString(8);
                    txtApplicantType.Text = reader.GetString(9);
                    txtCurrentStatus.Text = reader.GetString(10);


                }
            }
        }

        private void btnAddApplicant_Click(object sender, EventArgs e)
        {
            AddLoanApplicant frm = new AddLoanApplicant(lblID.Text,lblName.Text,txtNoOfInstallments.Text,txtInterestRate.Text);
            frm.ShowDialog();
        }

        private void panelData_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbYearFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYearFilter.SelectedIndex == 0)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillDT();
        }
    }
}
