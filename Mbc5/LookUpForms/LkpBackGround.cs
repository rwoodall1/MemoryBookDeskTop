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


    public partial class LkpBackGround : BaseClass.Forms.bTopBottom
    {
        public LkpBackGround(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator" }, userPrincipal)
        {
            InitializeComponent();
        }

       

        private void LkpLeadSource_Load(object sender, EventArgs e)
        {
          
            // TODO: This line of code loads data into the 'lookUp.lkTypeData' table. You can move, or remove it, as needed.
            this.lkpBackGroundTableAdapter.Fill(this.lookUp.lkpBackGround);
           
        }
        public override bool Save()
        {
            bool retval = true;
            this.Validate();
            this.lkpBackGroundBindingSource.EndEdit();
            try
            {
                this.lkpBackGroundTableAdapter.Update(lookUp.lkpBackGround);
                
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

        private void LkpBackGround_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.lkpBackGroundBindingSource.EndEdit();
            if (this.lookUp.HasChanges())
            {
                DialogResult val = MessageBox.Show("Do you want to save your changes?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);
                if (val == DialogResult.Yes)
                {
                    this.Save();
                }else if (val == DialogResult.No)
                {
                   //do nothing close
                }else if (val == DialogResult.Cancel)
                {
                    e.Cancel = true;//stay on form
                }
            }
        }
    }
}