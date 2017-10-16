using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
