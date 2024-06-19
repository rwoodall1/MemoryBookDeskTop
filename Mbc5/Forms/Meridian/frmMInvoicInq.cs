using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BindingModels;
using BaseClass.Classes;
using System.IO;
using Microsoft.Reporting.WinForms;
using Mbc5.Classes;
using BaseClass;
using System.Collections;

using Core;
using System.Threading;
using System.Threading.Tasks;

namespace Mbc5.Forms.MemoryBook
{
    public partial class frmMInvoicInq : BaseClass.Forms.bTopBottom
    {
        public frmMInvoicInq(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
        }
        private void SetConnectionString()
        {
            frmMain frmMain = (frmMain)this.MdiParent;

        }
        public frmMain frmMain { get; set; }
        public List<Invoice> Invoices { get; set; }
        private void frmInvoicInq_Load(object sender, EventArgs e)
        {
            frmMain frmMain = (frmMain)this.MdiParent;

            dgInvoices.AutoGenerateColumns = false;
        }
       

        private void btnSearch_Click(object sender, EventArgs e)
        {

            dgAddressErrors.DataSource = null;
            pnlError.Visible = false;

            bsInvoices.Clear();
            var sqlClient = new SQLCustomClient(ApplicationConfig.DefaultConnectionString);
                 sqlClient.ClearParameters();
                sqlClient.CommandText(@"
                   
                SELECT P.ShpDate, I.Schname, I.Schcode, I.Baldue,
                 C.SchEmail AS InvoiceEmail1, C.ContEmail AS InvoiceEmail2,C.BContEmail As InvoiceEmail3,C.Contfname,C.Contlname,C.Bcontfname,C.Bcontlname
                ,P.Invno, Q.Holdpmt, CAST(1 AS bit) AS ToPrint
                FROM MerInvoice I
                Left Join MQuotes Q On I.invno=Q.invno
                Left Join MCust C On Q.Schcode=C.Schcode
                Left Join Produtn P On Q.Invno=P.Invno  
                 WHERE(P.Shpdate IS NOT NULL ) AND(I.Baldue > 0)
                ORDER BY I.Schname
                ");
                var invoiceResult = sqlClient.SelectMany<Invoice>();
                if (invoiceResult.IsError)
                {
                    MessageBox.Show(invoiceResult.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var vInvoices = (List<Invoice>)invoiceResult.Data;

                if (vInvoices != null && vInvoices.Count > 0)
                {
                    //var FinalInvoices = new List<Invoice>(vInvoices);
                    this.Invoices = vInvoices;
                    dgInvoices.AutoGenerateColumns = false;
                    bsInvoices.DataSource = Invoices;
                }
                else { MbcMessageBox.Exclamation("No records were found.", ""); }
          
           
           
        }

      

        private void chkPrint_CheckedChanged(object sender, EventArgs e)
        {
            var vInvoices = (List<Invoice>)bsInvoices.List;

            foreach (Invoice record in vInvoices)
            {
                record.ToPrint = chkPrint.Checked;
            }
            bsInvoices.DataSource = null;
            this.Invoices = vInvoices;
            bsInvoices.DataSource = vInvoices;
        }
		private async Task<ApiProcessingResult<string>>CreatekPdf(string vInvno) {
			var processingResult = new ApiProcessingResult<string>();
			if (Invoices == null || this.Invoices.Count == 0) {
				
				processingResult.IsError = true;
				processingResult.Errors.Add(new ApiProcessingError("There are no invoices to print.", "There are no invoices to print.",""));
				return processingResult;
			}

			var sqlClient = new SQLCustomClient(ApplicationConfig.DefaultConnectionString);
			sqlClient.CommandText(@"
				SELECT I.InvName,I.SchCode,I.InvAddr,I.InvAddr2,I.InvCity,I.InvZip,I.InvState,I.ShpName,I.ShpAddr,I.ShpAddr2,I.ShpCity,I.ShpState,I.ShpZip,
                I.QteDate,I.Invno,I.InvNotes,I.ShpDate,I.PoNum,I.Contryear,I.FplnPrc,I.SubTotal,I.SchType,
                    I.SalesTax,I.ShpHandling,I.FplnTot,I.Payments,I.BalDue,I.Schtype,I.QtyTotal,I.NoPages,I.QtyTeacher,I.QtyStudent,I.Generic,I.TeBasePrc,
                    I.BasePrc,I.Basetot,ID.Descr,ID.UnitPrice,ID.DiscPercent,ID.Amount,ID.Quantity
				FROM MerInvoice I
				LEFT JOIN MerInvdetail ID ON I.Invno=ID.Invno
				Where I.Invno =@Invno
				
				");
			sqlClient.ClearParameters();
			sqlClient.AddParameter("@Invno", vInvno);
	
            var result = sqlClient.SelectMany<MerMultiInvoiceModel>();
            if (result.IsError)
            {

                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError(result.Errors[0].ErrorMessage, result.Errors[0].ErrorMessage, ""));
                return processingResult;
            }
            var InvoiceData = result.Data;
            FullInvoiceBindingSource.DataSource = InvoiceData;

            //https://stackoverflow.com/questions/2684221/creating-a-pdf-from-a-rdlc-report-in-the-background

            Warning[] warnings;
			string[] streamIds;
			string mimeType = string.Empty;
			string encoding = string.Empty;
			string extension = string.Empty;
			//string HIJRA_TODAY = "01/10/1435";
			// ReportParameter[] param = new ReportParameter[3];
			//param[0] = new ReportParameter("CUSTOMER_NUM", CUSTOMER_NUMTBX.Text);
			//param[1] = new ReportParameter("REF_CD", REF_CDTB.Text);
			//param[2] = new ReportParameter("HIJRA_TODAY", HIJRA_TODAY);
			try {
					this.reportViewer1.LocalReport.Refresh();
					byte[] bytes = this.reportViewer1.LocalReport.Render(
					"PDF",
                    null,
                    out mimeType,
                    out encoding,
                    out extension,
                    out streamIds,
                    out warnings
                    );
				var vPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
				var newPath = vPath.Substring(0, vPath.IndexOf("Mbc5") + 4) + "\\tmp\\"+ vInvno + ".pdf";
				using (FileStream fs = new FileStream(newPath, FileMode.Create)) {
						fs.Write(bytes, 0, bytes.Length);
						fs.Dispose();
					}
				processingResult.Data = newPath;
			}catch(Exception ex) {
				processingResult.IsError = true;
				processingResult.Errors.Add(new ApiProcessingError(ex.Message,ex.Message, ""));
			}
			return processingResult;
		}
		private async void button4_ClickAsync(object sender, EventArgs e) {

			if (Invoices == null || this.Invoices.Count == 0) {
				MbcMessageBox.Information("There are no invoices to print or email.", "Invoices");
				return;
			}
			var badEmails = new List<string>();

			bool hasBadEmail = false;
			foreach (var rec in Invoices) {
				var result = await CreatekPdf(rec.Invno.ToString());
				if (result.IsError) {
					DialogResult dresult = MessageBox.Show("Invoice " + rec.Invno.ToString() + " Error:" + result.Errors[0].ErrorMessage + " Do you wish to continue?", "Invoices", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
					if (dresult == DialogResult.No) {
						return;
					}
				}
				var emailHelper = new EmailHelper();
				string subject ="Meridian Student Planner Invoice # "+  rec.Invno.ToString();
				;
				string body ="If you would like to pay online please go to <a href=http://www.meridianplanners.com/Orders/PoPayCode.aspx> <font color=blue> Meridian Planners</font></a> Use the last 6 digits of your customer number from invoice and make sure you are in the correct school payment page.  </br></br>If you do not have Adobe Reader to view your invoice you can download it here. http://get.adobe.com/reader/";
				List<string> addresses = new List<string>();

				if (!string.IsNullOrEmpty(rec.InvoiceEmail1)) {
					addresses.Add(rec.InvoiceEmail1.Trim());
				}
				if (!string.IsNullOrEmpty(rec.InvoiceEmail2)) {
					addresses.Add(rec.InvoiceEmail2.Trim());
				}
				if (!string.IsNullOrEmpty(rec.InvoiceEmail3.Trim())) {
					addresses.Add(rec.InvoiceEmail3);
				}
				var attachments = new List<OutlookAttachemt>();
				var attachment = new OutlookAttachemt() {
					Path = result.Data,
					Name = rec.Invno.ToString() + "pdf"
				};
				attachments.Add(attachment);
				var emailResult = emailHelper.SendOutLookEmail(subject, addresses, new List<string>(), body, EmailType.Mbc, attachments);
				if (!emailResult) {
					hasBadEmail = true;
					badEmails.Add(rec.Invno.ToString());
				}
			}

			if (hasBadEmail) {
				var msg = "The following invoice numbers failed to be emailed out:" + string.Join(",", badEmails);
				MbcMessageBox.Information(msg, "Failed Invoice Emails");
			}
		}
        private void button3_Click(object sender, EventArgs e)
        {
			var vInvoiceNoList = new List<string>();
			if (Invoices==null||this.Invoices.Count == 0) {
				MbcMessageBox.Information("There are no invoices to print.", "Invoices");
				return;
			} else {
				foreach (Invoice record in Invoices) {
					if (record.ToPrint) {
						vInvoiceNoList.Add(record.Invno.ToString());
					}
				}
				if (vInvoiceNoList ==null||vInvoiceNoList.Count==0) {
					MbcMessageBox.Information("There are no invoices to print.", "Invoices");
					return;
				}
			}
			var sqlClient = new SQLCustomClient(ApplicationConfig.DefaultConnectionString);
			sqlClient.CommandText(@"
				SELECT I.InvName,I.SchCode,I.InvAddr,I.InvAddr2,I.InvCity,I.InvZip,I.InvState,I.ShpName,I.ShpAddr,I.ShpAddr2,I.ShpCity,I.ShpState,I.ShpZip,
                I.QteDate,I.Invno,I.InvNotes,I.ShpDate,I.PoNum,I.Contryear,I.FplnPrc,I.SubTotal,I.SchType,
                    I.SalesTax,I.ShpHandling,I.FplnTot,I.Payments,I.BalDue,I.Schtype,I.QtyTotal,I.NoPages,I.QtyTeacher,I.QtyStudent,I.Generic,I.TeBasePrc,
                    I.BasePrc,I.Basetot,ID.Descr,ID.UnitPrice,ID.DiscPercent,ID.Amount,ID.Quantity
				FROM MerInvoice I
				LEFT JOIN MerInvdetail ID ON I.Invno=ID.Invno
				Where I.Invno IN (SELECT Item FROM @InvoiceList)
				
				");
			
			
			sqlClient.AddParameter("@InvoiceList", vInvoiceNoList);
			var result = sqlClient.SelectMany<MerMultiInvoiceModel>();
			if (result.IsError) {
				MbcMessageBox.Error(result.Errors[0].ErrorMessage, "");
				return;
			}
			var InvoiceData = result.Data;
			FullInvoiceBindingSource.DataSource = InvoiceData;
			reportViewer1.RefreshReport();

		}
        
		
		private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {

			DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN

			var result = dp.Export(reportViewer1.LocalReport, "");

			if (result.IsError) {
				var errorResult = MessageBox.Show("Printing Error:" + result.Errors[0].ErrorMessage , "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				
			}

		}

		private void reportViewer1_reportError(object sender, ReportErrorEventArgs e)
        {
            
        }

		private void reportViewer1_ReportRefresh(object sender, CancelEventArgs e) {
		
		}

        private void frmInvoicInq_Activated(object sender, EventArgs e)
        {
            try { this.frmMain.HideSearchButtons(); } catch { }
        }

        private void rdReceived_CheckedChanged(object sender, EventArgs e)
        {
            bsInvoices.Clear();
            //if (rdReceived.Checked)
            //{
            //    lblRecDte.Visible = true;
            //    dteRecvDte.Visible = true;
            //}
            //else {
            //    lblRecDte.Visible = false;
            //    dteRecvDte.Visible = false;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bsInvoices.Clear();
        }
    }
  
}
