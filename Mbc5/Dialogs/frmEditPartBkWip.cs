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
        public frmEditPartBkWip(int id,int invno) {
            InitializeComponent();
            ID = id;
            Invno = invno;
            }
        public int ID { get; set; }
        public int Invno { get; set; }
        public bool Refill { get; set; }
        private void partBkDetailBindingNavigatorSaveItem_Click(object sender,EventArgs e) {
            this.Validate();
            this.partBkDetailBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsProdutn);

            }

        private void frmEditPartBkWip_Load(object sender,EventArgs e) {
            wipDescriptionsTableAdapter.Fill(dsProdutn.WipDescriptions,"PartBk");
            this.partBkDetailTableAdapter.FillBy(this.dsProdutn.PartBkDetail,Invno);
            var pos = partBkDetailBindingSource.Find("id",ID);
            if (pos > -1) {
               
                partBkDetailBindingSource.Position = pos;
                } else {
                MessageBox.Show("Record was not found,first available record is showing.","Patial Bk Detail Detail Record",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                }

            }
        }
    }
