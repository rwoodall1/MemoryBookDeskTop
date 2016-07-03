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
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void quotesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.quotesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsSales);

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.quotesTableAdapter.Fill(this.dsSales.quotes, schcodeToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
