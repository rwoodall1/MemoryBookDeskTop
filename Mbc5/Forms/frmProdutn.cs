using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mbc5.Forms {
    public partial class frmProdutn : BaseClass.frmBase {
        public frmProdutn() {
            InitializeComponent();
            }

        private void produtnBindingNavigatorSaveItem_Click(object sender,EventArgs e) {
            this.Validate();
            this.produtnBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsProdutn);

            }

        private void fillToolStripButton_Click(object sender,EventArgs e) {
            try
                {
                this.produtnTableAdapter.Fill(this.dsProdutn.produtn,schcodeToolStripTextBox.Text);
                }
            catch (System.Exception ex)
                {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                }

            }
        }
    }
