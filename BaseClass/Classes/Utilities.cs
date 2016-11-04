using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
namespace BaseClass.Classes
{
     public enum EmailType
    {
       System,
       Mbc,
       Meridian
    }
    public class ScreenPrinter
    {
       // https://msdn.microsoft.com/en-us/library/6he9hz8c(v=vs.110).aspx
        private PrintDocument printDocument1 = new PrintDocument();
        Bitmap memoryImage;
        public ScreenPrinter(Form vForm)
        {
                this.Form = vForm;
                printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }
        
        public void PrintScreen()
        {
            CaptureScreen();
            PrintPreviewDialog
            printDocument1.Print();

        }
       
        private Form Form { get; set; }
        private void CaptureScreen()
        {

            Graphics myGraphics = this.Form.CreateGraphics();
            Size s = this.Form.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Form.Location.X, this.Form.Location.Y, 0, 0, s);
        }
        private void printDocument1_PrintPage(System.Object sender,
          System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.PageSettings.Landscape = true;
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }


    }



}
