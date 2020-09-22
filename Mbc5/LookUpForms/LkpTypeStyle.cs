using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using BaseClass;
using BaseClass.Core;
using NLog;
namespace Mbc5.LookUpForms
{


    public partial class LkpTypeStyle : BaseClass.Forms.bTopBottom
    {
        public LkpTypeStyle(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator" }, userPrincipal)
        {
            InitializeComponent();
        }

        private void lkpDdiscntBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
           

        }

        private void LkpLeadSource_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lookUp.lkTypeData' table. You can move, or remove it, as needed.
            this.lkTypeDataTableAdapter.Fill(this.lookUp.lkTypeData);
           
        }
        public override void Save(bool ShowSpinner)
        {
            //so call can be made from menu
            if (ShowSpinner)
            {
                basePanel.Visible = true;
                // backgroundWorker1.RunWorkerAsync("Save");
            }
            else
            {
                var result = Save();
                if (result.IsError)
                {
                    MbcMessageBox.Error(result.Errors[0].ErrorMessage);
                }

            }


        }
        public ApiProcessingResult<bool> Save()
        {
			var processingResult = new ApiProcessingResult<bool>();
            this.Validate();
            this.lkTypeDataBindingSource.EndEdit();
            try
            {
                this.lkTypeDataTableAdapter.Update(this.lookUp.lkTypeData);
                MessageBox.Show("Record Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //ex.ToExceptionless()
                //    .AddTags("Save Error")
                //    .Submit();
                MessageBox.Show("Error saving record:"+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
				processingResult.IsError = true;
				processingResult.Errors.Add(new ApiProcessingError("Error saving record:" + ex.Message, "Error saving record:" + ex.Message,""));
            }
            return processingResult;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void LkpTypeStyle_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.lkTypeDataBindingSource.EndEdit();
            if (this.lookUp.HasChanges())
            {
                DialogResult val = MessageBox.Show("Do you want to save your changes?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);
                if (val == DialogResult.Yes)
                {
                    this.Save();
                }
                else if (val == DialogResult.No)
                {
                    //do nothing close
                }
                else if (val == DialogResult.Cancel)
                {
                    e.Cancel = true;//stay on form
                }
            }
        }
    }
}