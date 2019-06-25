using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BindingModels;

namespace Mbc5.Dialogs {
    public partial class frmProdutnSelctCust : Form {
        //public frmSelctCust(DataTable dt)
            public frmProdutnSelctCust(List<ProdutnSchoolNameSearchModel> records)
        {
            InitializeComponent();
            datagrid.AutoGenerateColumns = false;
            this.datagrid.DataSource = records;
            }
        public int retval { get; set; }
        private void datagrid_CellDoubleClick(object sender,DataGridViewCellEventArgs e) {
         retval= (int)datagrid.Rows[datagrid.CurrentRow.Index].Cells["Invno"].Value;
            
            this.DialogResult = DialogResult.OK;
            this.Close();
            }

		private void datagrid_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue==13)
			{
				retval = (int)datagrid.Rows[datagrid.CurrentRow.Index].Cells["Invno"].Value;

				this.DialogResult = DialogResult.OK;
				this.Close();

			}

		}
	}
    }
