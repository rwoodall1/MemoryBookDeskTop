using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    [System.ComponentModel.DefaultBindingProperty("Date")]
    public partial class DateBox: UserControl
    {
        public string Date {
            get { if (txtbox.Text=="") {
                    return null;

                }
                else { return txtbox.Text; }

 }
            set { txtbox.Text = value; }
           }
        public DateTime? DateValue {
            get {
                if (txtbox.Text == "")
                {
                    return null;

                }
                else { return DateTime.Parse(txtbox.Text); }

            }
            set {
               
                txtbox.Text = value.ToString();
            }
        }
        public DateBox()
        {
            InitializeComponent();
            this.MinimumSize = new Size(114, 20);
        }

        private void btn_Click(object sender, EventArgs e)
        {
          
            dtp.Visible = true;
            dtp.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void dtp_CloseUp(object sender, EventArgs e)
        {
            txtbox.Text = dtp.Value.ToShortDateString();
            dtp.Visible = false;
        }

      

        private void txtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                txtbox.Text =null;
            }
        }

      

        
    }
}
