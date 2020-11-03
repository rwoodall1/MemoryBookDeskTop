using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mbc5.Dialogs
{
    public partial class frmquailtyHold : Form
    {
        public frmquailtyHold(int numProducts)
        {
            InitializeComponent();
            _qtyProducts = numProducts.ToString();
        }
        public string Location { get; set; }
        public string _qtyProducts { get; set; }
        private void frmquailtyHold_Load(object sender, EventArgs e)
        {
            lblText.Text = lblText.Text +" "+ _qtyProducts;
        }

        private void lblText_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Yes")
            {
                button1.Text = "Save";
                pnlLocation.Visible = true;
            }
            else
            {
                button1.Text = "Yes";
                this.Location = txtLocation.Text;
                this.DialogResult = DialogResult.Yes;
                txtLocation.Text = "";
                pnlLocation.Visible = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
