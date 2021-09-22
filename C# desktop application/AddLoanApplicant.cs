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
    public partial class AddLoanApplicant : Form
    {
        public AddLoanApplicant(string ID,string Name,string NoOfInstallments,string InterestRate)
        {
            InitializeComponent();
            lblLoanID.Text = ID;
            lblLoanName.Text = Name;
            lblNoOfInstallments.Text = NoOfInstallments;
            lblInterestRate.Text = InterestRate;
        }

        private void AddLoanApplicant_Load(object sender, EventArgs e)
        {
            ZAutocomplete.GetSalesRepIdAndName(txtSearchDeleveryPerson);
            ZAutocomplete.GetFarmersIdAndName(txtSearchFarmer);
            radioFarmer.Checked = true;
            lblRequestID.Text = ZAutoGenarate.GenarateNextID("loan request", "RQ_ID");
        }

        private void radioFarmer_CheckedChanged(object sender, EventArgs e)
        {
            if(radioFarmer.Checked==true)
            {
                txtSearchFarmer.Visible = true;
                txtSearchDeleveryPerson.Visible = false;
            }
        }

        private void radioDeleveryPerson_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDeleveryPerson.Checked == true)
            {
                txtSearchFarmer.Visible = false;
                txtSearchDeleveryPerson.Visible = true;
            }
        }

        private void txtSearchFarmer_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearchFarmer.Text))
            {
                MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
                connection.Open();
                string SelectQuery = @"SELECT `DP_ID` , `DP_NAME` FROM `delivery person` WHERE DP_ID  LIKE '" + txtSearchFarmer.Text + "%' OR DP_NAME  LIKE '" + txtSearchFarmer.Text + "%'";
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SelectQuery, connection);
                MySqlDataReader reader = adapter.SelectCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lblApplicantID.Text = reader.GetString(0);
                        lblApplicantName.Text = reader.GetString(1);
                    }
                }
                else if (!reader.HasRows)
                {
                    lblApplicantID.Text = "No matching results";
                    lblApplicantName.Text = "No matching results";
                    lblBasicSalary.Text = "No matching results";
                }
            }
            else
            {
                lblApplicantID.Text = "";
                lblApplicantName.Text = "";
                lblBasicSalary.Text = "";
            }

            
        }

        private void txtSearchDeleveryPerson_TextChanged(object sender, EventArgs e)
        {

            if(!string.IsNullOrWhiteSpace(txtSearchDeleveryPerson.Text))
            {
                MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
                connection.Open();
                string SelectQuery = @"SELECT `SR_ID` , `SR_NAME` , `BASIC_SALARY` FROM `sales rep` WHERE SR_ID  LIKE '" + txtSearchDeleveryPerson.Text + "%' OR SR_NAME  LIKE '" + txtSearchDeleveryPerson.Text + "%'";
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SelectQuery, connection);
                MySqlDataReader reader = adapter.SelectCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lblApplicantID.Text = reader.GetString(0);
                        lblApplicantName.Text = reader.GetString(1);
                        lblBasicSalary.Text = reader.GetDecimal(2).ToString();
                    }
                }
                else if (!reader.HasRows)
                {
                    lblApplicantID.Text = "No matching results";
                    lblApplicantName.Text = "No matching results";
                    lblBasicSalary.Text = "No matching results";
                }
            }
            else 
            {
                lblApplicantID.Text = "";
                lblApplicantName.Text = "";
                lblBasicSalary.Text = "";
            }

        }

        private void txtRequestedAmount_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtRequestedAmount.Text) && !string.IsNullOrWhiteSpace(txtNoOfInstallments.Text))
            {
                decimal Installment = (Convert.ToDecimal(txtRequestedAmount.Text) / Convert.ToDecimal(txtNoOfInstallments.Text));
                lblInstallment.Text = Installment.ToString();

                decimal Interest = Convert.ToDecimal(txtRequestedAmount.Text) * (Convert.ToDecimal(lblInterestRate.Text) / 100);
                decimal InterestForOneInstallment = Interest / Convert.ToDecimal(txtNoOfInstallments.Text);
                lblInterest.Text = Interest.ToString() + "/" + txtNoOfInstallments.Text + " = " + InterestForOneInstallment.ToString();

                decimal InstallmentValue = Installment + InterestForOneInstallment;
                lblFullInstallment.Text  =  InstallmentValue.ToString();
            }
        }

        private void txtNoOfInstallments_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRequestedAmount.Text) && !string.IsNullOrWhiteSpace(txtNoOfInstallments.Text))
            {
                decimal Installment = (Convert.ToDecimal(txtRequestedAmount.Text) / Convert.ToDecimal(txtNoOfInstallments.Text));
                lblInstallment.Text = Installment.ToString();

                decimal Interest = Convert.ToDecimal(txtRequestedAmount.Text) * (Convert.ToDecimal(lblInterestRate.Text) / 100);
                decimal InterestForOneInstallment = Interest / Convert.ToDecimal(txtNoOfInstallments.Text);
                lblInterest.Text = Interest.ToString()+"/"+txtNoOfInstallments.Text+" = "+ InterestForOneInstallment.ToString();

                decimal InstallmentValue = Installment + InterestForOneInstallment;
                lblFullInstallment.Text = InstallmentValue.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            using(MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString))
            {
                connection.Open();
                string SqlInsertREquest = @"INSERT INTO `loan request` (`RQ_ID`, `APPICANT_ID`, `LP_ID`, `RQ_DATE`, `PURPOSE`, `REQUESTED_AMOUNT`, `INSTALLMENT_VALUE`, `NO_OF_INSTALLMENTS`)" +
                                      " VALUES ('" + lblRequestID.Text + "', '" + lblApplicantID.Text + "', '" + lblLoanID.Text + "', '" + dtpRQDate.Value.ToString("yyyy-MM-dd") + "', '" + txtPurpose.Text + "', " + txtRequestedAmount.Text + ",'" + lblFullInstallment.Text + "','" + lblNoOfInstallments.Text + "')";
                string SqlInsertReport = @"INSERT INTO `loan report` (`RQ_ID`, `DUE_DATE`, `INSTALLMENTS_TO_BE_PAID`, `CURRENT_LOAN_VALUE`, `CURRENT_STATUS`)" +
                                           " VALUES ('" + lblRequestID.Text + "', '" + dtpRQDate.Value.AddMonths(+Convert.ToInt32(txtNoOfInstallments.Text)).ToString("yyyy-MM-dd") + "', '" + txtNoOfInstallments.Text + "', '" + txtRequestedAmount.Text + "', 'Approved')";
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                using(adapter.InsertCommand = new MySqlCommand(SqlInsertREquest, connection))
                {
                    adapter.InsertCommand.ExecuteNonQuery();
                    adapter.InsertCommand.Dispose();
                }
                using(adapter.InsertCommand=new MySqlCommand(SqlInsertReport, connection))
                {
                    adapter.InsertCommand.ExecuteNonQuery();
                    adapter.InsertCommand.Dispose();
                }
            }
            

            
           
            
            


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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
