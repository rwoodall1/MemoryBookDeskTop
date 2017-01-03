using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
namespace Mbc5.LookUpForms
{
    public partial class LkpWipDescriptions : BaseClass.Forms.bTopBottom
    {
        public LkpWipDescriptions(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator" }, userPrincipal)
        {
            InitializeComponent();
        }
        public DataTable TableVals { get; set; }
        private void wipDescriptionsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.wipDescriptionsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsProdutn);

        }

        private void LkpWipDescriptions_Load(object sender, EventArgs e)
        {
            DataTable vTable = new DataTable();
            DataColumn val = new DataColumn("val");
            val.DataType= System.Type.GetType("System.String");
            vTable.Columns.Add(val);
            DataRow row = vTable.NewRow();
            row["val"] = "WIP";
            vTable.Rows.Add(row);
            DataRow row1 = vTable.NewRow();
            row1["val"] = "Covers";
            vTable.Rows.Add(row1);
            TableVals = vTable;
            wipDescriptionsDataGridView.Columns[1].
            wipDescriptionsTableAdapter.FillAll(dsProdutn.WipDescriptions);
        }

        private void wipDescriptionsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

         
        }

       
    }
}
