using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using BaseClass;
using BaseClass.Core;
namespace Mbc5.Forms.MixBook
{
    public partial class frmMxInvoiceReport : BaseClass.frmBase
    {
        public frmMxInvoiceReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunReport();
        }
        private void RunReport()
        {
            var sqlClient = new SQLCustomClient();
            string cmd = @"Select M.ClientOrderId,M.ShipName,M.OrderReceivedDate,M.ShipDate,M.Code,M.Item
                ,M.Description,M.Pages,M.Copies,       ";
            sqlClient.CommandText(cmd);
        }
    }
}
