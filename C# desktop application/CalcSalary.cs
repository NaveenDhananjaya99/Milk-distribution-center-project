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
    public partial class CalcSalary : Form
    {
        public CalcSalary()
        {
            InitializeComponent();
        }

        private void cmbGenarateMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGenarateMode.SelectedIndex == 0)
            {
                dgvSalary.Visible = true;

            }
            else
            {
                dgvSalary.Visible = false;
                btnExportExcel.Visible = false;
            }
        }
        private void CalculateSalary(string SRID, string BeginingDate, string EndDate)
        {

            MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
            connection.Open();

            //get employees basic data
            string SQLEmployee = @"SELECT `delivery person`.`DP_NAME`, `delivery person`.`BASIC_SALARY` , COUNT(*) FROM  `daily selling report` LEFT JOIN `delivery person` ON `daily selling report`.`DP_ID`=`delivery person`.`DP_ID` " +
                        "WHERE `delivery person`.`DP_ID`='" + SRID + "' and `daily selling report`.`R_DATE` BETWEEN '" + BeginingDate + "' AND '" + EndDate + "'";

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            using (adapter.SelectCommand = new MySqlCommand(SQLEmployee, connection))
            {
                MySqlDataReader reader = adapter.SelectCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Name = reader.GetString(0);
                        BasicSalary = reader.GetDecimal(1);
                        WorkedDays = reader.GetInt32(2);
                    }
                }
                reader.Close();
            }

            if (WorkedDays != 0)
            {
                GetLoanDetails(SRID);
                //final calculations

                if (nudNoOfWorkingDays.Value - WorkedDays == 1)
                {
                    AttendanceAllowance = (AttendanceAllowance / 4) * 3;
                }
                if (nudNoOfWorkingDays.Value - WorkedDays == 2)
                {
                    AttendanceAllowance = (AttendanceAllowance / 4) * 2;
                }
                if (nudNoOfWorkingDays.Value - WorkedDays == 3)
                {
                    AttendanceAllowance = (AttendanceAllowance / 4) * 1;
                }
                if (nudNoOfWorkingDays.Value - WorkedDays == 3)
                {
                    AttendanceAllowance = 0;
                }


            }
            else
            {
                AttendanceAllowance = AttendanceAllowance  * 0;
                COLA = 0;
            }
            TotSalary = BasicSalary + COLA + AttendanceAllowance;
            ToEPF = ((TotSalary * 8) / 100);
            NetSalary = TotSalary - Installment - ToEPF;


            //display
            if (cmbGenarateMode.SelectedIndex == 0)
            {
                dgvSalary.DataSource = GetDataTable(SRID, Name, BasicSalary, WorkedDays, COLA, AttendanceAllowance, ToEPF, Installment, NetSalary);
                ResetValues();
            }
            else
            {
                lblBasic.Text = BasicSalary.ToString();
                lblWorkedDays.Text = WorkedDays.ToString();
                lblCOLA.Text = COLA.ToString();
                lblAttendanceAllowance.Text = AttendanceAllowance.ToString();
                lblTotalSalary.Text = TotSalary.ToString();

                lblForLoan.Text = Installment.ToString();
                lblForEPF.Text = ToEPF.ToString();
                lblNetSalary.Text = NetSalary.ToString();
            }

        }

        private void GetLoanDetails(string SRID)
        {
            MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
            connection.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string SQLLoan = @"SELECT `loan report`.`RQ_ID`,`loan request`.`REQUESTED_AMOUNT` ,`loan request`.`INSTALLMENT_VALUE` , `loan request`.`NO_OF_INSTALLMENTS`  FROM `loan request` INNER JOIN `loan report` ON `loan request`.`RQ_ID`= `loan report`.`RQ_ID` WHERE `loan request`.`APPICANT_ID`='" + SRID + "' and `loan report`.`CURRENT_STATUS` <> 'Settled'";
            using (adapter.SelectCommand = new MySqlCommand(SQLLoan, connection))
            {
                MySqlDataReader reader = adapter.SelectCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ReportID = reader.GetString(0);
                        LoanAmount = reader.GetDecimal(1);
                        Installment = reader.GetDecimal(2);
                        NoOfInstallment = reader.GetDecimal(3);
                    }

                    DeductFromLoan = LoanAmount / NoOfInstallment;
                }
                else
                {
                    ReportID = "";
                    LoanAmount = 0;
                    Installment = 0;
                    NoOfInstallment = 0;
                }
                reader.Close();
            }
        }

        DataTable DT = new DataTable();
        public DataTable GetDataTable(string Id, string Name, decimal BasicSalary, decimal WorkedDays, decimal COLA, decimal AttendanceAllowance, decimal ToEPF, decimal ToLoan, decimal NetSalary)
        {
            if (DT.Rows.Count == 0)
            {

                DataColumn dc00 = new DataColumn("Employee Id", typeof(string));
                DataColumn dc01 = new DataColumn("Employee Name", typeof(string));
                DataColumn dc02 = new DataColumn("Basic salary", typeof(decimal));
                DataColumn dc03 = new DataColumn("Worked Days", typeof(int));
                DataColumn dc04 = new DataColumn("COLA", typeof(decimal));
                DataColumn dc05 = new DataColumn("Attendance Allowance", typeof(decimal));
                DataColumn dc06 = new DataColumn("To EPF", typeof(decimal));
                DataColumn dc07 = new DataColumn("To Loan", typeof(decimal));
                DataColumn dc08 = new DataColumn("Net Salary", typeof(decimal));

                if (!DT.Columns.Contains("Employee Id"))
                {
                    DT.Columns.Add(dc00);
                }
                if (!DT.Columns.Contains("Employee Name"))
                {
                    DT.Columns.Add(dc01);
                }
                if (!DT.Columns.Contains("Basic salary"))
                {
                    DT.Columns.Add(dc02);
                }
                if (!DT.Columns.Contains("Worked Days"))
                {
                    DT.Columns.Add(dc03);
                }
                if (!DT.Columns.Contains("COLA"))
                {
                    DT.Columns.Add(dc04);
                }
                if (!DT.Columns.Contains("Attendance Allowance"))
                {
                    DT.Columns.Add(dc05);
                }
                if (!DT.Columns.Contains("To EPF"))
                {
                    DT.Columns.Add(dc06);
                }
                if (!DT.Columns.Contains("To Loan"))
                {
                    DT.Columns.Add(dc07);
                }
                if (!DT.Columns.Contains("Net Salary"))
                {
                    DT.Columns.Add(dc08);
                }

                DT.Rows.Add(Id, Name, BasicSalary, WorkedDays, COLA, AttendanceAllowance, ToEPF, ToLoan, NetSalary);

            }
            else
            {
                DT.Rows.Add(Id, Name, BasicSalary, WorkedDays, COLA, AttendanceAllowance, ToEPF, ToLoan, NetSalary);

            }

            return DT;

        }

        //variables
        string DPName = "";
        decimal BasicSalary = 0;
        int WorkedDays = 0;
        decimal COLA = 2000;
        decimal AttendanceAllowance = 1000;

        string ReportID = "";
        decimal LoanAmount = 0;
        decimal Installment = 0;
        decimal NoOfInstallment = 0;
        decimal DeductFromLoan = 0;


        decimal ToEPF = 0;
        decimal TotSalary = 0;
        decimal NetSalary = 0;

        private void ResetValues()
        {
            Name = "";
            BasicSalary = 0;
            WorkedDays = 0;
            COLA = 2000;
            AttendanceAllowance = 1000;

            ReportID = "";
            LoanAmount = 0;
            Installment = 0;
            NoOfInstallment = 0;
            DeductFromLoan = 0;


            ToEPF = 0;
            TotSalary = 0;
            NetSalary = 0;
        }

        private void InsertPaysheet(string ID, decimal BasicSalary, int WorkedDays, decimal COLA, decimal AttendanceAllowance, decimal ToEPF, decimal ForLoan, decimal NetSalary)
        {
            MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
            connection.Open();

            //insert paysheet details
            string SQLInsertPaysheet = @"INSERT INTO `paysheet` ( `DP_ID`, `GENARATED_DATE`, `MONTH`, `BASIC_SALARY`, `WORKED_DAYS`, `COLA`, `ATTENDANCE_ALLOWANCE`, `DEDUCT_TO_EPF`, `DEDUCT_TO_LOAN`, `NET_SALARY`)" +
                                                         " VALUES ('" + ID + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + dtpBeginingDate.Value.ToString("MMMM") + "', '" + BasicSalary + "', '" + WorkedDays + "', '" + COLA + "', '" + AttendanceAllowance + "', '" + ToEPF + "', '" + ForLoan + "', '" + NetSalary + "')";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            using (adapter.InsertCommand = new MySqlCommand(SQLInsertPaysheet, connection))
            {
                adapter.InsertCommand.ExecuteNonQuery();

            }
        }

        private void UpdateLoan()
        {
            if (ReportID != "" && WorkedDays != 0)
            {
                MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                string SQLUpdateLoan = @"UPDATE `loan report` SET `INSTALLMENTS_TO_BE_PAID`=`INSTALLMENTS_TO_BE_PAID`-1 , `CURRENT_LOAN_VALUE`=`CURRENT_LOAN_VALUE` - " + DeductFromLoan + " WHERE `RQ_ID`='" + ReportID + "'";
                using (adapter.UpdateCommand = new MySqlCommand(SQLUpdateLoan, connection))
                {
                    adapter.UpdateCommand.ExecuteNonQuery();

                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (dgvSalary.Visible == false)
            {
                InsertPaysheet(txtEmpID.Text, BasicSalary, WorkedDays, COLA, AttendanceAllowance, ToEPF, Installment, NetSalary);
                UpdateLoan();
                ResetValues();
            }
            else
            {
                for (int i = 0; i < dgvSalary.Rows.Count - 1; i++)
                {

                    BasicSalary = Convert.ToDecimal(dgvSalary.Rows[i].Cells[2].Value);
                    WorkedDays = Convert.ToInt32(dgvSalary.Rows[i].Cells[3].Value);
                    COLA = Convert.ToDecimal(dgvSalary.Rows[i].Cells[4].Value);
                    AttendanceAllowance = Convert.ToDecimal(dgvSalary.Rows[i].Cells[5].Value);
                    ToEPF = Convert.ToDecimal(dgvSalary.Rows[i].Cells[6].Value);
                    Installment = Convert.ToDecimal(dgvSalary.Rows[i].Cells[7].Value);
                    NetSalary = Convert.ToDecimal(dgvSalary.Rows[i].Cells[8].Value);

                    InsertPaysheet(dgvSalary.Rows[i].Cells[0].Value.ToString(), BasicSalary, WorkedDays, COLA, AttendanceAllowance, ToEPF, Installment, NetSalary);
                    GetLoanDetails(dgvSalary.Rows[i].Cells[0].Value.ToString());
                    UpdateLoan();



                }
            }

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (cmbGenarateMode.SelectedIndex == 0)
            {
                DT.Rows.Clear();


                MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
                connection.Open();

                string sql = @"SELECT `DP_ID` FROM `delivery person` ";
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = adapter.SelectCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CalculateSalary(reader.GetString(0), dtpBeginingDate.Value.ToString("yyyy-MM-dd"), dtpEndDate.Value.ToString("yyyy-MM-dd"));
                    }
                }
                btnExportExcel.Visible = true;
            }
            else if (cmbGenarateMode.SelectedIndex == 1)
            {
                CalculateSalary(txtEmpID.Text, dtpBeginingDate.Value.ToString("yyyy-MM-dd"), dtpEndDate.Value.ToString("yyyy-MM-dd"));

            }
            btnInsert.Visible = true;
        }

        private void txtEmpID_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
            connection.Open();

            string sql = @"SELECT `DP_NAME` FROM `delivery person` WHERE `DP_ID` LIKE '" + txtEmpID.Text + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(sql, connection);
            MySqlDataReader reader = adapter.SelectCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lblEmpName.Text = reader.GetString(0);
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ZExport.AsExcel(DT);
        }
    }
}
