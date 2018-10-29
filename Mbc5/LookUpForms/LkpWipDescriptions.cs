﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using Exceptionless;
using Exceptionless.Models;
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
         override public bool Save()          
        {
            bool retval = true;
           this.Validate();
            this.wipDescriptionsBindingSource.EndEdit();
            try
            {
              this.tableAdapterManager.UpdateAll(this.dsProdutn);
            }catch(Exception ex)
            {
                ex.ToExceptionless()
                    .AddTags("Save Error")
                    .Submit();
                MessageBox.Show("Error saving record. The record was not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return retval;
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
            string AppConnectionString = "";
            var Environment = ConfigurationManager.AppSettings["Environment"].ToString();
            if (Environment == "DEV")
            {
                AppConnectionString = "Data Source=192.168.1.101; Initial Catalog=Mbc5; Integrated Security=True;User Id=sa;password=Briggitte1; Connect Timeout=5";
            }
            else if (Environment == "PROD")
            {
                AppConnectionString = "Data Source=10.37.32.49;Initial Catalog=Mbc5;Integrated Security=True;User Id = MbcUser; password = 3l3phant1; Connect Timeout=5";
            }
            wipDescriptionsTableAdapter.Connection.ConnectionString = AppConnectionString;
        }

        private void LkpWipDescriptions_Load(object sender, EventArgs e)
        {
            this.SetConnectionString();
            wipDescriptionsTableAdapter.FillAll(dsProdutn.WipDescriptions);
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
