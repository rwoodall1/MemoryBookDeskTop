using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using BaseClass.Classes;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace BaseClass.Classes
{
     public enum EmailType
    {
       System,
       Mbc,
       Meridian,
       Blank
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

            printDocument1.Print();

            }
       
        private Form Form { get; set; }
        private void CaptureScreen() {

            using (Graphics myGraphics = this.Form.CreateGraphics()) {
                Size s = this.Form.Size;
                
                memoryImage = new Bitmap(s.Width,s.Height,myGraphics);
                using (Graphics memoryGraphics = Graphics.FromImage(memoryImage)) {
                    memoryGraphics.CopyFromScreen(this.Form.Location.X,this.Form.Location.Y,0,0,s);
                    }
                }
            }
        private void printDocument1_PrintPage(System.Object sender,
          System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.PageSettings.Landscape = false;
            // calculate width and height scalings taking page margins into account
            var wScale = e.MarginBounds.Width / (float)memoryImage.Width;
            var hScale = e.MarginBounds.Height / (float)memoryImage.Height;
            // choose the smaller of the two scales
            var scale = wScale < hScale ? wScale : hScale;
            // apply scaling to the image
             e.Graphics.ScaleTransform(scale,scale);
           // e.Graphics.ScaleTransform(wScale,hScale);

            
            e.Graphics.DrawImage(memoryImage, 0, 0);
         
            }


    }
    public static class CalulateBusinessDay {
        public static DateTime? PromiseDate(DateTime vStartDate,int vNumberOfDays)
        {
            var ldDate = vStartDate;
            bool llOK = false;
            var sqlClient = new SQLCustomClient();
            var queryString = "Select Holiday from Holidays";
            sqlClient.CommandText(queryString);
            var result = sqlClient.SelectMany<HolidayDate>(); 
            if (result.IsError)
            {
                MessageBox.Show(result.Errors[0].ErrorMessage,"SqlError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            var HolidayDates = (List<HolidayDate>)result.Data;
           

            for (int i=0; i<vNumberOfDays; ++i)
            {
                ldDate = ldDate.AddDays(-1);
				llOK = false;

				while (!llOK)
                {
                    if (ldDate.DayOfWeek==DayOfWeek.Saturday)
                    {
                        ldDate = ldDate.AddDays(-1);

                    }else if(ldDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        ldDate = ldDate.AddDays(-2);

                    }
                    //Check if holiday
                    if (HolidayDates == null || HolidayDates.Count == 0)
                    {
                        //no holidays to look at
                        llOK = true;
                        return ldDate;
                    }
					
					var vExist = HolidayDates.Exists(x => x.Holiday.Date ==ldDate.Date);

					if (vExist)
					{
						var a= ldDate.AddDays(-1);
						ldDate.AddDays(-1);
						ldDate= ldDate.AddDays(-1);

					}
					else
					{
						llOK = true;
					}

					

				}

            }
            return ldDate;
        }
        public static DateTime BusDaySubtract(DateTime EndDate,int NumberOfDays) {
            var sqlQuery = new SQLQuery();
            var queryString = "Select * from Holidays";
            SqlParameter[] parameters = new SqlParameter[] {
          
            };
       var result = sqlQuery.ExecuteReaderAsync<HolidayDate>(CommandType.Text,queryString,parameters);
            if (result == null) {
                MessageBox.Show("There are no Holiday dates entered to be calculated.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
               
                }
            var HolidayDates = new List<HolidayDate>();
            HolidayDates =(List<HolidayDate>)result;
            var vEndDate = EndDate;
            //Remember we are subtracing backwards
            for(int i=1; i< NumberOfDays; i++) {
                vEndDate = vEndDate.AddDays(-1);
                bool oK = false;
                while (!oK) {
                    //0=Sunday,1=Monday ect.
                    int day = (int)vEndDate.DayOfWeek;
                    //if Saturday go to Friday
                    if (day == 6) {
                       vEndDate =vEndDate.AddDays(-1);
                        } else if(day==0) {
                        //If Sunday go to Friday
                        vEndDate = vEndDate.AddDays(-2);
                        }
                    //Now check if holiday
                    if (HolidayDates!=null)
                    {
                        if (!HolidayDates.Exists(a => a.Holiday.Date == vEndDate.Date))
                        {
                            oK = true;
                        }
                        else { vEndDate = vEndDate.AddDays(-1); }
                    }
                    else
                    {
                        oK = true;

                    }
                    }//End While

                }//End for
            return vEndDate;
            }
        public static DateTime BusDayAdd(DateTime StartDate,int NumberOfDays) {
            var sqlQuery = new SQLQuery();
            var queryString = "Select * from Holidays";
            SqlParameter[] parameters = new SqlParameter[] {

            };
            var result = sqlQuery.ExecuteReaderAsync<HolidayDate>(CommandType.Text,queryString,parameters);
            if (result == null) {
                MessageBox.Show("There are no Holiday dates entered to be calculated.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
              
                }
            var HolidayDates = new List<HolidayDate>();
            HolidayDates = (List<HolidayDate>)result;
            var vStartDate = StartDate;
            //Remember we are subtracing backwards
            for (int i = 1; i < NumberOfDays; i++) {
                vStartDate = vStartDate.AddDays(1);
                bool oK = false;
                while (!oK) {
                    //0=Sunday,1=Monday ect.
                    int day = (int)vStartDate.DayOfWeek;
                    //if Saturday go to Monday
                    if (day == 6) {
                        vStartDate = vStartDate.AddDays(2);
                        } else if (day == 0) {
                        //If Sunday go to Monday
                        vStartDate = vStartDate.AddDays(1);
                        }
                    //Now check if holiday
                    if (HolidayDates != null)
                    {
                        if (!HolidayDates.Exists(a => a.Holiday.Date == vStartDate.Date)) {
                        oK = true;
                        } else { vStartDate = vStartDate.AddDays(1); }
                    }
                    else
                    {
                        oK = true;

                    }
                }//End While

                }//End for
            return vStartDate;
            }
        }
    public class HolidayDate {
        public DateTime Holiday{ get; set; }

        }
}
