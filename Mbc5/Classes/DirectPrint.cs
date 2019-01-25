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

using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.DataExtensions;
using Microsoft.ReportingServices.ReportRendering;

namespace Mbc5.Classes
{
    public class DirectPrint : IDisposable
    {
        private IList<Stream> m_streams;
        private int m_currentPageIndex;
        // Export the given report as an EMF (Enhanced Metafile) file.
        // Routine to provide to the report renderer, in order to
        //    save an image for each page of the report.
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new FileStream(@"..\..\" + name + "." + fileNameExtension, FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }
        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }
        public void Export(LocalReport report)
        {
            report.DataSources.RemoveAt(1);
            report.DataSources.RemoveAt(1);
            report.DataSources.RemoveAt(1);
            //string deviceInfo =
            //"" +
            //" EMF" +
            //" 8.5in" +
            //" 11in" +
            //" 0.25in" +
            //" 0.25in" +
            //" 0.25in" +
            //" 0.25in" +
            //"";
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
            try { report.Render("Image", deviceInfo, CreateStream,
            out warnings); }catch(Exception ex) { };


            foreach (Stream stream in m_streams)
            {
                stream.Position = 0;
                m_currentPageIndex = 0;
            }

            Print();
            Dispose();
        }
        

        // Then I modified the Print method to use the default printer instead of the hardcoded 'Microsoft Office Document....' printer.


        private void Print()
        {
            PrinterSettings settings = new PrinterSettings(); //set printer settings
            string printerName = settings.PrinterName; //use default printer name

            if (m_streams == null ||m_streams.Count == 0)
            {
                return;
            }
            

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;
            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format(
                "Can't find printer \"{0}\".", printerName);
                MessageBox.Show(msg, "Print Error");
                return;
            }

            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.Print();

        }
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

    }
}
//call with this
//directPrint dp = new directPrint(); //this is the name of the class added from MSDN
//dp.Export(reportViewer1.LocalReport); //export to default printer