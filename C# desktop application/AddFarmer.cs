using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
namespace ProjectZ
{
    public partial class AddFarmer :  Form
    {
        public AddFarmer()
        {
            InitializeComponent();
        }
       
        

        private void AddFarmer_Load(object sender, EventArgs e)
        {
            lblID.Text = ZAutoGenarate.GenarateNextID("dairy farmer","F_ID");
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtMobile.Text) ||
                    string.IsNullOrWhiteSpace(txtTp.Text) ||
                    string.IsNullOrWhiteSpace(txtAddress.Text) ||
                    string.IsNullOrWhiteSpace(txtNIC.Text) ||
                    pictureBoxPhoto.Image == null)
                {
                    errorProviderAll.SetError(btnSave, "Please fill all fields");
                }
                else
                {
                    MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                    con.Open();

                    string sql = "INSERT INTO `dairy farmer` (`F_ID`, `F_Name`, `F_ADDRESS`, `MOBILE_NO`, `TP_NO`, `F_NIC`, `REG_DATE`,`PHOTO`)" +
                        "VALUES ('" + lblID.Text + "','" + txtName.Text + "','" + txtAddress.Text + "', '" + txtMobile.Text + "', '" + txtTp.Text + "','" + txtNIC.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "',@Pic )";
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MemoryStream ms = new MemoryStream();
                    pictureBoxPhoto.Image.Save(ms, pictureBoxPhoto.Image.RawFormat);
                    byte[] imgArraySav = ms.ToArray();
                    cmd.Parameters.Add("@Pic", MySqlDbType.LongBlob).Value = imgArraySav;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("data inserted");
                    lblID.Text = ZAutoGenarate.GenarateNextID("dairy farmer", "F_ID");

                    con.Close();
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBoxPhoto.Image = new Bitmap(open.FileName);
                // image file path  
                string filename = open.FileName;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
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
