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
namespace Mbc5.Forms.MemoryBook
{
    public partial class frmInvoicInq : BaseClass.Forms.bTopBottom
    {
        public frmInvoicInq(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
        }
        private void SetConnectionString()
        {
            frmMain frmMain = (frmMain)this.MdiParent;

        }
        public List<Invoice> Invoices { get; set; }
        private void frmInvoicInq_Load(object sender, EventArgs e)
        {
		

			dgInvoices.AutoGenerateColumns = false;
        }
        private void dtShipDate_ValueChanged(object sender, EventArgs e)
        {
            dtShipDate.Format = DateTimePickerFormat.Short;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //search for bad addresses
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"
                SELECT I.schname AS InvoiceSchoolName,C.schname As CustomerSchname, I.schcode AS SchoolCode
                ,I.BalDue,P.invno As InvoiceNumber
                FROM Cust C Left Join Quotes Q On C.Schcode=Q.Schcode
                Left Join Produtn P On Q.Invno=P.Invno  
                Left Join Invoice I On Q.Invno =I.invno 
                WHERE(P.Shpdate IS NOT NULL )
                AND(I.BalDue > 0)
                AND((RTRIM(C.Schname) != RTRIM(I.Schname)) 
                OR(RTRIM(C.Schaddr) != RTRIM(I.Schaddr)) 
                OR(RTRIM(C.Schstate) != RTRIM(I.Schstate)))
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
                C.Schemail, C.Contemail,C.Bcontemail,C.Contfname,C.Contlname,C.Bcontfname,C.Bcontlname
                ,P.Invno, Q.Holdpmt, CAST(1 AS bit) AS ToPrint
                FROM Cust C Left Join Quotes Q On C.Schcode=Q.Schcode
                Left Join Produtn P On Q.Invno=P.Invno  
                Left Join Invoice I On Q.Invno =I.invno 
                WHERE(P.Shpdate IS NOT NULL ) AND(I.Baldue > 0)
                ORDER BY I.Schname
                ");
            var invoiceResult = sqlClient.SelectMany<Invoice>();
            if (invoiceResult.IsError)
            {
                MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        }

        private void button2_Click(object sender, EventArgs e)
        {
			//this.print();
            //var vInvoices = new BindingList<Invoice>();

            //bsInvoices.DataSource = vInvoices;
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
		private void Test(string vInvno) {
			if (Invoices == null || this.Invoices.Count == 0) {
				MbcMessageBox.Information("There are no invoices to print.", "Invoices");
				return;
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
				Where I.Invno =@Invno
				
				");
			sqlClient.ClearParameters();
			sqlClient.AddParameter("@Invno", vInvno);
			var result = sqlClient.SelectMany<FullInvoice>();
			if (result.IsError) {
				MbcMessageBox.Error(result.Errors[0].ErrorMessage, "");
				return;
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
	

				byte[] bytes = this.reportViewer1.LocalReport.Render(
					"PDF",
					null,
					out mimeType,
					out encoding,
					out extension,
					out streamIds,
					out warnings);

			using (FileStream fs = new FileStream("C:\\Users\\rwoodall.WDFM\\Desktop\\B\\New folder\\" + vInvno + ".pdf", FileMode.Create)) {
				fs.Write(bytes, 0, bytes.Length);
				fs.Dispose();
			}
		}
        private void button4_Click(object sender, EventArgs e)
        {

			foreach (var rec in Invoices) {
				Test(rec.Invno.ToString());
			}
			//if (Invoices == null || this.Invoices.Count == 0) {
			//	MbcMessageBox.Information("There are no invoices to print.", "Invoices");
			//	return;
			//}

			//var sqlClient = new SQLCustomClient();
			//sqlClient.CommandText(@"
			//	SELECT C.SchName,C.SchCode,C.schaddr AS SchAddress,C.SchCity,C.SchZip As ZipCode,C.ContFName AS ContactFirstName,
			//	C.ContLname AS ContactLastName,I.nocopies AS NumberCopies,I.nopages AS NumberPages,
			//	I.Freebooks,I.Laminate,I.allclrck AS AllColor,I.contryear AS ContractYear,I.Payments,I.Ponum As PoNumber,
			//	I.Invno,I.Baldue,I.BeforeTaxTotal,I.SalesTax,I.Invtot,qtedate AS QuoteDate,ID.Descr As Description,ID.Price,ID.DiscPercent
			//	FROM Invoice I
			//	LEFT JOIN Cust C ON I.Schcode=C.Schcode
			//	LEFT JOIN Invdetail ID ON I.Invno=ID.Invno
			//	Where I.Invno =@Invno

			//	");
			//foreach (var rec in Invoices) {
			//	sqlClient.ClearParameters();
			//	sqlClient.AddParameter("@Invno", rec.Invno);
			//	var result = sqlClient.SelectMany<FullInvoice>();
			//		if (result.IsError) {
			//			MbcMessageBox.Error(result.Errors[0].ErrorMessage, "");
			//			return;
			//		}
			//		var InvoiceData = result.Data;
			//FullInvoiceBindingSource.DataSource = InvoiceData;

				//https://stackoverflow.com/questions/2684221/creating-a-pdf-from-a-rdlc-report-in-the-background

				//Warning[] warnings;
				//string[] streamIds;
				//string mimeType = string.Empty;
				//string encoding = string.Empty;
				//string extension = string.Empty;
				////string HIJRA_TODAY = "01/10/1435";
				//// ReportParameter[] param = new ReportParameter[3];
				////param[0] = new ReportParameter("CUSTOMER_NUM", CUSTOMER_NUMTBX.Text);
				////param[1] = new ReportParameter("REF_CD", REF_CDTB.Text);
				////param[2] = new ReportParameter("HIJRA_TODAY", HIJRA_TODAY);
				//var a=this.reportViewer1.

				//byte[] bytes = this.reportViewer1.LocalReport.Render(
				//	"PDF",
				//	null,
				//	out mimeType,
				//	out encoding,
				//	out extension,
				//	out streamIds,
				//	out warnings);

				//using (FileStream fs = new FileStream("C:\\Users\\rwoodall.WDFM\\Desktop\\B\\New folder\\" + rec.Invno.ToString()+".pdf", FileMode.Create)) {
				//	fs.Write(bytes, 0, bytes.Length);
				//	fs.Dispose();
				//}

			}
	

        private void button3_Click(object sender, EventArgs e)
        {
			if (Invoices==null||this.Invoices.Count == 0) {
				MbcMessageBox.Information("There are no invoices to print.", "Invoices");
				return;
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
			var vInvoiceNoList= new List<string>();
			foreach(Invoice record in Invoices) {
				vInvoiceNoList.Add(record.Invno.ToString());

			}
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
	}
  
}
