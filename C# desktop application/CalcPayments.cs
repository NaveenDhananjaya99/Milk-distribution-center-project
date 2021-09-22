using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using ProjectZ.Data_Sets;
using ProjectZ.MyClasses;

namespace ProjectZ
{
    public partial class CalcPayments : Form
    {
        public CalcPayments()
        {
            InitializeComponent();
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice device;
        private void CalcPayments_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                comboBox1.Items.Add(filterInfo.Name);
            comboBox1.SelectedIndex = 0;
            lblReciptNo.Text = ZAutoGenarate.GenarateNextID("payment receipt", "DPR_ID");
            //reportViewer1.Visible = false; set in properties
            //GenarateReceipt(); // this line is commented out bcz we dont have report to print in load event
            

            this.reportViewer1.RefreshReport();
            ScannerOn();
        }

       
        private void ScannerOn()
        {
            pictureBox1.Visible = true;
            pictureBox1.Image = null;
            device = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            device.NewFrame += Device_NewFrame;
            device.Start();
            timer1.Start();
            this.reportViewer1.RefreshReport();
        }

        private void ScannerOff()
        {
            timer1.Stop();
            if (device.IsRunning)
            {
                device.Stop();
                pictureBox1.Visible = false;
                txtLactomiterReading.Focus();
            }
        }


        

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void CalcPayments_FormClosing(object sender, FormClosingEventArgs e)
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
                    lblFarmersID.Text = result.ToString();
                    //timer1.Stop(); *****this code part copied to txtID_TextChanged event
                    //if (device.IsRunning) 
                    //    device.Stop();
                }
                //lblFarmersID.Text = "F-10000002";//sample***********

            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            //GenarateReceipt();
            PrintToPrinter(this.reportViewer1.LocalReport);
            //printPreviewDialog.Document = printDocument;
            //printPreviewDialog.ShowDialog();

            InsertNewPaymentReceipt();

        }

        //***************************************************************************************************
        public void GenarateReceipt()
        {
            if(reportViewer1.Visible == false)
            reportViewer1.Visible = true;


            GenerateQR();//next method

            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("ReceiptNo", lblReciptNo.Text));
            rpc.Add(new ReportParameter("Date", DateTime.Now.ToString("yyyy-MM-dd  dddd")));
            rpc.Add(new ReportParameter("Time", DateTime.Now.ToString("HH.mm.ss")));
            rpc.Add(new ReportParameter("FID",  lblFarmersID.Text));
            rpc.Add(new ReportParameter("FName", lblFarmersName.Text));
            rpc.Add(new ReportParameter("LacReading", txtLactomiterReading.Text));
            rpc.Add(new ReportParameter("Grade", lblGrade.Text));
            rpc.Add(new ReportParameter("Volume", txtVolume.Text + "l"));
            rpc.Add(new ReportParameter("Price", "Rs: " + lblPricePer.Text));
            rpc.Add(new ReportParameter("Payment", "Rs: " + lblPayment.Text));
            rpc.Add(new ReportParameter("Deduction", "Rs: " + 00.00));
            rpc.Add(new ReportParameter("NetPayment", "Rs: " + lblNetPayment.Text));

            this.reportViewer1.LocalReport.SetParameters(rpc);
            this.reportViewer1.RefreshReport();
            

        }

        public void GenerateQR()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ZQR.GetQRAsBitmap(lblReciptNo.Text).Save(ms, ImageFormat.Bmp);
                ReceiptQR receiptQR = new ReceiptQR();
                ReceiptQR.QRCodeRow qRCodeRow = receiptQR.QRCode.NewQRCodeRow();
                qRCodeRow.Image = ms.ToArray();
                receiptQR.QRCode.AddQRCodeRow(qRCodeRow);

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "ReceiptQR";
                reportDataSource.Value = receiptQR.QRCode;
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            }
        }

        public static void PrintToPrinter(LocalReport report)
        {
            Export(report);

        }
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;

        public static void Export(LocalReport report, bool print = true)
        {
            string deviceInfo =
             @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.27in</PageWidth>
                <PageHeight>11.69in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;

            if (print)
            {
                Print();
            }
        }


        public static void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        public static Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        public static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        public static void DisposePrint()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }
       
        private void InsertNewPaymentReceipt()
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string InsertQuery = @"INSERT INTO `payment receipt` (`DPR_ID`, `F_ID`, `DPR_DATE`, `LACTOMETER_READING`, `GRADE`, `VOLUME_OF_MILK`, `PRICE_PER_LITER`, `PAYMENT`, `NET_PAYMENT`) " +
                                 " VALUES('" + lblReciptNo.Text + "', '" + lblFarmersID.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + Convert.ToDecimal(txtLactomiterReading.Text) + "', '" + lblGrade.Text + "', '" + Convert.ToDecimal(txtVolume.Text) + "','" + Convert.ToDecimal(lblPricePer.Text) + "', '" + Convert.ToDecimal(lblPayment.Text) + "', '" + Convert.ToDecimal(lblNetPayment.Text) + "')";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.InsertCommand = new MySqlCommand(InsertQuery, con);
            if (adapter.InsertCommand.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("inserted");
                lblReciptNo.Text = ZAutoGenarate.GenarateNextID("payment receipt", "DPR_ID");
            }
            //reset
            lblPrint.Visible = false;
            GetReadyForNewPayment();
        }
        //***************************************************************************************************



        private void lblFarmersID_TextChanged(object sender, EventArgs e)
        {
            
            MySqlConnection connection = new MySqlConnection(ConnectDB.ConnectionString);
            connection.Open();

            string sql = @"SELECT F_NAME FROM `dairy farmer` WHERE F_ID ='" + lblFarmersID.Text + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(sql, connection);
            MySqlDataReader reader = adapter.SelectCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lblFarmersName.Text = reader.GetString(0);
                    GenarateReceipt();
                }
            }
            ScannerOff();
        }

        private void txtFarmersID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                txtLactomiterReading.Focus();
                GenarateReceipt();
            }
        }

        private void txtLactomiterReading_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                con.Open();

                string sql= @"SELECT CATEGORY FROM `prices` where (RBTOP < '"+Convert.ToDecimal(txtLactomiterReading.Text) +"' OR RBTOP = '"+ Convert.ToDecimal(txtLactomiterReading.Text) + "') and (RBBOTTOM >'"+ Convert.ToDecimal(txtLactomiterReading.Text) + "')";
                MySqlCommand command = new MySqlCommand(sql, con);
                MySqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        lblGrade.Text = reader.GetString(0);
                    }
                }
                GenarateReceipt();

                txtVolume.Focus();
            }
        }

        private void txtVolume_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter  && lblPrint.Visible==false)
            {
                decimal UnitPrice=0;
                decimal Payment = 0;
                decimal Deduction = 0;
                decimal NetPayment = 0;


                MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                con.Open();

                string sql = @"SELECT PRICE FROM `prices` where `CATEGORY`='" + lblGrade.Text + "' ";
                MySqlCommand command = new MySqlCommand(sql, con);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UnitPrice = reader.GetDecimal(0);
                        lblPricePer.Text = UnitPrice.ToString();
                    }


                    Payment = Convert.ToDecimal(txtVolume.Text) * UnitPrice;
                    lblPayment.Text = Payment.ToString();

                    NetPayment = Payment-Deduction;
                    lblNetPayment.Text =NetPayment.ToString();

                }
                lblPrint.Visible = true;
                txtVolume.Focus();
                GenarateReceipt();
            }
            else if(e.KeyCode == Keys.Enter && lblPrint.Visible == true)
            {
                //GenarateReceipt();
                PrintToPrinter(this.reportViewer1.LocalReport);
                //printPreviewDialog.Document = printDocument;
                //printPreviewDialog.ShowDialog();

                InsertNewPaymentReceipt();
                reportViewer1.Visible = false;
            }
        }

        private decimal GetDeduction()
        {
            decimal deduction = (Convert.ToDecimal(lblPayment.Text) / 100) * 2;
            MessageBox.Show(deduction.ToString());
            return deduction;
        }







        private void txtLactomiterReading_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNetPayment_TextChanged(object sender, EventArgs e)
        {
            if(lblNetPayment.Text!="")
            lblPrint.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblPrint.Visible = false;
            ClearAll();
            ScannerOn();

        }

        private void GetReadyForNewPayment()
        {
            lblReciptNo.Text = ZAutoGenarate.GenarateNextID("payment receipt", "DPR_ID");
            lblPrint.Visible = false;
            ClearAll();
            ScannerOn();
        }

        private void ClearAll()
        {
            txtVolume.Text = "";
            txtLactomiterReading.Text = "";
            lblGrade.Text = "";
            lblPricePer.Text = "";
            lblPayment.Text = "";
            lblNetPayment.Text = "";
            lblFarmersID.Text = "";
            lblFarmersName.Text = "";
        }
    }
}
