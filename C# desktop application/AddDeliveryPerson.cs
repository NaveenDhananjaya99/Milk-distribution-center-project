using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectZ
{
    public partial class AddDeliveryPerson : Form
    {
        public AddDeliveryPerson()
        {
            InitializeComponent();
        }

        private void Field_Changed(object sender, EventArgs e)
        {
            if ( !string.IsNullOrWhiteSpace(txtName.Text) ||
                   !string.IsNullOrWhiteSpace(txtMobile.Text) ||
                   !string.IsNullOrWhiteSpace(txtTp.Text) ||
                   !string.IsNullOrWhiteSpace(txtAddress.Text) ||
                   !string.IsNullOrWhiteSpace(txtNIC.Text) ||
                   !string.IsNullOrWhiteSpace(txtVehicleNo.Text) ||
                   !string.IsNullOrWhiteSpace(txtArea.Text) ||
                   !string.IsNullOrWhiteSpace(txtBasicSalary.Text) ||
                   pictureBoxPhoto.Image != null)
            {
                errorProviderAll.Clear();
            }
        }

        private void AddDeliveryPerson_Load(object sender, EventArgs e)
        {
            lblID.Text = ZAutoGenarate.GenarateNextID("delivery person", "DP_ID");

        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            try
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

                    //FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                    //BinaryReader br = new BinaryReader(fs);
                    //ImageData = br.ReadBytes((int)fs.Length);
                    //br.Close();
                    //fs.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

       
       

        private void btnADD_Click(object sender, EventArgs e)
        {
          

            try
            {
                if(string.IsNullOrWhiteSpace(txtName.Text) || 
                    string.IsNullOrWhiteSpace(txtMobile.Text) ||
                    string.IsNullOrWhiteSpace(txtTp.Text) ||
                    string.IsNullOrWhiteSpace(txtAddress.Text) ||
                    string.IsNullOrWhiteSpace(txtNIC.Text) ||
                    string.IsNullOrWhiteSpace(txtVehicleNo.Text) ||
                    string.IsNullOrWhiteSpace(txtArea.Text) ||
                    string.IsNullOrWhiteSpace(txtBasicSalary.Text) ||
                    pictureBoxPhoto.Image==null )
                {
                    errorProviderAll.SetError(btnADD, "Please fill all fields");
                }
                else
                {
                    MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                    con.Open();

                    string sql = "INSERT INTO `delivery person` (`DP_ID`, `DP_NAME`, `MOBILE_NO`, `TP_NO`, `ADDRESS`, `NIC`, `VEHICLE_NO`, `AREA`, `BASIC_SALARY`, `REG_DATE`,`PHOTO`)" +
                                  " VALUES ('" + lblID.Text + "', '" + txtName.Text + "', '" + txtMobile.Text + "', '" + txtTp.Text + "', '" + txtAddress.Text + "', '" + txtNIC.Text + "', '" + txtVehicleNo.Text + "', '" + txtArea.Text + "', '" + Convert.ToDecimal(txtBasicSalary.Text) + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "',@Pic)";
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MemoryStream ms = new MemoryStream();
                    pictureBoxPhoto.Image.Save(ms, pictureBoxPhoto.Image.RawFormat);
                    byte[] imgArraySav = ms.ToArray();
                    cmd.Parameters.Add("@Pic", MySqlDbType.LongBlob).Value = imgArraySav;
                    cmd.ExecuteNonQuery();
                    con.Close();


                    lblID.Text = ZAutoGenarate.GenarateNextID("delivery person", "DP_ID");
                }
                
                

            }
            catch (Exception ex)
            {
                throw ex;
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
