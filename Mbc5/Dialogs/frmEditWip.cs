using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mbc5.Dialogs {
    public partial class frmEditWip : Form {
        public frmEditWip() {
            InitializeComponent();
            }

        private void wipDetailBindingNavigatorSaveItem_Click(object sender,EventArgs e) {
            this.Validate();
            this.wipDetailBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsProdutn);

            }

        private void fillToolStripButton_Click(object sender,EventArgs e) {
            try {
                this.wipDetailTableAdapter.Fill(this.dsProdutn.WipDetail,new System.Nullable<int>(((int)(System.Convert.ChangeType(invnoToolStripTextBox.Text,typeof(int))))));
                } catch (System.Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                }

            }
        }
    }
