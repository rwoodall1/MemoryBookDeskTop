using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mbc5.Forms
{
    public partial class frmBarScan : BaseClass.frmBase
    {
        public frmBarScan()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void txtDeptCode_Leave(object sender, EventArgs e)
        {
            string trkType = txtBarCode1.Text.Substring(9, 2);
            switch (trkType)
            {
                case "YB":

                    break;

                case "SC":

                    break;



            }
        }

        private void txtBarCode1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
