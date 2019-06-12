using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace Mbc5.Forms
{
    public partial class addresslabel : Form
    {
        public addresslabel()
        {
            InitializeComponent();
        }

        private void addresslabel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsCust.cust' table. You can move, or remove it, as needed.
            this.custTableAdapter.Fill(this.dsCust.cust,"038752");


         
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
