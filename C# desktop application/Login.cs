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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
                connection.Open();

                string sql = @"SELECT PASSWORD , PRIVILEGES FROM `logins` WHERE USERNAME='" + txtUsername.Text + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = adapter.SelectCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (txtpassword.Text == reader.GetString(0))
                        {
                            Main frm = new Main(reader.GetString(1), txtUsername.Text);
                            frm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("invalid password");
                        }
                    }
                }
                else if (!reader.HasRows)
                {
                    MessageBox.Show("invalid username");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }

            
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ZFormControls.ForCloseButtonClick(this);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }
    }
}
