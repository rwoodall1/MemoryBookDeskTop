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
            dtShipDate.Format = DateTimePickerFormat.Long;
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
            var badRecords = (List<InvoiceCheck>)result;
            if (badRecords != null && badRecords.Count > 0)
            {
                var errorList = new BindingList<InvoiceCheck>(badRecords);
                dgAddressErrors.DataSource = errorList;
                pnlError.Visible = true;
                MessageBox.Show("The following sales records have customer information errors in them and need invoice over rides done on them before you can proceed.", "Bad Address");
                return;
            }
            else { pnlError.Visible = false; }

            sqlClient.ClearParamters();
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
            var vInvoices = (List<Invoice>)invoiceResult;

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
            var vInvoices = new BindingList<Invoice>();

            bsInvoices.DataSource = vInvoices;
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

        private void button4_Click(object sender, EventArgs e)
        {

            var a = this.Invoices;

            var aa = this.invoiceTableAdapter.Fill(dsInvoice.invoice, this.Invoices[0].Invno);
            var rr = this.invdetailTableAdapter.Fill(dsInvoice.invdetail, this.Invoices[0].Invno);

            paymntTableAdapter.Fill(dsInvoice.paymnt, this.Invoices[0].Invno);
            //https://stackoverflow.com/questions/2684221/creating-a-pdf-from-a-rdlc-report-in-the-background
            //    reportViewer1.LocalReport.Render
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

            //byte[] bytes = this.reportViewer1.LocalReport.Render(
            //    "PDF",
            //    null,
            //    out mimeType,
            //    out encoding,
            //    out extension,
            //    out streamIds,
            //    out warnings);

            //using (FileStream fs = new FileStream("F:\\output.pdf", FileMode.Create))
            //{
            //    fs.Write(bytes, 0, bytes.Length);
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // var a = this.Invoices;
            for (int i = 0; i < 2; i++)
            {
                var aa = this.invoiceTableAdapter.Fill(dsInvoice.invoice, this.Invoices[0].Invno);
                var rr = this.invdetailTableAdapter.Fill(dsInvoice.invdetail, this.Invoices[0].Invno);
                var aaaa = this.custTableAdapter.Fill(dsCust.cust, "038752");
                this.print();
            }

            //this.reportViewer1.RefreshReport();
        }
        private void print()
        {
            this.reportViewer1.RefreshReport();
        }
        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {

            
            DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN
            
            dp.Export(reportViewer1.LocalReport);
            //reportViewer1;
            //reportViewer1.Clear();
            //reportViewer1.LocalReport.ReleaseSandboxAppDomain();
        }

        private void reportViewer1_reportError(object sender, ReportErrorEventArgs e)
        {
            var a = 1;
        }

    
    }
  
}
