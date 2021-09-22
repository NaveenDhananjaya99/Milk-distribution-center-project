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
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using ProjectZ.Data_Sets;
using ProjectZ.MyClasses;

namespace ProjectZ
{
    public partial class ViewOrders : Form
    {
        public ViewOrders()
        {
            InitializeComponent();


            PanelUnderline1.Visible = false;
            PanelUnderline2.Visible = false;
            PanelUnderline3.Visible = false;
            PanelUnderline4.Visible = false;
            
        }

        string Filter = "";
        DataTable dataTable = new DataTable();
        public void CreateDataPanel()
        {

            PanelDynamic.Controls.Clear();
            dataTable.Clear();
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string sql = @"SELECT * FROM `orders` LEFT JOIN `delivery person` ON `orders`.`DP_ID`=`delivery person`.`DP_ID` WHERE O_ID  LIKE '" + txtSearch.Text + "%' AND (O_STATUS  = '" + Filter + "' OR `DELEVERY_DATE` LIKE '" + Filter + "%')";
            MySqlDataAdapter da = new MySqlDataAdapter(sql,con);
            
            da.Fill(dataTable);
            if(dataTable.Rows.Count>0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {

                    FlowLayoutPanel P = AddPanel(
                        dataTable.Rows[i][0].ToString(),
                        dataTable.Rows[i][1].ToString(),
                        dataTable.Rows[i][2].ToString(),
                        dataTable.Rows[i][3].ToString(),
                        dataTable.Rows[i][4].ToString(),
                        dataTable.Rows[i][5].ToString(),
                        dataTable.Rows[i][6].ToString(),
                        dataTable.Rows[i][7].ToString(),
                        dataTable.Rows[i][9].ToString()
                        );
                    PanelDynamic.Controls.Add(P);

                }
            }

            

           
            
            con.Close();
        }

        public FlowLayoutPanel AddPanel(string ID, String Date, string Volume, String Price, string DelDate, String CName, string Contact, String Address, string Status)
        {
            Label lblOIDSTATUS = new Label();
            lblOIDSTATUS.Name = ID;
            if (Status == "Delevered")
            {
                lblOIDSTATUS.ForeColor = Color.Black;
            }
            else
            {
                lblOIDSTATUS.ForeColor = Color.Red;
            }
            lblOIDSTATUS.Font = new Font("Microsoft sans serif", 10, FontStyle.Bold);
            lblOIDSTATUS.Text = "ID " + ID + "                             " + Status;
            lblOIDSTATUS.AutoSize = true;
            lblOIDSTATUS.Margin = new Padding(5, 5, 5, 5);
            lblOIDSTATUS.Click += new System.EventHandler(this.Order_Click);

            Label lblVOLUME = new Label();
            lblVOLUME.Name = ID;
            lblVOLUME.ForeColor = Color.White;
            lblVOLUME.Font = new Font("Microsoft sans serif", 12, FontStyle.Bold);
            lblVOLUME.Text = "Order " + Volume + "L By ";
            lblVOLUME.AutoSize = true;
            lblVOLUME.Click += new System.EventHandler(this.Order_Click);

            Label lblCNAME = new Label();
            lblCNAME.Name = ID;
            lblCNAME.ForeColor = Color.FloralWhite;
            lblCNAME.Font = new Font("Calibri", 14, FontStyle.Regular);
            lblCNAME.Text = CName;
            lblCNAME.AutoSize = true;
            lblCNAME.Click += new System.EventHandler(this.Order_Click);

            Label lblADDRESS = new Label();
            lblADDRESS.Name = ID;
            lblADDRESS.ForeColor = Color.White;
            lblADDRESS.Font = new Font("Microsoft sans serif", 8, FontStyle.Regular);
            lblADDRESS.Text = Address;
            lblADDRESS.AutoSize = true;
            lblADDRESS.Click += new System.EventHandler(this.Order_Click);

            Label lblDELDATE = new Label();
            lblDELDATE.Name = ID;
            lblDELDATE.ForeColor = Color.White;
            lblDELDATE.Font = new Font("Microsoft sans serif", 8, FontStyle.Regular);
            lblDELDATE.Text = "on " + DelDate;
            lblDELDATE.AutoSize = true;
            lblDELDATE.Click += new System.EventHandler(this.Order_Click);

            Label lblPRICE = new Label();
            lblPRICE.Name = ID;
            lblPRICE.ForeColor = Color.Black;
            lblPRICE.Font = new Font("Arial", 14, FontStyle.Bold);
            lblPRICE.Text = "                                                Rs: " + Price;
            lblPRICE.AutoSize = true;
            lblPRICE.Click += new System.EventHandler(this.Order_Click);

            FlowLayoutPanel PZ = new FlowLayoutPanel();
            PZ.Name = ID;
            PZ.BackColor = Color.FromArgb(0, 51, 118);
            PZ.BorderStyle = BorderStyle.None;
            PZ.Width = 400;
            PZ.Height = 200;
            PZ.Margin = new Padding(10);
            PZ.FlowDirection = FlowDirection.TopDown;
            PZ.Click += new System.EventHandler(this.Order_Click);

            for (int i = 0; i < 10; i++)
            {
                FlowLayoutPanel pnl = new FlowLayoutPanel();
                pnl.Name = ID;
                pnl.BackColor = Color.FromArgb(0, 51, 118);
                pnl.Width = 390;
                pnl.Height = 25;
                pnl.Click += new System.EventHandler(this.Order_Click);

                if (i == 0)
                {
                    pnl.Width = 390;
                    pnl.Height = 30;
                    pnl.Controls.Add(lblOIDSTATUS);
                }
                else if (i == 1)
                {

                    pnl.Controls.Add(lblVOLUME);
                }
                else if (i == 2)
                {

                    pnl.Controls.Add(lblCNAME);
                }
                else if (i == 3)
                {

                    pnl.Controls.Add(lblADDRESS);
                }
                else if (i == 4)
                {
                    pnl.Width = 390;
                    pnl.Height = 20;
                    pnl.Controls.Add(lblDELDATE);
                }
                else if (i == 5)
                {

                    pnl.Controls.Add(lblPRICE);
                }
                PZ.Controls.Add(pnl);
            }
            return PZ;
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            PanelUnderline1.Visible = true;
            PanelUnderline2.Visible = false;
            PanelUnderline3.Visible = false;
            PanelUnderline4.Visible = false;
            txtSearch.Visible = true;
            btnGenarateAll.Visible = false;
            panelMask.Visible = true;
            Filter = "";
            CreateDataPanel();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            PanelUnderline1.Visible = false;
            PanelUnderline2.Visible = true;
            PanelUnderline3.Visible = false;
            PanelUnderline4.Visible = false;
            txtSearch.Visible = true;
            btnGenarateAll.Visible = false;
            panelMask.Visible = true;

            Filter = "Pending";
            CreateDataPanel();
        }

        private void btnDelevered_Click(object sender, EventArgs e)
        {
            PanelUnderline1.Visible = false;
            PanelUnderline2.Visible = false;
            PanelUnderline3.Visible = true;
            PanelUnderline4.Visible = false;
            txtSearch.Visible = true;
            btnGenarateAll.Visible = false;
            panelMask.Visible = true;

            Filter = "Delevered";
            CreateDataPanel();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            PanelUnderline1.Visible = false;
            PanelUnderline2.Visible = false;
            PanelUnderline3.Visible = false;
            PanelUnderline4.Visible = true;
            txtSearch.Visible = true;
            btnGenarateAll.Visible = true;
            panelMask.Visible = true;

            Filter = DateTime.Now.ToString("yyyy-MM-dd");
            CreateDataPanel();
        }

        private void ViewOrders_Load(object sender, EventArgs e)
        {
            CreateDataPanel();
            ZAutocomplete.GetSalesRepIdAndName(txtSearchDeleveryPerson);
            btnBrowse.PerformClick();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CreateDataPanel();
        }

        public void GetMoreData(string OrderID)
        {
           
            //if(btnSetSave.Text=="Save")
            //{
            //    btnSetSave.PerformClick();
            //}
            //btnSetSave.Text = "Set";
            //lblSRID.Text = "";
            //lblSRName.Text = "";
            //lblSRContact.Text = "";
            //lblSRVNo.Text = "";
           

            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string SQL = @"SELECT * FROM `orders` LEFT JOIN `delivery person` ON `orders`.`DP_ID`=`delivery person`.`DP_ID` WHERE `orders`.`O_ID`='" + OrderID + "'";
            MySqlCommand command = new MySqlCommand(SQL, con);
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
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
                    if(lblStatus.Text=="Delevered" || lblStatus.Text == "On the Way")
                    {
                        btnSetSave.Visible = false;
                    }
                    else
                    {
                        btnSetSave.Visible = true;
                    }

                    if(lblDPID.Text=="Not Set")
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

                if(lblStatus.Text=="Processing" && lblDeleveryDate.Text==DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    btnGenarateForThis.Text = "Genarate Delevery Documents for order " + lblID.Text;
                    btnGenarateForThis.Visible = true;
                }
                else
                {
                    btnGenarateForThis.Visible = false;
                }
            }
            con.Close();
            con.Dispose();
            command.Dispose();
            reader.Dispose();
            
        }

        private void Order_Click(object sender,EventArgs e)
        {
            if(btnSetSave.Text=="Set")
            {
                panelMask.Visible = false;
                if (sender.GetType().ToString() == "System.Windows.Forms.FlowLayoutPanel")
                {
                    FlowLayoutPanel CurrentPanel = (FlowLayoutPanel)sender;
                    lblID.Text = CurrentPanel.Name;

                }
                else if (sender.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    Label CurrentLable = (Label)sender;
                    lblID.Text = CurrentLable.Name;
                }
            }
        }
        private void lblID_TextChanged(object sender, EventArgs e)
        {
            GetMoreData(lblID.Text);
        }

        private void btnSetSave_Click(object sender, EventArgs e)
        {
            if(btnSetSave.Text=="Set")
            {
                panelDeleveryPerson.BorderStyle = BorderStyle.FixedSingle;
                txtSearchDeleveryPerson.Visible = true;
                btnSetSave.Text = "Save";
            }
            else if(btnSetSave.Text=="Save")
            {
                if (!string.IsNullOrEmpty(lblDPID.Text))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to set " + lblDPName.Text + " as delevery person?", "Message", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                        con.Open();

                        string UpdateQuery = @"UPDATE `orders` SET `DP_ID` = '" + lblDPID.Text + "', `O_STATUS` = 'Processing' WHERE `orders`.`O_ID` = '" + lblID.Text + "'";
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.UpdateCommand = new MySqlCommand(UpdateQuery, con);
                        if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Updateted");
                            btnSetSave.Text = "Set";
                            GetMoreData(lblID.Text);
                            CreateDataPanel();
                        }

                        panelDeleveryPerson.BorderStyle = BorderStyle.None;
                        txtSearchDeleveryPerson.Visible = false;
                        
                    }
                    else
                    {
                        GetMoreData(lblID.Text);
                        btnSetSave.Text = "Set";
                    }

                }
                else
                {
                    btnSetSave.Text = "Save";
                    MessageBox.Show("Pleace Select Delevery Person before click the save button");
                }

            }
        }

        private void txtSearchDeleveryPerson_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode==Keys.Enter)
            {
                MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
                con.Open();

                string SelectQuery = @"SELECT `DP_ID` , `DP_NAME`,`MOBILE_NO`,`TP_NO`,`VEHICLE_NO` FROM `delivery Person` WHERE `DP_ID`  ='" + txtSearchDeleveryPerson.Text + "' OR `DP_NAME`  = '" + txtSearchDeleveryPerson.Text + "'";
                MySqlCommand command = new MySqlCommand(SelectQuery, con);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lblDPID.Text = reader.GetString(0);
                        lblDPName.Text = reader.GetString(1);
                        lblDPContact.Text = reader.GetString(2) + "\n\n" + reader.GetString(3);
                        lblDPVNo.Text = reader.GetString(4);
                    }
                }
                con.Close();
                con.Dispose();
                command.Dispose();
                reader.Dispose();
            }
        }

        private void txtSearchDeleveryPerson_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchDeleveryPerson.Text == "")
            {
                lblDPID.Text = "";
                lblDPName.Text = "";
                lblDPContact.Text = "";
                lblDPVNo.Text = "";
            }
        }

        /// <summary>
        /// Genarate & print Documents for orders ********************************************
        /// </summary>
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;

        private List<string> SetOrderData(string ID,string DeliveryDate,string CustomerName,string CustomerAddress,string ContactNo,string MilkVolume,string Price,string DeliveryPersonName,string DeleveryPersonMobile)
        {
            List<string> OrderData = new List<string>();

            OrderData.Add(ID);
            OrderData.Add(DeliveryDate);
            OrderData.Add(CustomerName);
            OrderData.Add(CustomerAddress);
            OrderData.Add(ContactNo);
            OrderData.Add(MilkVolume);
            OrderData.Add(Price);
            OrderData.Add(DeliveryPersonName);
            OrderData.Add(DeleveryPersonMobile);

            return OrderData;
        }
        private void btnGenarateForThis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Genarated for " + lblID.Text);
            GenarateDocument(
                SetOrderData(
                    lblID.Text, 
                    lblDeleveryDate.Text,
                    lblCName.Text,
                    lblAddress.Text,
                    lblContactNo.Text,
                    lblVolume.Text,
                    lblPrice.Text,
                    lblDPName.Text,
                    lblDPContact.Text
                    )
                    );
        }
        private void btnGenarateAll_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string sql = @"SELECT `orders`.`O_ID` , `orders`.`DELEVERY_DATE` , `orders`.`CUSTOMER_NAME` , `orders`.`ADDRESS` , `orders`.`CONTACT_NO` , `orders`.`O_VOLUME` , `orders`.`PRICE` ,  `delivery person`.`DP_NAME` , `delivery person`.`MOBILE_NO` FROM `orders` INNER JOIN `sales rep` ON `orders`.`DP_ID`=`delivery person`.`DP_ID`
                         WHERE `orders`.`DELEVERY_DATE`  = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            MySqlCommand comobj = new MySqlCommand(sql, con);
            MySqlDataReader reader = comobj.ExecuteReader();
            if (reader.HasRows)
            {
                
                while (reader.Read())
                {
                    GenarateDocument(
                        SetOrderData(
                        reader.GetString(0), 
                        reader.GetDateTime(1).ToString("yyyy-MM-dd"),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetDecimal(5).ToString(),
                        reader.GetDecimal(6).ToString(),
                        reader.GetString(7),
                        reader.GetString(8)
                        )
                        );
                }
            }
            comobj.Dispose();
            reader.Dispose();
            con.Close();
        }

        private void GenarateDocument(List<string> OrderData)
        {
            
            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("OrderID", OrderData[0]));
            rpc.Add(new ReportParameter("Date", OrderData[1]));
            rpc.Add(new ReportParameter("ReceiversName", OrderData[2]));
            rpc.Add(new ReportParameter("Address", OrderData[3]));
            rpc.Add(new ReportParameter("ContactNo", OrderData[4]));
            rpc.Add(new ReportParameter("MilkVolume", OrderData[5] + " L"));
            rpc.Add(new ReportParameter("Price",  OrderData[6]));
            rpc.Add(new ReportParameter("DeliveryPersonName",  OrderData[7]));
            rpc.Add(new ReportParameter("DeliveryPersonMobile", OrderData[8]));


            LocalReport report = new LocalReport();

            GenarateQR(OrderData[0], report);

            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string FullPath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + @"\Reports\ReportDeleveryDocument.rdlc";
            report.ReportPath = FullPath;

            report.SetParameters(rpc);
            PrintToPrinter(report);

            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string UpdateQuery = @"UPDATE `orders` SET  `O_STATUS` = 'On the Way' WHERE `orders`.`O_ID` = '" + OrderData[0] + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.UpdateCommand = new MySqlCommand(UpdateQuery, con);
            adapter.UpdateCommand.ExecuteNonQuery();

        }

        private void GenarateQR(string Value,LocalReport report)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                ZQR.GetQRAsBitmap(Value).Save(ms, ImageFormat.Bmp);
                ReportData reportData = new ReportData();
                ReportData.QRCodeRow qRCodeRow = reportData.QRCode.NewQRCodeRow();
                qRCodeRow.Image = ms.ToArray();
                reportData.QRCode.AddQRCodeRow(qRCodeRow);

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "ReportData";
                reportDataSource.Value = reportData.QRCode;
                report.DataSources.Clear();
                report.DataSources.Add(reportDataSource);
            }
        }

        public static void PrintToPrinter(LocalReport report)
        {
            Export(report);

        }

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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if(dataTable!=null)
            {
                ZExport.AsExcel(dataTable);
            }
            
        }
    }
}
