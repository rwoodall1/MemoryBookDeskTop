﻿using System;
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

using BaseClass.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Mbc5.Forms.MemoryBook
{
    public partial class frmInvoicInq : BaseClass.Forms.bTopBottom
    {
        public frmInvoicInq(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
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
            var sqlClient = new SQLCustomClient();
            if (rdStatement.Checked)
            {
                //search for bad addresses
               
                sqlClient.CommandText(@"
                       SELECT I.schname AS InvoiceSchoolName,C.schname As CustomerSchname, I.schcode AS SchoolCode
                ,I.BalDue,P.invno As InvoiceNumber
                FROM Cust C Left Join Quotes Q On C.Schcode=Q.Schcode
                Left Join Produtn P On Q.Invno=P.Invno  
                Left Join Invoice I On Q.Invno =I.invno 
                WHERE(P.Shpdate IS NOT NULL )
                AND(I.BalDue > 0)
                AND (RTRIM(C.InvoiceAddr) != RTRIM(I.Schaddr)) 
                OR(RTRIM(C.InvoiceState) != RTRIM(I.Schstate))
                ORDER BY I.Schname
                ");
                var result = sqlClient.SelectMany<InvoiceCheck>();
                if (result.IsError)
                {
                    MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var badRecords = (List<InvoiceCheck>)result.Data;

                if (badRecords != null && badRecords.Count > 0)
                {
                    var errorList = new BindingList<InvoiceCheck>(badRecords);
                    dgAddressErrors.DataSource = errorList;
                    pnlError.Visible = true;
                    MessageBox.Show("The following sales records have customer information errors in them and need invoice over rides done on them before you can proceed.", "Bad Address");
                    return;
                }
                else { pnlError.Visible = false; }

                sqlClient.ClearParameters();
                sqlClient.CommandText(@"
                   
                SELECT P.ShpDate, I.Schname, I.Schcode, I.Baldue,
                 C.InvoiceEmail1, C.InvoiceEmail2,C.InvoiceEmail3,C.Contfname,C.Contlname,C.Bcontfname,C.Bcontlname
                ,P.Invno, Q.Holdpmt, CAST(1 AS bit) AS ToPrint
                FROM Invoice I
                Left Join Quotes Q On I.invno=Q.invno
                Left Join Cust C On Q.Schcode=C.Schcode
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
            }else if (rdReceived.Checked)
            {
                sqlClient.ClearParameters();
                sqlClient.CommandText(@"
                      SELECT P.ShpDate, C.Schname,C.Schcode,
                    C.InvoiceEmail1, C.InvoiceEmail2,C.InvoiceEmail3,C.Pin,C.Contfname,C.Contlname,C.Bcontfname,C.Bcontlname,
                    I.Invno,I.Baldue, Holdpmt, CAST(1 AS bit) AS ToPrint
                    FROM  cust C Left Join 
					Quotes Q ON C.schcode=Q.schcode
					LEFT JOIN invoice I ON Q.invno=I.invno
					Left JOIN Produtn P On Q.invno=P.invno      
                    WHERE Cast(P.kitrecvd AS Date)= @kitrecvd
                    ORDER BY C.Schname");

                sqlClient.AddParameter("@kitrecvd",dteRecvDte.Value.Date.ToShortDateString());
                var a = dteRecvDte.Value.Date.ToShortDateString();
                var invoiceResult1 = sqlClient.SelectMany<Invoice>();
                if (invoiceResult1.IsError)
                {
                    MessageBox.Show(invoiceResult1.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var vInvoices1 = (List<Invoice>)invoiceResult1.Data;

                if (vInvoices1 != null && vInvoices1.Count > 0)
                {
                    //var FinalInvoices = new List<Invoice>(vInvoices);
                    this.Invoices = vInvoices1;
                    dgInvoices.AutoGenerateColumns = false;
                    bsInvoices.DataSource = Invoices;
                }
                else
                {
                    MbcMessageBox.Information("No records found.");
                }
            }
            else { MbcMessageBox.Information("Please select a statement type.", ""); }

            

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

			var sqlClient = new SQLCustomClient();
			sqlClient.CommandText(@"
				SELECT C.SchName,C.SchCode,I.schaddr AS SchAddress,I.SchCity,I.SchZip As ZipCode,C.ContFName AS ContactFirstName,
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
			if (result.IsError) {
				
				processingResult.IsError = true;
				processingResult.Errors.Add(new ApiProcessingError(result.Errors[0].ErrorMessage, result.Errors[0].ErrorMessage,""));
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
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
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
                        Cursor.Current = Cursors.Default;
                        return;
					}
				}
				var emailHelper = new EmailHelper();
				string subject = "Memory Book Invoice # " + rec.Invno.ToString();
				;
				string body = "If you would like to pay online please go to https://online-pay.memorybook.com/school </br></br>If you do not have Adobe Reader to view your invoice you can download it here. http://get.adobe.com/reader/";
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
            Cursor.Current = Cursors.Default;
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
			var sqlClient = new SQLCustomClient();
			sqlClient.CommandText(@"
				SELECT C.SchName,C.SchCode,C.schaddr AS SchAddress,C.SchCity,C.SchZip As ZipCode,C.ContFName AS ContactFirstName,
				C.ContLname AS ContactLastName,I.nocopies AS NumberCopies,I.nopages AS NumberPages,
				I.Freebooks,I.Laminate,I.allclrck AS AllColor,I.contryear AS ContractYear,I.Payments,I.Ponum As PoNumber,
				I.Invno,I.Baldue,I.BeforeTaxTotal,I.SalesTax,I.Invtot,qtedate AS QuoteDate,ID.Descr As Description,ID.Price,ID.DiscPercent
				FROM Invoice I
				LEFT JOIN Cust C ON I.Schcode=C.Schcode
				LEFT JOIN Invdetail ID ON I.Invno=ID.Invno
				Where I.Invno IN (SELECT Item FROM @InvoiceList)
				
				");
			
			
			sqlClient.AddParameter("@InvoiceList", vInvoiceNoList);
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

        private void rdReceived_CheckedChanged(object sender, EventArgs e)
        {
            bsInvoices.Clear();
            if (rdReceived.Checked)
            {
                lblRecDte.Visible = true;
                dteRecvDte.Visible = true;
            }
            else {
                lblRecDte.Visible = false;
                dteRecvDte.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bsInvoices.Clear();
        }
    }
  
}
