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
using System.Configuration;
using Mbc5.Classes;
namespace Mbc5.LookUpForms
{
    public partial class LkpWipDescriptions : BaseClass.Forms.bTopBottom
    {
        public LkpWipDescriptions(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator" }, userPrincipal)
        {
            InitializeComponent();
        }
        public DataTable TableVals { get; set; }
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
       private ApiProcessingResult<bool> Save()          
        {
			var processingResult = new ApiProcessingResult<bool>();
           this.Validate();
            this.wipDescriptionsBindingSource.EndEdit();
            try
            {
              this.tableAdapterManager.UpdateAll(this.dsProdutn);
            }catch(Exception ex)
            {
                
                MessageBox.Show("Error saving record:"+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
				processingResult.IsError = true;
				processingResult.Errors.Add(new ApiProcessingError("Error saving record:" + ex.Message, "Error saving record:" + ex.Message,""));
            }
            return processingResult;
        }
        public override void Delete()
        {
            MessageBox.Show("Delete is not permitted for this table.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public override void Cancel()
        {
            wipDescriptionsBindingSource.CancelEdit();
        }
        override public bool Add()
        {
            wipDescriptionsBindingSource.AddNew();
			return true;
		}
        private void wipDescriptionsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Save();

        }
        private void SetConnectionString()
        {
         
            wipDescriptionsTableAdapter.Connection.ConnectionString = ApplicationConfig.DefaultConnectionString;
        }

        private void LkpWipDescriptions_Load(object sender, EventArgs e)
        {
            this.SetConnectionString();
			try {wipDescriptionsTableAdapter.FillAll(dsProdutn.WipDescriptions); }catch(Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
            
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbFilterVal.SelectedText))
            { wipDescriptionsBindingSource.Filter = "tablename='" + cmbFilterVal.SelectedText+"'"; }
            else { wipDescriptionsBindingSource.RemoveFilter(); }
                 
        }

        private void LkpWipDescriptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dsProdutn.HasChanges())
            {
               var result= MessageBox.Show("There are unsaved changes. Do you wish to save the record?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Save();
                }
            }
        }
    }
}
