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
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat;
using System.IO;
using ProjectZ.MyClasses;

namespace ProjectZ
{
    public partial class HandleOrders : Form
    {
        public HandleOrders()
        {
            InitializeComponent();
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice device;
        private void ScannerOn()
        {
            pictureBox1.Image = null;
            device = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            device.NewFrame += Device_NewFrame;
            device.Start();
            timer1.Start();
        }

        private void ScannerOff()
        {
            timer1.Stop();
            if (device.IsRunning)
            {
                device.Stop();
            }
        }
       

        private void HandleOrders_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                comboBox1.Items.Add(filterInfo.Name);
            comboBox1.SelectedIndex = 0;

            //on 
            ScannerOn();
        }

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void HandleOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
            filterInfoCollection.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox1.Image);
                if (result != null)
                {
                    txtID.Text = result.ToString();
                    //timer1.Stop(); *****this code part copied to txtID_TextChanged event
                    //if (device.IsRunning) 
                    //    device.Stop();
                    ScannerOff();
                }
                //txtID.Text = "2182";//sample***********
                
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                //off
                ScannerOff();
                MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                con.Open();

                string SQL = @"SELECT * FROM `orders` LEFT JOIN `delivery person` ON `orders`.`DP_ID`=`delivery person`.`DP_ID` WHERE `orders`.`O_ID`LIKE '" + txtID.Text + "%'";
                MySqlCommand command = new MySqlCommand(SQL, con);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lblPlacedDate.Text = reader.GetDateTime(1).ToString("yyyy-MM-dd");
                        lblVolume.Text = reader.GetDecimal(2).ToString();
                        lblPrice.Text = reader.GetDecimal(3).ToString();
                        lblDeleveryDate.Text = reader.GetDateTime(4).ToString("yyyy-MM-dd");
                        lblCName.Text = reader.GetString(5);
                        lblContactNo.Text = reader.GetString(6);
                        lblAddress.Text = reader.GetString(7);
                        lblDPID.Text = reader.GetString(8);
                        lblStatus.Text = reader.GetString(9);


                        if (lblDPID.Text == "Not Set")
                        {
                            lblDPName.Text = "Not Set";
                            lblDPContact.Text = "Not Set";
                            lblDPVNo.Text = "Not Set";
                        }
                        else
                        {

                            lblDPID.Text = reader.GetString(8);
                            lblDPName.Text = reader.GetString(11);
                            lblDPContact.Text = reader.GetString(12) + "\n\n" + reader.GetString(13);
                            lblDPVNo.Text = reader.GetString(17);

                        }

                    }


                }
                con.Close();
                con.Dispose();
                command.Dispose();
                reader.Dispose();
            }
            else
            {
                lblStatus.Text = "fhfdjgmgd";
            }

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            //restart scanner after confirm the delevery of order
            ScannerOn();
            txtID.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
    
}

