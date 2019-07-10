using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using System.Data.Sql;
using BaseClass;
using BaseClass.Core;
using Exceptionless;
namespace Mbc5.Forms.Meridian {
    public partial class frmMerCust : BaseClass.Forms.bTopBottom {
        public frmMerCust(UserPrincipal userPrincipal) : base(new string[] { "SA","Administrator","MerCS" },userPrincipal) {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            }

        public frmMerCust(UserPrincipal userPrincipal,string vschcode) : base(new string[] { "SA", "Administrator", "MerCS" }, userPrincipal)
        {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Schcode = vschcode;
        }
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        private UserPrincipal ApplicationUser { get; set; }
        public new frmMain frmMain { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public override string Schcode { get; set; } = "124487";//default schcode;

        private void frmMerCust_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lookUp.contpstn' table. You can move, or remove it, as needed.
            this.contpstnTableAdapter.Fill(this.lookUp.contpstn);
            // TODO: This line of code loads data into the 'lookUp.states' table. You can move, or remove it, as needed.
            this.statesTableAdapter.Fill(this.lookUp.states);
            ;

            this.frmMain = (frmMain)this.MdiParent;

            SetConnectionString();

            var vSchocode = this.Schcode;


           
            Fill();
            this.lblAppUser.Text = this.ApplicationUser.id;
            mcustBindingSource.ResetBindings(true);
        }

        #region Methods
        private void SetInvnoSchCode()
        {
            this.Schcode = lblSchcode.Text;
            int val = 0;
            this.Invno = 0;
            bool parsed = Int32.TryParse(lblInvno.Text, out val);
            if (parsed)
            {
                this.Invno = val;
            }

        }
        public override ApiProcessingResult<bool> Save()
        {
            var processingResult = new ApiProcessingResult<bool>();
            this.lblAppUser.Text = this.ApplicationUser.id;
            bool retval = false;

            txtSchname.ReadOnly = true;
            //     var a = this.ValidateChildren(ValidationConstraints.Enabled);
            //     var b=this.ValidateChildren(ValidationConstraints.ImmediateChildren);
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
               
                try
                {
                    mcustBindingSource.EndEdit();
                  var a=  mcustTableAdapter.Update(dsMcust.mcust);
                   
                    this.mcustTableAdapter.Fill(this.dsMcust.mcust, this.Schcode);
                    this.SetInvnoSchCode();
                    retval = true;
                }
                catch (DBConcurrencyException dbex)
                {
                    MbcMessageBox.Hand("Another user has updated this record, your copy is not current. Your data is being reverted, Please re-enter your data.", "Concurrency Error");
                    this.Fill();
                    //DialogResult result = ExceptionHandler.CreateMessage((DataSets.dsCust.custRow)(dbex.Row), ref dsCust);
                    //if (result == DialogResult.Yes) {
                    //    Save();
                    //}

                }
                catch (Exception ex)
                {

                    MessageBox.Show("School record failed to update:" + ex.Message);
                    ex.ToExceptionless()
                    .SetMessage("School record failed to update:" + ex.Message)
                    .Submit();
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError("Record not save:" + ex.Message, "Record not save:" + ex.Message, ""));
                }
            }

            return processingResult;
        }
   
        private void SetConnectionString()
        {
            mcustTableAdapter.Connection.ConnectionString = this.frmMain.AppConnectionString;
            datecontTableAdapter.Connection.ConnectionString= this.frmMain.AppConnectionString;
        }
        private void Fill()
        {
            try
            {
                this.statesTableAdapter.Fill(this.lookUp.states);
                this.contpstnTableAdapter.Fill(this.lookUp.contpstn);
                mcustTableAdapter.Fill(dsMcust.mcust, Schcode);
                datecontTableAdapter.Fill(dsMcust.datecont, Schcode);
            }catch(Exception ex)
            {
                ex.ToExceptionless()
                    .AddObject(ex)
                    .MarkAsCritical()
                    .Submit();
                MbcMessageBox.Error(ex.Message);
            }
        }
        #endregion
       

        private void taxExemptRecvdDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            taxExemptRecvdDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void dedayoutDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            dedayoutDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void dedayinDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            dedayinDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void pg1_Click(object sender, EventArgs e)
        {

        }

        private void dteschstartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            dteschstartDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void dteschendDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            dteschendDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void initcontDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            initcontDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void sourdateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            sourdateDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void contdateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            contdateDateTimePicker.Format = DateTimePickerFormat.Short;
        }

       

        private void xeldateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            xeldateDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void btnSchoolToInvoice_Click(object sender, EventArgs e)
        {
            var vInvAddress = ((DataRowView)mcustBindingSource.Current).Row["schaddr"].ToString().Trim();
            txtInvAddr.Text = vInvAddress;
            var vInvAddress2 = ((DataRowView)mcustBindingSource.Current).Row["schaddr2"].ToString().Trim();
            txtInvAddr2.Text = vInvAddress2;
            var vInvCity = ((DataRowView)mcustBindingSource.Current).Row["schcity"].ToString().Trim();
            txtInvCity.Text = vInvCity;
            var vInvState = ((DataRowView)mcustBindingSource.Current).Row["schstate"].ToString().Trim();
            cmbInvState.SelectedValue = vInvState;
            var vInvZipcode = ((DataRowView)mcustBindingSource.Current).Row["schzip"].ToString().Trim();
            if (vInvZipcode.Length > 5)
            {
                txtInvZipcode.Text = vInvZipcode.Substring(0, 5);
            }
            else { txtInvZipcode.Text = vInvZipcode; }
        }

        

        private void btnSaveInformation_Click(object sender, EventArgs e)
        {
           var result= Save();
            if (!result.IsError)
            {
                MbcMessageBox.Exclamation("Record Saved", "Saved");
            }
        }

        private void frmMerCust_FormClosing(object sender, FormClosingEventArgs e)
        {
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result = MessageBox.Show("Record failed to save. Continue closeing?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

            }
        }

        private void frmMerCust_Paint(object sender, PaintEventArgs e)
        {
            try { this.Text = "Meridian Customer-" + txtSchname.Text.Trim() + " (" + this.Schcode.Trim() + ")"; }
            catch
            {

            }
        }

        private void btnSchoolToShipping_Click(object sender, EventArgs e)
        {
            var vShpAddress = ((DataRowView)mcustBindingSource.Current).Row["schaddr"].ToString().Trim();
            txtShpAddr.Text = vShpAddress;
            var vShpAddress2 = ((DataRowView)mcustBindingSource.Current).Row["schaddr2"].ToString().Trim();
            txtShpAddr2.Text = vShpAddress2;
            var vShpCity = ((DataRowView)mcustBindingSource.Current).Row["schcity"].ToString().Trim();
            txtShpCity.Text = vShpCity;
            var vShpState = ((DataRowView)mcustBindingSource.Current).Row["schstate"].ToString().Trim();
            cmbShpState.SelectedValue = vShpState;
            var vShpZipcode = ((DataRowView)mcustBindingSource.Current).Row["schzip"].ToString().Trim();
            if (vShpZipcode.Length > 5)
            {
                txtShpZipcode.Text = vShpZipcode.Substring(0, 5);
            }
            else { txtShpZipcode.Text = vShpZipcode; }
        }

        //nothing below here
    }
}
