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
		private void test_Load(object sender, EventArgs e) {
			//this.invoiceTableAdapter.Fill(dsInvoice.invoice, 81551);
			//var rr = this.invdetailTableAdapter.Fill(dsInvoice.invdetail, 81551);

		//Mbc5.CrystalReports.InvoiceTest report = new Mbc5.CrystalReports.InvoiceTest();
		//	var a = dsInvoice.Tables["invoice"];
	
		//	report.SetDataSource(dsInvoice.Tables["invoice"]);
			//crystalReportViewer1.ReportSource = report;
			//crystalReportViewer1.Refresh();
		}

		
	}
}
