using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mbc5.Forms
{
    public partial class frmMessage : Form
    {
        public frmMessage(frmMain _frmMain)
        {
            InitializeComponent();
            this.Left = 20;
            this.Top = 30;
           
        }
        public frmMessage(frmMain _frmMain,string _msg)
        {
            InitializeComponent();
            this.Location = new Point(_frmMain.Location.X + (_frmMain.Width - this.Width) / 2, _frmMain.Location.Y + (_frmMain.Height - this.Height) / 2);
            this.lblMsg.Text = _msg;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
