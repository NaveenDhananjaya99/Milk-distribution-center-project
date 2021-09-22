using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using ProjectZ.Data_Sets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectZ.MyClasses
{
    public static class ZCreateID
    {
        public static void ForFarmer(string ID,String Name,string RegDate,string Address,Image image)
        {
            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("ID", ID));
            rpc.Add(new ReportParameter("FarmerName", Name));
            rpc.Add(new ReportParameter("RegDate", RegDate));
            rpc.Add(new ReportParameter("DateOfIssued", DateTime.Now.ToString("yyyy-MM-dd")));
            rpc.Add(new ReportParameter("Address", Address));


            LocalReport report = new LocalReport();
            SetPhoto(image, report);
            GenarateQR(ID, report);
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string FullPath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + @"\Reports\FarmerID.rdlc";// give path of created template
            report.ReportPath = FullPath;

            report.SetParameters(rpc);
            PrintToPrinter(report);
        }

        public static void ForDeliveryPerson(string ID, String Name,string VehicleNo, string RegDate, string Address, Image image)
        {
            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("ID", ID));
            rpc.Add(new ReportParameter("DeliveryPersonName", Name));
            rpc.Add(new ReportParameter("VehicleNo", VehicleNo));
            rpc.Add(new ReportParameter("RegDate", RegDate));
            rpc.Add(new ReportParameter("DateOfIssued", DateTime.Now.ToString("yyyy-MM-dd")));
            rpc.Add(new ReportParameter("Address", Address));



            LocalReport report = new LocalReport();
            SetPhoto(image, report);
            GenarateQR(ID, report);
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string FullPath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + @"\Reports\DeliveryPersonID.rdlc";// give path of created template
            report.ReportPath = FullPath;

            report.SetParameters(rpc);
            PrintToPrinter(report);
        }

        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;


        private static void SetPhoto(Image image, LocalReport report)
        {


            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                DataSet_ID dataSet_ID = new DataSet_ID();
                DataSet_ID.PhotoRow photoRow = dataSet_ID.Photo.NewPhotoRow();
                photoRow.Image = ms.ToArray();
                dataSet_ID.Photo.AddPhotoRow(photoRow);

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DT1";
                reportDataSource.Value = dataSet_ID.Photo;
                //report.DataSources.Clear();
                report.DataSources.Add(reportDataSource);
            }
        }

        private static void GenarateQR(string Value, LocalReport report)
        {
           
            using (MemoryStream ms = new MemoryStream())
            {
                ZQR.GetQRAsBitmap(Value).Save(ms, ImageFormat.Bmp);
                DataSet_ID dataSet_ID = new DataSet_ID();
                DataSet_ID.QRRow qRRow = dataSet_ID.QR.NewQRRow();
                qRRow.Image = ms.ToArray();
                dataSet_ID.QR.AddQRRow(qRRow);

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DT2";
                reportDataSource.Value = dataSet_ID.QR;
                //report.DataSources.Clear();
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
    }
}
