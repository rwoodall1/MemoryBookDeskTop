using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BindingModels;

namespace Mbc5.Reports
{
    public partial class ReportTest : Form
    {
        public ReportTest()
        {
            InitializeComponent();
        }

        private void ReportTest_Load(object sender, EventArgs e)
        {
            this.custTableAdapter.Fill(this.dsInvoice.cust, "038752");
            this.invoiceTableAdapter.Fill(this.dsInvoice.invoice,1135);
            this.invdetailTableAdapter.Fill(this.dsInvoice.invdetail,1135);
            this.paymntTableAdapter.Fill(this.dsInvoice.paymnt, 1135);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var a = new BidInvoiceDetail()
            {
                Price=50.00M,
                DiscountPercentage=".05",
                Description="Test"
            };
            bindingSource1.DataSource = a;
this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
            reportViewer1.PrintDialog();
        }
    }
}
