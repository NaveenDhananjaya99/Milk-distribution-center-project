using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace ProjectZ.MyClasses
{
    public  class ZQR
    {

        public static Bitmap GetQRAsBitmap(string Value)
        {
            Bitmap bmp=null;

            QRCoder.QRCodeGenerator qg = new QRCoder.QRCodeGenerator();
            var MyData = qg.CreateQrCode(Value, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(MyData);
            bmp = code.GetGraphic(50);

            return bmp;
        }

     

        
    }
}
