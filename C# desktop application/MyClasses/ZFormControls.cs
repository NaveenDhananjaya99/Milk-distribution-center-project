using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectZ
{
    public static class ZFormControls
    {
        static Boolean Dragable;
        static int mouseX;
        static int mouseY;

        public static void ForMouseDown(Form frm)
        {
            try
            {
                Dragable = true;
                mouseX = Cursor.Position.X - frm.Left;
                mouseY = Cursor.Position.Y - frm.Top;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }

        }

        public static void ForMouseMove(Form frm)
        {
            try
            {
                if (Dragable)
                {
                    frm.Top = Cursor.Position.Y - mouseY;
                    frm.Left = Cursor.Position.X - mouseX;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }
            
        }

        public static void ForMouseUp()
        {
            try
            {
                Dragable = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }
        }


        public static void ForCloseButtonClick(Form frm)
        {
            try
            {
                frm.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }
        }


        public static void ForRestoreDownButtonClick(Form frm, Button btn)
        {
            try
            {
                if (frm.WindowState == FormWindowState.Normal)
                {
                    frm.WindowState = FormWindowState.Maximized;
                    btn.Text = "2";
                }
                else if (frm.WindowState == FormWindowState.Maximized)
                {
                    frm.WindowState = FormWindowState.Normal;
                    btn.Text = "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }
            
        }

        public static void ForMinimizeButtonClick(Form frm)
        {
            try
            {
                if (frm.WindowState == FormWindowState.Normal)
                {
                    frm.WindowState = FormWindowState.Minimized;
                }
                else if (frm.WindowState == FormWindowState.Minimized)
                {
                    frm.WindowState = FormWindowState.Normal;
                }
                else if (frm.WindowState == FormWindowState.Maximized)
                {
                    frm.WindowState = FormWindowState.Minimized;
                }
                else if (frm.WindowState == FormWindowState.Minimized)
                {
                    frm.WindowState = FormWindowState.Maximized;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.HelpLink);
            }
            
        }

    }
}
