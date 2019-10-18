using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BaseClass.Classes;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using BaseClass;
using Mbc5.Dialogs;
using Mbc5.LookUpForms;
using Exceptionless;
using Exceptionless.Models;
using Mbc5.Classes;
using BindingModels;
using BaseClass.Core;
using Microsoft.Reporting.WinForms;
using System.Threading.Tasks;
using Mbc5.Classes;
namespace Mbc5.Forms.MemoryBook {
    public partial class frmMbcCust : BaseClass.Forms.bTopBottom ,INotifyPropertyChanged {
        private bool vMktGo = false;
        private string vSchcode = null;
        private int vInvno = 0;
        Bitmap memoryImage;
        public frmMbcCust(UserPrincipal userPrincipal) : base(new string[] { "SA","Administrator","MbcCS" },userPrincipal) {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;

            }
        public frmMbcCust(UserPrincipal userPrincipal,string vschcode) : base(new string[] { "SA","Administrator","MbcCS" },userPrincipal) {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Schcode = vschcode;
            
            }
        public void InvokePropertyChanged(PropertyChangedEventArgs e) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this,e);
            }
        private UserPrincipal ApplicationUser { get; set; }
        public new frmMain frmMain { get; set; }
        private bool CustAddressHasChanged { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
   #region "Properties"
        private bool MktGo {
            get { return vMktGo; }
            set {                
                    vMktGo = value;
                    InvokePropertyChanged(new PropertyChangedEventArgs("MktGo"));
                 }
            }
        private bool MktLogAdded { get; set; } = false;
        private bool TeleGo { get; set; } = false;
        private bool TeleLogAdded { get; set; } = false;
        public override string Schcode { get; set; } = "038752";
       

        #endregion
       
   private void frmMbcCust_Load(object sender,EventArgs e) {
            
            


            this.frmMain = (frmMain)this.MdiParent;

            SetConnectionString();
            
            var vSchocode = this.Schcode;
           

            if (!ApplicationUser.Roles.Contains("MbcCS"))
            {
                TeleGo = true;
                MktGo = true;
            }
            Fill();
            this.txtModifiedBy.Text = this.ApplicationUser.id;
            custBindingSource.ResetBindings(true);
            
        }



 #region CrudOperations
        public override void Save(bool ShowSpinner)
        {
           
            //so call can be made from menu
            if (ShowSpinner)
            {
                //basePanel.Visible = true;
                //backgroundWorker1.RunWorkerAsync("Save");

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
private  ApiProcessingResult<bool> Save()
{
	var processingResult = new ApiProcessingResult<bool>();
	this.txtModifiedBy.Text  = this.ApplicationUser.id;
    bool retval = false;
           
    txtSchname.ReadOnly = true;
           
//     var a = this.ValidateChildren(ValidationConstraints.Enabled);
    //     var b=this.ValidateChildren(ValidationConstraints.ImmediateChildren);
    if (this.ValidateChildren(ValidationConstraints.Enabled))
    {
        this.custBindingSource.EndEdit();
        try
        {
           var aa= custTableAdapter.Update(dsCust);
            this.custTableAdapter.Fill(this.dsCust.cust, this.Schcode);
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
                                 
        }catch(Exception ex) {
            MessageBox.Show("School record failed to update:" + ex.Message);
            ex.ToExceptionless()
            .SetMessage("School record failed to update:" + ex.Message)
            .Submit();
			processingResult.IsError = true;
			processingResult.Errors.Add(new ApiProcessingError("Record not save:"+ex.Message, "Record not save:" + ex.Message,""));
                    return processingResult;
            }
    }
            if (CustAddressHasChanged)
            {
                var updateResult=UpdateUpsAddresses();
                if (updateResult.IsError)
                {
                    processingResult.IsError = true;
                    processingResult.Errors = updateResult.Errors;
                    return processingResult;
                }
               
            }

    return processingResult;
}
public override bool Add() {
			
	dsCust.Clear();
    DataRowView newrow = (DataRowView)custBindingSource.AddNew();
    GetSetSchcode();
    txtSchname.ReadOnly = false;
            
    this.txtModifiedBy.Text = this.ApplicationUser.id;
    this.lblHiddenSchcode.Text = Schcode;
    frmMbcCust_Paint(null, null);

    return true;
    }
public override void Delete() {

	//should mark as deleted or remove??
	this.txtModifiedBy.Text = this.ApplicationUser.id;
	DialogResult messageResult = MessageBox.Show("This will delete the current customer. Do you want to proceed?","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
	if (messageResult == DialogResult.Yes)
	{
		DataRowView current = (DataRowView)custBindingSource.Current;
		var schcode = current["schcode"];

		var sqlQuery = new SQLQuery();
		var queryString = "Delete  From  cust where schcode=@schcode ";
		SqlParameter[] parameters = new SqlParameter[] {
		new SqlParameter("@schcode",schcode)
	};
		try {
		var result = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, queryString, parameters);
		this.custTableAdapter.Fill(this.dsCust.cust, "038752");//set to cs record   
        this.SetInvnoSchCode();
		} catch (Exception ex) {
			MbcMessageBox.Error(ex.Message, "");
		}
				
    }

}
public override void Cancel() {
    custBindingSource.CancelEdit();
    }     
    #endregion
 #region Validation
    private void txtSchname_Validating(object sender,CancelEventArgs e) {
        bool cancel = false;
        if (string.IsNullOrEmpty(this.txtSchname.Text.Trim()))
            {
            //This control fails validation: Name cannot be empty.
            cancel = true;
            this.errorProvider1.SetError(this.txtSchname,"School name is required.");
            }
        e.Cancel = cancel;
        }

    private void txtSchPhone_Validating(object sender,CancelEventArgs e) {
        bool cancel = false;
        if (string.IsNullOrEmpty(this.txtSchPhone.Text.Trim()))
            {
            //This control fails validation: Name cannot be empty.
            cancel = true;
            this.errorProvider1.SetError(this.txtSchPhone,"School phone number is required.");
            }
        e.Cancel = cancel;
        }

    private void txtaddress_Validating(object sender,CancelEventArgs e) {
        bool cancel = false;
        if (string.IsNullOrEmpty(this.txtaddress.Text.Trim()))
            {
            //This control fails validation: Name cannot be empty.
            cancel = true;
            this.errorProvider1.SetError(this.txtaddress,"School address is required.");
            }
        e.Cancel = cancel;
        }

    private void txtCity_Validating(object sender,CancelEventArgs e) {
        bool cancel = false;
        if (string.IsNullOrEmpty(this.txtCity.Text.Trim()))
            {
            //This control fails validation: Name cannot be empty.
            cancel = true;
            this.errorProvider1.SetError(this.txtCity,"School city is required.");
            }
        e.Cancel = cancel;
        }

    private void cmbState_Validating(object sender,CancelEventArgs e) {
        bool cancel = false;
        if (string.IsNullOrEmpty(this.cmbState.Text))
            {
            //This control fails validation: Name cannot be empty.
            cancel = true;
            this.errorProvider1.SetError(this.cmbState,"School state is required.");
            }
        e.Cancel = cancel;
        }

    private void txtZip_Validating(object sender,CancelEventArgs e) {
        bool cancel = false;
        if (string.IsNullOrEmpty(this.txtZip.Text.Trim()))
            {
            //This control fails validation: Name cannot be empty.
            cancel = true;
            this.errorProvider1.SetError(this.txtZip,"School zip code is required.");
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
        return;
    }
    private void txtCsRep_Validated(object sender, EventArgs e)
    {
        this.errorProvider1.SetError(this.txtCsRep, string.Empty);
    }
    private void txtSchname_Validated(object sender,EventArgs e) {
        this.errorProvider1.SetError(this.txtSchname,string.Empty);
        }

    private void txtaddress_Validated(object sender,EventArgs e) {
        this.errorProvider1.SetError(this.txtaddress,string.Empty);
        }

    private void txtCity_Validated(object sender,EventArgs e) {
        this.errorProvider1.SetError(this.txtCity,string.Empty);
        }

    private void cmbState_Validated(object sender,EventArgs e) {
        this.errorProvider1.SetError(this.cmbState,string.Empty);
        }

    private void txtZip_Validated(object sender,EventArgs e) {
        this.errorProvider1.SetError(this.txtZip,string.Empty);
        }

    private void txtSchPhone_Validated(object sender,EventArgs e) {
        this.errorProvider1.SetError(this.txtSchPhone,string.Empty);
        }
    //private void yb_sthTextBox_Validating(object sender,CancelEventArgs e) {
    //    //bool cancel = false;
    //    //if (yb_sthTextBox.Text!="Y" || !string.IsNullOrEmpty(this.yb_sthTextBox.Text.Trim()))
    //    //{
    //    //    //This control fails validation: Name cannot be empty.
    //    //    cancel = true;
    //    //    this.errorProvider1.SetError(this.yb_sthTextBox, "Value must be empty or Y.");
    //    //}
    //    //e.Cancel = cancel;
    //    }

    private void yb_sthTextBox_Validated(object sender,EventArgs e) {
        //this.errorProvider1.SetError(this.yb_sthTextBox, string.Empty);
        }

    private void shiptocontTextBox_Validated(object sender,EventArgs e) {
        //this.errorProvider1.SetError(this.shiptocontTextBox, string.Empty);
        }

        //private void shiptocontTextBox_Validating(object sender,CancelEventArgs e) {
        //    //bool cancel = false;
        //    //var a = !string.IsNullOrEmpty(this.shiptocontTextBox.Text.Trim());
        //    //if (shiptocontTextBox.Text != "Y" || !string.IsNullOrEmpty(this.shiptocontTextBox.Text.Trim()))
        //    //{
        //    //    //This control fails validation: Name cannot be empty.
        //    //    cancel = true;
        //    //    this.errorProvider1.SetError(this.shiptocontTextBox, "Value must be empty or Y.");
        //    //}
        //    //e.Cancel = cancel;
        //    }
        #endregion
 #region Methods
    private  ApiProcessingResult<bool> UpdateUpsAddresses()
    {
                var processingResult = new ApiProcessingResult<bool>();
                try
                {
                var sqlquery = new SQLCustomClient();
                var dr = (DataRowView)custBindingSource.Current;
                var vYearBookToHome = dr.Row["yb_sth"].ToString();
                var vOther = dr.Row["shiptocont1"].ToString();
                var vSchcode = dr.Row["Schcode"].ToString().Trim();
                var vSchname = dr.Row["Schname"].ToString().Trim();
                var vContemail = dr.Row["contemail"].ToString();
                var vSchemail = dr.Row["schemail"].ToString();
                var vAttn = dr.Row["contfname"].ToString().Trim() + " " + dr.Row["contLname"].ToString().Trim();
                var vAddr1 = dr.Row["SchAddr"].ToString().Trim();
                var vAddr2 = dr.Row["SchAddr2"].ToString().Trim();
                var vCity = dr.Row["SchCity"].ToString().Trim();
                var vState = dr.Row["SchState"].ToString().Trim();
                var vZip = dr.Row["schZip"].ToString().Trim();
                var vCAddr1 = dr.Row["contAddr"].ToString().Trim();
                var vCAddr2 = dr.Row["contAddr2"].ToString().Trim();
                var vCCity = dr.Row["contCity"].ToString().Trim();
                var vCState = dr.Row["contState"].ToString().Trim();
                var vCZip = dr.Row["contZip"].ToString().Trim();
                
                var vFax = dr.Row["SchFax"].ToString().Trim().Replace("(","").Replace(")","").Replace("-","");
               
                

                var vSvdesc = dr.Row["Svdesc1"].ToString().Trim();



                string updateCommandYearbook = @"UPDATE UpsList
                SET 
                Schame =@Schame
                ,Attn =@Attn 
                ,Addr1 =@Addr1 
                ,Addr2 =@Addr2
                ,City =@City
                ,State =@State 
                ,Zip =@Zip
                ,Option1 =@Option1
                ,Type1 =@Type1 
                ,Fax =@Fax 
                ,Option2 =@Option2 
                ,Type2 =@Type2
                ,Email =@Email 
    
                ,Svdesc =@Svdesc 
    
                WHERE Schcode=@Schcode";

                string YearbookInsert = @"
                INSERT INTO UpsList
                (Schcode
                ,Schame
                ,Attn
                ,Addr1
                ,Addr2
                ,City
                ,State
                ,Zip
                ,Option1
                ,Type1
                ,Fax
                ,Option2
                ,Type2
                ,Email          
                ,Svdesc
                )
                Values(    @Schcode
                ,@Schame
                ,@Attn
                ,@Addr1
                ,@Addr2
                ,@City
                ,@State
                ,@Zip
                ,@Option1
                ,@Type1
                ,@Fax
                ,@Option2
                ,@Type2
                ,@Email          
                ,@Svdesc)";


                sqlquery.CommandText("Select Schcode from UpsList WHERE SUBSTRING(Schcode,1,6)=@Schcode");
                sqlquery.AddParameter("@Schcode", Schcode.Trim());//should bring 2 recs with y and k behind schcode
                var selectResult = sqlquery.SelectMany<SchCheck>();
                if (selectResult.IsError)
                {
               
                ExceptionlessClient.Default.CreateLog("UpsUpdate Error")
                    .AddObject(selectResult)
                    .Submit();
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError("UpsUpdate failed:" + selectResult.Errors[0].ErrorMessage, "UpsUpdate failed:" + selectResult.Errors[0].ErrorMessage,""));
                return processingResult ;
                }
                if (selectResult.Data == null)
                {
                //Insert 2 records
                sqlquery.ClearParameters();
                sqlquery.CommandText(YearbookInsert);
                sqlquery.AddParameter("@Schcode", vSchcode + "Y");
                sqlquery.AddParameter("@Schame", vYearBookToHome == "Y" ? "Residence" : vSchname);
                sqlquery.AddParameter("@Attn", vAttn);
                sqlquery.AddParameter("@Addr1", vYearBookToHome == "Y" ? vCAddr1 : vAddr1);
                sqlquery.AddParameter("@Addr2", vYearBookToHome == "Y" ? vCAddr2 : vAddr2);
                sqlquery.AddParameter("@City", vYearBookToHome == "Y" ? vCCity : vCity);
                sqlquery.AddParameter("@State", vYearBookToHome == "Y" ? vCState : vState);
                sqlquery.AddParameter("@Zip", vYearBookToHome == "Y" ? vCZip : vZip);
                sqlquery.AddParameter("@Type1", "    ");
                sqlquery.AddParameter("@Option1", false);
                sqlquery.AddParameter("@Fax", vFax);
                sqlquery.AddParameter("@Option2", !string.IsNullOrEmpty(vContemail) || !string.IsNullOrEmpty(vSchemail) ? true : false);
                sqlquery.AddParameter("@Type2", !string.IsNullOrEmpty(vContemail) || !string.IsNullOrEmpty(vSchemail) ? "email" : "    ");
                sqlquery.AddParameter("@Email", string.IsNullOrEmpty(vContemail) ? vContemail : vSchemail);
                sqlquery.AddParameter("@Svdesc", string.IsNullOrEmpty(vSvdesc) ? "Ground" : vSvdesc);
                var insertResult = sqlquery.Insert();
                if (insertResult.IsError)
                {
                   
                    ExceptionlessClient.Default.CreateLog("UpsAddress Error")
                        .AddObject(insertResult)
                        .AddObject(sqlquery)
                        .Submit();
                        processingResult.IsError = true;
                        processingResult.Errors.Add(new ApiProcessingError("Failed to insert into UPSAddress Table:" + insertResult.Errors[0].ErrorMessage, "Failed to insert into UPSAddress Table:" + insertResult.Errors[0].ErrorMessage, ""));
                        return processingResult;
                    }
                sqlquery.ClearParameters();
                sqlquery.AddParameter("@Schcode", vSchcode + "K");
                sqlquery.AddParameter("@Schame", vOther == "Y" ? "Residence" : vSchname);
                sqlquery.AddParameter("@Attn", vAttn);
                sqlquery.AddParameter("@Addr1", vOther == "Y" ? vCAddr1 : vAddr1);
                sqlquery.AddParameter("@Addr2", vOther == "Y" ? vCAddr2 : vAddr2);
                sqlquery.AddParameter("@City", vOther == "Y" ? vCCity : vCity);
                sqlquery.AddParameter("@State", vOther == "Y" ? vCState : vState);
                sqlquery.AddParameter("@Zip", vOther == "Y" ? vCZip : vZip);
                sqlquery.AddParameter("@Type1", "    ");
                sqlquery.AddParameter("@Option1", false);
                sqlquery.AddParameter("@Fax", vFax);
                sqlquery.AddParameter("@Option2", !string.IsNullOrEmpty(vContemail) || !string.IsNullOrEmpty(vSchemail) ? true : false);
                sqlquery.AddParameter("@Type2", !string.IsNullOrEmpty(vContemail) || !string.IsNullOrEmpty(vSchemail) ? "email" : "    ");
                sqlquery.AddParameter("@Email", string.IsNullOrEmpty(vContemail) ? vContemail : vSchemail);
                sqlquery.AddParameter("@Svdesc", string.IsNullOrEmpty(vSvdesc) ? "Ground" : vSvdesc);

                var insertResult2 = sqlquery.Insert();
                if (insertResult2.IsError)
                {
                    
                    ExceptionlessClient.Default.CreateLog("UpsAddress Error")
                        .AddObject(insertResult)
                        .AddObject(sqlquery)
                        .Submit();
                        processingResult.IsError = true;
                        processingResult.Errors.Add(new ApiProcessingError("Failed to insert into UPSAddress Table:" + insertResult2.Errors[0].ErrorMessage, "Failed to insert into UPSAddress Table:" + insertResult2.Errors[0].ErrorMessage, ""));
                        return processingResult;
                    }
                return processingResult; 
                }
                var returnedData = (List<SchCheck>)selectResult.Data;
                sqlquery.ClearParameters();
                if (returnedData.Count == 2)
                {
                //update y and k
                sqlquery.CommandText(updateCommandYearbook);
                sqlquery.AddParameter("@Schcode", vSchcode + "Y");
                sqlquery.AddParameter("@Schame", vYearBookToHome == "Y" ? "Residence" : vSchname);
                sqlquery.AddParameter("@Attn", vAttn);
                sqlquery.AddParameter("@Addr1", vYearBookToHome == "Y" ? vCAddr1 : vAddr1);
                sqlquery.AddParameter("@Addr2", vYearBookToHome == "Y" ? vCAddr2 : vAddr2);
                sqlquery.AddParameter("@City", vYearBookToHome == "Y" ? vCCity : vCity);
                sqlquery.AddParameter("@State", vYearBookToHome == "Y" ? vCState : vState);
                sqlquery.AddParameter("@Zip", vYearBookToHome == "Y" ? vCZip : vZip);
                sqlquery.AddParameter("@Type1", "    ");
                sqlquery.AddParameter("@Option1", false);
                sqlquery.AddParameter("@Fax", vFax);
                sqlquery.AddParameter("@Option2", !string.IsNullOrEmpty(vContemail) || !string.IsNullOrEmpty(vSchemail) ? true : false);
                sqlquery.AddParameter("@Type2", !string.IsNullOrEmpty(vContemail) || !string.IsNullOrEmpty(vSchemail) ? "email" : "    ");
                sqlquery.AddParameter("@Email", string.IsNullOrEmpty(vContemail) ? vContemail : vSchemail);
                sqlquery.AddParameter("@Svdesc", string.IsNullOrEmpty(vSvdesc) ? "Ground" : vSvdesc);
                var updateResult = sqlquery.Update();
                if (updateResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert into UPSAddress Table:" + updateResult.Errors[0].ErrorMessage);
                    ExceptionlessClient.Default.CreateLog("UpsAddress Error")
                        .AddObject(updateResult)
                        .AddObject(sqlquery)
                        .Submit();
                        processingResult.IsError = true;
                        processingResult.Errors.Add(new ApiProcessingError("Failed to insert into UPSAddress Table:" + updateResult.Errors[0].ErrorMessage, "Failed to insert into UPSAddress Table:" + updateResult.Errors[0].ErrorMessage, ""));
                        return processingResult;
                    }
                sqlquery.ClearParameters();
                sqlquery.AddParameter("@Schcode", vSchcode + "K");
                sqlquery.AddParameter("@Schame", vOther == "Y" ? "Residence" : vSchname);
                sqlquery.AddParameter("@Attn", vAttn);
                sqlquery.AddParameter("@Addr1", vOther == "Y" ? vCAddr1 : vAddr1);
                sqlquery.AddParameter("@Addr2", vOther == "Y" ? vCAddr2 : vAddr2);
                sqlquery.AddParameter("@City", vOther == "Y" ? vCCity : vCity);
                sqlquery.AddParameter("@State", vOther == "Y" ? vCState : vState);
                sqlquery.AddParameter("@Zip", vOther == "Y" ? vCZip : vZip);
                sqlquery.AddParameter("@Type1", "    ");
                sqlquery.AddParameter("@Option1", false);
                sqlquery.AddParameter("@Fax", vFax);
                sqlquery.AddParameter("@Option2", !string.IsNullOrEmpty(vContemail) || !string.IsNullOrEmpty(vSchemail) ? true : false);
                sqlquery.AddParameter("@Type2", !string.IsNullOrEmpty(vContemail) || !string.IsNullOrEmpty(vSchemail) ? "email" : "    ");
                sqlquery.AddParameter("@Email", string.IsNullOrEmpty(vContemail) ? vContemail : vSchemail);
                sqlquery.AddParameter("@Svdesc", string.IsNullOrEmpty(vSvdesc) ? "Ground" : vSvdesc);
                sqlquery.CommandText(YearbookInsert);
                var updateResult2 = sqlquery.Update();
                if (updateResult2.IsError)
                {
                    MbcMessageBox.Error("Failed to insert into UPSAddress Table:" + updateResult2.Errors[0].ErrorMessage);
                    ExceptionlessClient.Default.CreateLog("UpsAddress Error")
                        .AddObject(updateResult2)
                        .AddObject(sqlquery)
                        .Submit();
                        processingResult.IsError = true;
                        processingResult.Errors.Add(new ApiProcessingError("Failed to insert into UPSAddress Table:" + updateResult2.Errors[0].ErrorMessage, "Failed to insert into UPSAddress Table:" + "Failed to insert into UPSAddress Table:" + updateResult2.Errors[0].ErrorMessage, ""));
                        return processingResult;
                    }
                return processingResult;


                }
                if (returnedData.Count == 1)
                {
                //update 1 and insert1
                if (returnedData[0].Schcode.Contains("Y"))
                {
                        //update y
                        //insert K
                        sqlquery.CommandText(updateCommandYearbook);
                        sqlquery.AddParameter("@Schcode", vSchcode + "Y");
                        sqlquery.AddParameter("@Schame", vYearBookToHome == "Y" ? "Residence" : vSchname);
                        sqlquery.AddParameter("@Attn", vAttn);
                        sqlquery.AddParameter("@Addr1", vYearBookToHome == "Y" ? vCAddr1 : vAddr1);
                        sqlquery.AddParameter("@Addr2", vYearBookToHome == "Y" ? vCAddr2 : vAddr2);
                        sqlquery.AddParameter("@City", vYearBookToHome == "Y" ? vCCity : vCity);
                        sqlquery.AddParameter("@State", vYearBookToHome == "Y" ? vCState : vState);
                        sqlquery.AddParameter("@Zip", vYearBookToHome == "Y" ? vCZip : vZip);
                        sqlquery.AddParameter("@Type1", "    ");
                        sqlquery.AddParameter("@Option1", false);
                        sqlquery.AddParameter("@Fax", vFax);
                        sqlquery.AddParameter("@Option2", !string.IsNullOrEmpty(vContemail) || !string.IsNullOrEmpty(vSchemail) ? true : false);
                        sqlquery.AddParameter("@Type2", !string.IsNullOrEmpty(vContemail) || !string.IsNullOrEmpty(vSchemail) ? "email" : "    ");
                        sqlquery.AddParameter("@Email", string.IsNullOrEmpty(vContemail) ? vContemail : vSchemail);
                        sqlquery.AddParameter("@Svdesc", string.IsNullOrEmpty(vSvdesc) ? "Ground" : vSvdesc);
                        var updateResult = sqlquery.Update();
                        if (updateResult.IsError)
                        {
                                
                                ExceptionlessClient.Default.CreateLog("UpsAddress Error")
                                    .AddObject(updateResult)
                                    .AddObject(sqlquery)
                                    .Submit();
                            processingResult.IsError = true;
                            processingResult.Errors.Add(new ApiProcessingError("Failed to insert into UPSAddress Table:" + updateResult.Errors[0].ErrorMessage, "Failed to insert into UPSAddress Table:" + updateResult.Errors[0].ErrorMessage, ""));
                            return processingResult;
                        }
                        sqlquery.ClearParameters();
                        sqlquery.AddParameter("@Schcode", vSchcode + "K");
                        sqlquery.AddParameter("@Schame", vOther == "Y" ? "Residence" : vSchname);
                        sqlquery.AddParameter("@Attn", vAttn);
                        sqlquery.AddParameter("@Addr1", vOther == "Y" ? vCAddr1 : vAddr1);
                        sqlquery.AddParameter("@Addr2", vOther == "Y" ? vCAddr2 : vAddr2);
                        sqlquery.AddParameter("@City", vOther == "Y" ? vCCity : vCity);
                        sqlquery.AddParameter("@State", vOther == "Y" ? vCState : vState);
                        sqlquery.AddParameter("@Zip", vOther == "Y" ? vCZip : vZip);
                        sqlquery.AddParameter("@Type1", "    ");
                        sqlquery.AddParameter("@Option1", false);
                        sqlquery.AddParameter("@Fax", vFax);
                        sqlquery.AddParameter("@Option2", !string.IsNullOrEmpty(vContemail) || !string.IsNullOrEmpty(vSchemail) ? true : false);
                        sqlquery.AddParameter("@Type2", !string.IsNullOrEmpty(vContemail) || !string.IsNullOrEmpty(vSchemail) ? "email" : "    ");
                        sqlquery.AddParameter("@Email", string.IsNullOrEmpty(vContemail) ? vContemail : vSchemail);
                        sqlquery.AddParameter("@Svdesc", string.IsNullOrEmpty(vSvdesc) ? "Ground" : vSvdesc);
                        sqlquery.CommandText(YearbookInsert);
                        var insertResult2 = sqlquery.Insert();
                        if (insertResult2.IsError)
                        {
                            MbcMessageBox.Error("Failed to insert into UPSAddress Table:" + insertResult2.Errors[0].ErrorMessage);
                            ExceptionlessClient.Default.CreateLog("UpsAddress Error")
                                .AddObject(insertResult2)
                                .AddObject(sqlquery)
                                .Submit();
                            processingResult.IsError = true;
                            processingResult.Errors.Add(new ApiProcessingError("Failed to insert into UPSAddress Table:" + insertResult2.Errors[0].ErrorMessage, "Failed to insert into UPSAddress Table:" + insertResult2.Errors[0].ErrorMessage, ""));
                            return processingResult;
                        }
                        return processingResult;
                  }
                else
                {
                    //update k
                    sqlquery.CommandText(updateCommandYearbook);
                    sqlquery.AddParameter("@Schcode", vSchcode + "K");
                    sqlquery.AddParameter("@Schame", vOther == "Y" ? "Residence" : vSchname);
                    sqlquery.AddParameter("@Attn", vAttn);
                    sqlquery.AddParameter("@Addr1", vOther == "Y" ? vCAddr1 : vAddr1);
                    sqlquery.AddParameter("@Addr2", vOther == "Y" ? vCAddr2 : vAddr2);
                    sqlquery.AddParameter("@City", vOther == "Y" ? vCCity : vCity);
                    sqlquery.AddParameter("@State", vOther == "Y" ? vCState : vState);
                    sqlquery.AddParameter("@Zip", vOther == "Y" ? vCZip : vZip);
                    sqlquery.AddParameter("@Type1", "    ");
                    sqlquery.AddParameter("@Option1", false);
                    sqlquery.AddParameter("@Fax", vFax);
                    sqlquery.AddParameter("@Option2", !string.IsNullOrEmpty(vContemail) || !string.IsNullOrEmpty(vSchemail) ? true : false);
                    sqlquery.AddParameter("@Type2", !string.IsNullOrEmpty(vContemail) || !string.IsNullOrEmpty(vSchemail) ? "email" : "    ");
                    sqlquery.AddParameter("@Email", string.IsNullOrEmpty(vContemail) ? vContemail : vSchemail);
                    sqlquery.AddParameter("@Svdesc", string.IsNullOrEmpty(vSvdesc) ? "Ground" : vSvdesc);
                        
                    var updateResult2 = sqlquery.Update();
                    if (updateResult2.IsError)
                    {
                        MbcMessageBox.Error("Failed to insert into UPSAddress Table:" + updateResult2.Errors[0].ErrorMessage);
                        ExceptionlessClient.Default.CreateLog("UpsAddress Error")
                            .AddObject(updateResult2)
                            .AddObject(sqlquery)
                            .Submit();
                            processingResult.IsError = true;
                            processingResult.Errors.Add(new ApiProcessingError("Failed to insert into UPSAddress Table:" + updateResult2.Errors[0].ErrorMessage, "Failed to insert into UPSAddress Table:" + updateResult2.Errors[0].ErrorMessage, ""));
                            return processingResult;
                        }
                    //insert y
                    sqlquery.CommandText(YearbookInsert);
                    sqlquery.ClearParameters();
                    sqlquery.AddParameter("@Schcode", vSchcode + "Y");
                    sqlquery.AddParameter("@Schame", vYearBookToHome == "Y" ? "Residence" : vSchname);
                    sqlquery.AddParameter("@Attn", vAttn);
                    sqlquery.AddParameter("@Addr1", vYearBookToHome == "Y" ? vCAddr1 : vAddr1);
                    sqlquery.AddParameter("@Addr2", vYearBookToHome == "Y" ? vCAddr2 : vAddr2);
                    sqlquery.AddParameter("@City", vYearBookToHome == "Y" ? vCCity : vCity);
                    sqlquery.AddParameter("@State", vYearBookToHome == "Y" ? vCState : vState);
                    sqlquery.AddParameter("@Zip", vYearBookToHome == "Y" ? vCZip : vZip);
                    sqlquery.AddParameter("@Type1", "    ");
                    sqlquery.AddParameter("@Option1", false);
                    sqlquery.AddParameter("@Fax", vFax);
                    sqlquery.AddParameter("@Option2", !string.IsNullOrEmpty(vContemail) || !string.IsNullOrEmpty(vSchemail) ? true : false);
                    sqlquery.AddParameter("@Type2", !string.IsNullOrEmpty(vContemail) || !string.IsNullOrEmpty(vSchemail) ? "email" : "    ");
                    sqlquery.AddParameter("@Email", string.IsNullOrEmpty(vContemail) ? vContemail : vSchemail);
                    sqlquery.AddParameter("@Svdesc", string.IsNullOrEmpty(vSvdesc) ? "Ground" : vSvdesc);
                    var insertResult = sqlquery.Insert();
                    if (insertResult.IsError)
                    {
                        MbcMessageBox.Error("Failed to insert into UPSAddress Table:" + insertResult.Errors[0].ErrorMessage);
                        ExceptionlessClient.Default.CreateLog("UpsAddress Error")
                            .AddObject(insertResult)
                            .AddObject(sqlquery)
                            .Submit();
                            processingResult.IsError = true;
                            processingResult.Errors.Add(new ApiProcessingError("Failed to insert into UPSAddress Table:" + insertResult.Errors[0].ErrorMessage, "Failed to insert into UPSAddress Table:" + insertResult.Errors[0].ErrorMessage, ""));
                            return processingResult;
                        }
                    return processingResult;
                }
                }
                }catch(Exception ex) {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError(ex.Message, ex.Message, ""));
                return processingResult;

            };
            return processingResult;
        }
        private  ApiProcessingResult<bool> PrintProductionTicket()
        {
            var processingResult = new ApiProcessingResult<bool>();
            var sqlClient = new SQLCustomClient();
            string cmdText = @"Select  C.Schname,C.Schcode,C.SchState AS State,C.spcinst AS SpecialInstructions,C.SchColors,P.JobNo,P.Company,Q.Invno,Q.contryear as ContractYear,
             Q.BookType,P.PerfBind,Q.Insck,Q.YirSchool,P.ProdNo,P.bkgrnd AS BackGround,P.NoPages,P.NoCopies,P.CoilClr,P.Theme,P.Laminated,P.persnlz AS Personalize,Q.perscopies AS PersonalCopies,Q.allclrck As AllClrck
             ,Q.msstanqty AS MSstandardQty,ES.endshtno AS EndsheetNumb,P.TypeStyle,P.CoverType,P.CoverDesc,P.BindVend,P.Prshpdte,R.numpgs
                FROM Cust C
                LEFT JOIN Quotes Q ON C.Schcode=Q.Schcode
				Left JOIN EndSheet ES ON Q.Invno=ES.Invno
				Left JOIN Recv2 R ON Q.Invno=R.Invno
                LEFT JOIN Produtn P ON Q.Invno=P.Invno
            Where Q.Invno=@Invno";

            sqlClient.CommandText(cmdText);
            sqlClient.AddParameter("@Invno", this.Invno);
            var dataReturned = sqlClient.Select<ProdutnTicketModel>();
            if (dataReturned.IsError)
            {
               
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError(dataReturned.Errors[0].ErrorMessage, dataReturned.Errors[0].ErrorMessage,""));
                return processingResult;
            }

            var data = (ProdutnTicketModel)dataReturned.Data;

            ProdutnTicketModelBindingSource.DataSource = data;
            reportViewer1.RefreshReport();
          
            return processingResult;
        }
        private  ApiProcessingResult<bool> PrintProdCheckList()
        {
            var processingResult = new ApiProcessingResult<bool>();
            var sqlClient = new SQLCustomClient();
            string cmdText = @"
                        Select  C.Schname,C.Schcode,C.SchState,C.SchCity,C.SchAddr,C.SchZip,C.SchPhone,C.Vcrsent,C.Spcinst,C.magic,
                        C.Enrollment,C.AllColor,C.ContFname,C.ContLname,C.ContAddr,C.ContAddr2,C.ContCity,C.ContState,C.ContZip,C.ShipToCont,C.Contphnhom,
                        C.Sal,C.ShipMemo,Q.NoPages,Q.NoCopies,Q.Glspaper,Q.Insck,Q.Dc1,Q.BookType,Q.Allclrck,P.Invno,P.Prodno,P.Covertype,P.Diecut,
                        P.Laminated,P.Contrecvd,P.Perfbind,P.Screcv,P.Speccover,P.Kitrecvd,P.Dedayin,P.Dedayout,P.Shpdate,P.Coilclr,
                        P.Cstat,I.Invtot,I.Payments,I.BalDue,R.Hndred,R.Schout
                        FROM Cust C
                            LEFT JOIN Quotes Q ON C.Schcode=Q.Schcode
                            Left JOIN Invoice I ON Q.Invno=I.Invno
                            Left JOIN Recv2 R ON Q.Invno=R.Invno
                            LEFT JOIN Produtn P ON Q.Invno=P.Invno
                        Where Q.Invno=@Invno";

            sqlClient.CommandText(cmdText);
            sqlClient.AddParameter("@Invno", this.Invno);
            var dataReturnedResult = sqlClient.Select<ProductionCheckList>();
            if (dataReturnedResult.IsError)
            {
                
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError(dataReturnedResult.Errors[0].ErrorMessage, dataReturnedResult.Errors[0].ErrorMessage,""));

            }
            var data = (ProductionCheckList)dataReturnedResult.Data;

            ProductionCheckListBindingSource.DataSource = data;
            Cursor.Current = Cursors.WaitCursor;
            reportViewerCheckList.RefreshReport();
            Cursor.Current = Cursors.Default;
            return processingResult;
        }
        private void EmailAllContacts()
        {
            this.Cursor = Cursors.AppStarting;
            string body = "";
            string subj = txtSchname.Text.Trim() + " " + Schcode + " " + cmbState.SelectedValue.ToString();
            var dr = (DataRowView)custBindingSource.Current;
            var vCont1 = dr["contemail"].ToString().Trim();
            var vCont2 = dr["bcontemail"].ToString().Trim();
            var vCont3 = dr["ccontemail"].ToString().Trim();
            List<string> emailList = new List<string>();
            var emailHelper = new EmailHelper();
            if (!string.IsNullOrEmpty(vCont1))
            {
                emailList.Add(vCont1);
            }
            if (!string.IsNullOrEmpty(vCont2))
            {
                emailList.Add(vCont2);
            }
            if (!string.IsNullOrEmpty(vCont3))
            {
                emailList.Add(vCont3);
            }
            EmailType type = EmailType.Mbc;
            emailHelper.SendOutLookEmail(subj, emailList, "", body, type);
            this.Cursor = Cursors.Default;
        }
        private void SaveAddressInfo()
        {
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"
                                    UPDATE Cust Set InvoiceAddr=@InvoiceAddr
                                        ,InvoiceName=@InvoiceName
                                        ,InvoiceAddr2=@InvoiceAddr2
                                        ,InvoiceCity=@InvoiceCity
                                        ,InvoiceState=@InvoiceState
                                        ,InvoiceZipCode=@InvoiceZipCode 
                                         ,ShippingName=@ShippingName
                                        ,ShippingAddr=@ShippingAddr
                                        ,ShippingAddr2=@ShippingAddr2
                                        ,ShippingCity=@ShippingCity
                                        ,ShippingState=@ShippingState
                                        ,ShippingZipCode=@ShippingZipCode
                                        ,OtherName=@ShippingName
                                        ,OtherAddr=@ShippingAddr
                                        ,OtherAddr2=@ShippingAddr2
                                        ,OtherCity=@ShippingCity
                                        ,OtherState=@ShippingState
                                        ,OtherZipCode=@ShippingZipCode
                                        ,InvoiceEmail1=@InvoiceEmail1
                                        ,InvoiceEmail2=@InvoiceEmail2
                                        ,InvoiceEmail3=@InvoiceEmail3
                                    WHERE Schcode=@Schcode
                                    ");
            try
            {
                //use try here because this fire when closing form. combo are empty and throws and error.
                sqlClient.AddParameter("@InvoiceName", invoiceNameTextBox.Text);
                sqlClient.AddParameter("@InvoiceAddr", invAddrTextBox.Text);
                sqlClient.AddParameter("@InvoiceAddr2", invAddr2TextBox.Text);
                sqlClient.AddParameter("@InvoiceCity", invCityTextBox.Text);
                sqlClient.AddParameter("@InvoiceState", cmbInvStateComboBox.SelectedValue.ToString());
                sqlClient.AddParameter("@InvoiceZipCode", invZipCodeTextBox.Text);
                sqlClient.AddParameter("@ShippingName", shippingNameTextBox.Text);
                sqlClient.AddParameter("@ShippingAddr", shipppingAddrTextBox1.Text);
                sqlClient.AddParameter("@ShippingAddr2", shippingAddr2TextBox1.Text);
                sqlClient.AddParameter("@ShippingCity", shippingCityTextBox.Text);
                sqlClient.AddParameter("@ShippingState", cmbshippingState.SelectedValue.ToString());
                sqlClient.AddParameter("@ShippingZipCode", shippingZipCodeTextBox.Text);
                sqlClient.AddParameter("@OtherName", txtOtherName.Text);
                sqlClient.AddParameter("@OtherAddr", txtOtherAddr.Text);
                sqlClient.AddParameter("@OtherAddr2", txtOtherAddr2.Text);
                sqlClient.AddParameter("@OtherCity", txtOtherCity.Text);
                sqlClient.AddParameter("@OtherState", cmbOtherState.SelectedValue.ToString());
                sqlClient.AddParameter("@OtherZipCode", txtOtherZipCode.Text);
                sqlClient.AddParameter("@SchCode", Schcode);
                sqlClient.AddParameter("@InvoiceEmail1", invoiceEmail1TextBox.Text);
                sqlClient.AddParameter("@InvoiceEmail2", invoiceEmail2TextBox.Text);
                sqlClient.AddParameter("@InvoiceEmail3", invoiceEmail3TextBox.Text);
                var updateResult = sqlClient.Update();
                if (updateResult.IsError)
                {
                    MbcMessageBox.Error("Error saving address information:" + updateResult.Errors[0].ErrorMessage, "");
                    ExceptionlessClient.Default.CreateLog("Update Error")
                        .AddObject(updateResult)
                        .MarkAsCritical()
                        .Submit();
                    return;
                }
                //get current timestamp
                UpdateUpsAddresses();
                this.Fill();
            }
            catch
            {

            }
        }
       public override void Fill()
        {

            try
            {

                // TODO: This line of code loads data into the 'dsCust.lkpLeadSource' table. You can move, or remove it, as needed.
                this.lkpLeadSourceTableAdapter.Fill(this.dsCust.lkpLeadSource);
                // TODO: This line of code loads data into the 'dsCust.lkpLeadName' table. You can move, or remove it, as needed.
                this.lkpLeadNameTableAdapter.Fill(this.dsCust.lkpLeadName);
                // TODO: This line of code loads data into the 'dsCust.custSearch' table. You can move, or remove it, as needed.
                this.custSearchTableAdapter.Fill(this.dsCust.custSearch);
                // TODO: This line of code loads data into the 'lookUp.lkpschtype' table. You can move, or remove it, as needed.
                this.lkpschtypeTableAdapter.Fill(this.lookUp.lkpschtype);
                // TODO: This line of code loads data into the 'lookUp.lkpMultiYearOptions' table. You can move, or remove it, as needed.
                this.lkpMultiYearOptionsTableAdapter.Fill(this.lookUp.lkpMultiYearOptions);
                this.txtModifiedBy.Text = this.ApplicationUser.id;
                this.lkpSupplyItemsTableAdapter.Fill(this.lookUp.lkpSupplyItems);
                xsuppliesTableAdapter.Fill(dsXSupplies.xsupplies, Schcode);
                this.lkpSupplyItemsTableAdapter.Fill(this.lookUp.lkpSupplyItems);
                this.statesTableAdapter.Fill(this.lookUp.states);
                this.lkpTypeContTableAdapter.Fill(this.lookUp.lkpTypeCont);
                // TODO: This line of code loads data into the 'lookUp.lkpPromotions' table. You can move, or remove it, as needed.
                this.lkpPromotionsTableAdapter.Fill(this.lookUp.lkpPromotions);
                this.lkpPrevPubTableAdapter.Fill(this.lookUp.lkpPrevPub);
                this.lkpNoRebookTableAdapter.Fill(this.lookUp.lkpNoRebook);
                this.lkpschtypeTableAdapter.Fill(this.lookUp.lkpschtype);
                // TODO: This line of code loads data into the 'lookUp.lkpMktReference' table. You can move, or remove it, as needed.
                this.lkpMktReferenceTableAdapter.Fill(this.lookUp.lkpMktReference);           
                this.lkpCommentsTableAdapter.Fill(this.lookUp.lkpComments);
                this.datecontTableAdapter.Fill(this.dsCust.datecont, Schcode);
                this.custTableAdapter.Fill(this.dsCust.cust, Schcode);        
                this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, Schcode);
                this.xsuppliesTableAdapter.Fill(this.dsXSupplies.xsupplies, Schcode);
                this.xSuppliesDetailTableAdapter.Fill(dsXSupplies.XSuppliesDetail, Schcode);
            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                    .AddObject(ex)
                    .MarkAsCritical()
                    .Submit();
                MbcMessageBox.Error(ex.Message, "");
            }

        }
        public void PrintLabel(string vLabel)
        {
            switch (vLabel.ToUpper())
            {
                case "FILEFOLDER" :
                    // change reportviewer source report
                    reportViewer2.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.30321FileFolderLabel.rdlc";
                    reportViewer2.LocalReport.DataSources.Clear();
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", custBindingSource));
                    try
                    {
                    var ProdNo = ((DataRowView)this.custBindingSource.Current).Row["ProdNo"].ToString();
                    ReportParameter rp0 = new ReportParameter("ProdNo", ProdNo);
                    reportViewer2.LocalReport.SetParameters(new ReportParameter[] { rp0 });
                    this.reportViewer2.RefreshReport();
                }
                catch(Exception ex)
                {
                        MbcMessageBox.Error(ex.Message, "");
                }
                    break;
                case "ADDRESSLABEL":
                    //change reportviewer source report
                    reportViewer2.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.30256AddressLabel.rdlc";
                    reportViewer2.LocalReport.DataSources.Clear();
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", custBindingSource));
                    this.reportViewer2.RefreshReport();
                    break;
                case "RECEIVINGLABEL":
                    //change reportviewer source report
                    try
                    {
                        reportViewer2.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.30321ReceivingLabel.rdlc";
                        reportViewer2.LocalReport.DataSources.Clear();
                        reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", custBindingSource));
                        string KitRecvd = "/  /";
                        string PrShipDate = "/  /";
                        if (!((DataRowView)this.custBindingSource.Current).Row.IsNull("kitrecvd"))
                        {
                            var vKitRecvd = (DateTime)((DataRowView)this.custBindingSource.Current).Row["kitrecvd"];
                            KitRecvd = vKitRecvd.ToString("d");
                        }
                        if (!((DataRowView)this.custBindingSource.Current).Row.IsNull("prshpdte"))
                        {
                            var vPrShipDate = (DateTime)((DataRowView)this.custBindingSource.Current).Row["prshpdte"];
                            PrShipDate = vPrShipDate.ToString("d");
                        }


                       
                       
                        ReportParameter rp0 = new ReportParameter("KitRecvd", KitRecvd);
                        ReportParameter rp1 = new ReportParameter("PromiseShipDate", PrShipDate);
                        reportViewer2.LocalReport.SetParameters(new ReportParameter[] { rp0,rp1 });
                        this.reportViewer2.RefreshReport();
                    }
                    catch (Exception ex)
                    {
                        MbcMessageBox.Error(ex.Message, "");
                    }
                  
                    break;
                case "ENVELOPELABEL":
                    //change reportviewer source report
                    try
                    {
                        reportViewer2.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.30321Envelope.rdlc";
                        reportViewer2.LocalReport.DataSources.Clear();
                        reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", custBindingSource));
                       this.reportViewer2.RefreshReport();
                    }
                    catch (Exception ex)
                    {
                        MbcMessageBox.Error(ex.Message, "");
                    }

                    break;
                default:
                    MbcMessageBox.Stop("Missing Parameter", "");
                    break;
            }    
        }
        private void SetConnectionString()
        {
            frmMain frmMain = (frmMain)this.MdiParent;
            xsuppliesTableAdapter.Connection.ConnectionString= frmMain.AppConnectionString;
            this.custTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.statesTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpLeadSourceTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpLeadNameTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.custSearchTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpSupplyItemsTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpMultiYearOptionsTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpTypeContTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpPromotionsTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpPrevPubTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpNoRebookTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpschtypeTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpMktReferenceTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpCommentsTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.datecontTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpschtypeTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpSupplyItemsTableAdapter.Connection.ConnectionString= frmMain.AppConnectionString;
            this.contpstnTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.mktinfoTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.xsuppliesTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.xSuppliesDetailTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;

        }
        public override void OracleCodeSearch() {
			var currentOracleCode = oraclecodeTextBox.Text;
			if (DoPhoneLog()) {
				MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
           
                var custSaveResult = Save();
                if (custSaveResult.IsError) {
                    DialogResult result1 = MessageBox.Show("Record failed to save, correct and save again.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            

			frmSearch frmSearch = new frmSearch("OracleCode", "Cust", currentOracleCode);

			var result = frmSearch.ShowDialog();
			if (result == DialogResult.OK) {
                string retSchcode = frmSearch.ReturnValue.Schcode;
                if (string.IsNullOrEmpty(retSchcode))
                {
                    return;
                }
			          //values preserved after close
				int records = 0;
				try {
					records = this.custTableAdapter.Fill(this.dsCust.cust, retSchcode);
                   
                   
				
				} catch (Exception ex) {
					MbcMessageBox.Error(ex.Message, "Error");
					return;

				}
				try {
					this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
					this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
					TeleGo = false;
				} catch (Exception ex) {
					MbcMessageBox.Error(ex.Message, "Error");
				}
				this.Cursor = Cursors.Default;
			} else { return; }

			SetInvnoSchCode();
			frmMbcCust_Paint(this, null);
		}
		public override void SchnameSearch() {
			var currentSchool = this.Schcode;
			if (DoPhoneLog()) {
				MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
			var custSaveResult = Save();
			if (custSaveResult.IsError) {
				DialogResult result1 = MessageBox.Show("Record failed to save correct and save again.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}


			frmSearch frmSearch = new frmSearch("Schname", "Cust", txtSchname.Text.Trim());

			var result = frmSearch.ShowDialog();
			if (result == DialogResult.OK) {
				string retSchcode = frmSearch.ReturnValue.Schcode;            //values preserved after close
				if (string.IsNullOrEmpty(retSchcode)) {
					MbcMessageBox.Hand("A search value was not returned", "Error");
				}
				int records = 0;
				try {
					records = this.custTableAdapter.Fill(this.dsCust.cust, retSchcode);
					//records = this.custTableAdapter.Fill(this.dsCust.cust, txtSchCodesrch.Text);
				} catch (Exception ex) {
					MbcMessageBox.Error(ex.Message, "Error");
					return;

				}
				try {
					this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
					this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
					TeleGo = false;
				} catch (Exception ex) {
					MbcMessageBox.Error(ex.Message, "Error");
				}
				this.Cursor = Cursors.Default;
			} else { return; }

			SetInvnoSchCode();
			frmMbcCust_Paint(this, null);
		}
		public override void SchCodeSearch() {
			var currentSchool = this.Schcode;
			if (DoPhoneLog()) {
				MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
			var custSaveResult = Save();
			if (custSaveResult.IsError) {
				DialogResult result1 = MessageBox.Show("Record failed to save. Hit cancel to correct.", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if (result1 == DialogResult.Cancel) {
					return;
				}
			}

			frmSearch frmSearch = new frmSearch("Schcode", "Cust", Schcode);

			var result = frmSearch.ShowDialog();
			if (result == DialogResult.OK) {
				string retSchcode = frmSearch.ReturnValue.Schcode;            //values preserved after close
				if (string.IsNullOrEmpty(retSchcode)) {
					MbcMessageBox.Hand("A search value was not returned", "Error");
				}
				int records = 0;
				try {
					records = this.custTableAdapter.Fill(this.dsCust.cust, retSchcode);
					//records = this.custTableAdapter.Fill(this.dsCust.cust, txtSchCodesrch.Text);
				} catch (Exception ex) {
					MbcMessageBox.Error(ex.Message, "Error");
					return;

				}
				try {
					this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
					this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
					TeleGo = false;
				} catch (Exception ex) {
					MbcMessageBox.Error(ex.Message, "Error");
				}
				this.Cursor = Cursors.Default;
			} else { return; }

			SetInvnoSchCode();
			frmMbcCust_Paint(this, null);
		}
		public override void ProdutnNoSearch() {
			var currentSchool = this.Schcode;
			if (DoPhoneLog()) {
				MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
			var custSaveResult = Save();
			if (custSaveResult.IsError) {
				DialogResult result1 = MessageBox.Show("Record failed to save. Hit cancel to correct.", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if (result1 == DialogResult.Cancel) {
					return;
				}
			}
			DataRowView current = (DataRowView)custBindingSource.Current;
			string vProdNo = current["Prodno"].ToString().Substring(1,5);

			frmSearch frmSearch = new frmSearch("PRODNO", "Cust", vProdNo);

			var result = frmSearch.ShowDialog();
			if (result == DialogResult.OK) {
				string retSchcode = frmSearch.ReturnValue.Schcode;            //values preserved after close
				if (string.IsNullOrEmpty(retSchcode)) {
					MbcMessageBox.Hand("A search value was not returned","Error");
				}
				int records = 0;
				try {
					records = this.custTableAdapter.Fill(this.dsCust.cust, retSchcode);
					//records = this.custTableAdapter.Fill(this.dsCust.cust, txtSchCodesrch.Text);
				} catch (Exception ex) {
					MbcMessageBox.Error(ex.Message, "Error");
					return;

				}
				try {
					this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
					this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
					TeleGo = false;
				} catch (Exception ex) {
					MbcMessageBox.Error(ex.Message, "Error");
				}
				this.Cursor = Cursors.Default;
			} else { return; }

			SetInvnoSchCode();
			frmMbcCust_Paint(this, null);

		}
        public override void InvoiceNumberSearch()
        {
            var currentSchool = this.Schcode;
            if (DoPhoneLog())
            {
                MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result1 = MessageBox.Show("Record failed to save. Hit cancel to correct.", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result1 == DialogResult.Cancel)
                {
                    return;
                }
            }

            frmSearch frmSearch = new frmSearch("Invno", "Cust", this.Invno.ToString());

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                string retSchcode = frmSearch.ReturnValue.Schcode;            //values preserved after close
                if (string.IsNullOrEmpty(retSchcode))
                {
                    MbcMessageBox.Hand("A search value was not returned", "Error");
                }
                int records = 0;
                try
                {
                    records = this.custTableAdapter.Fill(this.dsCust.cust, retSchcode);
                    //records = this.custTableAdapter.Fill(this.dsCust.cust, txtSchCodesrch.Text);
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                try
                {
                    this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
                    this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
                    TeleGo = false;
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                }
                this.Cursor = Cursors.Default;
            }
            else { return; }

            SetInvnoSchCode();
            frmMbcCust_Paint(this, null);

        }
        public override void FirstNameSearch()
        {
            var currentSchool = this.Schcode;
            if (DoPhoneLog())
            {
                MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result1 = MessageBox.Show("Record failed to save. Hit cancel to correct.", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result1 == DialogResult.Cancel)
                {
                    return;
                }
            }

            frmSearch frmSearch = new frmSearch("FirstName", "Cust","");

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                string retSchcode = frmSearch.ReturnValue.Schcode;            //values preserved after close
                if (string.IsNullOrEmpty(retSchcode))
                {
                    MbcMessageBox.Hand("A search value was not returned", "Error");
                }
                int records = 0;
                try
                {
                    records = this.custTableAdapter.Fill(this.dsCust.cust, retSchcode);
                    //records = this.custTableAdapter.Fill(this.dsCust.cust, txtSchCodesrch.Text);
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                try
                {
                    this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
                    this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
                    TeleGo = false;
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                }
                this.Cursor = Cursors.Default;
            }
            else { return; }

            SetInvnoSchCode();
            frmMbcCust_Paint(this, null);

        }
        public override void LastNameSearch()
        {
            var currentSchool = this.Schcode;
            if (DoPhoneLog())
            {
                MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result1 = MessageBox.Show("Record failed to save. Hit cancel to correct.", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result1 == DialogResult.Cancel)
                {
                    return;
                }
            }

            frmSearch frmSearch = new frmSearch("LastName", "Cust", "");

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                string retSchcode = frmSearch.ReturnValue.Schcode;            //values preserved after close
                if (string.IsNullOrEmpty(retSchcode))
                {
                    MbcMessageBox.Hand("A search value was not returned", "Error");
                }
                int records = 0;
                try
                {
                    records = this.custTableAdapter.Fill(this.dsCust.cust, retSchcode);
                    //records = this.custTableAdapter.Fill(this.dsCust.cust, txtSchCodesrch.Text);
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                try
                {
                    this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
                    this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
                    TeleGo = false;
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                }
                this.Cursor = Cursors.Default;
            }
            else { return; }

            SetInvnoSchCode();
            frmMbcCust_Paint(this, null);

        }
        public override void ZipCodeSearch()
        {
            var currentSchool = this.Schcode;
            if (DoPhoneLog())
            {
                MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result1 = MessageBox.Show("Record failed to save. Hit cancel to correct.", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result1 == DialogResult.Cancel)
                {
                    return;
                }
            }

            frmSearch frmSearch = new frmSearch("ZipCode", "Cust", "");

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                string retSchcode = frmSearch.ReturnValue.Schcode;            //values preserved after close
                if (string.IsNullOrEmpty(retSchcode))
                {
                    MbcMessageBox.Hand("A search value was not returned", "Error");
                }
                int records = 0;
                try
                {
                    records = this.custTableAdapter.Fill(this.dsCust.cust, retSchcode);
                    //records = this.custTableAdapter.Fill(this.dsCust.cust, txtSchCodesrch.Text);
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                try
                {
                    this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
                    this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
                    TeleGo = false;
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                }
                this.Cursor = Cursors.Default;
            }
            else { return; }

            SetInvnoSchCode();
            frmMbcCust_Paint(this, null);

        }
        public override void EmailSearch()
        {
            var currentSchool = this.Schcode;
            if (DoPhoneLog())
            {
                MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result1 = MessageBox.Show("Record failed to save. Hit cancel to correct.", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result1 == DialogResult.Cancel)
                {
                    return;
                }
            }

            frmSearch frmSearch = new frmSearch("Email", "Cust", "");

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                string retSchcode = frmSearch.ReturnValue.Schcode;            //values preserved after close
                if (string.IsNullOrEmpty(retSchcode))
                {
                    MbcMessageBox.Hand("A search value was not returned", "Error");
                }
                int records = 0;
                try
                {
                    records = this.custTableAdapter.Fill(this.dsCust.cust, retSchcode);
                    //records = this.custTableAdapter.Fill(this.dsCust.cust, txtSchCodesrch.Text);
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                try
                {
                    this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
                    this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
                    TeleGo = false;
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                }
                this.Cursor = Cursors.Default;
            }
            else { return; }

            SetInvnoSchCode();
            frmMbcCust_Paint(this, null);

        }
        public override void JobNoSearch()
        {
            DataRowView currentrow = (DataRowView)custBindingSource.Current;
            var jobno = currentrow["jobno"].ToString();
            if (DoPhoneLog())
            {
                MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result1 = MessageBox.Show("Record failed to save. Hit cancel to correct.", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result1 == DialogResult.Cancel)
                {
                    return;
                }
            }

            frmSearch frmSearch = new frmSearch("JobNo", "Cust", jobno);

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                string retSchcode = frmSearch.ReturnValue.Schcode;            //values preserved after close
                if (string.IsNullOrEmpty(retSchcode))
                {
                    MbcMessageBox.Hand("A search value was not returned", "Error");
                }
                int records = 0;
                try
                {
                    records = this.custTableAdapter.Fill(this.dsCust.cust, retSchcode);
                    //records = this.custTableAdapter.Fill(this.dsCust.cust, txtSchCodesrch.Text);
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                try
                {
                    this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
                    this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
                    TeleGo = false;
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                }
                this.Cursor = Cursors.Default;
            }
            else { return; }

            SetInvnoSchCode();
            frmMbcCust_Paint(this, null);
        }
        private void AddSalesRecord()
		{
			DialogResult result = MessageBox.Show("Do you wish to add a sales record?", "Add Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
                int InvNum = this.frmMain.GetNewInvno();
                    //old function GetInvno();
                  
				if (InvNum != 0)
				{
					var sqlQuery = new SQLQuery();
					try {
						SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@Invno",InvNum),
					 new SqlParameter("@Schcode",this.Schcode),
					  new SqlParameter("@Contryear", contryearTextBox.Text)
					};
						var strQuery = "INSERT INTO [dbo].[Quotes](Invno,Schcode,Contryear)  VALUES (@Invno,@Schcode,@Contryear)";

						var userResult = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters);
						if (userResult != 1) {
							MessageBox.Show("Failed to insert sales record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return;
						}
						SqlParameter[] parameters1 = new SqlParameter[] {
					new SqlParameter("@Invno",InvNum),
					 new SqlParameter("@Schcode",this.Schcode),
					 new SqlParameter("@ProdNo",this.frmMain.GetProdNo()),
					  new SqlParameter("@Contryear", contryearTextBox.Text),
					   new SqlParameter("@Company","MBC"),
                      new SqlParameter("@ProdCustDate",contdateDateBox.Date)
                    };
						strQuery = "INSERT INTO [dbo].[produtn](Invno,Schcode,Contryear,Prodno,Company,ProdCustDate)  VALUES (@Invno,@Schcode,@Contryear,@ProdNo,@Company,@ProdCustDate)";
						var userResult1 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters1);
						if (userResult1 != 1) {
							MessageBox.Show("Failed to insert production record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return;
						}
                        
						SqlParameter[] parameters2 = new SqlParameter[] {
					new SqlParameter("@Invno",InvNum),
					 new SqlParameter("@Schcode",this.Schcode),
					 new SqlParameter("@Specovr",frmMain.GetCoverNumber()),
						 new SqlParameter("@Specinst",GetInstructions() ),
					   new SqlParameter("@Company","MBC"),
                    
                    };
						strQuery = "Insert into Covers (schcode,invno,company,specovr,Specinst) Values(@Schcode,@Invno,@Company,@Specovr,@Specinst)";
						var userResult2 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters2);
						if (userResult2 != 1) {
							MessageBox.Show("Failed to insert covers record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return;
						}

						SqlParameter[] parameters3 = new SqlParameter[] {
					new SqlParameter("@Invno",InvNum),
					 new SqlParameter("@Schcode",this.Schcode),

					   new SqlParameter("@Company","MBC")
					};
						strQuery = "Insert into Wip (schcode,invno) Values(@Schcode,@Invno)";
						var Result3 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters3);
						if (Result3 != 1) {
							MessageBox.Show("Failed to insert wip record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return;
						}
					}catch(Exception ex) {
						MbcMessageBox.Error(ex.Message, "");
						return;
					}

                    Fill();
					
                    this.SetInvnoSchCode();
                };
			}//not = 0
		}
		private void GoToSales() {

            var a = this.lblSchcode.Text;
                this.Cursor = Cursors.AppStarting;
                     int vInvno = this.Invno;
                    string vSchcode = this.Schcode;

                frmSales frmSales = new frmSales(this.ApplicationUser,vInvno,vSchcode);
                frmSales.MdiParent = this.MdiParent;
                frmSales.Show();
                this.Cursor = Cursors.Default;

                

            }
        private bool DoPhoneLog() {
            bool retval = true;
            frmMain vparent =(frmMain) this.ParentForm;
            
            if(vparent.ValidatedUserRoles.Contains("SA")|| vparent.ValidatedUserRoles.Contains("Administrator")) {
               retval= false;

                }
            if (this.Schcode == "038752") {
                retval = false;

                }
            if (this.TeleGo && this.MktGo) {
                retval = false;

                }
            return retval;
             }
        //private int GetInvno()
        //{
        //No longer in use
           
        //    var sqlQuery = new BaseClass.Classes.SQLQuery();

        //    SqlParameter[] parameters = new SqlParameter[] {

        //            };
        //    var strQuery = "SELECT Invno FROM Invcnum";
        //    try
        //    {
        //        DataTable userResult = sqlQuery.ExecuteReaderAsync(CommandType.Text, strQuery, parameters);
        //        DataRow dr = userResult.Rows[0];
        //        int Invno =(int) dr["Invno"];
        //        int newInvno = Invno + 1;
        //        strQuery = "Update Invcnum Set invno=@newInvno";
        //        SqlParameter[] parameters1 = new SqlParameter[] {
        //              new SqlParameter("@newInvno",newInvno),
        //            };
        //        sqlQuery.ExecuteNonQueryAsync(CommandType.Text,strQuery,parameters1);

        //        return Invno;

        //    }catch(Exception ex)
        //    {
        //        Log.Error("Failed to get invoice number for a new record:" + ex.Message);
        //        MessageBox.Show("Failed to get invoice number for a new record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return 0;

        //    }
           
        //}
        //private string GetProdNo() {
        //    No longer in user
        //    var sqlQuery = new SQLQuery();
        //    //useing hard code until function to generate invno is done
        //    SqlParameter[] parameters = new SqlParameter[] { };
        //    var strQuery = "Select * from prodnum";
        //    var result = sqlQuery.ExecuteReaderAsync(CommandType.Text,strQuery,parameters);
        //    int? prodNum = null;
        //    try {
        //        prodNum = Convert.ToInt32(result.Rows[0]["lstprodno"]);
        //        strQuery = "Update Prodnum Set lstprodno=@lstprodno";
        //        SqlParameter[] parameters1 = new SqlParameter[] { new SqlParameter("@lstprodno",(prodNum + 1)) };
        //        var result1 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text,strQuery,parameters1);
        //        if (result1 != 1) {
        //            ExceptionlessClient.Default.CreateLog("Error updating Prodnum table with new value.")
        //                 .AddTags("New prod number error.")
        //                 .Submit();

        //            }

        //        } catch (Exception ex) {
        //        MessageBox.Show("There was an error getting the production number.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);

        //        ex.ToExceptionless()
        //          .AddTags("MBCWindows")
        //          .SetMessage("Error getting production number.")
        //          .Submit();

        //        }

        //    return prodNum.ToString();

        //    }
        private void SetInvnoSchCode()
        {
            this.Schcode = lblSchcodeVal.Text;
            int val = 0;
            this.Invno = 0;
            bool parsed = Int32.TryParse(lblInvno.Text, out val);
            if (parsed)
            {
                this.Invno = val;
            }
           
        }
        //private string GetCoverNumber() {
        //    No longer in user
        //    var sqlQuery = new SQLQuery();
        //    //useing hard code until function to generate invno is done
        //    SqlParameter[] parameters = new SqlParameter[] {};
        //    var strQuery = "Select * from Spcover";
        //    var result = sqlQuery.ExecuteReaderAsync(CommandType.Text,strQuery,parameters);
        //    int? coverNum=null;
        //    try {
        //           coverNum = Convert.ToInt32(result.Rows[0]["speccvno"]);
        //          strQuery = "Update Spcover set speccvno=@speccvno";
        //        SqlParameter[] parameters1 = new SqlParameter[] { new SqlParameter("@speccvno",(coverNum+1)) };
        //        var result1 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text,strQuery,parameters1);
        //        if (result1 != 1) {
        //            ExceptionlessClient.Default.CreateLog("Error updating Spcover table with new value.")
        //                 .AddTags("New cover number error.")
        //                 .Submit();
                         
        //            }

        //        } catch(Exception ex){
        //        MessageBox.Show("There was an error getting the cover number.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        //        ex.ToExceptionless()
        //          .AddTags("MBCWindows")
        //          .SetMessage("Error getting cover number.")
        //          .Submit();

        //        }

        //    return coverNum.ToString();
        //    }
        private void GetSetSchcode() {
            SqlConnection conn = new SqlConnection(frmMain.AppConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT precode,schcode from codecnt ",conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();


            try
                {


                string vPreCode = null;
                string vSchcode = null;
                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    {

                    vPreCode = rdr["precode"].ToString();
                    vSchcode = rdr["schcode"].ToString();

                    }
                rdr.Close();
                int tmpSchcode = 0;
                if (Int32.TryParse(vSchcode,out tmpSchcode))
                    {
                    tmpSchcode += 1;
                    this.Schcode = vPreCode + tmpSchcode.ToString();
                    cmd.CommandText = "Update codecnt Set schcode=@schcode";
                    cmd.Parameters.AddWithValue("@schcode",tmpSchcode.ToString());
                    cmd.ExecuteNonQuery();

                    }
                else
                    { this.Schcode = "error"; }


                }

            catch (Exception ex)
                {
                Log.Fatal("Failed to get new schcode:" + ex.Message);
                MessageBox.Show("Error generating school code.","School Code Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;

                }
            finally { cmd.Connection.Close(); }


            }
        private void SaveMktLog() {
            
            this.ValidateChildren();
            DataTable EditedRecs = dsMktInfo.mktinfo.GetChanges();
            if (EditedRecs != null)
                {
                SqlConnection conn = new SqlConnection(FormConnectionString);
                string sql = "UPDATE MktInfo Set note=@note,promo=@promo,refered=@refered where Id=@Id ;";
                SqlCommand cmd = new SqlCommand(sql,conn);
                foreach (DataRow row in EditedRecs.Rows)
                    {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Id",row["Id"]);
                    cmd.Parameters.AddWithValue("@note",row["note"]);
                    cmd.Parameters.AddWithValue("@promo",row["promo"]);
                    cmd.Parameters.AddWithValue("@refered",row["refered"]);
                   

                    try
                        {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        TeleLogAdded = false;
                        MktGo = true;
                        MktLogAdded = false;
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show("Failed to update marketing log record.");
                        Log.Error("Failed to update marketing log:" + ex.Message);
                        }
                    finally { cmd.Connection.Close(); }

                    this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo,this.Schcode);
                    }
                }
            else
                { MessageBox.Show("You do not have any records to be saved.","Log",MessageBoxButtons.OK,MessageBoxIcon.Stop); }
            }
        private void SaveTeleLog() {
             datecontBindingSource.EndEdit();
           var a= this.ValidateChildren(ValidationConstraints.ImmediateChildren);
           
            DataTable EditedRecs = dsCust.datecont.GetChanges();
            if (EditedRecs != null)
                {
                var sqlquery = new SQLCustomClient();
                sqlquery.CommandText("UPDATE DateCont Set Id=@Id,reason=@reason,contact=@contact,typecont=@typecont, nxtdate=@nxtdate,callcont=@callcont, calltime=@calltime,priority=@priority,techcall=@techcall where id=@id ");
             
              
                foreach (DataRow row in EditedRecs.Rows)
                    {
                    sqlquery.ClearParameters();
                   sqlquery.AddParameter("@Id",row["id"]);
                    sqlquery.AddParameter("@reason",row["reason"]);
                    sqlquery.AddParameter("@contact",row["contact"]);
                    sqlquery.AddParameter("@typecont",row["typecont"]);
                    sqlquery.AddParameter("@nxtdate",row["nxtdate"]);
                    sqlquery.AddParameter("@callcont",row["callcont"]);
                    sqlquery.AddParameter("@calltime",row["calltime"]);
                    sqlquery.AddParameter("@priority",row["priority"]);
                    sqlquery.AddParameter("@techcall",row["techcall"]);
                    var logResult=sqlquery.Insert();
                    if (logResult.IsError)
                    {
                        MbcMessageBox.Error("Failed to insert phone log:"+logResult.Errors[0].ErrorMessage, "");
                        ExceptionlessClient.Default.CreateLog("Failed to insert phone log")
                            .AddObject(logResult)
                            .Submit();
                        return;
                    }
                   
                        TeleLogAdded = false;
                        TeleGo = true;
					
					try {
						this.datecontTableAdapter.Fill(this.dsCust.datecont, this.Schcode);
					}catch(Exception ex) {
                        ex.ToExceptionless()
                            .AddObject(ex)
                            .Submit();
						MbcMessageBox.Error(ex.Message, "");
					}
                    
                    }
                }
            else
                {
                
                    MessageBox.Show("You do not have any records to be saved.","Log",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    
                  
                }
            }
        private void DataRefresh() {
			try {
					this.custTableAdapter.Fill(this.dsCust.cust, this.Schcode);
                this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo,this.Schcode);
                this.datecontTableAdapter.Fill(this.dsCust.datecont,this.Schcode);
				this.SetInvnoSchCode();
			}catch(Exception ex) {
				MbcMessageBox.Error(ex.Message, "");
			}
               
        }
        private string GetInstructions()
        {

            DataRowView current = (DataRowView)custBindingSource.Current;
            string instructions = current["spcinst"].ToString();
            return instructions;

        }
        #endregion
 #region Events
        private void txtSchname_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void txtSchname_DoubleClick(object sender, EventArgs e)
        {
            if (ApplicationUser.IsInRole("SA") || ApplicationUser.IsInRole("Administrator"))
            {
                txtSchname.ReadOnly = false;
            }
        }
        private void frmMbcCust_Paint(object sender, PaintEventArgs e)
        {
            try { this.Text = "MBC Customer-" + txtSchname.Text.Trim() + " (" + this.Schcode.Trim() + ")"; }
            catch
            {

            }
        }
       
        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            string body = txtSchname.Text.Trim() + "<br/>" + txtaddress.Text.Trim() + "<br/>" + txtCity.Text.Trim() + ", " + cmbState.SelectedValue + ' ' + txtZip.Text.Trim() + "<br/><br/>Congratulations to the Jostens Team...Memory Book just signed the following NEW customer in your territory for the " + contryearTextBox.Text + " school year! ";
            string subj = Schcode + " " + txtSchname.Text.Trim() + " " + cmbState.SelectedValue + " NEW SCHOOL By Customer Service Rep " + txtCsRep.Text;
            //string email = "yearbook@memorybook.com;hcantrell@memorybook.com;john.cox@jostens.com;tammy.whitaker@jostens.com";
            
            List<string> emailList = new List<string>();
            var emailHelper = new EmailHelper();
            emailList.Add("randy.woodall@jostens.com");//test email
            //emailList.Add("yearbook@memorybook.com");
            //emailList.Add("hcantrell@memorybook.com");
            //emailList.Add("john.cox@jostens.com");
            //emailList.Add("tammy.whitaker@jostens.com");
            EmailType type = EmailType.Mbc;
            emailHelper.SendOutLookEmail(subj, emailList, "", body, type);
            this.Cursor = Cursors.Default;


        }
        private void contdateDateTimePicker_CloseUp(object sender, EventArgs e)
        {

            AddSalesRecord();

        }
        private void btnWebsite_Click_1(object sender, EventArgs e)
        {
            try
            { Process.Start(txtWebsite.Text); }
            catch (Exception ex)
            {
                MessageBox.Show("Url is invalid.");
            }

        }
        private void txtSchname_DoubleClick_1(object sender, EventArgs e)
        {
            //if (ApplicationUser.IsInRole("SA") || ApplicationUser.IsInRole("Administrator"))
            //{
                txtSchname.ReadOnly = false;
           // }
        }
        private void btnEmailContac3_Click_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtContact3Email.Text))
            {
                this.errorProvider1.SetError(txtContact3Email, string.Empty);
                var emailHelper = new EmailHelper();
                emailHelper.SendOutLookEmail("", txtContactEmail.Text, "", "", EmailType.Mbc);
            }
            else
            {
                this.errorProvider1.SetError(txtContact3Email, "Email address is required.");
            }

        }
        private void btnEmailCont2_Click_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtContact2Email.Text))
            {
                this.errorProvider1.SetError(txtContact2Email, string.Empty);
                var emailHelper = new EmailHelper();
                emailHelper.SendOutLookEmail("", txtContactEmail.Text, "", "", EmailType.Mbc);
            }
            else
            {
                this.errorProvider1.SetError(txtContact2Email, "Email address is required.");
            }

        }
     
        private void btnProdTckt_Click(object sender, EventArgs e)
        {
            //this.basePanel.Visible = true;
            //backgroundWorker1.RunWorkerAsync("PrintProductionTicket");
            var result=PrintProductionTicket();
            if (result.IsError)
            {
                MbcMessageBox.Error(result.Errors[0].ErrorMessage);
            }


        }
        private void reportViewer1_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try { reportViewer1.PrintDialog(); } catch (Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
            Cursor.Current = Cursors.Default;
        }
        private void splitContainer_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void frmMbcCust_Shown(object sender, EventArgs e)
        {
            CustTab.Visible = true;
            SetInvnoSchCode();
        }
        private void btnProdChk_Click(object sender, EventArgs e)
        {
            //basePanel.Visible = true;
            //backgroundWorker1.RunWorkerAsync("PrintProdCheckList");
            var result = PrintProdCheckList();
            if (result.IsError)
            {
                MbcMessageBox.Error(result.Errors[0].ErrorMessage);
            }
        }
        private void reportViewerCheckList_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try { reportViewer1.PrintDialog(); } catch (Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
            Cursor.Current = Cursors.Default;
        }
        private void AddLeadName_Click(object sender, EventArgs e)
        {
            LkpLeadName frmLkpLeadName = new LkpLeadName(this.ApplicationUser);
            this.Cursor = Cursors.AppStarting;
            frmLkpLeadName.MdiParent = this.ParentForm;
            frmLkpLeadName.Show();
            this.Cursor = Cursors.Default;
        }
        private void leadsourceComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (ApplicationUser.IsInRole("Administrator") || ApplicationUser.IsInRole("SA"))
            {
                if (e.Button == MouseButtons.Right)
                {
                    addItemMenu.Items["AddLeadSource"].Visible = true;
                    addItemMenu.Items["AddLeadName"].Visible = false;
                    addItemMenu.Show(this, new Point(e.X, e.Y));
                }
            }
        }
        private void leadnameComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (ApplicationUser.IsInRole("Administrator") || ApplicationUser.IsInRole("SA"))
            {
                if (e.Button == MouseButtons.Right)
                {
                    addItemMenu.Items["AddLeadName"].Visible = true;
                    addItemMenu.Items["AddLeadSource"].Visible = false;
                    addItemMenu.Show(this, new Point(e.X, e.Y));
                }
            }
        }
        private void AddLeadSource_Click(object sender, EventArgs e)
        {
            LkpLeadSource frmLkpLeadSource = new LkpLeadSource(this.ApplicationUser);
            this.Cursor = Cursors.AppStarting;
            frmLkpLeadSource.MdiParent = this.ParentForm;
            frmLkpLeadSource.Show();
            this.Cursor = Cursors.Default;
        }
       
        private void frmMbcCust_Activated(object sender, EventArgs e)
        {

            try { frmMain.ShowSearchButtons(this.Name); } catch { }
        }
        private void frmMbcCust_Deactivate(object sender, EventArgs e)
        {
            try { frmMain.HideSearchButtons(); } catch { }

        }
        private void btnMainLog_Click(object sender, EventArgs e)
        {
            AddLog();
        }
        private void btnAddcust_Click(object sender, EventArgs e)
        {
            Add();
        }
        private void btnInterOffice_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.AppStarting;
            string body = inofficeTextBox.Text;
            string subj = txtSchname.Text.Trim() + " " + Schcode;
            string email = "yearbook@memorybook.com";
            var emailHelper = new EmailHelper();
            EmailType type = EmailType.Mbc;
            emailHelper.SendOutLookEmail(subj, email, "", body, type);
            this.Cursor = Cursors.Default;

        }
        private void btnSchoolEmail_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            string body = "";
            string subj = txtSchname.Text.Trim() + " " + Schcode + " " + cmbState.SelectedValue.ToString();
            var dr = (DataRowView)custBindingSource.Current;
            var vCont1 = dr["schemail"].ToString().Trim();
           
            List<string> emailList = new List<string>();
            var emailHelper = new EmailHelper();
            if (!string.IsNullOrEmpty(vCont1))
            {
                emailList.Add(vCont1);
            }
           
            EmailType type = EmailType.Mbc;
            emailHelper.SendOutLookEmail(subj, emailList, "", body, type);
            this.Cursor = Cursors.Default;
        }
        private void btnEmailContact_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtContactEmail.Text))
            {
                this.errorProvider1.SetError(txtContactEmail, string.Empty);
                var emailHelper = new EmailHelper();
                emailHelper.SendOutLookEmail("", txtContactEmail.Text, "", "", EmailType.Mbc);
            }
            else
            {
                this.errorProvider1.SetError(txtContactEmail, "Email address is required.");
            }

        }
        private void txtReason_Leave(object sender, EventArgs e)
        {
            datecontDataGridView.Select();
            this.BindingContext[this.datecontDataGridView.DataSource].EndCurrentEdit();
            datecontDataGridView.Refresh();
            datecontDataGridView.Parent.Refresh();
        }
        private void btnAddLog_Click(object sender, EventArgs e)
        {

            AddLog();

        }
        private void btnEditTeleLog_Click(object sender, EventArgs e)
        {
            var vresult = datecontDataGridView.Rows[datecontDataGridView.SelectedCells[0].RowIndex].Cells["id"].Value;
            var vLogId = Convert.ToInt32(vresult);
            frmTeleLogModify frmTeleLogModify = new frmTeleLogModify(vLogId, "T", frmMain);
            DialogResult result = frmTeleLogModify.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    this.datecontTableAdapter.Fill(this.dsCust.datecont, this.Schcode);
                    mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, Schcode);

                }
                catch (Exception ex)
                {
                    ex.ToExceptionless()
                        .AddObject(ex)
                        .Submit();
                    MbcMessageBox.Error(ex.Message, "");
                    return;
                }
            }
        }
        private void btnSaveMktLog_Click(object sender, EventArgs e)
        {
            var vresult = mktinfoDataGridView.Rows[mktinfoDataGridView.SelectedCells[0].RowIndex].Cells["id"].Value;
            var vLogId = Convert.ToInt32(vresult);
            frmTeleLogModify frmTeleLogModify = new frmTeleLogModify(vLogId, "M", frmMain);
            DialogResult result = frmTeleLogModify.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    this.datecontTableAdapter.Fill(this.dsCust.datecont, this.Schcode);
                    mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, Schcode);

                }
                catch (Exception ex)
                {
                    ex.ToExceptionless()
                        .AddObject(ex)
                        .Submit();
                    MbcMessageBox.Error(ex.Message, "");
                    return;
                }
            }
        }
        private void btnAddMarketLog_Click(object sender, EventArgs e)
        {
            AddLog();
        }
        private void AddLog()
        {
            frmTeleLogModify frmTeleLogModify = new frmTeleLogModify("MBC", Schcode, this.frmMain);
            frmTeleLogModify.TopMost = true;
            DialogResult result = frmTeleLogModify.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    this.datecontTableAdapter.Fill(this.dsCust.datecont, this.Schcode);
                    mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, Schcode);
                    TeleGo = true;
                    MktGo = true;
                }
                catch (Exception ex)
                {
                    ex.ToExceptionless()
                        .AddObject(ex)
                        .Submit();
                    MbcMessageBox.Error(ex.Message, "");
                    return;
                }
            }
        }
        private void frmMbcCust_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DoPhoneLog())
            {
                e.Cancel = true;
                MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result = MessageBox.Show("Record failed to save. Continue closing?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

            }

        }
        private void datecontDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                DataGridViewCell cell = (DataGridViewCell)datecontDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = DateTime.Now.ToShortDateString();
            }

        }
        private void mktinfoDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //leave
        }
        private void datecontDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //Leave Here;

        }
        private void pg3_Leave(object sender, EventArgs e)
        {
            //save if user leaves to another tab or form will not affect log check.
            DataTable EditedRecs = dsMktInfo.mktinfo.GetChanges();
            if (EditedRecs != null)
            {
                SaveMktLog();
            }
            DataTable EditedRecs1 = dsCust.datecont.GetChanges();
            if (EditedRecs1 != null)
            {
                SaveTeleLog();
            }
        }
        private void lblSchcodeVal_TextChanged(object sender, EventArgs e)
        {
            SetInvnoSchCode();
        }
        private void custDataGridView_Leave(object sender, EventArgs e)
        {

            lblSchcode.Refresh();
            custDataGridView.Parent.Refresh();
        }
        private void lblInvno_TextChanged(object sender, EventArgs e)
        {
            SetInvnoSchCode();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            var a = new ScreenPrinter(this);
            a.PrintScreen();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            var a = 1;
            ScreenPrinter aa = new ScreenPrinter(this);

        }
        private void pg1_Enter(object sender, EventArgs e)
        {
            if (custBindingSource.Count < 1)
            {
                this.splitContainer.Panel1.Enabled = false;
                this.splitContainer.Panel2.Enabled = false;
            }
        }
        private void custDataGridView_Enter(object sender, EventArgs e)
        {
            try
            {
                this.custTableAdapter.Fill(this.dsCust.cust, this.Schcode);
          
                SetInvnoSchCode();
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error(ex.Message, "");
            }

        }
        private void custDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GoToSales();
        }
        private void contdateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void reportViewer2_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
            try { reportViewer2.PrintDialog(); } catch (Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
        }

        private void shipppingAddrLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnSchoolToInvoice_Click(object sender, EventArgs e)
         {
            var vInvAddress = ((DataRowView)custBindingSource.Current).Row["Schaddr"].ToString().Trim();
            invAddrTextBox.Text = vInvAddress;
            var vInvAddress2 = ((DataRowView)custBindingSource.Current).Row["SchAddr2"].ToString().Trim();
            invAddr2TextBox.Text = vInvAddress2;
            var vInvCity = ((DataRowView)custBindingSource.Current).Row["SchCity"].ToString().Trim();
            invCityTextBox.Text = vInvCity;
            var vInvState = ((DataRowView)custBindingSource.Current).Row["SchState"].ToString().Trim();
            cmbInvStateComboBox.SelectedValue = vInvState;
            var vInvZipcode = ((DataRowView)custBindingSource.Current).Row["SchZip"].ToString().Trim();
            var vInvEmail1 = ((DataRowView)custBindingSource.Current).Row["SchEmail"].ToString().Trim();
            invoiceEmail1TextBox.Text = vInvEmail1;
            var vInvEmail2 = ((DataRowView)custBindingSource.Current).Row["ContEmail"].ToString().Trim();
            invoiceEmail2TextBox.Text = vInvEmail2;
            var vInvEmail3 = ((DataRowView)custBindingSource.Current).Row["BContEmail"].ToString().Trim();
            invoiceEmail3TextBox.Text = vInvEmail3;
            if (vInvZipcode.Length>5)
            {
                invZipCodeTextBox.Text = vInvZipcode.Substring(0, 5);
            }
            else
            {
                invZipCodeTextBox.Text = vInvZipcode;
            }
            
        }

        private void btnSchoolToShipping_Click(object sender, EventArgs e)
        {
            var vShpAddress = ((DataRowView)custBindingSource.Current).Row["Schaddr"].ToString().Trim();
            shipppingAddrTextBox1.Text = vShpAddress;
            var vShpAddress2 = ((DataRowView)custBindingSource.Current).Row["SchAddr2"].ToString().Trim();
            shippingAddr2TextBox1.Text = vShpAddress2;
             var vShpCity = ((DataRowView)custBindingSource.Current).Row["SchCity"].ToString().Trim();
            shippingCityTextBox.Text = vShpCity;
            var vShpState = ((DataRowView)custBindingSource.Current).Row["SchState"].ToString().Trim();
            cmbshippingState.SelectedValue = vShpState;
            var vShpZipcode = ((DataRowView)custBindingSource.Current).Row["SchZip"].ToString().Trim();
            if (vShpZipcode.Length>0)
            {
                shippingZipCodeTextBox.Text = vShpZipcode.Substring(0, 5);
            }
            else
            {
                shippingZipCodeTextBox.Text = vShpZipcode;
            }
            
         
        }

        private void btnSaveInformation_Click(object sender, EventArgs e)
        {
            SaveAddressInfo();
           
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        

        private void btnSaveSupply_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            int vqty = 0;
            int vInvno = 0;
            if (!int.TryParse(txtSupplyQty.Text, out vqty) || vqty == 0)
            {
                errorProvider1.SetError(txtSupplyQty, "Enter a valid quantity.");
                return;
            }
            
            else if (cmbSupplyItem.SelectedValue == null || cmbSupplyItem.SelectedValue.ToString() == "--Select Item--")
            {
                errorProvider1.SetError(cmbSupplyItem, "Select an item.");
                return;
            }


            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"
                                            INSERT INTO XSuppliesDetail(Item,Quantity,Schcode,Invno,XSuppliesID)
                                            Values(@Item,@Quantity,@Schcode,@Invno,@XSuppliesID)"
                                 );
     
            sqlClient.AddParameter("@Item", cmbSupplyItem.SelectedValue.ToString());
            sqlClient.AddParameter("@Quantity", txtSupplyQty.Text);
            sqlClient.AddParameter("@Schcode", Schcode);
            sqlClient.AddParameter("@Invno", Invno);
            sqlClient.AddParameter("@XSuppliesID",lblId.Text);
            var insertResult = sqlClient.Insert();
            if (insertResult.IsError)
            {
                MbcMessageBox.Error("Failed to insert xsuppliesDetails record:"+insertResult.Errors[0].ErrorMessage, "");
                ExceptionlessClient.Default.CreateLog(insertResult.Errors[0].ErrorMessage)
                    .AddObject(insertResult)
                    .Submit();
                return;
            }

            pnlAdd.Visible = false;
            btnAddDetail.Visible = true;
            txtSupplyQty.Text = "";
            cmbSupplyItem.SelectedValue = "";
            errorProvider1.Clear();
            try
            {
               
                xSuppliesDetailTableAdapter.Fill(dsXSupplies.XSuppliesDetail, Schcode);

            }
            catch
            {

            }
                
               

        }

        private void txtSupplyQty_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void pg4_Leave(object sender, EventArgs e)
        {
            SaveAddressInfo();
        }

        private void btnNewSupplyRecord_Click(object sender, EventArgs e)
        {
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Insert Into XSupplies (Schcode,Schname,Schphone,Invno,AdvisorName,ShipAddress,ShipAddress2,ShipCity,ShipState,ShipZipCode)
                                        VALUES(@Schcode,@Schname,@Schphone,@Invno,@AdvisorName,@ShipAddress,@ShipAddress2,@ShipCity,@ShipState,@ShipZipCode)");
            

            var vAdvisorName = ((DataRowView)custBindingSource.Current).Row["contfname"].ToString().Trim()+" "+ ((DataRowView)custBindingSource.Current).Row["contlname"].ToString().Trim();
            sqlClient.AddParameter("@AdvisorName", vAdvisorName);
            sqlClient.AddParameter("@Schname", ((DataRowView)custBindingSource.Current).Row["schname"].ToString().Trim());
            sqlClient.AddParameter("@Schphone", ((DataRowView)custBindingSource.Current).Row["schphone"].ToString().Trim());
            sqlClient.AddParameter("@Schcode",Schcode);
            sqlClient.AddParameter("@Invno",Invno);
            sqlClient.AddParameter("@ShipAddress", ((DataRowView)custBindingSource.Current).Row.IsNull("shipaddr") ?"":((DataRowView)custBindingSource.Current).Row["shipaddr"].ToString());
            sqlClient.AddParameter("@ShipAddress2", ((DataRowView)custBindingSource.Current).Row.IsNull("ShippingAddr2") ? "" : ((DataRowView)custBindingSource.Current).Row["ShippingAddr2"].ToString());
            sqlClient.AddParameter("@ShipCity", ((DataRowView)custBindingSource.Current).Row.IsNull("ShippingCity") ? "" : ((DataRowView)custBindingSource.Current).Row["ShippingCity"].ToString());
            sqlClient.AddParameter("@ShipState", ((DataRowView)custBindingSource.Current).Row.IsNull("ShippingState") ? "" : ((DataRowView)custBindingSource.Current).Row["ShippingState"].ToString());
            sqlClient.AddParameter("@ShipZipCode", ((DataRowView)custBindingSource.Current).Row.IsNull("ShippingZipCode") ? "" : ((DataRowView)custBindingSource.Current).Row["ShippingZipCode"].ToString());
            var insertResult = sqlClient.Insert();
            if (insertResult.IsError)
            {
                MbcMessageBox.Error("Failed to insert a supply record:" + insertResult.Errors[0].ErrorMessage,"");
                ExceptionlessClient.Default.CreateLog("Failed to insert a supply record")
                    .AddObject(insertResult)
                    .Submit();
                return;
            }
            var vId = insertResult.Data;
            this.xsuppliesTableAdapter.Fill(this.dsXSupplies.xsupplies, Schcode);
           var vPos= xSuppliesBindingSource.Find("Id", vId);
            if (vPos > -1)
            {
                xSuppliesBindingSource.Position = vPos;
            }

        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            this.pnlAdd.Visible = true;
            btnAddDetail.Visible = false;
            
        }

        private void btnCancelSupply_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
           
            txtSupplyQty.Text = "";
            cmbSupplyItem.SelectedValue = "";
            this.pnlAdd.Visible = false;
            btnAddDetail.Visible = true;
        }

        private void xSuppliesDetailDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var vId = senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                var sqlClient = new SQLCustomClient();
                sqlClient.CommandText(@"Delete FROM XSuppliesDetail where Id=@Id");
                sqlClient.AddParameter("@Id", vId);
               var deleteResult= sqlClient.Delete();
                if (deleteResult.IsError)
                {
                    MbcMessageBox.Error("Delete failed:" + deleteResult.Errors[0].ErrorMessage, "");
                    return;
                }
                xSuppliesDetailBindingSource.RemoveCurrent();
            }
        }

        private void pg5_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            reportViewer3.RefreshReport();
        }

      

        private void reportViewer3_RenderingComplete_1(object sender, RenderingCompleteEventArgs e)
        {
            try { reportViewer3.PrintDialog(); } catch (Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Fill();
           
        }

        private void txtSchname_Validating_1(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtSchname, "");
            if (txtSchname.Text.Trim()=="")
            {
                errorProvider1.SetError(txtSchname, "Name is required");
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var vShpAddress = ((DataRowView)custBindingSource.Current).Row["Contaddr"].ToString().Trim();
            shipppingAddrTextBox1.Text = vShpAddress;
            var vShpAddress2 = ((DataRowView)custBindingSource.Current).Row["ContAddr2"].ToString().Trim();
            shippingAddr2TextBox1.Text = vShpAddress2;
            var vShpCity = ((DataRowView)custBindingSource.Current).Row["ContCity"].ToString().Trim();
            shippingCityTextBox.Text = vShpCity;
            var vShpState = ((DataRowView)custBindingSource.Current).Row["ContState"].ToString().Trim();
            cmbshippingState.SelectedValue = vShpState;
            var vShpZipcode = ((DataRowView)custBindingSource.Current).Row["ContZip"].ToString().Trim();
            if (vShpZipcode.Length > 0)
            {
                shippingZipCodeTextBox.Text = vShpZipcode.Substring(0, 5);
            }
            else
            {
                shippingZipCodeTextBox.Text = vShpZipcode;
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            EmailAllContacts();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            EmailAllContacts();
        }

        private void contdateDateBox_Leave(object sender, EventArgs e)
        {
            AddSalesRecord();
        }

        private void reportViewer2_RenderingComplete_1(object sender, RenderingCompleteEventArgs e)
        {
            reportViewer2.PrintDialog();
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var vShpAddress = ((DataRowView)custBindingSource.Current).Row["Schaddr"].ToString().Trim();
            txtOtherAddr.Text = vShpAddress;
            var vShpAddress2 = ((DataRowView)custBindingSource.Current).Row["SchAddr2"].ToString().Trim();
            txtOtherAddr2.Text = vShpAddress2;
            var vShpCity = ((DataRowView)custBindingSource.Current).Row["SchCity"].ToString().Trim();
            txtOtherCity.Text = vShpCity;
            var vShpState = ((DataRowView)custBindingSource.Current).Row["SchState"].ToString().Trim();
            cmbOtherState.SelectedValue = vShpState;
            var vShpZipcode = ((DataRowView)custBindingSource.Current).Row["SchZip"].ToString().Trim();
            if (vShpZipcode.Length > 0)
            {
                txtOtherZipCode.Text = vShpZipcode.Substring(0, 5);
            }
            else
            {
                txtOtherZipCode.Text = vShpZipcode;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var vShpAddress = ((DataRowView)custBindingSource.Current).Row["Contaddr"].ToString().Trim();
            txtOtherAddr.Text = vShpAddress;
            var vShpAddress2 = ((DataRowView)custBindingSource.Current).Row["ContAddr2"].ToString().Trim();
            txtOtherAddr2.Text = vShpAddress2;
            var vShpCity = ((DataRowView)custBindingSource.Current).Row["ContCity"].ToString().Trim();
            txtOtherCity.Text = vShpCity;
            var vShpState = ((DataRowView)custBindingSource.Current).Row["ContState"].ToString().Trim();
            cmbOtherState.SelectedValue = vShpState;
            var vShpZipcode = ((DataRowView)custBindingSource.Current).Row["ContZip"].ToString().Trim();
            if (vShpZipcode.Length > 0)
            {
                txtOtherZipCode.Text = vShpZipcode.Substring(0, 5);
            }
            else
            {
                txtOtherZipCode.Text = vShpZipcode;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //this.basePanel.Visible = true;
            //backgroundWorker1.RunWorkerAsync("UpdateUPSAddress");
            var result=UpdateUpsAddresses();
            if (result.IsError)
            {
                MbcMessageBox.Error(result.Errors[0].ErrorMessage);
            }
           
        }

        private void txtaddress_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.basePanel.Visible = true;
            
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string Arg = e.Argument.ToString();

           ApiProcessingResult<bool> taskResult ;
            var result = new ApiProcessingResult();
            switch (Arg)
            {
                case "UpdateUPSAddress":
                    result = UpdateUpsAddresses();
                   
                    break;
                case "PrintProductionTicket":
                    result = PrintProductionTicket();
                    

                    break;
                case "PrintProdCheckList":
                    result = PrintProdCheckList();
                 
                    break;
                case "Save":
                 
                   result = Save();
              
                    break;


            }
            System.Threading.Thread.Sleep(2000);
            e.Result = result;
            
              
           
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
         
            this.basePanel.Visible = false;
            ApiProcessingResult result = (ApiProcessingResult)e.Result;
            if (result.IsError)
                {
                    MbcMessageBox.Error(result.Errors[0].ErrorMessage);
                }
            if (result.Tag == "reportViewer1refresh")
            {
                reportViewer1.RefreshReport();
            }
           
            if (result.Tag == "reportViewer3refresh")
            {
                reportViewer3.RefreshReport();
            }
        }

        private void custDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //event must be here to bypass data errors due to background worker issue.
        }





        #endregion

        //Nothing below here
    }
    }

