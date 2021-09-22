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
    public partial class AddMedicalIsuue : Form
    {
        string FID = "";//for insert 
        public AddMedicalIsuue(string FID,string Name,string Address,string Contact,string ID,string AnimalIntro)
        {
            InitializeComponent();
            lblName.Text = Name;
            lblAddress.Text = Address;
            lblContact.Text = Contact;
            lblID.Text = ID;
            lblAnimalIntro.Text = AnimalIntro;
            this.FID = FID;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AddMedicalIsuue_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();
            string sql = @"SELECT V_NAME,V_NIC FROM `veterinarian`";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvVeterinarians.DataSource = dt;
        }
        string VNIC = "";//for insert 
        private void dgvVeterinarians_SelectionChanged(object sender, EventArgs e)
        {
            
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {

                DataGridViewRow row = dgv.SelectedRows[0];
                if (row != null)
                {
                    string VName = row.Cells[0].Value.ToString();
                    VNIC = row.Cells[1].Value.ToString();

                    MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                    con.Open();
                    string sql = @"SELECT * FROM `veterinarian` WHERE V_NAME ='"+ VName + "'";
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = new MySqlCommand(sql, con);
                    MySqlDataReader reader = adapter.SelectCommand.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            lblDName.Text = VName;
                            lblDAddress.Text = reader.GetString(4);
                            lblDContact.Text = reader.GetString(2) + " / " + reader.GetString(3);
                            lblDEmail.Text = reader.GetString(5);

                        }
                    }
                    con.Close();
                    adapter.SelectCommand.Dispose();
                    adapter.Dispose();
                    reader.Close();

                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();
            string sql = @"INSERT INTO `medical issue` (`M_ID`, `F_ID`, `A_ID`, `M_DATE`, `M_DESCRIPTION`, `V_ID`,`status`) 
                         VALUES ('"+ZAutoGenarate.GenarateNextID("medical issue", "M_ID") +"', '"+FID+"', '"+lblID.Text+"', '"+DateTime.Now.ToString("yyyy-MM-dd")+"', '"+txtDiscription.Text+"', '"+VNIC+"' ,'')";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.InsertCommand = new MySqlCommand(sql, con);
            if(adapter.InsertCommand.ExecuteNonQuery()>0)
            {
                MessageBox.Show("Submitted!");
            }
            adapter.InsertCommand.Dispose();
            adapter.Dispose();
            con.Close();
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
