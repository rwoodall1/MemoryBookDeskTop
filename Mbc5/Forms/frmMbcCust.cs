using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BaseClass.Classes;
namespace Mbc5.Forms
{
    public partial class frmMbcCust : BaseClass.Forms.bTopBottom
    {
        public frmMbcCust(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MbcCS"}, userPrincipal)
        {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
        }

        private void frmMbcCust_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsCust.cust' table. You can move, or remove it, as needed.
            this.custTableAdapter.Fill(this.dsCust.cust,"001655");
          

        }

        private void btnSchoolCode_Click(object sender, EventArgs e)
        {
           
            this.custTableAdapter.Fill(this.dsCust.cust,txtSchCodesrch.Text.Trim());
        }
        #region CrudOperations
        public override void Save()
        {
            this.ValidateChildren(ValidationConstraints.Enabled);
            this.custBindingSource.EndEdit();
            custTableAdapter.Update(dsCust);
        }
        public override void Add()
        {
            DataRowView newrow = (DataRowView)custBindingSource.AddNew();
        }
        public override void Delete()
        {
            
        }
        public override void Cancel()
        {
            
        }
        #endregion

        #region Validation
        private void txtSchname_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtSchname.Text.Trim()))
            {
                //This control fails validation: Name cannot be empty.
                cancel = true;
                this.errorProvider1.SetError(this.txtSchname, "School name is required.");
            }
            e.Cancel = cancel;
        }

        private void txtSchPhone_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtSchPhone.Text.Trim()))
            {
                //This control fails validation: Name cannot be empty.
                cancel = true;
                this.errorProvider1.SetError(this.txtSchPhone, "School phone number is required.");
            }
            e.Cancel = cancel;
        }

        private void txtaddress_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtaddress.Text.Trim()))
            {
                //This control fails validation: Name cannot be empty.
                cancel = true;
                this.errorProvider1.SetError(this.txtaddress, "School address is required.");
            }
            e.Cancel = cancel;
        }

        private void txtCity_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtCity.Text.Trim()))
            {
                //This control fails validation: Name cannot be empty.
                cancel = true;
                this.errorProvider1.SetError(this.txtCity, "School city is required.");
            }
            e.Cancel = cancel;
        }

        private void cmbState_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.cmbState.Text))
            {
                //This control fails validation: Name cannot be empty.
                cancel = true;
                this.errorProvider1.SetError(this.cmbState, "School state is required.");
            }
            e.Cancel = cancel;
        }

        private void txtZip_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtZip.Text.Trim()))
            {
                //This control fails validation: Name cannot be empty.
                cancel = true;
                this.errorProvider1.SetError(this.txtZip, "School zip code is required.");
            }
            e.Cancel = cancel;
        }

         private void txtCsRep_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtCsRep.Text.Trim()))
            {
                //This control fails validation: Name cannot be empty.
                cancel = true;
                this.errorProvider1.SetError(this.txtCsRep, "Sales rep is required.");
            }
            e.Cancel = cancel;
        }

        private void txtSchname_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtSchname,string.Empty);
        }

        private void txtaddress_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtaddress, string.Empty);
        }

        private void txtCity_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtCity, string.Empty);
        }

        private void cmbState_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.cmbState, string.Empty);
        }

        private void txtZip_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtZip, string.Empty);
        }

        private void txtSchPhone_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtSchPhone, string.Empty);
        }
        private void yb_sthTextBox_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (yb_sthTextBox.Text!="Y" || !string.IsNullOrEmpty(this.yb_sthTextBox.Text.Trim()))
            {
                //This control fails validation: Name cannot be empty.
                cancel = true;
                this.errorProvider1.SetError(this.yb_sthTextBox, "Value must be empty or Y.");
            }
            e.Cancel = cancel;
        }

        private void yb_sthTextBox_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.yb_sthTextBox, string.Empty);
        }

        private void shiptocontTextBox_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.shiptocontTextBox, string.Empty);
        }

        private void shiptocontTextBox_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (shiptocontTextBox.Text != "Y" || !string.IsNullOrEmpty(this.shiptocontTextBox.Text.Trim()))
            {
                //This control fails validation: Name cannot be empty.
                cancel = true;
                this.errorProvider1.SetError(this.shiptocontTextBox, "Value must be empty or Y.");
            }
            e.Cancel = cancel;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Save();
        }

       
    }
}
