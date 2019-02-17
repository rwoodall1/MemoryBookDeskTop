using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Mbc5.CrystalReports;
using BaseClass.Classes;
using BindingModels;
using Microsoft.Reporting.WinForms;
namespace Mbc5.Forms {
	public partial class test : Form {
		public test() {
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			var sqlClient = new SQLCustomClient();
			sqlClient.CommandText(@"
				SELECT C.SchName,C.SchCode,I.Invno,I.Baldue,I.BeforeTaxTotal,I.SalesTax,I.Invtot,qtedate AS QuoteDate,ID.Descr AS Description,ID.Price,ID.DiscPercent
				FROM Invoice I
				LEFT JOIN Cust C ON I.Schcode=C.Schcode
				LEFT JOIN Invdetail ID ON I.Invno=ID.Invno
				Where I.Invno=81551
				
				");
			var result = sqlClient.SelectMany<FullInvoice>();
			if (result.IsError) {
				return;
			}
			var InvoiceData = result.Data;
			FullInvoiceBindingSource.DataSource = InvoiceData;
			reportViewer1.RefreshReport();

			
			//ReportDocument cryRpt = new ReportDocument();
			//cryRpt.Load("F:\\InetPub\\wwwroot\\MemoryBook\\MemoryBookDeskTop\\Mbc5\\CrystalReports\\MultiInvoice.rpt");

			//crystalReportViewer1.ReportSource = cryRpt;
			//crystalReportViewer1.Refresh();
		}

		private void test_Load(object sender, EventArgs e) {
			//this.invoiceTableAdapter.Fill(dsInvoice.invoice, 81551);
			//var rr = this.invdetailTableAdapter.Fill(dsInvoice.invdetail, 81551);

		//Mbc5.CrystalReports.InvoiceTest report = new Mbc5.CrystalReports.InvoiceTest();
		//	var a = dsInvoice.Tables["invoice"];
	
		//	report.SetDataSource(dsInvoice.Tables["invoice"]);
			//crystalReportViewer1.ReportSource = report;
			//crystalReportViewer1.Refresh();
		}

		private void reportViewer1_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e) {
			var a = 1;
		}

		private void reportViewer1_ReportError(object sender, Microsoft.Reporting.WinForms.ReportErrorEventArgs e) {
			var b = 1;
		}
	}
}
