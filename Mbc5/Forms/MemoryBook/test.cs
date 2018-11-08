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



        private void test_Load(object sender, EventArgs e)
        {
            foreach (Control C in this.Controls)
            {
                if (C.GetType() == typeof(IDataAdapter))
                {
                    var a = C;


                }
            }
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.custTableAdapter.Fill(this.dsSales.cust, schcodeToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void custBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.custBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsSales);

        }

        private void fillToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.custTableAdapter.Fill(this.dsSales.cust, schcodeToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void custBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.custBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsSales);

        }

        private void fillToolStripButton_Click_2(object sender, EventArgs e)
        {
            try
            {
                this.custTableAdapter.Fill(this.dsSales.cust, schcodeToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void custBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.custBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsSales);

        }

        private void fillToolStripButton_Click_3(object sender, EventArgs e)
        {
            try
            {
                this.custTableAdapter.Fill(this.dsSales.cust, schcodeToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
