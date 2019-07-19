using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mbc5.Forms {
    public partial class Form1 : Form {
        public Form1()
        {
            InitializeComponent();
        }

        private void mquotesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.mquotesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsMSales);

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.mquotesTableAdapter.Fill(this.dsMSales.mquotes, ((int)(System.Convert.ChangeType(invnoToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mquotesBindingSource.EndEdit();
            var a = mquotesTableAdapter.Update(dsMSales.mquotes);

        }
    }
}
