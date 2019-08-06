using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass;
using BaseClass.Classes;
using BaseClass.Forms;
using Exceptionless;
using Mbc5.Forms;
using BindingModels;
namespace Mbc5.Dialogs
{
    public partial class frmTeleLogModify : Form
    {
        public frmTeleLogModify(int vLogId,string type,frmMain parent)
        {
            if (type=="T")
            {
                EditType = "T";
              
            }
            else
            {
                EditType = "M";
               
            }
            LogId = vLogId;
            frmMain = parent;
            InitializeComponent();
        }
        public frmTeleLogModify(string company, string schcode, frmMain parent) 
        {
            this.Schcode = schcode;
            frmMain = parent;
            Company = company;
            InitializeComponent();
        }

        private string EditType;
        private string Schcode;
        private frmMain frmMain;
        private int LogId=0;
        private string Company = "";
        public bool MarketRecAdded { get; set; } = false;
        private void frmTeleLogModify_Load(object sender, EventArgs e)
        {
            if (EditType == "T")
            {
             
                this.tbLog.TabPages.Remove(pg2);
            }
            else if(EditType == "M")
            {
               
                this.tbLog.TabPages.Remove(pg1);
            }
            var tmpMktRec = new MktInfo();
            mktinfoBindingSource.DataSource = tmpMktRec;
            try
            {
                datecontTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
                lkpMktReferenceTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
                lkpTypeContTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
                lkpPromotionsTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
                this.lkpMktReferenceTableAdapter.Fill(this.lookUp.lkpMktReference);
                this.lkpTypeContTableAdapter.Fill(this.lookUp.lkpTypeCont);
                this.lkpPromotionsTableAdapter.Fill(this.lookUp.lkpPromotions);
            }catch(Exception ex)
            {
                ex.ToExceptionless()
                    .AddObject(ex)
                    .Submit();
                MbcMessageBox.Error(ex.Message, "");
            }
          var sqlquery = new SQLCustomClient();
            if (LogId > 0 && EditType == "T") {
                //edit

                sqlquery.CommandText(@"Select C.Schname,D.Schcode,D.Datecont,D.Reason,D.Initial,D.Contact,D.TypeCont,D.NxtDate,D.NxtDays,D.CallCont,D.CallTime,D.Priority,D.Company,D.TechCall,D.Id 
                    FROM DateCont D 
                    Left Join Cust C On D.Schcode=C.Schcode
                    Where Id=@Id");
                sqlquery.AddParameter("@Id", LogId);
                var contactResult = sqlquery.Select<TelephonLogRecord>();
                if (contactResult.IsError)
                {
                    MbcMessageBox.Error("Failed to retrieve Telephone Log record", "");
                    ExceptionlessClient.Default.CreateLog("Failed to retrieve Telephone Log record")
                          .AddObject(contactResult)
                            .Submit();
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
                var vData = (TelephonLogRecord)contactResult.Data;
                datecontBindingSource.DataSource = vData;
                lblTitle.Text = vData.Schname.Trim() + "(" + vData.Schcode + ")";
            }
            else if(LogId > 0 && EditType == "M") { 
                //mkt info
                sqlquery.ClearParameters();
                sqlquery.CommandText(@"SELECT [Id
                                        ,C.Schname
                                        ,M.Ddate
                                        ,M.Initial
                                        ,M.Note
                                        ,M.Promo
                                        ,M.Refered
                                        ,M.Schcode
                                        ,M.Company
                                        ,M.ProspectId
                                    FROM mktinfo M 
                                    Left Join Cust C On M.shcode=C.schcode
                                    Where Id=@Id");
                sqlquery.AddParameter("@Id", LogId);
                var mktResult = sqlquery.Select<MktInfo>();
                if (mktResult.IsError)
                {
                    MbcMessageBox.Error("Failed to retrieve Marketing Log record", "");
                    ExceptionlessClient.Default.CreateLog("Failed to retrieve Marketing Log record")
                          .AddObject(mktResult)
                            .Submit();
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
                var vData1 = (MktInfo)mktResult.Data;
                mktinfoBindingSource.DataSource = vData1;
                lblTitle.Text = vData1.Schname.Trim() + "(" + vData1.Schcode + ")";
                





            }
            else
            {
                //new
                sqlquery.CommandText(@"Insert INTO DateCont (Schcode,Datecont,Initial,Company) VALUES(@Schcode,GETDATE(),@Initial,@Company)");
                sqlquery.AddParameter(@"Schcode",Schcode);
                sqlquery.AddParameter("@Initial",frmMain.ApplicationUser.Initials);
                sqlquery.AddParameter("@Company", Company);
               
                var contactResult =sqlquery.Insert();
               
                if (!int.TryParse(contactResult.Data, out LogId))
                {
                    MbcMessageBox.Error("Insert did not receive an Id in return.", "");
                    this.DialogResult = DialogResult.Cancel;
                    return;
                };
                if (contactResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert Telephone Log record", "");
                    ExceptionlessClient.Default.CreateLog("Failed to insert Telephone Log record")
                          .AddObject(contactResult)
                            .Submit();
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
                sqlquery.ClearParameters();
                sqlquery.CommandText(@"Select C.Schname,D.Schcode,D.Datecont,D.Reason,D.Initial,D.Contact,D.TypeCont,D.NxtDays,D.CallCont,D.CallTime,D.Priority,D.Company,D.TechCall,D.Id 
                    FROM DateCont D 
                    Left Join Cust C On D.Schcode=C.Schcode
                    Where Id=@Id");
                sqlquery.AddParameter("@Id", LogId);
                var contactResult1 = sqlquery.Select<TelephonLogRecord>();
                if (contactResult1.IsError)
                {
                    MbcMessageBox.Error("Failed to retrieve Telephone Log record", "");
                    ExceptionlessClient.Default.CreateLog("Failed to retrieve Telephone Log record")
                          .AddObject(contactResult)
                            .Submit();
                    this.DialogResult = DialogResult.Cancel;
                }
                var vData = (TelephonLogRecord)contactResult1.Data;
                datecontBindingSource.DataSource = vData;
                lblTitle.Text = vData.Schname.Trim() + "(" + vData.Schcode + ")";

            }

        }

       private void AddMktRecord()
        {
            var sqlquery = new SQLCustomClient();
            sqlquery.CommandText(@"INSERT INTO [dbo].[mktinfo]
                                    (
                                         ddate
                                        ,initial
                                        ,schcode
                                        ,company
                                    )
                                    VALUES
                                    (
                                        GETDATE()
                                        ,@initial 
                                        ,@schcode
                                        ,@company 
                                    )");
            sqlquery.AddParameter(@"Schcode", Schcode);
            sqlquery.AddParameter("@Initial", frmMain.ApplicationUser.Initials);
            sqlquery.AddParameter("@Company", Company);

            var contactResult = sqlquery.Insert();
            if (contactResult.IsError)
            {
                MbcMessageBox.Error("Failed to insert Marketing record", "");
                ExceptionlessClient.Default.CreateLog("Failed to insert Marketing record")
                      .AddObject(contactResult)
                        .Submit();
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            if (!int.TryParse(contactResult.Data, out LogId))
            {
                MbcMessageBox.Error("Insert did not receive an Id in return.", "");
                this.DialogResult = DialogResult.Cancel;
                return;
            };
            sqlquery.ClearParameters();
            sqlquery.CommandText(@"SELECT [Id]
                                        ,[Ddate]
                                        ,[Initial]
                                        ,[Note]
                                        ,[Promo]
                                        ,[Refered]
                                        ,[Schcode]
                                        ,[Company]
                                        ,[ProspectId]
                                        FROM [dbo].[mktinfo]
                                                    Where Id=@Id");
            sqlquery.AddParameter("@Id", LogId);
            var contactResult1 = sqlquery.Select<MktInfo>();
            if (contactResult1.IsError)
            {
                MbcMessageBox.Error("Failed to retrieve Marketing Log record", "");
                ExceptionlessClient.Default.CreateLog("Failed to retrieve Marketing Log record")
                      .AddObject(contactResult)
                        .Submit();
                this.DialogResult = DialogResult.Cancel;
            }
            var vData = (MktInfo)contactResult1.Data;
         mktinfoBindingSource.DataSource = vData;
            pnlMkt.Enabled = true;
            this.MarketRecAdded = true;
        }
        private void nxtdateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            nxtdateDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void cmbReasons_SelectedValueChanged(object sender, EventArgs e)
        {
            reasonTextBox.Text = cmbReasons.Text;
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            if (reasonTextBox.Text.Trim() == "")
            {
                this.errorProvider1.SetError(reasonTextBox, "Reason is required");
                return;
            }

             var sqlquery = new SQLCustomClient();
            sqlquery.CommandText(@"UPDATE DateCont Set Reason=@Reason,Contact=@Contact,TypeCont=@TypeContact,
                                    NxtDays=@NxtDays,NxtDate=@NxtDate,CallCont=@CallCont,CallTime=@CallTime,
                                    Priority=@Priority,Company=@Company,TechCall=@TechCall   
                                    Where Id=@Id And Initial=@Initial");
            sqlquery.AddParameter("@Id", LogId);
            sqlquery.AddParameter("@Initial", frmMain.ApplicationUser.Initials);
            sqlquery.AddParameter("@Reason", reasonTextBox.Text);
            sqlquery.AddParameter("@Contact", contactTextBox.Text);
            sqlquery.AddParameter("@TypeContact", typecontComboBox.Text.Trim());
            sqlquery.AddParameter("@NxtDays", nxtdaysComboBox.Text==""?null : nxtdaysComboBox.Text);
            sqlquery.AddParameter("@NxtDate", nxtdateDateTimePicker.Text==""?null: nxtdateDateTimePicker.Text);
            sqlquery.AddParameter("@CallCont", callcontCheckBox.Checked);
            sqlquery.AddParameter("@CallTime", callTimeTextBox.Text=="0"?null: callTimeTextBox.Text);
            sqlquery.AddParameter("@Priority",priorityComboBox.Text == "" ? null : priorityComboBox.Text);
            sqlquery.AddParameter("@Company",Company );
            sqlquery.AddParameter("@TechCall ",techcallCheckBox.Checked );

            var updateResult= sqlquery.Update();
            if (updateResult.IsError)
            {
                MbcMessageBox.Error("Failed to save Telephone Log record", "");
                ExceptionlessClient.Default.CreateLog("Failed to save Telephone Log record")
                      .AddObject(updateResult)
                        .Submit();
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            sqlquery.ClearParameters();
                if (chkbypassMkt.Checked && MarketRecAdded)
                {   sqlquery.CommandText(@"UPDATE MktInfo Set Note=@Note,Promo=@Promo,Refered=@Refered,ProspectId=@ProspectId   
                                    Where Id=@Id AND Initial=@Initial");
                sqlquery.AddParameter("@Id", LogId);
                sqlquery.AddParameter("@Initial", frmMain.ApplicationUser.Initials);
                sqlquery.AddParameter("@Note", noteTextBox.Text);
                sqlquery.AddParameter("@Promo",promoComboBox.Text);
                sqlquery.AddParameter("@Refered",referedComboBox.Text);
                sqlquery.AddParameter("@ProspectId ", typecontComboBox.Text.Trim());
                
                var updateResult1 = sqlquery.Update();
                if (updateResult1.IsError)
                {
                    MbcMessageBox.Error("Failed to save Telephone Log record", "");
                    ExceptionlessClient.Default.CreateLog("Failed to save Telephone Log record")
                          .AddObject(updateResult)
                            .Submit();
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }


            }else if (!chkbypassMkt.Checked && frmMain.ApplicationUser.UserName.Substring(0,2).ToUpper()=="CS")
            {
                MbcMessageBox.Hand("Please verify you have added Market Information by clicking the Market Information Completed checkbox.", "Information");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCreateMktLog_Click(object sender, EventArgs e)
        {
            AddMktRecord();

        }

        private void reasonTextBox_Leave(object sender, EventArgs e)
        {
            if (reasonTextBox.Text.Trim() != ""){
                errorProvider1.Clear();
            }
        }

        private void nxtdateDateTimePicker_ValueChanged_1(object sender, EventArgs e)
        {
            nxtdateDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void nxtdaysComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            int vDays = 0;
            var a = nxtdaysComboBox.Text;
            int.TryParse(nxtdaysComboBox.Text, out vDays);
            if (vDays > 0)
            {
                nxtdateDateTimePicker.Value = DateTime.Now.AddDays(vDays);
            }
            else { nxtdateDateTimePicker.Value = DateTime.Now; }
            
        }
    }
   
}
