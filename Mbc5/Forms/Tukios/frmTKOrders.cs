using BaseClass;
using BaseClass.Classes;
using BindingModels;
using Mbc5.Classes;
using Mbc5.Dialogs;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
namespace Mbc5.Forms.Tukios
{
    public partial class frmTKOrders : BaseClass.frmBase
    {
        //
        public frmMain frmMain { get; set; }
        public frmTKOrders(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "Tukios", "BARCODE", "MBLead" }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
        }
        public frmTKOrders(UserPrincipal userPrincipal, string clientId) : base(new string[] { "SA", "Administrator", "MixBook", "BARCODE", "MBLead" }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
            this.OrderId = clientId;
        }
        private static string LastPageStorage = "\\\\sedsujpisl01\\workflow\\TukiosLastPageImage\\";
        private static string BookArchivePath = "\\\\sedsujpisl01\\workflow\\TukiosBookArchive\\";
        public string OrderId { get; set; } = "";
        public UserPrincipal ApplicationUser { get; set; }

        private void frmTKOrders_Load(object sender, EventArgs e)
        {
            List<string> mylist2 = new List<string>(new string[] { "SA", "Administrator", });
            if (this.ApplicationUser.IsInOneOfRoles(mylist2))
            {
                btnCancelOrder.Visible = true;
                // btnRemoveOrder.Visible = true;
            }
            List<string> mylist1 = new List<string>(new string[] { "SA", "Administrator", "Tukios", "MBLead" });
            if (this.ApplicationUser.IsInOneOfRoles(mylist1))
            {
                this.pnlRemake.Visible = true;
                this.btnEmailTrk.Visible = true;
            }
            this.pnlOrder.Enabled = false;
            this.frmMain = (frmMain)this.MdiParent;

            List<string> mylist = new List<string>(new string[] { "SA", "Administrator", "Tukios" });
            this.btnEdit.Enabled = ApplicationUser.IsInOneOfRoles(mylist);
            btnDownloadFiles.Enabled = ApplicationUser.IsInOneOfRoles(mylist);
            SetConnectionString();
            this.Invno = 0;
            if (!string.IsNullOrEmpty(this.OrderId))
            {
                Fill();
            }

        }


        public void SaveOrder()
        {
            try
            {
                this.Validate();
                this.tukiosOrderBindingSource.EndEdit();

                this.tukiosOrderTableAdapter.Update(dsTukiosOrders);
                this.pnlOrder.Enabled = false;
            }
            catch (Exception ex)
            {
                // var a = dsmixBookOrders.Tables["MixBookOrder"].GetErrors();
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Failed to update order,INVNO:" + Invno.ToString());
            }
            this.Fill();
        }


        private void SetConnectionString()
        {
            try
            {
                this.statesTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
                this.tukiosOrderTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;


            }
            catch (Exception ex)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Failed to set Tukios orders connection strings");

            }
        }
        #region Search
        private void OrderIdSearch()
        {
            string vcurrentOrderId = "0";
            if (tukiosOrderBindingSource.Current != null)
            {
                try
                {
                    vcurrentOrderId = ((DataRowView)tukiosOrderBindingSource.Current).Row["ClientOrderId"].ToString();
                }
                catch (Exception ex) { Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "OrderId not found. Tukios OrderId Search"); }
            }


            frmSearch frmSearch = new frmSearch("OrderId", "TUKIOS", vcurrentOrderId);
            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    var retOrderId = frmSearch.ReturnValue.OrderId;            //values preserved after close

                    if (string.IsNullOrEmpty(retOrderId))
                    {
                        BaseClass.MbcMessageBox.Hand("A search value was not returned", "Error");
                    }
                    else
                    {
                        this.OrderId = retOrderId;
                        Fill();
                    }


                }
                catch (Exception ex)
                {
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Failed to search Order Id");
                }
            }

        }
        private void GroupIdSearch()
        {
            string vcurrentItemId = "";
            if (tukiosOrderBindingSource.Current != null)
            {
                try
                {
                    if (tukiosOrderBindingSource.Current != null)
                    {
                        vcurrentItemId = ((DataRowView)tukiosOrderBindingSource.Current).Row["GroupId"].ToString();
                    }
                }
                catch (Exception ex) { Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Failed to search Group ID"); }
            }

            frmSearch frmSearch = new frmSearch("GROUPID", "TUKIOS", vcurrentItemId);
            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                var retOrderId = frmSearch.ReturnValue.OrderId;            //values preserved after close
                if (string.IsNullOrEmpty(retOrderId))
                {
                    BaseClass.MbcMessageBox.Hand("A search value was not returned", "Error");
                }
                else
                {

                    this.OrderId = retOrderId;
                    Fill();
                }
            }
        }
        private void InvnoSearch()
        {
            string vcurrentItemId = "";
            if (tukiosOrderBindingSource.Current != null)
            {
                try
                {
                    if (tukiosOrderBindingSource.Current != null)
                    {
                        vcurrentItemId = ((DataRowView)tukiosOrderBindingSource.Current).Row["Invno"].ToString();
                    }
                }
                catch (Exception ex) { Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Failed to search Invno"); }
            }

            frmSearch frmSearch = new frmSearch("INVNO", "TUKIOS", vcurrentItemId);
            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                var retOrderId = frmSearch.ReturnValue.OrderId;            //values preserved after close
                if (string.IsNullOrEmpty(retOrderId))
                {
                    BaseClass.MbcMessageBox.Hand("A search value was not returned", "Error");
                }
                else
                {

                    this.OrderId = retOrderId;
                    Fill();
                }
            }
        }
        private void OrderNameSearch()
        {
            string vcurrentName = "";
            try
            {
                if (tukiosOrderBindingSource.Current != null)
                {
                    vcurrentName = ((DataRowView)tukiosOrderBindingSource.Current).Row["ShipName"].ToString();
                }
            }
            catch (Exception ex) { Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Failed to search Order Name"); }

            frmSearch frmSearch = new frmSearch("SHIPNAME", "Tukios", vcurrentName);
            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                var retOrderId = frmSearch.ReturnValue.OrderId;            //values preserved after close
                if (string.IsNullOrEmpty(retOrderId))
                {
                    BaseClass.MbcMessageBox.Hand("A search value was not returned", "Error");
                }
                else
                {

                    this.OrderId = retOrderId;
                    Fill();

                }
            }
        }

        #endregion
        #region "Methods"
        private void Remake(string remakeType)
        {
            string vreasonCode = "";
            InputBox.Show("Reason Code", "Enter a reason code", ref vreasonCode);

            if (string.IsNullOrEmpty(vreasonCode))
            {
                MbcMessageBox.Stop("Invalid reason code", "Reason Code");
                return;
            }
            if (vreasonCode.Length > 2)
            {
                MbcMessageBox.Stop("Invalid Reason Code", "Reason Code");
                return;
            }
            int vReason = 0;
            if (!int.TryParse(vreasonCode, out vReason))
            {
                MbcMessageBox.Error("Invalid reason code.");
                return;
            }
            string vQuantity = "";
            InputBox.Show("Quantity", "Number of remakes", ref vQuantity);

            if (string.IsNullOrEmpty(vQuantity))
            {
                MbcMessageBox.Stop("Enter a quantity", "Quantity");
                return;
            }
            int vRemakeQuantity = 0;
            if (!int.TryParse(vQuantity, out vRemakeQuantity))
            {
                MbcMessageBox.Error("Invalid Quantity");
                return;
            }
            if (vRemakeQuantity == 0)
            {
                MbcMessageBox.Error("Quantity can not be zero");
                return;
            }

            var sqlClient = new SQLCustomClient();

            //insure we have correct invno, should already be set
            if (this.Invno.ToString() != invnoLabel1.Text.Trim())
            {
                MbcMessageBox.Stop("The invoice number does not match the system invoice number. Re-search the record and try again.", "Invoice# Error");
                return;
            }

            if (remakeType == "CVR")
            {
                sqlClient.ClearParameters();
                sqlClient.CommandText(@"Delete From COVERDETAIL Where INVNO=@Invno");
                sqlClient.AddParameter("@Invno", this.Invno);

                var deleteResult = sqlClient.Delete();
                if (deleteResult.IsError)
                {
                    MbcMessageBox.Error("Failed to remove cover scans for this order. Try again or contact a supervisor.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to remove cover scans for this order. Try again or contact a supervisor." + deleteResult.Errors[0].DeveloperMessage);
                    return;
                }

                sqlClient.ClearParameters();
                sqlClient.CommandText(@"UPDATE COVERS SET  Reprntdte=GETDATE(),FullRemake=@FullRemake,remake=1,RemakeReason=@RemakeReason,persondest=@persondest,specinst=@Memo +' | ' + CAST(COALESCE(specinst,'') as varchar) Where INVNO=@Invno");
                string vmemo = "Remake issued by:" + ApplicationUser.UserName.ToUpper() + " on " + DateTime.Now.ToString();
                sqlClient.AddParameter("@Memo", vmemo);
                sqlClient.AddParameter("FullRemake", vRemakeQuantity);
                sqlClient.AddParameter("@persondest", ApplicationUser.UserName.ToUpper());
                sqlClient.AddParameter("@Invno", this.Invno);
                if (vReason == 0)
                {
                    MbcMessageBox.Error("Invalid reason code.");
                    return;
                }
                sqlClient.AddParameter("@RemakeReason", vReason);
                var updateResult = sqlClient.Update();
                if (updateResult.IsError)
                {
                    MbcMessageBox.Error("Failed to update cover reprint date.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update cover reprint date:" + updateResult.Errors[0].DeveloperMessage);
                    return;
                }

                sqlClient.ClearParameters();
                sqlClient.CommandText(@"Update TukiosOrder SET CoverStatus='',CurrentCoverLoc='' where Invno=@Invno");
                sqlClient.AddParameter("@Invno", Invno);
                var updateResult11 = sqlClient.Update();
                if (updateResult11.IsError)
                {
                    MbcMessageBox.Error("Failed to update Order remake data.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update Tukios Order Remake Data SC:" + updateResult11.Errors[0].DeveloperMessage);
                    return;
                }
                vreasonCode = null;
                vQuantity = null;
            }
            else if (remakeType == "BK")
            {
                sqlClient.ClearParameters();
                sqlClient.CommandText(@"Delete From WIPDETAIL Where INVNO=@Invno");
                sqlClient.AddParameter("@Invno", this.Invno);
                var deleteResult = sqlClient.Delete();
                if (deleteResult.IsError)
                {
                    MbcMessageBox.Error("Failed to remove wip scans for this order. Try again or contact a supervisor.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to remove wip scans for this order:" + deleteResult.Errors[0].DeveloperMessage);
                    return;
                }

                sqlClient.ClearParameters();
                string vmemo = "Remake issued by:" + ApplicationUser.UserName.ToUpper() + " on " + DateTime.Now.ToString();
                sqlClient.CommandText(@"UPDATE WIP SET  RmbTo=GETDATE(),RmbTot=@RmbTot,iinit=@iinit,RemakeReason=@RemakeReason,WipMemo=@Memo + ' | ' + CAST(COALESCE(WipMemo,' ') as varchar) Where INVNO=@Invno");
                sqlClient.AddParameter("@iinit", ApplicationUser.UserName.ToUpper());
                sqlClient.AddParameter("@Invno", this.Invno);
                sqlClient.AddParameter("@RmbTot", vRemakeQuantity);
                sqlClient.AddParameter("@Memo", vmemo);
                if (vReason == 0)
                {
                    MbcMessageBox.Error("Invalid reason code.");
                    return;
                }
                sqlClient.AddParameter("@RemakeReason", vReason);
                var updateResult = sqlClient.Update();
                if (updateResult.IsError)
                {
                    MbcMessageBox.Error("Failed to update wip remake date.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update wip remake date:" + updateResult.Errors[0].DeveloperMessage);
                    return;
                }

                sqlClient.ClearParameters();
                sqlClient.CommandText(@"Update TukiosOrder SET BookStatus='',CurrentBookLoc='',RemakeTicketPrinted=0 where Invno=@Invno");
                sqlClient.AddParameter("@Invno", Invno);
                var updateResul1t = sqlClient.Update();
                if (updateResul1t.IsError)
                {
                    MbcMessageBox.Error("Failed to update Order remake data.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update Tukios Order Remake Data YB:" + updateResul1t.Errors[0].DeveloperMessage);
                    return;
                }

            }
            vreasonCode = null;
            vQuantity = null;
        }
        public override void Fill()
        {

            pnlOrder.Enabled = false;
            if (string.IsNullOrEmpty(OrderId))
            {
                dsTukiosOrders.Clear();
                return;
            }
            try
            {
                this.statesTableAdapter.Fill(this.lookUp.states);

                int vIInvno = 0;
                tukiosOrderTableAdapter.Fill(dsTukiosOrders.TukiosOrder, OrderId);
                string vSInvno = ((DataRowView)tukiosOrderBindingSource.Current).Row["Invno"].ToString();
                int.TryParse(vSInvno, out vIInvno);
                this.Invno = vIInvno;
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error(ex.Message);
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Failed to fill tukios orders data adapters,INVNO:" + Invno.ToString());
            }
            if (orderStatusLabel2.Text.ToUpper() == "CANCELLED")
            {
                lblCanceled.Visible = true;
            }
            else { lblCanceled.Visible = false; }
            if (orderStatusLabel2.Text.ToUpper() == "HOLD" || orderStatusLabel2.Text.ToUpper() == "ON HOLD")
            {
                lblHold.Visible = true;
                lblHold.BringToFront();

            }
            else { lblHold.Visible = false; }

        }
        private void PrintJobTicket()
        {
            if (tukiosOrderBindingSource.Current == null)
            {
                return;
            }
            var value = ((DataRowView)tukiosOrderBindingSource.Current).Row["Invno"].ToString();


            var sqlClient = new SQLCustomClient().CommandText(@"
                      
  Select Invno,
  ClientOrderId,
  BookBlockURL,
CoverURL,
  PrintergyFile,
     ShipName,
     RequestedShipDate,
     BookId,
     CAST(Invno as varchar)+'   X'+CAST(ProdInOrder as varchar) AS DSInvno,
     (Select Sum(Copies) from tukiosorder  where Clientorderid=TO1.ClientOrderid )As NumToShip,
     Description,
     Copies,ProdCopies,
     Pages,
    Backing,
    OrderReceivedDate,
    ProdInOrder,
    '*MXB'+CAST(Invno as varchar)+'SC*' AS SCBarcode,
    '*MXB'+CAST(Invno as varchar)+'YB*' AS YBBarcode,
    Case

                        when (ProdCopies>3 )  Then

                        CASE
                        When  ProdCopies % 4=0 Then
                        ProdCopies/4

                        When ProdCopies % 4>0 Then
                        (ProdCopies/4)+1
                        End
                       else
                        ProdCopies
                        End AS LargePressQty,

            Case
              when ProdCopies>4 Then
           		ProdCopies/1
            else
                ProdCopies
            End AS SmallPressQty
                
        From TukiosOrder TO1
        Where Invno=@Invno
                    ");

            sqlClient.AddParameter("@Invno", value);

            var result = sqlClient.Select<TukiosJobTicketQuery>();
            if (result.IsError)
            {
                MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to retieve orders for JobTicketQuery:" + result.Errors[0].DeveloperMessage);
                return;
            }
            var jobData = (TukiosJobTicketQuery)result.Data;
            if (jobData != null)
            {
                jobData = this.SetPageImage(jobData);
                string imagePath1Param = null;
                string imagePath2Param = null;
                string imagePath3Param = null;

                imagePath1Param = new Uri(jobData.FirstPageLocation).AbsoluteUri; // yields file://...
                imagePath2Param = new Uri(jobData.LastPageLocation).AbsoluteUri; // yields file://..
                imagePath3Param = new Uri(jobData.CoverPageLocation).AbsoluteUri; // yields file://..



                reportViewer3.LocalReport.DataSources.Clear();
                JobTicketQueryBindingSource.DataSource = jobData;
                try
                {
                    reportViewer3.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.TukiosJobTicketSingle.rdlc";
                    reportViewer3.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", JobTicketQueryBindingSource));
                    reportViewer3.LocalReport.EnableExternalImages = true;
                    ReportParameter parameter = new ReportParameter("ImagePath", imagePath1Param ?? string.Empty);
                    ReportParameter parameter2 = new ReportParameter("ImagePath2", imagePath2Param ?? string.Empty);
                    ReportParameter parameter3 = new ReportParameter("ImagePath3", imagePath3Param ?? string.Empty);//path to image

                    reportViewer3.LocalReport.SetParameters(new ReportParameter[] { parameter, parameter2, parameter3 });


                    this.reportViewer3.RefreshReport();
                }
                catch (Exception ex) { }
            }
            else
            {
                MbcMessageBox.Hand("There were no records found to print.", "No Records");
            }
        }

        private TukiosJobTicketQuery SetPageImage(TukiosJobTicketQuery data)
        {
            TukiosJobTicketQuery result = SetLastPageImage(data);
            result = SetFirstPageImage(result);
            result = SetCoverPageImage(result);
            return result;
        }
        private TukiosJobTicketQuery SetLastPageImage(TukiosJobTicketQuery data)
        {
            if (string.IsNullOrEmpty(data.BookBlockURL))
            {
                return data;
            }
            string pdfPath = "";
            string file = data.PrintergyFile ?? "";
            int idx = file.IndexOf("_.");
            if (idx > 0)
            {
                file = file.Substring(0, idx);
            }
            // original logic appended _BB.pdf
            file += "_BB.pdf";

            // combine UNC share + filename
            string archiveFullPath = Path.Combine(BookArchivePath, file);

            if (File.Exists(archiveFullPath))
            {
                pdfPath = archiveFullPath;

            }
            else
            {
                pdfPath = data.BookBlockURL;
            }

            // Suggest default filename based on PDF name
            string defaultName = data.Invno.ToString() + "LastPage.jpeg";
            var fullPath = Path.Combine(LastPageStorage, defaultName);
            string lastPageImageFilePath = fullPath;
            if (File.Exists(lastPageImageFilePath))
            {
                data.LastPageLocation = lastPageImageFilePath;
                return data;

            }
            Stream pdfStream = null;
            if (pdfPath.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                pdfPath.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                using (var http = new HttpClient())
                {
                    var resp = http.GetAsync(pdfPath).GetAwaiter().GetResult();
                    resp.EnsureSuccessStatusCode();
                    // copy to memory so stream is seekable for PdfiumViewer
                    var ms = new MemoryStream();
                    resp.Content.ReadAsStreamAsync().GetAwaiter().GetResult().CopyTo(ms);
                    ms.Position = 0;
                    pdfStream = ms;
                }
            }
            else if (!string.IsNullOrEmpty(pdfPath) && File.Exists(pdfPath))
            {
                pdfStream = File.OpenRead(pdfPath);
            }


            try
            {
                using (pdfStream)
                {
                    // Load PDF with PdfiumViewer (uses native pdfium for reliable rendering)
                    //LastPage
                    using (var doc = PdfDocument.Load(pdfStream))
                    {
                        if (doc.PageCount <= 0)
                        {
                            MessageBox.Show(this, "PDF contains no pages.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return data;
                        }

                        // Render the last page (choose another index if you want)
                        int pageIndex = Math.Max(0, doc.PageCount - 1);

                        // Desired DPI
                        int dpi = 300;

                        // Determine target pixel size from PDF page size (PdfiumViewer exposes PageSizes in points)
                        // PageSizes entries are in points (1 point = 1/72 inch)
                        var pageSize = doc.PageSizes[pageIndex]; // SizeF (width/height in points)
                        int pixelWidth = (int)Math.Ceiling(pageSize.Width / 72.0f * dpi);
                        int pixelHeight = (int)Math.Ceiling(pageSize.Height / 72.0f * dpi);

                        // Clamp to avoid extremely large bitmaps (adjust limit as needed)
                        const int maxDimension = 10000;
                        if (pixelWidth > maxDimension || pixelHeight > maxDimension)
                        {
                            double scale = Math.Min((double)maxDimension / pixelWidth, (double)maxDimension / pixelHeight);
                            pixelWidth = Math.Max(1, (int)(pixelWidth * scale));
                            pixelHeight = Math.Max(1, (int)(pixelHeight * scale));
                        }

                        // Render page to a Bitmap using Pdfium (includes annotations)
                        using (var rendered = doc.Render(pageIndex, pixelWidth, pixelHeight, dpi, dpi, PdfRenderFlags.Annotations))
                        {

                            rendered.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            data.LastPageLocation = lastPageImageFilePath;
                            return data;
                            //MessageBox.Show(this, "Saved image: " + sfd.FileName, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                // Show full exception to aid diagnosis of native/pdfium issues
                MessageBox.Show(this, "Error processing PDF: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return data;
            }



        }
        private TukiosJobTicketQuery SetFirstPageImage(TukiosJobTicketQuery data)
        {
            if (string.IsNullOrEmpty(data.BookBlockURL))
            {
                return data;
            }
            string pdfPath = "";
            string file = data.PrintergyFile ?? "";
            int idx = file.IndexOf("_.");
            if (idx > 0)
            {
                file = file.Substring(0, idx);
            }
            // original logic appended _BB.pdf
            file += "_BB.pdf";

            // combine UNC share + filename
            string archiveFullPath = Path.Combine(BookArchivePath, file);

            if (File.Exists(archiveFullPath))
            {
                pdfPath = archiveFullPath;

            }
            else
            {
                pdfPath = data.BookBlockURL;
            }

            // Suggest default filename based on PDF name
            string defaultName = data.Invno.ToString() + "FirstPage.jpeg";
            var fullPath = Path.Combine(LastPageStorage, defaultName);
            string firstPageImageFilePath = fullPath;
            if (File.Exists(firstPageImageFilePath))
            {
                data.FirstPageLocation = firstPageImageFilePath;
                return data;

            }
            Stream pdfStream = null;
            if (pdfPath.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                pdfPath.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                using (var http = new HttpClient())
                {
                    var resp = http.GetAsync(pdfPath).GetAwaiter().GetResult();
                    resp.EnsureSuccessStatusCode();
                    // copy to memory so stream is seekable for PdfiumViewer
                    var ms = new MemoryStream();
                    resp.Content.ReadAsStreamAsync().GetAwaiter().GetResult().CopyTo(ms);
                    ms.Position = 0;
                    pdfStream = ms;
                }
            }
            else if (!string.IsNullOrEmpty(pdfPath) && File.Exists(pdfPath))
            {
                pdfStream = File.OpenRead(pdfPath);
            }


            try
            {
                using (pdfStream)
                {
                    // Load PDF with PdfiumViewer (uses native pdfium for reliable rendering)
                    //LastPage
                    using (var doc = PdfDocument.Load(pdfStream))
                    {
                        if (doc.PageCount <= 0)
                        {
                            MessageBox.Show(this, "PDF contains no pages.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return data;
                        }

                        // Render the last page (choose another index if you want)
                        int pageIndex = Math.Max(0, 1 - 1);

                        // Desired DPI
                        int dpi = 300;

                        // Determine target pixel size from PDF page size (PdfiumViewer exposes PageSizes in points)
                        // PageSizes entries are in points (1 point = 1/72 inch)
                        var pageSize = doc.PageSizes[pageIndex]; // SizeF (width/height in points)
                        int pixelWidth = (int)Math.Ceiling(pageSize.Width / 72.0f * dpi);
                        int pixelHeight = (int)Math.Ceiling(pageSize.Height / 72.0f * dpi);

                        // Clamp to avoid extremely large bitmaps (adjust limit as needed)
                        const int maxDimension = 10000;
                        if (pixelWidth > maxDimension || pixelHeight > maxDimension)
                        {
                            double scale = Math.Min((double)maxDimension / pixelWidth, (double)maxDimension / pixelHeight);
                            pixelWidth = Math.Max(1, (int)(pixelWidth * scale));
                            pixelHeight = Math.Max(1, (int)(pixelHeight * scale));
                        }

                        // Render page to a Bitmap using Pdfium (includes annotations)
                        using (var rendered = doc.Render(pageIndex, pixelWidth, pixelHeight, dpi, dpi, PdfRenderFlags.Annotations))
                        {

                            rendered.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            data.FirstPageLocation = firstPageImageFilePath;
                            return data;
                            //MessageBox.Show(this, "Saved image: " + sfd.FileName, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                // Show full exception to aid diagnosis of native/pdfium issues
                MessageBox.Show(this, "Error processing PDF: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return data;
            }



        }
        private TukiosJobTicketQuery SetCoverPageImage(TukiosJobTicketQuery data)
        {
            if (string.IsNullOrEmpty(data.CoverURL))
            {
                return data;
            }
            string pdfPath = "";
            string file = data.PrintergyFile ?? "";
            int idx = file.IndexOf("_.");
            if (idx > 0)
            {
                file = file.Substring(0, idx);
            }
            // original logic appended _BB.pdf
            file += "_CV.pdf";

            // combine UNC share + filename
            string archiveFullPath = Path.Combine(BookArchivePath, file);

            if (File.Exists(archiveFullPath))
            {
                pdfPath = archiveFullPath;

            }
            else
            {
                pdfPath = data.CoverURL;
            }

            // Suggest default filename based on PDF name
            string defaultName = data.Invno.ToString() + "CoverPage.jpeg";
            var fullPath = Path.Combine(LastPageStorage, defaultName);
            string coverPageImageFilePath = fullPath;
            if (File.Exists(coverPageImageFilePath))
            {
                data.CoverPageLocation = coverPageImageFilePath;
                return data;

            }
            Stream pdfStream = null;
            if (pdfPath.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                pdfPath.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                using (var http = new HttpClient())
                {
                    var resp = http.GetAsync(pdfPath).GetAwaiter().GetResult();
                    resp.EnsureSuccessStatusCode();
                    // copy to memory so stream is seekable for PdfiumViewer
                    var ms = new MemoryStream();
                    resp.Content.ReadAsStreamAsync().GetAwaiter().GetResult().CopyTo(ms);
                    ms.Position = 0;
                    pdfStream = ms;
                }
            }
            else if (!string.IsNullOrEmpty(pdfPath) && File.Exists(pdfPath))
            {
                pdfStream = File.OpenRead(pdfPath);
            }


            try
            {
                using (pdfStream)
                {
                    // Load PDF with PdfiumViewer (uses native pdfium for reliable rendering)
                    //LastPage
                    using (var doc = PdfDocument.Load(pdfStream))
                    {
                        if (doc.PageCount <= 0)
                        {
                            MessageBox.Show(this, "PDF contains no pages.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return data;
                        }

                        // Render the last page (choose another index if you want)
                        int pageIndex = Math.Max(0, 1 - 1);

                        // Desired DPI
                        int dpi = 300;

                        // Determine target pixel size from PDF page size (PdfiumViewer exposes PageSizes in points)
                        // PageSizes entries are in points (1 point = 1/72 inch)
                        var pageSize = doc.PageSizes[pageIndex]; // SizeF (width/height in points)
                        int pixelWidth = (int)Math.Ceiling(pageSize.Width / 72.0f * dpi);
                        int pixelHeight = (int)Math.Ceiling(pageSize.Height / 72.0f * dpi);

                        // Clamp to avoid extremely large bitmaps (adjust limit as needed)
                        const int maxDimension = 10000;
                        if (pixelWidth > maxDimension || pixelHeight > maxDimension)
                        {
                            double scale = Math.Min((double)maxDimension / pixelWidth, (double)maxDimension / pixelHeight);
                            pixelWidth = Math.Max(1, (int)(pixelWidth * scale));
                            pixelHeight = Math.Max(1, (int)(pixelHeight * scale));
                        }

                        // Render page to a Bitmap using Pdfium (includes annotations)
                        using (var rendered = doc.Render(pageIndex, pixelWidth, pixelHeight, dpi, dpi, PdfRenderFlags.Annotations))
                        {

                            rendered.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            data.CoverPageLocation = coverPageImageFilePath;
                            return data;
                            //MessageBox.Show(this, "Saved image: " + sfd.FileName, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                // Show full exception to aid diagnosis of native/pdfium issues
                MessageBox.Show(this, "Error processing PDF: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return data;
            }



        }

        private TukiosRemakeTicketQuery SetPageImage(TukiosRemakeTicketQuery data)
        {
            TukiosRemakeTicketQuery result = SetLastPageImage(data);
            result = SetFirstPageImage(result);
            result = SetCoverPageImage(result);
            return result;
        }
        private TukiosRemakeTicketQuery SetLastPageImage(TukiosRemakeTicketQuery data)
        {
            if (string.IsNullOrEmpty(data.BookBlockURL))
            {
                return data;
            }
            string pdfPath = "";
            string file = data.PrintergyFile ?? "";
            int idx = file.IndexOf("_.");
            if (idx > 0)
            {
                file = file.Substring(0, idx);
            }
            // original logic appended _BB.pdf
            file += "_BB.pdf";

            // combine UNC share + filename
            string archiveFullPath = Path.Combine(BookArchivePath, file);

            if (File.Exists(archiveFullPath))
            {
                pdfPath = archiveFullPath;

            }
            else
            {
                pdfPath = data.BookBlockURL;
            }

            // Suggest default filename based on PDF name
            string defaultName = data.Invno.ToString() + "LastPage.jpeg";
            var fullPath = Path.Combine(LastPageStorage, defaultName);
            string lastPageImageFilePath = fullPath;
            if (File.Exists(lastPageImageFilePath))
            {
                data.LastPageLocation = lastPageImageFilePath;
                return data;

            }
            Stream pdfStream = null;
            if (pdfPath.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                pdfPath.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                using (var http = new HttpClient())
                {
                    var resp = http.GetAsync(pdfPath).GetAwaiter().GetResult();
                    resp.EnsureSuccessStatusCode();
                    // copy to memory so stream is seekable for PdfiumViewer
                    var ms = new MemoryStream();
                    resp.Content.ReadAsStreamAsync().GetAwaiter().GetResult().CopyTo(ms);
                    ms.Position = 0;
                    pdfStream = ms;
                }
            }
            else if (!string.IsNullOrEmpty(pdfPath) && File.Exists(pdfPath))
            {
                pdfStream = File.OpenRead(pdfPath);
            }


            try
            {
                using (pdfStream)
                {
                    // Load PDF with PdfiumViewer (uses native pdfium for reliable rendering)
                    //LastPage
                    using (var doc = PdfDocument.Load(pdfStream))
                    {
                        if (doc.PageCount <= 0)
                        {
                            MessageBox.Show(this, "PDF contains no pages.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return data;
                        }

                        // Render the last page (choose another index if you want)
                        int pageIndex = Math.Max(0, doc.PageCount - 1);

                        // Desired DPI
                        int dpi = 300;

                        // Determine target pixel size from PDF page size (PdfiumViewer exposes PageSizes in points)
                        // PageSizes entries are in points (1 point = 1/72 inch)
                        var pageSize = doc.PageSizes[pageIndex]; // SizeF (width/height in points)
                        int pixelWidth = (int)Math.Ceiling(pageSize.Width / 72.0f * dpi);
                        int pixelHeight = (int)Math.Ceiling(pageSize.Height / 72.0f * dpi);

                        // Clamp to avoid extremely large bitmaps (adjust limit as needed)
                        const int maxDimension = 10000;
                        if (pixelWidth > maxDimension || pixelHeight > maxDimension)
                        {
                            double scale = Math.Min((double)maxDimension / pixelWidth, (double)maxDimension / pixelHeight);
                            pixelWidth = Math.Max(1, (int)(pixelWidth * scale));
                            pixelHeight = Math.Max(1, (int)(pixelHeight * scale));
                        }

                        // Render page to a Bitmap using Pdfium (includes annotations)
                        using (var rendered = doc.Render(pageIndex, pixelWidth, pixelHeight, dpi, dpi, PdfRenderFlags.Annotations))
                        {

                            rendered.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            data.LastPageLocation = lastPageImageFilePath;
                            return data;
                            //MessageBox.Show(this, "Saved image: " + sfd.FileName, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                // Show full exception to aid diagnosis of native/pdfium issues
                MessageBox.Show(this, "Error processing PDF: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return data;
            }



        }
        private TukiosRemakeTicketQuery SetFirstPageImage(TukiosRemakeTicketQuery data)
        {
            if (string.IsNullOrEmpty(data.BookBlockURL))
            {
                return data;
            }
            string pdfPath = "";
            string file = data.PrintergyFile ?? "";
            int idx = file.IndexOf("_.");
            if (idx > 0)
            {
                file = file.Substring(0, idx);
            }
            // original logic appended _BB.pdf
            file += "_BB.pdf";

            // combine UNC share + filename
            string archiveFullPath = Path.Combine(BookArchivePath, file);

            if (File.Exists(archiveFullPath))
            {
                pdfPath = archiveFullPath;

            }
            else
            {
                pdfPath = data.BookBlockURL;
            }

            // Suggest default filename based on PDF name
            string defaultName = data.Invno.ToString() + "FirstPage.jpeg";
            var fullPath = Path.Combine(LastPageStorage, defaultName);
            string firstPageImageFilePath = fullPath;
            if (File.Exists(firstPageImageFilePath))
            {
                data.FirstPageLocation = firstPageImageFilePath;
                return data;

            }
            Stream pdfStream = null;
            if (pdfPath.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                pdfPath.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                using (var http = new HttpClient())
                {
                    var resp = http.GetAsync(pdfPath).GetAwaiter().GetResult();
                    resp.EnsureSuccessStatusCode();
                    // copy to memory so stream is seekable for PdfiumViewer
                    var ms = new MemoryStream();
                    resp.Content.ReadAsStreamAsync().GetAwaiter().GetResult().CopyTo(ms);
                    ms.Position = 0;
                    pdfStream = ms;
                }
            }
            else if (!string.IsNullOrEmpty(pdfPath) && File.Exists(pdfPath))
            {
                pdfStream = File.OpenRead(pdfPath);
            }


            try
            {
                using (pdfStream)
                {
                    // Load PDF with PdfiumViewer (uses native pdfium for reliable rendering)
                    //LastPage
                    using (var doc = PdfDocument.Load(pdfStream))
                    {
                        if (doc.PageCount <= 0)
                        {
                            MessageBox.Show(this, "PDF contains no pages.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return data;
                        }

                        // Render the last page (choose another index if you want)
                        int pageIndex = Math.Max(0, 1 - 1);

                        // Desired DPI
                        int dpi = 300;

                        // Determine target pixel size from PDF page size (PdfiumViewer exposes PageSizes in points)
                        // PageSizes entries are in points (1 point = 1/72 inch)
                        var pageSize = doc.PageSizes[pageIndex]; // SizeF (width/height in points)
                        int pixelWidth = (int)Math.Ceiling(pageSize.Width / 72.0f * dpi);
                        int pixelHeight = (int)Math.Ceiling(pageSize.Height / 72.0f * dpi);

                        // Clamp to avoid extremely large bitmaps (adjust limit as needed)
                        const int maxDimension = 10000;
                        if (pixelWidth > maxDimension || pixelHeight > maxDimension)
                        {
                            double scale = Math.Min((double)maxDimension / pixelWidth, (double)maxDimension / pixelHeight);
                            pixelWidth = Math.Max(1, (int)(pixelWidth * scale));
                            pixelHeight = Math.Max(1, (int)(pixelHeight * scale));
                        }

                        // Render page to a Bitmap using Pdfium (includes annotations)
                        using (var rendered = doc.Render(pageIndex, pixelWidth, pixelHeight, dpi, dpi, PdfRenderFlags.Annotations))
                        {

                            rendered.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            data.FirstPageLocation = firstPageImageFilePath;
                            return data;
                            //MessageBox.Show(this, "Saved image: " + sfd.FileName, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                // Show full exception to aid diagnosis of native/pdfium issues
                MessageBox.Show(this, "Error processing PDF: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return data;
            }



        }
        private TukiosRemakeTicketQuery SetCoverPageImage(TukiosRemakeTicketQuery data)
        {
            if (string.IsNullOrEmpty(data.CoverURL))
            {
                return data;
            }
            string pdfPath = "";
            string file = data.PrintergyFile ?? "";
            int idx = file.IndexOf("_.");
            if (idx > 0)
            {
                file = file.Substring(0, idx);
            }
            // original logic appended _BB.pdf
            file += "_CV.pdf";

            // combine UNC share + filename
            string archiveFullPath = Path.Combine(BookArchivePath, file);

            if (File.Exists(archiveFullPath))
            {
                pdfPath = archiveFullPath;

            }
            else
            {
                pdfPath = data.CoverURL;
            }

            // Suggest default filename based on PDF name
            string defaultName = data.Invno.ToString() + "CoverPage.jpeg";
            var fullPath = Path.Combine(LastPageStorage, defaultName);
            string coverPageImageFilePath = fullPath;
            if (File.Exists(coverPageImageFilePath))
            {
                data.CoverPageLocation = coverPageImageFilePath;
                return data;

            }
            Stream pdfStream = null;
            if (pdfPath.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                pdfPath.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                using (var http = new HttpClient())
                {
                    var resp = http.GetAsync(pdfPath).GetAwaiter().GetResult();
                    resp.EnsureSuccessStatusCode();
                    // copy to memory so stream is seekable for PdfiumViewer
                    var ms = new MemoryStream();
                    resp.Content.ReadAsStreamAsync().GetAwaiter().GetResult().CopyTo(ms);
                    ms.Position = 0;
                    pdfStream = ms;
                }
            }
            else if (!string.IsNullOrEmpty(pdfPath) && File.Exists(pdfPath))
            {
                pdfStream = File.OpenRead(pdfPath);
            }


            try
            {
                using (pdfStream)
                {
                    // Load PDF with PdfiumViewer (uses native pdfium for reliable rendering)
                    //LastPage
                    using (var doc = PdfDocument.Load(pdfStream))
                    {
                        if (doc.PageCount <= 0)
                        {
                            MessageBox.Show(this, "PDF contains no pages.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return data;
                        }

                        // Render the last page (choose another index if you want)
                        int pageIndex = Math.Max(0, 1 - 1);

                        // Desired DPI
                        int dpi = 300;

                        // Determine target pixel size from PDF page size (PdfiumViewer exposes PageSizes in points)
                        // PageSizes entries are in points (1 point = 1/72 inch)
                        var pageSize = doc.PageSizes[pageIndex]; // SizeF (width/height in points)
                        int pixelWidth = (int)Math.Ceiling(pageSize.Width / 72.0f * dpi);
                        int pixelHeight = (int)Math.Ceiling(pageSize.Height / 72.0f * dpi);

                        // Clamp to avoid extremely large bitmaps (adjust limit as needed)
                        const int maxDimension = 10000;
                        if (pixelWidth > maxDimension || pixelHeight > maxDimension)
                        {
                            double scale = Math.Min((double)maxDimension / pixelWidth, (double)maxDimension / pixelHeight);
                            pixelWidth = Math.Max(1, (int)(pixelWidth * scale));
                            pixelHeight = Math.Max(1, (int)(pixelHeight * scale));
                        }

                        // Render page to a Bitmap using Pdfium (includes annotations)
                        using (var rendered = doc.Render(pageIndex, pixelWidth, pixelHeight, dpi, dpi, PdfRenderFlags.Annotations))
                        {

                            rendered.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            data.CoverPageLocation = coverPageImageFilePath;
                            return data;
                            //MessageBox.Show(this, "Saved image: " + sfd.FileName, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                // Show full exception to aid diagnosis of native/pdfium issues
                MessageBox.Show(this, "Error processing PDF: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return data;
            }



        }


        private void PrintPackingList(int vClientOrderId)
        {
            MessageBox.Show("Packing slip printing is currently unavailable. Please contact a supervisor.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //var sqlClient = new SQLCustomClient();
            //sqlClient.CommandText(@"Select MO.Invno,MO.CoverPreviewUrl,MO.ShipName,MO.ShipAddr,MO.ShipAddr2,MO.ShipCity,MO.ShipState,'*MXB'+CAST(MO.Invno AS varchar)+'YB*' AS BarCode
            //                            ,MO.ShipZip,MO.OrderNumber,MO.ClientOrderId,MO.Copies,Mo.Pages,Mo.Description,Mo.ItemCode,MO.JobId,MO.ItemId, SC.ShipName AS ShipMethod,SC.Carrier,CD.MxbLocation AS CoverLocation,WD.MxbLocation As BookLocation
            //                            FROM MixbookOrder MO
            //                            Left Join ShipCarriers SC On MO.ShipMethod=SC.ShipAlias
            //                            Left Join CoverDetail CD On MO.Invno=CD.Invno AND CD.DescripId IN (Select TOP 1 DescripId From coverdetail where  COALESCE(mxbLocation,'')!='' AND Invno=MO.Invno  Order by DescripId desc )
            //                            Left Join WipDetail WD On MO.Invno=WD.Invno AND WD.DescripId IN (Select TOP 1 DescripId From wipdetail where  COALESCE(mxbLocation,'')!='' AND Invno=MO.Invno  Order by DescripId desc ) 
            //                            Where ClientOrderId=@ClientOrderId");
            //sqlClient.AddParameter("@ClientOrderId", vClientOrderId);
            //var result = sqlClient.SelectMany<MixbookPackingSlip>();
            //if (result.IsError || result.Data == null)
            //{
            //    MbcMessageBox.Error("Failed to retrieve order, packing slip could not be printed");
            //    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to print packing list:" + result.Errors[0].DeveloperMessage);
            //    return;
            //}
            //var packingSlipData = (List<MixbookPackingSlip>)result.Data;
            //reportViewer2.LocalReport.DataSources.Clear();
            //reportViewer2.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixBookPkgList.rdlc";
            //reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("dsMxPackingSlip", packingSlipData));
            //reportViewer2.RefreshReport();
        }
        private void PrintRemakeTicket(int vInvno)
        {

            var sqlClient = new SQLCustomClient().CommandText(@"
                        Select  TO1.Invno
                ,TO1.ShipName
                ,TO1.ClientOrderId
                ,TO1.RequestedShipDate
                ,TO1.Description
                ,TO1.Copies,TO1.Pages
               ,TO1. CoverURL
                ,TO1.BookBlockURL
                ,TO1.Backing,TO1.OrderReceivedDate,PrintergyFile
                ,TO1.ProdInOrder
                ,CAST(TO1.Invno as varchar)+'   X'+CAST(ProdInOrder as varchar) AS DSInvno             
                ,(Select Sum(Copies) from TukiosOrder where Clientorderid=TO1.clientOrderid )As NumToShip 
                ,'*MXB'+CAST(TO1.Invno as varchar)+'SC*' AS SCBarcode
                              
                ,'*MXB'+CAST(TO1.Invno as varchar)+'YB*' AS YBBarcode
                ,W.Rmbto AS RemakeDate
                ,W.Rmbtot As RemakeTotal
                ,wd.invno
                 ,Case

                        when (ProdCopies>3 )  Then

                        CASE
                        When  ProdCopies % 4=0 Then
                        ProdCopies/4

                        When ProdCopies % 4>0 Then
                        (ProdCopies/4)+1
                        End
                       else
                        ProdCopies
                        End AS LargePressQty

            ,Case
              when ProdCopies>4 Then
           		ProdCopies/1
            else
                ProdCopies
            End AS SmallPressQty

                From TukiosOrder TO1 LEFT JOIN WIP W ON TO1.Invno=W.INVNO
                Left Join (Select * From WipDetail)Wd On W.Invno=wd.invno
                Where TO1.Invno=@Invno
                    ");
            sqlClient.AddParameter("@Invno", vInvno);
            var result = sqlClient.Select<TukiosRemakeTicketQuery>();
            if (result.IsError)
            {
                MbcMessageBox.Error("Failed to retrieve order, remake ticket could not be printed");
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to retrieve order, tukios remake ticket could not be printed:" + result.Errors[0].DeveloperMessage);
                return;
            }
            if (result.Data == null)
            {
                MbcMessageBox.Error("There are no records availble to print.");
                return;
            }

            var remakeData = (TukiosRemakeTicketQuery)result.Data;
            if (remakeData != null)
            {
                remakeData = this.SetPageImage(remakeData);
                string imagePath1Param = null;
                string imagePath2Param = null;
                string imagePath3Param = null;
                imagePath1Param = new Uri(remakeData.FirstPageLocation).AbsoluteUri; // yields file://...
                imagePath2Param = new Uri(remakeData.LastPageLocation).AbsoluteUri; // yields file://..
                imagePath3Param = new Uri(remakeData.CoverPageLocation).AbsoluteUri; // yields file://..
                reportViewer3.LocalReport.DataSources.Clear();
                RemakeTicketQueryBindingSource.DataSource = remakeData;
                try
                {
                    reportViewer3.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.TukiosRemakeTicketSingle.rdlc";
                    reportViewer3.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", RemakeTicketQueryBindingSource));
                    reportViewer3.LocalReport.EnableExternalImages = true;
                    ReportParameter parameter = new ReportParameter("ImagePath", imagePath1Param ?? string.Empty);
                    ReportParameter parameter2 = new ReportParameter("ImagePath2", imagePath2Param ?? string.Empty);
                    ReportParameter parameter3 = new ReportParameter("ImagePath3", imagePath3Param ?? string.Empty);//path to image

                    reportViewer3.LocalReport.SetParameters(new ReportParameter[] { parameter, parameter2, parameter3 });
                    this.reportViewer3.RefreshReport();
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);

                }
            }
            else
            {
                MbcMessageBox.Hand("There were no records found to print.", "No Records");
            }

        }


        private void SetJobTicketPrinted()
        {

            var sqlClient = new SQLCustomClient().CommandText(@"Update TukiosOrder Set JobTicketPrinted=@SetJobTicketPrinted Where Invno=@Invno");


            var vInvno = this.Invno.ToString();
            sqlClient.ClearParameters();
            sqlClient.AddParameter("@Invno", vInvno);
            sqlClient.AddParameter("@SetJobTicketPrinted", 1);
            var updateResult = sqlClient.Update();

        }
        private void SetRemakeTicketPrinted()
        {
            var sqlClient = new SQLCustomClient().CommandText(@"Update TukiosOrder Set RemakeTicketPrinted=@RemakeTicketPrinted,RemakePrintedBy=@RemakePrintedBy Where Invno=@Invno");
            string _userIntials = "";
            InputBox.Show("User Intials", "Enter your intials", ref _userIntials);

            var vInvno = this.Invno.ToString();
            sqlClient.ClearParameters();
            sqlClient.AddParameter("@Invno", vInvno);
            sqlClient.AddParameter("@RemakeTicketPrinted", 1);
            sqlClient.AddParameter("@RemakePrintedBy", _userIntials);
            var updateResult = sqlClient.Update();

        }
        #endregion


        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            OrderIdSearch();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OrderNameSearch();
        }
        private void itemIdToolStripBtn_Click(object sender, EventArgs e)
        {
            InvnoSearch();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            GroupIdSearch();
        }
        private void btnTukiosPkgList_Click(object sender, EventArgs e)
        {

            int vClientOrderId = 0;
            int.TryParse(orderIdLabel1.Text, out vClientOrderId);
            if (vClientOrderId == 0)
            {
                MbcMessageBox.Error("Client Id is not in proper format");
                return;
            }
            PrintPackingList(vClientOrderId);
        }
        private void reportViewer2_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            MessageBox.Show("Packing slip rendering is currently unavailable. Please contact a supervisor.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Cursor.Current = Cursors.WaitCursor;
            //Application.DoEvents();
            //PrinterSettings printerName = new PrinterSettings();
            //string printer = printerName.PrinterName;
            //DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN

            //var result = dp.Export(reportViewer2.LocalReport, printer, 1, false);

            //if (result.IsError)
            //{
            //    var errorResult = MessageBox.Show("Printing Error:" + result.Errors[0].ErrorMessage, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Printing Error:" + result.Errors[0].ErrorMessage);
            //}

            //Cursor.Current = Cursors.Default;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (pnlOrder.Enabled == true)
            {
                pnlOrder.Enabled = false;
            }
            else { pnlOrder.Enabled = true; }

        }
        private void btnDownloadFiles_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(orderIdLabel1.Text))
            {
                var sqlClient = new SQLCustomClient();
                sqlClient.CommandText(@"Update TukiosOrder Set FilesDownloaded=0 where ClientOrderId=@ClientOrderId");
                sqlClient.AddParameter("@ClientOrderId", orderIdLabel1.Text);
                var result = sqlClient.Update();
                if (result.IsError)
                {
                    MbcMessageBox.Error("Failed to iniate download of files, try again or contact developer.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to iniated download of files:" + result.Errors[0].DeveloperMessage);
                    return;
                }
                MbcMessageBox.Information("Files are marked to be downloaded. Check for them in 15 minutes.");
            }
        }





        private void btnRemake_Click(object sender, EventArgs e)
        {
            int vInvno = 0;
            int.TryParse(invnoLabel1.Text, out vInvno);
            if (Invno == 0)
            {
                MbcMessageBox.Error("Invoice number is not valid");
                return;
            }
            if (orderStatusLabel2.Text.ToUpper() == "CANCELLED" || orderStatusLabel2.Text.ToUpper() == "HOLD")
            {
                MbcMessageBox.Information("Order is on hold.", "HOLD");
                return;
            }
            PrintRemakeTicket(vInvno);
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            PrinterSettings printerName = new PrinterSettings();
            string printer = printerName.PrinterName;
            DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN

            var result = dp.Export(reportViewer1.LocalReport, printer, 1, false);

            if (result.IsError)
            {
                var errorResult = MessageBox.Show("Printing Error:" + result.Errors[0].ErrorMessage, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Printing Error:" + result.Errors[0].ErrorMessage);
            }
            Cursor.Current = Cursors.Default;
        }

        private void purgeStripButton2_Click(object sender, EventArgs e)
        {
            if (orderIdLabel1.Text == "") { return; }

            var dialogResult = MessageBox.Show("This will remove all traces of this record from the system, are you sure you want to do this?", "Purge", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dialogResult == DialogResult.Yes)
            {

                var sqlClient = new SQLCustomClient();
                sqlClient.CommandText(@"Delete From TukiosOrder Where ClientOrderId=@ClientOrderId");
                sqlClient.AddParameter("@ClientOrderId", orderIdLabel1.Text);
                var deleteResult = sqlClient.Delete();
                if (deleteResult.IsError)
                {
                    MbcMessageBox.Error("Failed to purge order");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to purge order" + deleteResult.Errors[0].DeveloperMessage);
                    return;
                }
                sqlClient.ClearParameters();
                sqlClient.CommandText("Delete From Produtn Where TukiosClientOrderId=@ClientOrderId");
                sqlClient.AddParameter("@ClientOrderId", orderIdLabel1.Text);
                var deleteResult1 = sqlClient.Delete();
                if (deleteResult1.IsError)
                {
                    MbcMessageBox.Error("Failed to purge Production record.");
                    return;
                }
                sqlClient.ClearParameters();
                sqlClient.CommandText("Delete From Wip Substring(CONVERT(varchar,Invno),1,7)=@Invno");
                sqlClient.AddParameter("@Invno", orderIdLabel1.Text.Substring(0, 7));
                var deleteResult11 = sqlClient.Delete();
                if (deleteResult11.IsError)
                {
                    MbcMessageBox.Error("Failed to purge Wip records.");
                    return;
                }
                sqlClient.ClearParameters();
                sqlClient.CommandText("Delete From WipDetail Substring(CONVERT(varchar,Invno),1,7)=@Invno");
                sqlClient.AddParameter("@Invno", orderIdLabel1.Text.Substring(0, 7));
                var deleteResult111 = sqlClient.Delete();
                if (deleteResult111.IsError)
                {
                    MbcMessageBox.Error("Failed to purge Wip records.");
                    return;
                }
                sqlClient.ClearParameters();
                sqlClient.CommandText("Delete From Cover Substring(CONVERT(varchar,Invno),1,7)==@Invno");
                sqlClient.AddParameter("@Invno", orderIdLabel1.Text.Substring(0, 7));
                var deleteResult11111 = sqlClient.Delete();
                if (deleteResult11111.IsError)
                {
                    MbcMessageBox.Error("Failed to purge cover records.");
                    return;
                }
                sqlClient.ClearParameters();
                sqlClient.CommandText("Delete From CoverDetail Substring(CONVERT(varchar,Invno),1,7)==@Invno");
                sqlClient.AddParameter("@Invno", orderIdLabel1.Text.Substring(0, 7));
                var deleteResult1111 = sqlClient.Delete();
                if (deleteResult1111.IsError)
                {
                    MbcMessageBox.Error("Failed to purge cover records.");
                    return;
                }
                MbcMessageBox.Information("Order has been purged");
                this.OrderId = "";
                Fill();
            }
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(invnoLabel1.Text) || string.IsNullOrEmpty(orderStatusLabel2.Text))
            {
                return;
            }
            var sqlClient = new SQLCustomClient();
            string status = "";
            if (orderStatusLabel2.Text == "Hold" || orderStatusLabel2.Text == "On Hold")
            {
                sqlClient.AddParameter("@OrderStatus", "In Process");
                status = "In Process";
            }
            else if (orderStatusLabel2.Text == "In Process")
            {
                sqlClient.AddParameter("@OrderStatus", "On Hold");
                status = "On Hold";

            }
            else
            {
                MbcMessageBox.Information("Status can not be changed if Cancelled or Shipped.");
                return;
            }

            sqlClient.CommandText("Update TukiosOrder Set TukiosOrderStatus=@OrderStatus Where ClientOrderId=@ClientOrderId");
            sqlClient.AddParameter("@ClientOrderId", orderIdLabel1.Text);
            var result = sqlClient.Update();
            if (result.IsError)
            {
                MbcMessageBox.Error("Failed to change status:" + result.Errors[0].DeveloperMessage);
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to change hold status:" + result.Errors[0].DeveloperMessage);
                return;
            }
            MbcMessageBox.Exclamation("Status has been changed to " + status);
            Fill();
        }

        private void cmdJobTicket_Click(object sender, EventArgs e)
        {
            if (orderStatusLabel2.Text == "CANCELLED" || orderStatusLabel2.Text == "HOLD")
            {
                MbcMessageBox.Information("Order is on hold.", "HOLD");
                return;
            }
            PrintJobTicket();
        }

        private void reportViewer3_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            if (reportViewer3.LocalReport.ReportEmbeddedResource == "Mbc5.Reports.TukiosJobTicketSingle.rdlc")
            {
                try
                {

                    if (reportViewer3.PrintDialog() != DialogResult.Cancel)
                    {
                        SetJobTicketPrinted();
                    }
                }
                catch (Exception ex)
                {
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("PrintJobTicketSingle" + ex.Message);
                }
            }
            else
            {
                //Remake Ticket
                if (reportViewer3.PrintDialog() != DialogResult.Cancel)
                {
                    SetRemakeTicketPrinted();
                }
            }
        }

        private void pnlOrder_EnabledChanged(object sender, EventArgs e)
        {
            foreach (Control c in this.pnlOrder.Controls)
            {
                if (c is TextBox || c is ComboBox || c is CustomControls.DateBox)
                {
                    c.BackColor = Color.White;
                }
            }

        }

        private void btnCvrRemake_Click(object sender, EventArgs e)
        {
            Remake("CVR");
        }

        private void btnBkRemake_Click(object sender, EventArgs e)
        {
            Remake("BK");
        }



        private void coverStatusLabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ApplicationUser.UserName.ToUpper() == "TAMMY" || ApplicationUser.UserName.ToUpper() == "HILLARY")
            {
                var result = MessageBox.Show("Do you want to clear the cover status of this cover?", "Clear Cover Status", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);

                if (result == DialogResult.Yes)
                {
                    int vInvno = 0;
                    if (int.TryParse(invnoLabel1.Text, out vInvno))
                    {
                        var sqlclient = new SQLCustomClient().CommandText("Update TukiosOrder Set CoverStatus='' Where Invno=@Invno").AddParameter("Invno", vInvno).Update();
                        Fill();
                    }
                    else { MbcMessageBox.Error("Failed to parse Invoice number"); }

                }
            }
        }

        private void bookStatusLabel_Click(object sender, EventArgs e)
        {
            if (ApplicationUser.UserName.ToUpper() == "TAMMY" || ApplicationUser.UserName.ToUpper() == "HILLARY")
            {
                var result = MessageBox.Show("Do you want to clear the book status of this book?", "Clear book Status", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (result == DialogResult.Yes)
                {
                    int vInvno = 0;
                    if (int.TryParse(invnoLabel1.Text, out vInvno))
                    {
                        var sqlclient = new SQLCustomClient().CommandText("Update TukiosOrder Set BookStatus='' Where Invno=@Invno").AddParameter("Invno", vInvno).Update();
                        Fill();
                    }
                    else { MbcMessageBox.Error("Failed to parse Invoice number"); }
                }
            }
        }

        private void tukiosOrderStatusLabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ApplicationUser.UserName.ToUpper() == "TAMMY" || ApplicationUser.UserName.ToUpper() == "SA" || ApplicationUser.UserName.ToUpper() == "HILARY")
            {
                var result = MessageBox.Show("Do you want to reset to 'In Process'?", "Reset Status", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);

                if (result == DialogResult.Yes)
                {
                    int vInvno = 0;
                    if (int.TryParse(invnoLabel1.Text, out vInvno))
                    {
                        var sqlclient = new SQLCustomClient().CommandText("Update TukiosOrder Set TukiosOrderStatus='In Process' Where Invno=@Invno").AddParameter("Invno", vInvno).Update();
                        Fill();
                    }
                    else { MbcMessageBox.Error("Failed to parse Invoice number"); }

                }
            }
        }

        private void btnEmailTrk_Click(object sender, EventArgs e)
        {
            string vBody = @"The tracking numbers for order <b>#" + orderIdLabel1.Text + @"</b> have been updated. You may not have all the tracking numbers. <br/><br/><b>" + trackingNumberTextBox.Text.Replace("|", ",") + "</b>";
            //new EmailHelper().SendOutLookEmail("#" + orderIdLabel1.Text + " Updated Tracking Numbers", "email@tukios.com", "", vBody, EmailType.System);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblHold_Paint(object sender, PaintEventArgs e)
        {
            if (orderStatusLabel2.Text.ToUpper() == "CANCELLED")
            {
                lblCanceled.Visible = true;
            }
            else { lblCanceled.Visible = false; }
            if (orderStatusLabel2.Text.ToUpper() == "HOLD")
            {
                lblHold.Visible = true;
            }
            else { lblHold.Visible = false; }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("This will totally remove the order from the system. Tukios is not notified. Do you still want to remove this order?", "Remove Order", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (result == DialogResult.Yes)
            {
                var sqlClient = new SQLCustomClient();
                sqlClient.CommandText("Delete from TukiosOrder where ClientOrderId=@ClientOrderId");
                sqlClient.AddParameter("@ClientOrderId", orderIdLabel1.Text);
                var deleteResult = sqlClient.Delete();
                if (deleteResult.IsError)
                {
                    Log.Error("Failed to remove order " + orderIdLabel1.Text + " reason:" + deleteResult.Errors[0].DeveloperMessage);
                    return;
                }
                MbcMessageBox.Information("Order has been removed.");
                tukiosOrderBindingSource.Clear();
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(orderIdLabel1.Text))
            {
                CancelOrder();
            }
        }

        private void CancelOrder()
        {
            MbcMessageBox.Information("This procedure cancels the order in DB only. It does not send a notification to Tukios.");

            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Update TukiosOrder Set TukiosOrderStatus='Cancelled',BookBlockUrl='',CoverUrl='',DateModified=GETDATE(),ModifiedBy=@ModifiedBy Where ClientOrderId=@ClientOrderId");
            sqlClient.AddParameter("@ClientOrderId", orderIdLabel1.Text);
            sqlClient.AddParameter("@ModifiedBy", ApplicationUser.Initials);
            var result = sqlClient.Update();
            if (result.IsError)
            {
                Log.Error("Failed to update tukios order " + orderIdLabel1.Text + ":" + JsonConvert.SerializeObject(result));
                MbcMessageBox.Error("Failed to update tukios order " + orderIdLabel1.Text + ":" + JsonConvert.SerializeObject(result));

                return;
            }
            sqlClient.ClearParameters();
            //going with clientid are 7 digits long
            sqlClient.CommandText(@"Update produtn Set KitRecvd=null, prshpdte=null,DateModified=GETDATE(),ModifiedBy='APICANCEL' Where TukiosClientOrderId=@ClientOrderId");
            sqlClient.AddParameter("@ClientOrderId", orderIdLabel1.Text);
            var prodResult = sqlClient.Update();
            if (prodResult.IsError)
            {
                Log.Error("Failed to update produtn for cancel order " + orderIdLabel1.Text + ":" + JsonConvert.SerializeObject(prodResult));

                MbcMessageBox.Error("Failed to update produtn for cancel order " + orderIdLabel1.Text + ":" + JsonConvert.SerializeObject(prodResult));
                return;

            }
            this.Fill();
            //var processingResult = new ApiProcessingResult();
            //var returnNotification = new MixbookNotification();
            //var bookId = ((DataRowView)tukiosOrderBindingSource.Current).Row["BookId"].ToString();
            //string reason = "";
            //InputBox.Show("Reason", "Enter a reason", ref reason);
            //returnNotification.Request.identifier = bookId;//neeeds to be set with bookId
            //returnNotification.Request.Status.occurredAt = DateTime.Now;
            //returnNotification.Request.Status.Value = "Cancelled";
            //returnNotification.Request.Status.message = reason;
            //var vReturnNotification = Serialize.ToXml(returnNotification);

        }

        public string AddEventLog(string jobId, string status, string note, string notificationXML, bool notified)
        {
            var retval = "0";
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Insert Into TukiosEventLog (JobId,DateCreated,ModifiedDate,StatusChangedTo,Notified,Note,NotificationXML) Values(@JobId,GetDate(),GETDATE(),@StatusChangedTo,@Notified,@Note,@NotificationXML)");
            sqlClient.AddParameter("@Jobid", jobId);
            sqlClient.AddParameter("@StatusChangedTo", status);
            sqlClient.AddParameter("@Notified", notified);
            sqlClient.AddParameter("@Note", note);
            sqlClient.AddParameter("@NotificationXML", notificationXML);
            var sqlResult = sqlClient.Insert();
            if (sqlResult.IsError)
            {
                Log.Error(sqlResult.Errors[0].ErrorMessage);


                return retval;
            }
            retval = sqlResult.Data;
            return retval;
        }

        private void tukiosOrderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tukiosOrderDataGridView.CurrentCell.ColumnIndex.Equals(6) || tukiosOrderDataGridView.CurrentCell.ColumnIndex.Equals(7))
                if (tukiosOrderDataGridView.CurrentCell != null && tukiosOrderDataGridView.CurrentCell.Value != null)
                {
                    try
                    { Process.Start(tukiosOrderDataGridView.CurrentCell.Value.ToString()); }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Url is invalid.");
                        Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Url is invalid.");
                    }
                }
            if (tukiosOrderDataGridView.CurrentCell.ColumnIndex.Equals(0))
            {

            }
        }



        private void tukiosOrderDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                e.Value = "Cover.pdf";
            }
            if (e.ColumnIndex == 7)
            {
                e.Value = "Book.pdf";
            }
        }
        private void tukiosOrderDataGridView_Enter(object sender, EventArgs e)
        {
            if (tukiosOrderDataGridView.CurrentRow != null)
            {
                try
                {
                    var value = (int)tukiosOrderDataGridView.CurrentRow.Cells[1].Value;
                    this.Invno = value;
                }
                catch (Exception ex) { Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "OrderDataGridview Enter Error,INVNO:" + Invno.ToString()); }
            }
        }

        private void tukiosOrderBindingSource_PositionChanged(object sender, EventArgs e)
        {
            int vIInvno = 0;


            try
            {
                if (tukiosOrderBindingSource.Current == null)
                {
                    return;
                }
                string vSInvno = ((DataRowView)tukiosOrderBindingSource.Current).Row["Invno"].ToString();
                int.TryParse(vSInvno, out vIInvno);
                this.Invno = vIInvno;
            }
            catch { }
        }

        private void tukiosOrderBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.SaveOrder();
        }

        private void tukiosOrderDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            int vInvno = this.Invno;
            string vSchcode = "01";
            frmProdutn frmProdutn = new frmProdutn(this.ApplicationUser, vInvno, vSchcode);
            frmProdutn.MdiParent = this.MdiParent;
            frmProdutn.Show();
            this.Cursor = Cursors.Default;
        }


    }
}
