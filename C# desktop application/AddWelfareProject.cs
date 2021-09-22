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
    public partial class AddWelfareProject : Form
    {
        public AddWelfareProject()
        {
            InitializeComponent();
        }

        private void AddWelfareProject_Load(object sender, EventArgs e)
        {
            lblID.Text = ZAutoGenarate.GenarateNextID("welfare project", "W_ID");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
            connection.Open();

            string InsertQuery = @"INSERT INTO `welfare project` (`W_ID`, `W_NAME`, `W_DESCRIPTION`, `STARTED_DATE`, `BENEFICIARY_TYPE`, `STATUS`) VALUES ('" + lblID.Text + "', '" + txtName.Text + "', '" + txtDescription.Text + "', '" + dtpStartedDate.Value.ToString("yyyy-MM-dd") + "', '" + txtBeneficiaryType.Text + "', '" + cmbStatus.Text + "')";

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.InsertCommand = new MySqlCommand(InsertQuery, connection);
            if(adapter.InsertCommand.ExecuteNonQuery()>0)
            {
                MessageBox.Show("Inserted");
            }
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
