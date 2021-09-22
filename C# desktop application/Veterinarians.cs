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
    public partial class Veterinarians : Form
    {
        public Veterinarians()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Normal;
        }
        
        private void Veterinarians_Load(object sender, EventArgs e)
        {
            ZAutocomplete.GetVeteriIdAndName(txtSearch);

            CreateAndFilterDataPanels();
       
        }


      

        public void CreateAndFilterDataPanels()
        {
            flowLayoutPanel1.Controls.Clear();

            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();
            string sql = @"SELECT * FROM `veterinarian` WHERE V_NIC  LIKE '" + txtSearch.Text + "%' OR V_NAME  LIKE '" + txtSearch.Text + "%'";
            MySqlCommand comobj = new MySqlCommand(sql, con);
            MySqlDataReader reader = comobj.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    FlowLayoutPanel p = AddPanel(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    //FlowLayoutPanel p = new FlowLayoutPanel();
                    flowLayoutPanel1.Controls.Add(p);
                }
            }
        }

        public FlowLayoutPanel AddPanel(string NIC,String Name,string Mobile,String TP,string Address,String Email)
        {
            Label VNIC = new Label();
            VNIC.Name = "VNIC".ToString();
            VNIC.ForeColor = Color.Black;
            VNIC.Font = new Font("Microsoft sans serif", 12, FontStyle.Bold);
            VNIC.Text = NIC;
            VNIC.AutoSize = true;
            VNIC.Margin = new Padding(20, 5, 5, 5);

            Label VName = new Label();
            VName.Name = "VName".ToString();
            VName.ForeColor = Color.FloralWhite;
            VName.Font = new Font("Calibri", 24, FontStyle.Bold);
            VName.Text ="Dr. "+ Name;
            VName.AutoSize = true;
            VName.Margin = new Padding(20,10,10,10);

            Label VMobile = new Label();
            VMobile.Name = "VMobile".ToString();
            VMobile.ForeColor = Color.Black;
            VMobile.Font = new Font("Microsoft sans serif", 12, FontStyle.Bold);
            VMobile.Text = Mobile;
            VMobile.AutoSize = true;
            VMobile.Margin = new Padding(20, 5, 5, 5);

            Label VTP = new Label();
            VTP.Name = "VTP".ToString();
            VTP.ForeColor = Color.Black;
            VTP.Font = new Font("Microsoft sans serif", 12, FontStyle.Bold);
            VTP.Text =  TP;
            VTP.AutoSize = true;
            VTP.Margin = new Padding(20, 5, 5, 5);


            Label VAddress = new Label();
            VAddress.Name = "VAddress".ToString();
            VAddress.ForeColor = Color.Black;
            VAddress.Font = new Font("Microsoft sans serif",12, FontStyle.Bold);
            VAddress.Text = Address;
            VAddress.AutoSize = true;
            VAddress.Margin = new Padding(20,5,5,5);

            Label VEmail = new Label();
            VEmail.Name = "VEmail".ToString();
            VEmail.ForeColor = Color.Black;
            VEmail.Font = new Font("Microsoft sans serif", 12, FontStyle.Bold);
            VEmail.Text = Email;
            VEmail.AutoSize = true;
            VEmail.Margin = new Padding(20, 5, 5, 5);

            Button btnEdit = new Button();
            btnEdit.Name = NIC;
            btnEdit.ForeColor = Color.Black;
            btnEdit.BackColor = Color.White;
            btnEdit.Font = new Font("Microsoft sans serif", 12, FontStyle.Bold);
            btnEdit.Text = "Edit";
            //btnEdit.Width = 150;
            //btnEdit.Height =20;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Dock = DockStyle.Right;
            btnEdit.AutoSize = true;
            btnEdit.Click += new System.EventHandler(this.btnEdit_Click);



            FlowLayoutPanel PZ = new FlowLayoutPanel();
            PZ.Name = NIC;
            PZ.BackColor = Color.Navy;
            PZ.BorderStyle = BorderStyle.Fixed3D;
            PZ.Width = 350;
            PZ.Height = 500;
            PZ.Margin = new Padding(10);
            PZ.FlowDirection = FlowDirection.TopDown;

            for(int i=0;i<7;i++)
            {
                FlowLayoutPanel pnl = new FlowLayoutPanel();

                if (i==0)
                {
                    pnl.BackColor = Color.Navy;
                    pnl.Width = 325;
                    pnl.Height = 90;
                    pnl.Controls.Add(VName);
                }
                else if (i == 1)
                {
                    pnl.BackColor = Color.FromArgb(0, 67, 187);
                    pnl.Width = 325;
                    pnl.Height = 40;
                    pnl.Controls.Add(VNIC);
                }
                else if (i == 2)
                {
                    pnl.BackColor = Color.FromArgb(11, 52, 219);
                    pnl.Width = 325;
                    pnl.Height = 40;
                    pnl.Controls.Add(VMobile);
                }
                else if (i == 3)
                {
                    pnl.BackColor = Color.FromArgb(0, 99, 246);
                    pnl.Width = 325;
                    pnl.Height = 40;
                    pnl.Controls.Add(VTP);
                }
                else if (i == 4)
                {
                    pnl.BackColor = Color.FromArgb(0, 147, 255);
                    pnl.Width = 325;
                    pnl.Height = 90;
                    pnl.Controls.Add(VAddress);
                }
                else if (i == 5)
                {
                    
                    pnl.BackColor = Color.FromArgb(0, 212, 255);
                    pnl.Width = 325;
                    pnl.Height = 90;
                    pnl.Controls.Add(VEmail);

                }
                else if (i == 6)
                {

                    pnl.BackColor = Color.Navy;
                    pnl.Width = 325;
                    pnl.Height =60;
                    pnl.Dock = DockStyle.Bottom;
                    pnl.Controls.Add(btnEdit);

                }
                PZ.Controls.Add(pnl);
            }

            return PZ;
        }

        private void btnEdit_Click(object sender,EventArgs e)
        {
            Button CurrentButton = (Button)sender;
            EditVeterinarian frm = new EditVeterinarian(CurrentButton.Name);
            frm.ShowDialog();

            CreateAndFilterDataPanels();
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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

      

        private void txtSearchID_TextChanged(object sender, EventArgs e)
        {
            CreateAndFilterDataPanels();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddVeterinarion frm = new AddVeterinarion();
            frm.ShowDialog();
            ZAutocomplete.GetVeteriIdAndName(txtSearch);
            CreateAndFilterDataPanels();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
                connection.Open();
                string sql = @"SELECT * FROM `veterinarian`";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                if(dataTable!=null)
                {
                    ZExport.AsExcel(dataTable);
                }
                
                

                connection.Close();
                adapter.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}
