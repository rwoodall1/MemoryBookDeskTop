using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using NLog;
using BaseClass;
using Core;
using Mbc5.Classes;
namespace Mbc5.LookUpForms
{
   

    public partial class LkpDiscount : BaseClass.Forms.bTopBottom
    {
        public LkpDiscount(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator" }, userPrincipal)
        {
            InitializeComponent();
        }
        private void LkpDiscount_Load(object sender, EventArgs e)
        {
            this.lkpDiscountTableAdapter.Connection.ConnectionString = ApplicationConfig.DefaultConnectionString;
            lkpDiscountTableAdapter.Fill(lookUp.lkpDiscount);
        }
        private void lkpDdiscntBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Save();

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            this.Save();
        }
        public override void Save(bool ShowSpinner)
        {
            //so call can be made from menu
            if (ShowSpinner)
            {
                var result = Save();
                if (result.IsError)
                {
                    MbcMessageBox.Error(result.Errors[0].ErrorMessage);
                }
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
            var processngResult = new ApiProcessingResult<bool>();
            bool retval = true;
            
            try
            {
                this.Validate();
                this.lkpDdiscntBindingSource.EndEdit();
                var a = lkpDiscountTableAdapter.Update(lookUp);
                MessageBox.Show("Record Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //ex.ToExceptionless()
                //    .AddTags("Save Error")
                //    .Submit();
                MessageBox.Show("Error saving record:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                processngResult.IsError = true;
                processngResult.Errors.Add(new ApiProcessingError("Error saving record:" + ex.Message, "Error saving record:" + ex.Message, ""));
            }
            return processngResult;
        }
    }
}
