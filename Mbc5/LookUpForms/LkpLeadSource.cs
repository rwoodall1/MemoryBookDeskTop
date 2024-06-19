using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using BaseClass;
using Core;
using NLog;
namespace Mbc5.LookUpForms
{


    public partial class LkpLeadSource : BaseClass.Forms.bTopBottom
    {
        public LkpLeadSource(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator" }, userPrincipal)
        {
            InitializeComponent();
        }

        private void lkpDdiscntBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lkpLeadSourceBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.lookUp);

        }

        private void LkpLeadSource_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lookUp.lkpLeadSource' table. You can move, or remove it, as needed.
            this.lkpLeadSourceTableAdapter.Fill(this.lookUp.lkpLeadSource);

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
        public  ApiProcessingResult<bool> Save()
        {
			var processingResult = new ApiProcessingResult<bool>();
            this.Validate();
            this.lkpLeadSourceBindingSource.EndEdit();
            try
            {
                this.tableAdapterManager.UpdateAll(this.lookUp);
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
    }
}