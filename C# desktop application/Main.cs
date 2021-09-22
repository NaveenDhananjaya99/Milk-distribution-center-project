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
    public partial class Main : Form
    {
        public Main(string Privileges,string UserName)
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Normal;
            this.Privileges = Privileges;
            this.UserName = UserName;

        }
        string Privileges = "";
        string UserName = "";

        private void Main_Load(object sender, EventArgs e)
        {
            if (Privileges=="All")
            {
                
               
                btnCreateLogin.Visible = true;
                btnSetPrices.Visible = true;
                panelSubOrders.Visible = true;
                btnOrders.Visible = true;
                panelSubPayrol.Visible = true;
                btnPayroll.Visible = true;
                btnPayments.Visible = true;
                btnSalary.Visible = true;
                btnWelfareProjects.Visible = true;
                btnLoans.Visible = true;
                btnDeleveryPerson.Visible = true;
                btnVeterinarions.Visible = true;
                btnLiveStocks.Visible = true;
                btnFarmers.Visible = true;


                btnOrders.PerformClick();
                btnPayroll.PerformClick();

            }
            else if(Privileges!="All")
            {

                string[] arr = Privileges.Split('-');
                for (int i = 0; arr.Length > i; i++)
                {
                    if (arr[i]=="Pricing")
                    {
                        btnSetPrices.Visible = true;
                    }
                    else if (arr[i] == "Order Management")
                    {
                        panelSubOrders.Visible = true;
                        btnOrders.Visible = true;
                    }
                    else if (arr[i] == "Calculate Salaries" || arr[i] == "Calculate Payments")
                    {
                        if(arr[i] == "Calculate Salaries")
                        {
                            panelSubPayrol.Visible = true;
                            btnSalary.Visible = true;
                            btnPayroll.Visible = true;
                        }
                        else if(arr[i] == "Calculate Payments")
                        {
                            panelSubPayrol.Visible = true;
                            btnPayments.Visible = true;
                            btnPayroll.Visible = true;
                        }
                        
                    }
                    else if (arr[i] == "Welfare Projects")
                    {
                        btnWelfareProjects.Visible = true;
                    }
                    else if (arr[i] == "Loan Proposals")
                    {
                        btnLoans.Visible = true;
                    }
                    else if (arr[i] == "Delevery Person")
                    {
                        btnDeleveryPerson.Visible = true;
                    }
                    else if (arr[i] == "Veterinarian")
                    {
                        btnVeterinarions.Visible = true;
                    }
                    else if (arr[i] == "Live Stock Management")
                    {
                        btnLiveStocks.Visible = true;
                    }
                    else if (arr[i] == "Farmers")
                    {
                        btnFarmers.Visible = true;
                    }

                }
                
                btnOrders.PerformClick();
                btnPayroll.PerformClick();
            }
            btnDashboard.Visible = true;
            panelMainMenu.VerticalScroll.Value = 100;
            btnDashboard.PerformClick();
            btnDashboard.Focus();
            timer.Start();
        }

        private void panelDashparent_MouseDown(object sender, MouseEventArgs e)
        {
            ZFormControls.ForMouseDown(this);
        }

        private void panelDashparent_MouseMove(object sender, MouseEventArgs e)
        {
            ZFormControls.ForMouseMove(this);
        }

        private void panelDashparent_MouseUp(object sender, MouseEventArgs e)
        {
            ZFormControls.ForMouseUp();
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                panelMainParent.Controls.Clear();
                Dashboard frm = new Dashboard();
                frm.TopLevel = false;
                panelMainParent.Controls.Add(frm);
                panelMainParent.BringToFront();
                frm.Dock = DockStyle.Fill;
                frm.Show();
                lbltitle.Text = btnDashboard.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }
           
        }

        private void btnPayroll_Click(object sender, EventArgs e)
        {
            try
            {
                if (panelSubPayrol.Visible == true)
                {
                    panelSubPayrol.Visible = false;
                }
                else if (panelSubPayrol.Visible == false)
                {
                    panelSubPayrol.Visible = true;
                    panelSubPayrol.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }

           

            
        }

        private void btnFarmers_Click(object sender, EventArgs e)
        {
            try
            {
                Farmers frm = new Farmers();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }
            

        }

        private void btnLiveStocks_Click(object sender, EventArgs e)
        {
            try
            {
                LiveStock frm = new LiveStock();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }

        }

        private void btnVeterinarions_Click(object sender, EventArgs e)
        {
            try
            {
                Veterinarians frm = new Veterinarians();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }

        }

        private void btnSalesRep_Click(object sender, EventArgs e)
        {
            try
            {
                DeliveryPerson frm = new DeliveryPerson();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }

        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            try
            {
                if (panelSubOrders.Visible == true)
                {
                    panelSubOrders.Visible = false;
                }
                else if (panelSubOrders.Visible == false)
                {
                    panelSubOrders.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }


        }

        private void btnLoans_Click(object sender, EventArgs e)
        {
            try
            {
                panelMainParent.Controls.Clear();
                LoanProposals frm = new LoanProposals();
                frm.TopLevel = false;
                panelMainParent.Controls.Add(frm);
                panelMainParent.BringToFront();
                frm.Dock = DockStyle.Fill;
                frm.Show();
                lbltitle.Text = btnLoans.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }


        }

        private void btnWelfareProjects_Click(object sender, EventArgs e)
        {
            try
            {
                panelMainParent.Controls.Clear();
                WelfareProject frm = new WelfareProject();
                frm.TopLevel = false;
                panelMainParent.Controls.Add(frm);
                panelMainParent.BringToFront();
                frm.Dock = DockStyle.Fill;
                frm.Show();
                lbltitle.Text = btnWelfareProjects.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }

        }

        private void btnSetPrices_Click(object sender, EventArgs e)
        {
            try
            {
                SetPrices frm = new SetPrices();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }

        }

        private void panelHead_MouseDown(object sender, MouseEventArgs e)
        {
            ZFormControls.ForMouseDown(this);
        }

        private void panelHead_MouseMove(object sender, MouseEventArgs e)
        {
            ZFormControls.ForMouseMove(this);
        }

        private void panelHead_MouseUp(object sender, MouseEventArgs e)
        {
            ZFormControls.ForMouseUp();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:");
            lblSecond.Text = DateTime.Now.ToString("ss");
            lblDate.Text = DateTime.Now.ToString("MMMM dd yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");

            if (DateTime.Now.Hour > 0 && DateTime.Now.Hour < 12)
            {
                lblGreeting.Text = "Good Morning";
            }
            else if (DateTime.Now.Hour > 12 && DateTime.Now.Hour < 16)
            {
                lblGreeting.Text = "Good Afternoon";
            }
            else if (DateTime.Now.Hour >= 16 && DateTime.Now.Hour <= 19)
            {
                lblGreeting.Text = "Good Evening";
            }
            else if (DateTime.Now.Hour > 19)
            {
                lblGreeting.Text = "Good Night";
            }
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            panelMainParent.Controls.Clear();
            CalcPayments frm = new CalcPayments();
            frm.TopLevel = false;
            panelMainParent.Controls.Add(frm);
            panelMainParent.BringToFront();
            frm.Dock = DockStyle.Fill;
            frm.Show();
            lbltitle.Text = "Calculate Payments";
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            panelMainParent.Controls.Clear();
            CalcSalary frm = new CalcSalary();
            frm.TopLevel = false;
            panelMainParent.Controls.Add(frm);
            panelMainParent.BringToFront();
            frm.Dock = DockStyle.Fill;
            frm.Show();
            lbltitle.Text = "Calculate Salary";
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            panelMainParent.Controls.Clear();
            ViewOrders frm = new ViewOrders();
            frm.TopLevel = false;
            panelMainParent.Controls.Add(frm);
            panelMainParent.BringToFront();
            frm.Dock = DockStyle.Fill;
            frm.Show();
            lbltitle.Text = "View Orders";
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            panelMainParent.Controls.Clear();
            HandleOrders frm = new HandleOrders();
            frm.TopLevel = false;
            panelMainParent.Controls.Add(frm);
            panelMainParent.BringToFront();
            frm.Dock = DockStyle.Fill;
            frm.Show();
            lbltitle.Text = "Manage Orders";
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCreateLogin_Click(object sender, EventArgs e)
        {
            CreateLogin frm = new CreateLogin();
            frm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to log out ? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result==DialogResult.Yes)
            {
                UserName = "";
                this.Close();
                Login frm = new Login();
                frm.Show();

            }
        }
    }
}
