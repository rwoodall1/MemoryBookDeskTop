using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using NLog;
namespace Mbc5.LookUpForms
{
   

    public partial class LkpDiscount : BaseClass.Forms.bTopBottom
    {
        public LkpDiscount(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator" }, userPrincipal)
        {
            InitializeComponent();
        }

        private void lkpDdiscntBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lkpDdiscntBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.lookUp);

        }

        private void LkpDiscount_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lookUp.LkpDdiscnt' table. You can move, or remove it, as needed.
            this.lkpDdiscntTableAdapter.Fill(this.lookUp.LkpDdiscnt);

        }
    }
}
