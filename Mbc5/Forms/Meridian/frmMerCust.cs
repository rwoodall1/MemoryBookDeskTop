﻿using System;
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
using Mbc5.Dialogs;
using System.Data.SqlClient;
using System.Reflection;
using BindingModels;
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
            

            this.frmMain = (frmMain)this.MdiParent;

            SetConnectionString();

            var vSchocode = this.Schcode;


           
            Fill();
            this.lblAppUser.Text = this.ApplicationUser.id;
            mcustBindingSource.ResetBindings(true);
        }

        #region Methods
        private void AddSalesRecord()
        {
            var dr = (DataRowView)mcustBindingSource.Current;
            var a = dr.Row["QInvno"].ToString();
            var vCurrentInvno = dr.Row.IsNull("QInvno")?0:(int) dr.Row["QInvno"];
            DateTime vContdate =(DateTime) dr.Row["contdate"];//should always have a date.
            var vOrigYear = dr.Row.IsNull("origyear");                
            bool vInvoiced = dr.Row.IsNull("invoiced")?false:(bool)dr.Row["invoiced"];
            
            string vYear = "0";
            if (vContdate!=null&&vOrigYear)
            {
               
                if (DateTime.Now.Month > 8)
                {
                     vYear = (DateTime.Now.Year + 1).ToString().Substring(2);
                }
                else
                {
                    vYear = DateTime.Now.Year.ToString().Substring(2);
                }
                txtContryear.Text = vYear.ToString().Substring(2);
                dr.Row["origyear"] = vYear.ToString().Substring(2);
            }
            else
            {
                txtContryear.Text = contdateDateTimePicker.Value.Year.ToString().Substring(2);
                vYear = contdateDateTimePicker.Value.Year.ToString().Substring(2);
            }
            DialogResult vDialogResult;
            if (vCurrentInvno>0)
            {
                vDialogResult = MessageBox.Show("A Production Record DOES Exist, Do you wish to ADD another one?", "Production Record DOES Exist", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            }
            else
            {
               vDialogResult = MessageBox.Show("A Production Record DOES NOT Exist, Do you wish to ADD another one?", "Add Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            }

            if (vDialogResult == DialogResult.No)
            {
                //done leave
                return;
            }
            //add record
            string vProdNumber = "";
            MeridianNewProdRecord frmGetProdRec = new MeridianNewProdRecord();

                    var result = frmGetProdRec.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            vProdNumber = frmGetProdRec.retProdNo;
                    }
                    else
                    {
                        MbcMessageBox.Information("New order record was not created.");
                        return;
                    }
            //Get Invno number

            int vInvno= this.frmMain.GetNewInvno();
            if (vInvno == 0)
            {
                MbcMessageBox.Information("New order record was not created.");
                    return;
            }
            var sqlQuery = new SQLCustomClient();
            sqlQuery.CommandText(@"Insert into MQuotes (Schcode,Bpyear,Invno,Contryear,Schtype,Booktype,Sf,Lf) Values(@Schcode,@Bpyear,@Invno,@Contryear,@Schtype,@Booktype,@Sf,@Lf)");
            sqlQuery.AddParameter("@Schcode",this.Schcode);
            sqlQuery.AddParameter("@Contryear",vYear);
            sqlQuery.AddParameter("@Invno", vInvno);
            sqlQuery.AddParameter("@Bpyear", vYear);
            sqlQuery.AddParameter("@Schtype","HS");
            sqlQuery.AddParameter("Booktype","ND");
            sqlQuery.AddParameter("Sf",true);
            sqlQuery.AddParameter("Lf",false);
            var quoteresult=sqlQuery.Insert();
            if (quoteresult.IsError)
            {
                MbcMessageBox.Error("Failed to insert sales record:"+quoteresult.Errors[0].ErrorMessage);
                ExceptionlessClient.Default.CreateLog("Error inserting meridian sales record.")
                    .AddObject(quoteresult)
                    .MarkAsCritical()
                    .Submit();
                return;
            }
            var coverNo = frmMain.GetCoverNumber();
            if (coverNo=="0")
            {
                MbcMessageBox.Error("Production record was not added");
                return;
            }

            //get cstat
            string vCStat = "";
        if (vCurrentInvno>0 && vInvoiced)
            {
                vCStat = "Rebook";
            }
            
                sqlQuery.ClearParameters();
                sqlQuery.CommandText(@"Insert INTO Produtn (Schcode,Invno,Prodno,SpecCover,PerfBind,CStat,Company,Contryear,Prodcustdate) Values(@Schcode,@Invno,@Prodno,@SpecCover,@PerfBind,@CStat,@Company,@Contryear,@Prodcustdate)");
                sqlQuery.AddParameter("@Schcode", this.Schcode);
                sqlQuery.AddParameter("@Invno", vInvno);
                sqlQuery.AddParameter("@Prodno",vProdNumber);
                sqlQuery.AddParameter("@SpecCover", coverNo);
                sqlQuery.AddParameter("@PerfBind","M");
                sqlQuery.AddParameter("CStat", vCStat);
                sqlQuery.AddParameter("Company", "MER");
                sqlQuery.AddParameter("@Contryear", vYear);          
                sqlQuery.AddParameter("Prodcustdate", contdateDateTimePicker.Value);
            var prodResult = sqlQuery.Insert();
            if(prodResult.IsError)
                {
                MbcMessageBox.Error("Failed to insert production record:" + prodResult.Errors[0].ErrorMessage);
                ExceptionlessClient.Default.CreateLog("Error inserting meridian production record.")
                    .AddObject(prodResult)
                    .MarkAsCritical()
                    .Submit();
                return;
                }
            DataRowView current = (DataRowView)mcustBindingSource.Current;
            string instructions = current["spcinst"].ToString();
            sqlQuery.ClearParameters();
                sqlQuery.CommandText(@"Insert INTO Covers (Schcode,Invno,SpeCovr,Specinst,Company) Values(@Schcode,@Invno,@SpeCovr,@Specinst,@Company)");
                sqlQuery.AddParameter("@Schcode", this.Schcode);
                sqlQuery.AddParameter("@Invno", vInvno);
                sqlQuery.AddParameter("@SpeCovr", coverNo);
                sqlQuery.AddParameter("@Specinst", instructions);    
                sqlQuery.AddParameter("Company","MER");
                var coverResult = sqlQuery.Insert();
                if (coverResult.IsError)
                {
                    MbcMessageBox.Error("Failed to insert cover record:" + coverResult.Errors[0].ErrorMessage);
                    ExceptionlessClient.Default.CreateLog("Error inserting meridian cover record.")
                        .AddObject(quoteresult)
                        .MarkAsCritical()
                        .Submit();
                    return;
                }
            sqlQuery.ClearParameters();
            sqlQuery.CommandText(@"Insert INTO Wip (Schcode,Invno) Values(@Schcode,@Invno)");
            sqlQuery.AddParameter("@Schcode", this.Schcode);
            sqlQuery.AddParameter("@Invno", vInvno);
            var wipResult = sqlQuery.Insert();
            if (wipResult.IsError)
            {
                MbcMessageBox.Error("Failed to insert Color Page record:" + wipResult.Errors[0].ErrorMessage);
                ExceptionlessClient.Default.CreateLog("Error inserting meridian Color Page record.")
                    .AddObject(quoteresult)
                    .MarkAsCritical()
                    .Submit();
                return;
            }
            sqlQuery.ClearParameters();
            sqlQuery.CommandText(@"Insert INTO Wipg (Schcode,Invno) Values(@Schcode,@Invno)");
            sqlQuery.AddParameter("@Schcode", this.Schcode);
            sqlQuery.AddParameter("@Invno", vInvno);
            var wipgResult = sqlQuery.Insert();
            if (wipgResult.IsError)
            {
                MbcMessageBox.Error("Failed to insert Color Page record:" + wipgResult.Errors[0].ErrorMessage);
                ExceptionlessClient.Default.CreateLog("Error inserting meridian Color Page record.")
                    .AddObject(quoteresult)
                    .MarkAsCritical()
                    .Submit();
                
            }
            this.Save();
            SetInvnoSchCode();

        }
        
        public override void OracleCodeSearch()
        {
            var currentOracleCode = txtOracleCode.Text;
            //if (DoPhoneLog())
            //{
            //    MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result1 = MessageBox.Show("Record failed to save, correct and save again.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            frmSearch frmSearch = new frmSearch("OracleCode", "MCust", currentOracleCode);

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                string retSchcode = frmSearch.ReturnValue.Schcode;            //values preserved after close
                int records = 0;
                try
                {
                    records = this.mcustTableAdapter.Fill(this.dsMcust.mcust, retSchcode);
                    //records = this.custTableAdapter.Fill(this.dsCust.cust, txtSchCodesrch.Text);
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                try
                {
                    //this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
                    //this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
                    //TeleGo = false;
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                }
                this.Cursor = Cursors.Default;
            }
            else { return; }

            SetInvnoSchCode();
            frmMerCust_Paint(this, null);
        }
        public override void SchnameSearch()
        {
            var currentSchool = this.Schcode;
            //if (DoPhoneLog())
            //{
            //    MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result1 = MessageBox.Show("Record failed to save correct and save again.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            frmSearch frmSearch = new frmSearch("Schname", "MCust", txtSchname.Text.Trim());

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
                    records = this.mcustTableAdapter.Fill(this.dsMcust.mcust, retSchcode);
                   
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                try
                {
                    //this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
                    //this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
                    //TeleGo = false;
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                }
                this.Cursor = Cursors.Default;
            }
            else { return; }

            SetInvnoSchCode();
            frmMerCust_Paint(this, null);
        }
        public override void SchCodeSearch()
        {
            var currentSchool = this.Schcode;
            //if (DoPhoneLog())
            //{
            //    MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result1 = MessageBox.Show("Record failed to save. Hit cancel to correct.", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result1 == DialogResult.Cancel)
                {
                    return;
                }
            }

            frmSearch frmSearch = new frmSearch("Schcode", "MCust", Schcode);

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
                    records = this.mcustTableAdapter.Fill(this.dsMcust.mcust, retSchcode);
                    this.SetInvnoSchCode();
                   
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                try
                {
                    //this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
                    //this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
                    //TeleGo = false;
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                }
                this.Cursor = Cursors.Default;
            }
            else { return; }

          
            frmMerCust_Paint(this, null);
        }
        public override void ProdutnNoSearch()
        {
            var currentSchool = this.Schcode;
            //if (DoPhoneLog())
            //{
            //    MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result1 = MessageBox.Show("Record failed to save. Hit cancel to correct.", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result1 == DialogResult.Cancel)
                {
                    return;
                }
            }
            DataRowView current = (DataRowView)mcustBindingSource.Current;
            string vProdNo = current["Prodno"].ToString().Substring(1, 5);

            frmSearch frmSearch = new frmSearch("PRODNO", "MCust", vProdNo);

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
                    records = this.mcustTableAdapter.Fill(this.dsMcust.mcust, retSchcode);
                   
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                try
                {
                    //this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
                    //this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
                    //TeleGo = false;
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                }
                this.Cursor = Cursors.Default;
            }
            else { return; }

            SetInvnoSchCode();
            frmMerCust_Paint(this, null);

        }
        public override void InvoiceNumberSearch()
        {
            var currentSchool = this.Schcode;
            //if (DoPhoneLog())
            //{
            //    MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result1 = MessageBox.Show("Record failed to save. Hit cancel to correct.", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result1 == DialogResult.Cancel)
                {
                    return;
                }
            }

            frmSearch frmSearch = new frmSearch("Invno", "MCust", this.Invno.ToString());

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
                    records = this.mcustTableAdapter.Fill(this.dsMcust.mcust, retSchcode);
                   
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                try
                {
                    //this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
                    //this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
                    //TeleGo = false;
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                }
                this.Cursor = Cursors.Default;
            }
            else { return; }

            SetInvnoSchCode();
            frmMerCust_Paint(this, null);

        }
        public override void FirstNameSearch()
        {
            var currentSchool = this.Schcode;
            //if (DoPhoneLog())
            //{
            //    MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result1 = MessageBox.Show("Record failed to save. Hit cancel to correct.", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result1 == DialogResult.Cancel)
                {
                    return;
                }
            }

            frmSearch frmSearch = new frmSearch("FirstName", "MCust", "");

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
                    records = this.mcustTableAdapter.Fill(this.dsMcust.mcust, retSchcode);
                   
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                try
                {
                    //this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
                    //this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
                    //TeleGo = false;
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                }
                this.Cursor = Cursors.Default;
            }
            else { return; }

            SetInvnoSchCode();
            frmMerCust_Paint(this, null);

        }
        public override void LastNameSearch()
        {
            var currentSchool = this.Schcode;
            //if (DoPhoneLog())
            //{
            //    MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result1 = MessageBox.Show("Record failed to save. Hit cancel to correct.", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result1 == DialogResult.Cancel)
                {
                    return;
                }
            }

            frmSearch frmSearch = new frmSearch("LastName", "MCust", "");

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
                    records = this.mcustTableAdapter.Fill(this.dsMcust.mcust, retSchcode);
                    //records = this.custTableAdapter.Fill(this.dsCust.cust, txtSchCodesrch.Text);
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                try
                {
                    //this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
                    //this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
                    //TeleGo = false;
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                }
                this.Cursor = Cursors.Default;
            }
            else { return; }

            SetInvnoSchCode();
            frmMerCust_Paint(this, null);

        }
        public override void ZipCodeSearch()
        {
            var currentSchool = this.Schcode;
            //if (DoPhoneLog())
            //{
            //    MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result1 = MessageBox.Show("Record failed to save. Hit cancel to correct.", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result1 == DialogResult.Cancel)
                {
                    return;
                }
            }

            frmSearch frmSearch = new frmSearch("ZipCode", "MCust", "");

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
                    records = this.mcustTableAdapter.Fill(this.dsMcust.mcust, retSchcode);
                    
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                try
                {
                    //this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
                    //this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
                    //TeleGo = false;
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                }
                this.Cursor = Cursors.Default;
            }
            else { return; }

            SetInvnoSchCode();
            frmMerCust_Paint(this, null);

        }
        public override void EmailSearch()
        {
            var currentSchool = this.Schcode;
            //if (DoPhoneLog())
            //{
            //    MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            var custSaveResult = Save();
            if (custSaveResult.IsError)
            {
                DialogResult result1 = MessageBox.Show("Record failed to save. Hit cancel to correct.", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result1 == DialogResult.Cancel)
                {
                    return;
                }
            }

            frmSearch frmSearch = new frmSearch("Email", "MCust", "");

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
                    records = this.mcustTableAdapter.Fill(this.dsMcust.mcust, retSchcode);
                    //records = this.custTableAdapter.Fill(this.dsCust.cust, txtSchCodesrch.Text);
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                try
                {
                    //this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text);
                    //this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text);
                    //TeleGo = false;
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                }
                this.Cursor = Cursors.Default;
            }
            else { return; }

            SetInvnoSchCode();
            frmMerCust_Paint(this, null);

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
                    var a = dsMcust.Tables["mcust"].GetErrors();
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
                SetInvnoSchCode();
            }
            catch(Exception ex)
            {
                ex.ToExceptionless()
                    .AddObject(ex)
                    .MarkAsCritical()
                    .Submit();
                var a=dsMcust.Tables["mcust"].GetErrors();
                MbcMessageBox.Error(ex.Message);
            }
        }
        private void SetInvnoSchCode()
        {
            this.Schcode =lblSchcode.Text;
            int val = 0;
            this.Invno = 0;
            bool parsed = Int32.TryParse(lblInvno.Text, out val);
            if (parsed)
            {
                this.Invno = val;
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
                txtInvZip.Text = vInvZipcode.Substring(0, 5);
            }
            else { txtInvZip.Text = vInvZipcode; }
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
            //try { this.Text = "Meridian Customer-" + txtSchname.Text.Trim() + " (" + this.Schcode.Trim() + ")"; }
            //catch
            //{

            //}
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
                txtShpZip.Text = vShpZipcode.Substring(0, 5);
            }
            else { txtShpZip.Text = vShpZipcode; }
        }

        private void btnSaveInformation_Click_1(object sender, EventArgs e)
        {
            var result = Save();
            if (!result.IsError)
            {
                MbcMessageBox.Exclamation("Record Saved", "Record Saved");
            }
        }

        private void frmMerCust_Activated(object sender, EventArgs e)
        {
            try { frmMain.ShowSearchButtons(this.Name); } catch { }
        }

        private void frmMerCust_Deactivate(object sender, EventArgs e)
        {
            try { frmMain.HideSearchButtons(); } catch { }
        }

        private void contdateDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            AddSalesRecord();
        }

      
        private void Test()
        {
           
                var sqlQuery = new SQLCustomClient();
                sqlQuery.ClearParameters();
                
               
                sqlQuery.CommandText(@"
                SELECT * From MeridianPricing where Type='LF' and yr='19' 
                ");
                
                var pricingResult = sqlQuery.Select<MeridianPrice>();
                if (pricingResult.IsError)
                {
                    ExceptionlessClient.Default.CreateLog("Error getting Meridian Pricing")
                        .AddObject(pricingResult)
                        .MarkAsCritical()
                        .Submit();
                    MbcMessageBox.Error("Failed to get meridian pricing" + pricingResult.Errors[0].DeveloperMessage);
                 
                }
                
                var Pricing = (MeridianPrice)pricingResult.Data;
            ///
            var qtyField = "Q400";

            var a=(decimal)ObjectFieldValue.Get<MeridianPrice>(qtyField,Pricing);
       





            return;
            
        }
        //nothing below here
    }
}
