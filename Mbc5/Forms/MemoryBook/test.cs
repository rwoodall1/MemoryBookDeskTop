using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mbc5.Forms.MemoryBook
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
         var a= quotesTableAdapter.Update(dsSales.quotes);
          
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            

        }

        private void test_Load(object sender, EventArgs e)
        {
            try
            {
                this.quotesTableAdapter.Fill(this.dsSales.quotes,"038752");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            
                var pos = quotesBindingSource.Find("invno", "81512");
                if (pos > -1)
                {
                    quotesBindingSource.Position = pos;
                }
                else
                {
                    MessageBox.Show("Invoice number was not found.", "Invoice#", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.quotesBindingSource.EndEdit();
            var a = quotesTableAdapter.Update(dsSales.quotes);
        }

        private void quotesBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.quotesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsSales);

        }

        private void fillToolStripButton_Click_1(object sender, EventArgs e)
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
