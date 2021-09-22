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
    public partial class SetPrices : Form
    {
        public SetPrices()
        {
            InitializeComponent();
        }

        private void SetPrices_Load(object sender, EventArgs e)
        {
            FillDT();
        }

        void FillDT()
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string SelectQuery = "SELECT * FROM `prices`"; 
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            adapter.SelectCommand = new MySqlCommand(SelectQuery, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvPrices.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string Update = "UPDATE `prices` SET `RBTOP`='" + Convert.ToDecimal(txt01.Text) + "',`RBBOTTOM`='" + Convert.ToDecimal(txt02.Text) + "',`PRICE`='" + Convert.ToDecimal(txtPrice.Text) + "' WHERE `CATEGORY`='" + txtCategory.Text + "'";
            MySqlCommand command = new MySqlCommand(Update, con);
            command.ExecuteNonQuery();
        }

        private void dgvPrices_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                if (row != null)
                {
                    txtCategory.Text = row.Cells[0].Value.ToString();
                    txt01.Text = row.Cells[1].Value.ToString();
                    txt02.Text = row.Cells[2].Value.ToString();
                    txtPrice.Text = row.Cells[3].Value.ToString();

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void headers_MouseDown(object sender, MouseEventArgs e)
        {
            ZFormControls.ForMouseDown(this);
        }

        private void headers_MouseMove(object sender, MouseEventArgs e)
        {
            ZFormControls.ForMouseMove(this);

        }

        private void headers_MouseUp(object sender, MouseEventArgs e)
        {
            ZFormControls.ForMouseUp();

        }
    }
}
