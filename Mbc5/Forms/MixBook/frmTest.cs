using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mbc5.Forms.MixBook
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void mixBookOrderBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.mixBookOrderBindingSource.EndEdit();
            var b = this.mixBookOrderTableAdapter.Update(mixBookOrders);
             var a=this.tableAdapterManager.UpdateAll(this.mixBookOrders);

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.mixBookOrderTableAdapter.Fill(this.mixBookOrders.MixBookOrder, new System.Nullable<int>(((int)(System.Convert.ChangeType(clientOrderIdToolStripTextBox.Text, typeof(int))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            this.mixBookOrderTableAdapter.Connection.ConnectionString = "Data Source=sedswjpsql02;Initial Catalog=Mbc5; Persist Security Info =True;Trusted_Connection=True;";
        }
    }
}
