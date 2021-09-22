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
    public partial class AddLoanProposal : Form
    {
        public AddLoanProposal()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string InsertQuery = "INSERT INTO `loan proposal` (`LP_ID`, `STARTED_DATE`, `LP_NAME`, `MAX_LOAN_VALUE`, `REPAYMERNT_PERIOD`, `No_of_installments`, `INTEREST_RATE`, `INTEREST_MODE`, `LP_DESCRIPTION`, `APPLICANT_TYPE`, `CURRENT_STATUS`)" +
                "VALUES ('"+ lblID.Text + "','"+this.dtpStarteddate.Text+"','"+txtName.Text+"','"+Convert.ToDecimal(txtvalue.Text)+"','"+txtRepaymentPeriod.Text+"','"+Convert.ToDecimal(txtInstallments.Text)+"','"+Convert.ToDecimal(txtInterestRate.Text)+"','"+txtInterestMode.Text+"','"+txtDescription.Text+"','"+cmbApplicantType.Text+"','"+cmbCurrentStatus.Text+"')";




                                
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.InsertCommand = new MySqlCommand(InsertQuery, con);
            if(adapter.InsertCommand.ExecuteNonQuery()>0)
            {
                MessageBox.Show("inserted");
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddLoanProposal_Load(object sender, EventArgs e)
        {
            lblID.Text = ZAutoGenarate.GenarateNextID("loan proposal", "LP_ID");
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
