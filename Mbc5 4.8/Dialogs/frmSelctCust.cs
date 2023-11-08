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
    public partial class frmSelctCust : Form {
        //public frmSelctCust(DataTable dt)
            public frmSelctCust(List<SchoolNameSearchModel> records)
        {
            InitializeComponent();
            datagrid.AutoGenerateColumns = false;
            this.datagrid.DataSource = records;
            }
        public string retval { get; set; }
        private void datagrid_CellDoubleClick(object sender,DataGridViewCellEventArgs e) {
         retval= datagrid.Rows[datagrid.CurrentRow.Index].Cells["schcode"].Value.ToString();
            
            this.DialogResult = DialogResult.OK;
            this.Close();
            }
        }
    }
