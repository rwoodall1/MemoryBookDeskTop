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
        public frmquailtyHold(int numProducts,string location)
        {
            InitializeComponent();
            _qtyProducts = numProducts.ToString();
            _currrentlocation = location;
        }
        public string Location { get; set; }
        public string _currrentlocation { get; set; }
        public string _qtyProducts { get; set; }
        private void frmquailtyHold_Load(object sender, EventArgs e)
        {
            lblText.Text = lblText.Text +" "+ _qtyProducts;
            if (!string.IsNullOrEmpty(_currrentlocation))
            {
                lblCurLocation.Text = "Current Location:" + _currrentlocation;
            }
            else { lblCurLocation.Text = ""; }
      
        }

        private void lblText_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtLocation.Text.Length>3)
            {
                MessageBox.Show("Invalid Location");
                return;
            }
            if (button1.Text == "Yes")
            {
                button1.Text = "Save";
                pnlLocation.Visible = true;
                lblCurLocation.Focus();
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

        private void txtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (true)
            {
                button1.Text = "Yes";
                this.Location = txtLocation.Text;
                this.DialogResult = DialogResult.Yes;
                txtLocation.Text = "";
                pnlLocation.Visible = false;
            }
        }
    }
}
