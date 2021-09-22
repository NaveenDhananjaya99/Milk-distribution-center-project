using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectZ
{
    public partial class CreateLogin : Form
    {
        public CreateLogin()
        {
            InitializeComponent();
        }

        private void FillDT()
        {
            MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
            connection.Open();

            string sql = @"SELECT `USERNAME` , `PASSWORD` , `ROLE` , `PRIVILEGES` FROM logins";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql,connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvLogins.DataSource = dt;

            connection.Close();

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbRole.Text=="Admin")
            {
                checkBoxCheckAll.Checked = true;
            }
            else
            {
                checkBoxCheckAll.Checked = false;
            }
        }

        private void checkBoxCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxCheckAll.Checked==true)
            {
                checkBoxPricing.Checked = true;
                checkBoxPayrol.Checked = true;
                checkBoxHRMGT.Checked = true;
                checkBoxOrders.Checked = true;
                checkBoxLoanProposals.Checked = true;
                checkBoxWelfareProjects.Checked = true;
                checkBoxLiveStockManagement.Checked = true;

                checkBoxPricing.Enabled = false;
                checkBoxPayrol.Enabled = false;
                checkBoxHRMGT.Enabled = false;
                checkBoxOrders.Enabled = false;
                checkBoxLoanProposals.Enabled = false;
                checkBoxWelfareProjects.Enabled = false;
                checkBoxLiveStockManagement.Enabled = false;
            }
            else if(checkBoxCheckAll.Checked == false)
            {
                checkBoxPricing.Checked = false;
                checkBoxPayrol.Checked = false;
                checkBoxHRMGT.Checked = false;
                checkBoxOrders.Checked = false;
                checkBoxLoanProposals.Checked = false;
                checkBoxWelfareProjects.Checked = false;
                checkBoxLiveStockManagement.Checked = false;

                checkBoxPricing.Enabled = true;
                checkBoxPayrol.Enabled = true;
                checkBoxHRMGT.Enabled = true;
                checkBoxOrders.Enabled = true;
                checkBoxLoanProposals.Enabled = true;
                checkBoxWelfareProjects.Enabled = true;
                checkBoxLiveStockManagement.Enabled = true;
            }
        }
        private string SetPrivileges()
        {
            string Privileges = "";
            if(checkBoxCheckAll.Checked == true)
            {
                Privileges = "All";
            }
            else if(checkBoxCheckAll.Checked == false)
            {
                if (checkBoxPricing.Checked == true)
                {
                    Privileges = Privileges + checkBoxPricing.Text + "-";
                }
                if (checkBoxOrders.Checked == true)
                {
                    Privileges = Privileges  + checkBoxOrders.Text + "-";
                }
                if (checkBoxCalcSalary.Checked == true)
                {
                    Privileges = Privileges + checkBoxCalcSalary.Text + "-";
                }
                if (checkBoxCalcPayments.Checked == true)
                {
                    Privileges = Privileges  + checkBoxCalcPayments.Text + "-";
                }
                if (checkBoxWelfareProjects.Checked == true)
                {
                    Privileges = Privileges  + checkBoxWelfareProjects.Text + "-";
                }
                if (checkBoxLoanProposals.Checked == true)
                {
                    Privileges = Privileges  + checkBoxLoanProposals.Text + "-";
                }
                if (checkBoxDeleveryPerson.Checked == true)
                {
                    Privileges = Privileges  + checkBoxDeleveryPerson.Text + "-";
                }
                if (checkBoxVeterinarian.Checked == true)
                {
                    Privileges = Privileges + checkBoxVeterinarian.Text + "-";
                }
                if (checkBoxLiveStockManagement.Checked == true)
                {
                    Privileges = Privileges + checkBoxLiveStockManagement.Text + "-";
                }
                if (checkBoxFarmers.Checked == true)
                {
                    Privileges = Privileges + checkBoxFarmers.Text + "-";
                }


            }
            return Privileges;
           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
            connection.Open();

            string sql = @"INSERT INTO `logins` (`USERNAME`, `PASSWORD`, `ROLE`, `PRIVILEGES`) VALUES('" + txtUserName.Text + "', '" + txtPassword.Text + "', '" + cmbRole.Text + "', '"+SetPrivileges()+"')";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            using(adapter.InsertCommand = new MySqlCommand(sql, connection))
            {
                adapter.InsertCommand.ExecuteNonQuery();
                FillDT();
            }
            connection.Close();
            adapter.InsertCommand.Dispose();
            adapter.Dispose();
            

            

        }

        private void CreateLogin_Load(object sender, EventArgs e)
        {
            FillDT();
        }

        private void checkBoxPayrol_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPayrol.Checked == true)
            {
                checkBoxCalcSalary.Checked = true;
                checkBoxCalcPayments.Checked = true;

                checkBoxCalcSalary.Enabled = false;
                checkBoxCalcPayments.Enabled = false;
            }
            else if(checkBoxPayrol.Checked == false)
            {
                checkBoxCalcSalary.Checked = false;
                checkBoxCalcPayments.Checked = false;

                checkBoxCalcSalary.Enabled = true;
                checkBoxCalcPayments.Enabled = true;
            }
            
        }

        private void checkBoxHRMGT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHRMGT.Checked == true)
            {
                checkBoxDeleveryPerson.Checked = true;
                checkBoxVeterinarian.Checked = true;
                checkBoxLiveStockManagement.Checked = true;
                checkBoxFarmers.Checked = true;

                checkBoxDeleveryPerson.Enabled = false;
                checkBoxVeterinarian.Enabled = false;
                checkBoxLiveStockManagement.Enabled = false;
                checkBoxFarmers.Enabled = false;
            }
            else if (checkBoxHRMGT.Checked == false)
            {
                checkBoxDeleveryPerson.Checked = false;
                checkBoxVeterinarian.Checked = false;
                checkBoxLiveStockManagement.Checked = false;
                checkBoxFarmers.Checked = false;

                checkBoxDeleveryPerson.Enabled = true;
                checkBoxVeterinarian.Enabled = true;
                checkBoxLiveStockManagement.Enabled = true;
                checkBoxFarmers.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ZFormControls.ForCloseButtonClick(this);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            checkBoxCheckAll.Checked = true;
            checkBoxCheckAll.Checked = false;
            txtUserName.Clear();
            txtPassword.Clear();
            txtRePassword.Clear();
            cmbRole.Text = "";
        }
        string[] PrivilegesList = { "pricing", "Order Management", "Calculate Salaries", "Calculate Payments", "Welfare Projects", "Loan Proposals", "Delevery Person", "Veterinarian", "Live Stock Management", "Farmers" };
        private void dgvLogins_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvLogins.Rows[dgvLogins.SelectedRows[0].Index];

            DialogResult result = MessageBox.Show("Are you sure yiu want to edit User = " + row.Cells[0].Value.ToString() + "?","Message",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result==DialogResult.Yes)
            {
                txtUserName.Text= row.Cells[0].Value.ToString();
                txtPassword.Text = row.Cells[1].Value.ToString();
                txtRePassword.Text = row.Cells[1].Value.ToString();
                cmbRole.Text = row.Cells[2].Value.ToString();
                string Privileges = row.Cells[3].Value.ToString();

                string[] array = Privileges.Split('-');
                for (int i = 0; i < array.Length; i++)
                {
                    Privileges = array[i];
                    if(Privileges=="All")
                    {
                        checkBoxCheckAll.Checked = true;
                    }
                    else
                    {
                        if (Privileges=="pricing")
                        {
                            checkBoxPricing.Checked = true;
                        }
                        if (Privileges == "Order Management")
                        {
                            checkBoxOrders.Checked = true;
                        }
                        if (Privileges == "Calculate Salaries")
                        {
                            checkBoxCalcSalary.Checked = true;
                        }
                        if (Privileges == "Calculate Payments")
                        {
                            checkBoxCalcPayments.Checked = true;
                        }
                        if (Privileges == "Welfare Projects")
                        {
                            checkBoxWelfareProjects.Checked = true;
                        }
                        if (Privileges == "Loan Proposals")
                        {
                            checkBoxLoanProposals.Checked = true;
                        }

                        if (Privileges == "Delevery Person")
                        {
                            checkBoxDeleveryPerson.Checked = true;
                        }
                        if (Privileges == "Veterinarian")
                        {
                            checkBoxVeterinarian.Checked = true;
                        }
                        if (Privileges == "Live Stock Management")
                        {
                            checkBoxLiveStockManagement.Checked = true;
                        }
                        if (Privileges == "Farmers")
                        {
                            checkBoxFarmers.Checked = true;
                        }
                    }
                }
            }
        }
    }
}
