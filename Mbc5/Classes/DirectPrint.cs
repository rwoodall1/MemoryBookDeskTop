using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BaseClass.Core;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.DataExtensions;
using Microsoft.ReportingServices.ReportRendering;
using BaseClass;
namespace Mbc5.Classes
{
    public class DirectPrint : IDisposable
    {
        private IList<Stream> m_streams;
        private int m_currentPageIndex=0;
		// Export the given report as an EMF (Enhanced Metafile) file.
		// Routine to provide to the report renderer, in order to
		//    save an image for each page of the report.
		private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
		{
			Stream stream = new FileStream(@"..\..\" + name + "." + fileNameExtension, FileMode.Create);
			m_streams.Add(stream);
			return stream;
		}
		//private Stream CreateStream(string name,string fileNameExtension, Encoding encoding,string mimeType, bool willSeek)
		//{
		//	Stream stream = new MemoryStream();
		//	m_streams.Add(stream);
		//	return stream;
		//}
		public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }
        public ApiProcessingResult Export(LocalReport report, string _printer)
        {
			var processingResult = new ApiProcessingResult();
            string deviceInfo =
		  @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.25in</MarginLeft>
                <MarginRight>0.25in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            try {
				report.Render("Image", deviceInfo, CreateStream,out warnings);
			} catch(Exception ex) {
				processingResult.IsError = true;
				processingResult.Errors.Add(new ApiProcessingError(ex.Message, ex.Message, ""));
				return processingResult;
			};


            foreach (Stream stream in m_streams)
            {
                stream.Position = 0;
                
            }

			
			var printResult = Print(_printer);
			Dispose();
			return printResult;

        }
        

        // Then I modified the Print method to use the default printer instead of the hardcoded 'Microsoft Office Document....' printer.


        private ApiProcessingResult Print(string _printer)
        {
			var processingResult = new ApiProcessingResult();
			string printerName;
			if (!string.IsNullOrEmpty(_printer))
			{
				printerName = _printer;
			}
			else
			{
				PrinterSettings settings = new PrinterSettings(); //set printer settings
				 printerName = settings.PrinterName; //use default printer name
			}
           

            if (m_streams == null ||m_streams.Count == 0)
            {
				processingResult.IsError = true;
				processingResult.Errors.Add(new ApiProcessingError("Report stream is not present.", "Report stream is not present.", ""));
				return processingResult;
			
            }
            

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;
            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format(
                "Can't find printer \"{0}\".", printerName);
                MessageBox.Show(msg, "Print Error");
				processingResult.IsError = true;
				processingResult.Errors.Add(new ApiProcessingError(msg, msg, ""));
				return processingResult;
			}

            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
			try {
				printDoc.Print();
			}catch(Exception ex) {
				processingResult.IsError = true;
				processingResult.Errors.Add(new ApiProcessingError(ex.Message, ex.Message, ""));
			}
           
			return processingResult;
		}
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }
		//
	}
}
//call with this
//directPrint dp = new directPrint(); //this is the name of the class added from MSDN
//dp.Export(reportViewer1.LocalReport); //export to default printer