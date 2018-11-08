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


    public partial class LkpCustType : BaseClass.Forms.bTopBottom
    {
        public LkpCustType(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator" }, userPrincipal)
        {
            InitializeComponent();
        }

     
        private void LkpLeadSource_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lookUp.lkpCustType' table. You can move, or remove it, as needed.
            this.lkpCustTypeTableAdapter.Fill(this.lookUp.lkpCustType);
          
           
        }
        public override bool Save()
        {
            bool retval = true;
            this.Validate();
            this.lkpCustTypeBindingSource.EndEdit();
            try
            {
                this.lkpCustTypeTableAdapter.Update(this.lookUp.lkpCustType);
                MessageBox.Show("Record Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //ex.ToExceptionless()
                //    .AddTags("Save Error")
                //    .Submit();
                MessageBox.Show("Error saving record. The record was not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return retval;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            this.Save();
        }
    }
}