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
    public partial class frmCancellationStatements : BaseClass.Forms.bTopBottom
    {
        public frmCancellationStatements(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
           
        }
        private void SetConnectionString()
        {
            

        }
        public frmMain frmMain { get; set; }
        public List<Cancellation> Cancellations { get; set; }

        private void frmCancellationStatements_Load(object sender, EventArgs e)
        {
            this.frmMain = (frmMain)this.MdiParent;

            dgCancellations.AutoGenerateColumns = false;
            dteStart.Value = DateTime.Now.AddDays(-30);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            bsCancellations.Clear();
            var sqlClient = new SQLCustomClient(ApplicationConfig.DefaultConnectionString);
           
                sqlClient.ClearParameters();
                sqlClient.CommandText(@"
                      SELECT P.ShpDate, C.Schname,C.Schcode,Cast(C.xeldate As Date)As CancelDate,
                    C.Schemail, C.Contemail,C.Bcontemail,C.Pin,C.Contfname,C.Contlname,C.Bcontfname,C.Bcontlname,
                    I.Invno,I.Baldue, Holdpmt, CAST(1 AS bit) AS ToPrint
                    FROM Invoice I
                    Left Join Quotes Q ON I.invno=Q.invno
					Left Join Cust C ON Q.schcode=C.schcode
				   Left JOIN Produtn P On Q.invno=P.invno      
                    WHERE Cast(C.xeldate As Date)>=@StartDate AND Cast(C.xeldate As Date)<=@EndDate AND Q.Invoiced=1 AND C.rbdate IS NULL  and P.kitrecvd IS NULL
                    ORDER BY C.Schname");

                sqlClient.AddParameter("@StartDate", dteStart.Value.Date.ToShortDateString());
               sqlClient.AddParameter("@EndDate", dteEnd.Value.Date.ToShortDateString());
            var cancelResult = sqlClient.SelectMany<Cancellation>();
                if (cancelResult.IsError)
                {
                    MessageBox.Show(cancelResult.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var vCancellations = (List<Cancellation>)cancelResult.Data;

                if (vCancellations != null && vCancellations.Count > 0)
                {
                 
                    this.Cancellations = vCancellations;
                    dgCancellations.AutoGenerateColumns = false;
                    bsCancellations.DataSource = Cancellations;
                }
      
           

            

        }

      

        private void chkPrint_CheckedChanged(object sender, EventArgs e)
        {
            var vCancellations = (List<Cancellation>)bsCancellations.List;

            foreach (Cancellation record in vCancellations)
            {
                record.ToPrint = chkPrint.Checked;
            }
            bsCancellations.DataSource = null;
            this.Cancellations = vCancellations;
            bsCancellations.DataSource = vCancellations;
        }
		private async Task<ApiProcessingResult<string>>CreatePdf(string vInvno) {
            var processingResult = new ApiProcessingResult<string>();
            if (Cancellations == null || this.Cancellations.Count == 0)
            {

                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("There are no cancellations to print.", "There are no cancellations to print.", ""));
                return processingResult;
            }

            var sqlClient = new SQLCustomClient(ApplicationConfig.DefaultConnectionString);
            sqlClient.CommandText(@"
				SELECT C.SchName,C.SchCode,C.schaddr AS SchAddress,C.SchCity,C.SchZip As ZipCode,C.ContFName AS ContactFirstName,
				C.ContLname AS ContactLastName,I.nocopies AS NumberCopies,I.nopages AS NumberPages,
				I.Freebooks,I.Laminate,I.allclrck AS AllColor,I.contryear AS ContractYear,I.Payments,I.Ponum As PoNumber,
				I.Invno,I.Baldue,I.BeforeTaxTotal,I.SalesTax,I.Invtot,qtedate AS QuoteDate,ID.Descr As Description,ID.Price,ID.DiscPercent
				FROM Invoice I
				LEFT JOIN Cust C ON I.Schcode=C.Schcode
				LEFT JOIN Invdetail ID ON I.Invno=ID.Invno
				Where I.Invno =@Invno
				
				");
            sqlClient.ClearParameters();
            sqlClient.AddParameter("@Invno", vInvno);
            var result = sqlClient.SelectMany<FullInvoice>();
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
					out warnings);
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

			if (Cancellations == null || this.Cancellations.Count == 0) {
				MbcMessageBox.Information("There are no Cancellations to print or email.", "Cancellations");
				return;
			}
			var badEmails = new List<string>();

			bool hasBadEmail = false;
			foreach (var rec in Cancellations) {
				var result = await CreatePdf(rec.Invno.ToString());
				if (result.IsError) {
					DialogResult dresult = MessageBox.Show("Invoice " + rec.Invno.ToString() + " Error:" + result.Errors[0].ErrorMessage + " Do you wish to continue?", "Invoices", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
					if (dresult == DialogResult.No) {
						return;
					}
				}
				var emailHelper = new EmailHelper();
				string subject = "Memory Book Invoice # " + rec.Invno.ToString();
				;
				string body = "If you would like to pay online please go to https://online-pay.memorybook.com/school </br></br>If you do not have Adobe Reader to view your invoice you can download it here. http://get.adobe.com/reader/";
				List<string> addresses = new List<string>();

				if (!string.IsNullOrEmpty(rec.Schemail)) {
					addresses.Add(rec.Schemail.Trim());
				}
				if (!string.IsNullOrEmpty(rec.Contemail)) {
					addresses.Add(rec.Contemail.Trim());
				}
				if (!string.IsNullOrEmpty(rec.Bcontemail)) {
					addresses.Add(rec.Bcontemail.Trim());
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
			var vCancellationNoList = new List<string>();
			if (Cancellations == null||this.Cancellations.Count == 0) {
				MbcMessageBox.Information("There are no cancellations to print.", "Cancellations");
				return;
			} else {
				foreach (Cancellation record in Cancellations) {
					if (record.ToPrint) {
                        vCancellationNoList.Add(record.Invno.ToString());
					}
				}
				if (vCancellationNoList == null|| vCancellationNoList.Count==0) {
					MbcMessageBox.Information("There are no Cancellations to print.", "Cancellations");
					return;
				}
			}
			var sqlClient = new SQLCustomClient(ApplicationConfig.DefaultConnectionString);
			sqlClient.CommandText(@"
				SELECT C.SchName,C.SchCode,I.schaddr AS SchAddress,I.SchCity,I.SchZip As ZipCode,C.ContFName AS ContactFirstName,
				C.ContLname AS ContactLastName,I.nocopies AS NumberCopies,I.nopages AS NumberPages,
				I.Freebooks,I.Laminate,I.allclrck AS AllColor,I.contryear AS ContractYear,I.Payments,I.Ponum As PoNumber,
				I.Invno,I.Baldue,I.BeforeTaxTotal,I.SalesTax,I.Invtot,qtedate AS QuoteDate,ID.Descr As Description,ID.Price,ID.DiscPercent
				FROM Invoice I
				LEFT JOIN Cust C ON I.Schcode=C.Schcode
				LEFT JOIN Invdetail ID ON I.Invno=ID.Invno
				Where I.Invno IN (SELECT Item FROM @InvoiceList)
				
				");
			
			
			sqlClient.AddParameter("@InvoiceList", vCancellationNoList);
			var result = sqlClient.SelectMany<FullInvoice>();
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

       

        private void button2_Click(object sender, EventArgs e)
        {
            bsCancellations.Clear();
        }

       
    }
  
}
