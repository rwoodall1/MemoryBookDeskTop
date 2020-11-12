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
            Location = location;
        }
        public string Location { get; set; }
        public string _qtyProducts { get; set; }
        private void frmquailtyHold_Load(object sender, EventArgs e)
        {
            var vLoc = string.IsNullOrEmpty(Location) ? "No location available" : "  Location:" + Location;
            lblText.Text = "Do you wish to put this order on hold until any sibling orders are processed? Number of products in order is " + _qtyProducts +vLoc ;
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
