using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace ProjectZ
{
    public static class ZExport
    {
        public static void AsExcel(DataTable dataTable )
        {
            try
            {
                string data = null;
                

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= dataTable.Columns.Count - 1; j++)
                    {
                        data = dataTable.Rows[i].ItemArray[j].ToString();
                        xlWorkSheet.Cells[i + 1, j + 1] = data;
                    }
                }

                SaveFileDialog SFD = new SaveFileDialog();
                SFD.InitialDirectory = @"";
                SFD.RestoreDirectory = true;
                SFD.FileName = "*.xls";
                SFD.DefaultExt = ".xls";
                SFD.Filter = "Excel files (*.xls)|*.xls ";
                if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    xlWorkBook.SaveAs(SFD.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    MessageBox.Show("Excel file created , you can find the file " + SFD.FileName);

                }
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                ReleseObject(xlWorkSheet);
                ReleseObject(xlWorkBook);
                ReleseObject(xlApp);

            }
            catch (Exception)
            {

                throw;
            }
        }
        private static void ReleseObject(object obj)// for relese the objects of AsExcel method
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
