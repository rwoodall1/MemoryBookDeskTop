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
    public partial class frmEditPartBkWip : Form {
        public frmEditPartBkWip() {
            InitializeComponent();
            }

        private void partBkDetailBindingNavigatorSaveItem_Click(object sender,EventArgs e) {
            this.Validate();
            this.partBkDetailBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsProdutn);

            }

        private void frmEditPartBkWip_Load(object sender,EventArgs e) {
            // TODO: This line of code loads data into the 'dsProdutn.PartBkDetail' table. You can move, or remove it, as needed.
            this.partBkDetailTableAdapter.Fill(this.dsProdutn.PartBkDetail);

            }
        }
    }
