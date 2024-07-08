using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Outlook = Microsoft.Office.Interop.Outlook;

using BindingModels;

using Core;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Windows.Forms;

namespace BaseClass.Classes {
    public class PdfAttachementGenerator {
       
        public ApiProcessingResult<string> GenerateAttachement(ReportViewer rv,string fileName)
        {
            var apiProcessingResult = new ApiProcessingResult<string>();
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            string savePath = "";
            try
            {
                rv.LocalReport.Refresh();

                byte[] bytes = rv.LocalReport.Render(
                "PDF",
                null,
                out mimeType,
                out encoding,
                out extension,
                out streamIds,
                out warnings);
                var vPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
              savePath = vPath.Substring(0, vPath.IndexOf("Mbc5") + 4) + "\\tmp\\" + fileName;

                using (FileStream fs = new FileStream(savePath, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Dispose();
                }
                apiProcessingResult.Data = savePath;
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error(ex.Message);
               
                apiProcessingResult.IsError = true;
                apiProcessingResult.Errors.Add(new ApiProcessingError(ex.Message, "Failed to generate attachement:" + ex.Message, ""));
                return apiProcessingResult;
               
            }
            return apiProcessingResult;


        }

    }
}
