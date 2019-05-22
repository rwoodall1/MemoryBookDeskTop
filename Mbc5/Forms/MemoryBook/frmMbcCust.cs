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
      public event PropertyChangedEventHandler PropertyChanged;
        #region "Properties"
        public bool MktGo {
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
        public frmMain frmMain { get; set; }

        #endregion
        private void SetConnectionString()
        {
            frmMain frmMain = (frmMain)this.MdiParent;
            this.custTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.statesTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpLeadSourceTableAdapter.Connection.ConnectionString= frmMain.AppConnectionString;
            this.lkpLeadNameTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.custSearchTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
         
            this.lkpMultiYearOptionsTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpTypeContTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpPromotionsTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpPrevPubTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpNoRebookTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpschtypeTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpMktReferenceTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.lkpCommentsTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.datecontTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
           
            this.contpstnTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.mktinfoTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;


        }
        private void frmMbcCust_Load(object sender,EventArgs e) {
            this.frmMain = (frmMain)this.MdiParent;

            SetConnectionString();
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

            var vSchocode = this.Schcode;
            this.chkMktComplete.DataBindings.Add("Checked", this, "MktGo", false, DataSourceUpdateMode.OnPropertyChanged);//bind check box to property of form

            if (!ApplicationUser.Roles.Contains("MbcCS"))
            {
                TeleGo = true;
                MktGo = true;
            }
			try {
				this.statesTableAdapter.Fill(this.lookUp.states);
				this.lkpTypeContTableAdapter.Fill(this.lookUp.lkpTypeCont);
				// TODO: This line of code loads data into the 'lookUp.lkpPromotions' table. You can move, or remove it, as needed.
				this.lkpPromotionsTableAdapter.Fill(this.lookUp.lkpPromotions);
				this.lkpPrevPubTableAdapter.Fill(this.lookUp.lkpPrevPub);
				this.lkpNoRebookTableAdapter.Fill(this.lookUp.lkpNoRebook);
				this.lkpschtypeTableAdapter.Fill(this.lookUp.lkpschtype);
				// TODO: This line of code loads data into the 'lookUp.lkpMktReference' table. You can move, or remove it, as needed.
				this.lkpMktReferenceTableAdapter.Fill(this.lookUp.lkpMktReference);
				// TODO: This line of code loads data into the 'lookUp.lkpComments' table. You can move, or remove it, as needed.
				this.lkpCommentsTableAdapter.Fill(this.lookUp.lkpComments);
				// TODO: This line of code loads data into the 'lookUp.lkpTypeCont' table. You can move, or remove it, as needed.

				// TODO: This line of code loads data into the 'dsCust.datecont' table. You can move, or remove it, as needed.
				this.datecontTableAdapter.Fill(this.dsCust.datecont, vSchocode);
				// TODO: This line of code loads data into the 'dsCust.cust' table. You can move, or remove it, as needed.

				this.custTableAdapter.Fill(this.dsCust.cust, vSchocode);
				// TODO: This line of code loads data into the 'lookUp.contpstn' table. You can move, or remove it, as needed.
				this.contpstnTableAdapter.Fill(this.lookUp.contpstn);
				// TODO: This line of code loads data into the 'lookUp.states' table. You can move, or remove it, as needed.

				this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, vSchocode);
			}catch(Exception ex) {
				MbcMessageBox.Error(ex.Message, "");
			}
            
           
        }
       
    
        #region CrudOperations
        public override ApiProcessingResult<bool> Save()
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
                    custTableAdapter.Update(dsCust);
                    this.custTableAdapter.Fill(this.dsCust.cust, this.Schcode);
                    this.SetInvnoSchCode();
                    retval = true;
                }
                catch (DBConcurrencyException dbex)
                {
                    DialogResult result = ExceptionHandler.CreateMessage((DataSets.dsCust.custRow)(dbex.Row), ref dsCust);
                    if (result == DialogResult.Yes) {
                        Save();
                    }
                                 
                }catch(Exception ex) {
                    MessageBox.Show("School record failed to update:" + ex.Message);
                    ex.ToExceptionless()
                   .SetMessage("School record failed to update:" + ex.Message)
                   .Submit();
					processingResult.IsError = true;
					processingResult.Errors.Add(new ApiProcessingError("Record not save:"+ex.Message, "Record not save:" + ex.Message,""));
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
		public override void OracleCodeSearch() {
			var currentOracleCode = oraclecodeTextBox.Text;
			if (DoPhoneLog()) {
				MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
			var custSaveResult = Save();
			if (custSaveResult.IsError) {
				DialogResult result1 = MessageBox.Show("Record failed to save correct and save again.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}


			frmSearch frmSearch = new frmSearch("OracleCode", "Cust", currentOracleCode);

			var result = frmSearch.ShowDialog();
			if (result == DialogResult.OK) {
				string retSchcode = frmSearch.ReturnValue;            //values preserved after close
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
				string retSchcode = frmSearch.ReturnValue;            //values preserved after close
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
				string retSchcode = frmSearch.ReturnValue;            //values preserved after close
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

			frmSearch frmSearch = new frmSearch("PRODUTNNO", "Cust", vProdNo);

			var result = frmSearch.ShowDialog();
			if (result == DialogResult.OK) {
				string retSchcode = frmSearch.ReturnValue;            //values preserved after close
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
					   new SqlParameter("@Company","MBC")
					};
						strQuery = "INSERT INTO [dbo].[produtn](Invno,Schcode,Contryear,Prodno,Company)  VALUES (@Invno,@Schcode,@Contryear,@ProdNo,@Company)";
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
					   new SqlParameter("@Company","MBC")
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


					Save();
					try {
						this.custTableAdapter.Fill(this.dsCust.cust, this.Schcode);
					}catch(Exception ex){
						MbcMessageBox.Error(ex.Message, "");
					}
					
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
        public bool DoPhoneLog() {
            bool retval = true;
            frmMain vparent =(frmMain) this.ParentForm;
            
            if(vparent.ValidatedUserRoles.Contains("SA")|| vparent.ValidatedUserRoles.Contains("Admin")) {
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
            SqlConnection conn = new SqlConnection(FormConnectionString);
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
                SqlConnection conn = new SqlConnection(FormConnectionString);
                string sql = "UPDATE DateCont Set Id=@Id,reason=@reason,contact=@contact,typecont=@typecont, nxtdate=@nxtdate,callcont=@callcont, calltime=@calltime,priority=@priority,techcall=@techcall where id=@id ;";
                SqlCommand cmd = new SqlCommand(sql,conn);
                foreach (DataRow row in EditedRecs.Rows)
                    {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Id",row["id"]);
                    cmd.Parameters.AddWithValue("@reason",row["reason"]);
                    cmd.Parameters.AddWithValue("@contact",row["contact"]);
                    cmd.Parameters.AddWithValue("@typecont",row["typecont"]);
                    cmd.Parameters.AddWithValue("@nxtdate",row["nxtdate"]);
                    cmd.Parameters.AddWithValue("@callcont",row["callcont"]);
                    cmd.Parameters.AddWithValue("@calltime",row["calltime"]);
                    cmd.Parameters.AddWithValue("@priority",row["priority"]);
                    cmd.Parameters.AddWithValue("@techcall",row["techcall"]);

                    try
                        {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        TeleLogAdded = false;
                        TeleGo = true;
					
					}
                    catch (Exception ex)
                        {
                        MessageBox.Show("Failed to update telephone log record.");
                        Log.Error("Failed to update telephone log:" + ex.Message);
                        //go on we are not stopping the program for this
                        }
                    finally { cmd.Connection.Close(); }
					try {
						this.datecontTableAdapter.Fill(this.dsCust.datecont, this.Schcode);
					}catch(Exception ex) {
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

            string val = "";
            //custBindingSource.MoveFirst();//make sure on first row
            DataRowView current = (DataRowView)custBindingSource.Current;
            string instructions = current["spcinst"].ToString();

            return instructions;

        }
        #endregion




        private void btnInterOffice_Click(object sender,EventArgs e) {
         
                this.Cursor = Cursors.AppStarting;
                string body = inofficeTextBox.Text;
                string subj = "Inter Office Memo";
                string email = "";
                var emailHelper = new EmailHelper();
                EmailType type = EmailType.Mbc;
                emailHelper.SendOutLookEmail(subj, email, "", body, type);
                this.Cursor = Cursors.Default;
         
        }

        private void btnSchoolEmail_Click(object sender,EventArgs e) {
            this.Cursor = Cursors.AppStarting;
            string body = txtSchEmail.Text;
            string subj = "Inter Office Memo";
            string email = "";
            var emailHelper = new EmailHelper();
            EmailType type = EmailType.Mbc;
            emailHelper.SendOutLookEmail(subj, email, "", body, type);
            this.Cursor = Cursors.Default;
        }

        private void btnEmailContact_Click(object sender,EventArgs e) {
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
        private void commentListBox_DoubleClick(object sender,EventArgs e) {
            string val = commentListBox.GetItemText(commentListBox.SelectedItem);
            txtReason.Text = val;

            txtReason.Select();


            }

        private void txtReason_Leave(object sender,EventArgs e) {
            datecontDataGridView.Select();
            this.BindingContext[this.datecontDataGridView.DataSource].EndCurrentEdit();
            datecontDataGridView.Refresh();
            datecontDataGridView.Parent.Refresh();
            }

        private void btnAddLog_Click(object sender,EventArgs e) {

            SqlConnection conn = new SqlConnection(FormConnectionString);
            string sql = "INSERT INTO DateCont (Id,schcode,datecont,initial) VALUES(@Id,@schcode,@datecont,@initial);";
            SqlCommand cmd = new SqlCommand(sql,conn);
            cmd.Parameters.AddWithValue("@Id",Guid.NewGuid().ToString());
            cmd.Parameters.AddWithValue("@initial",ApplicationUser.FirstName.Substring(0,1) + ApplicationUser.LastName.Substring(0,1));
            cmd.Parameters.AddWithValue("@datecont",DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@schcode",lblSchcode.Text);
            try
                {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                TeleLogAdded = true;
                }
            catch (Exception ex)
                {
                MessageBox.Show("Failed to insert telephone log record.");
                Log.Error("Failed to Insert telephone log:" + ex.Message);
                //go on we are not stopping the program for this
                }
            finally { cmd.Connection.Close(); }
            this.datecontTableAdapter.Fill(this.dsCust.datecont, this.Schcode);

            }

        private void btnAddMarketLog_Click(object sender,EventArgs e) {
            SqlConnection conn = new SqlConnection(FormConnectionString);
            string sql = "INSERT INTO MktInfo (ddate,initial,schcode) VALUES(@ddate,@initial,@schcode);";
            SqlCommand cmd = new SqlCommand(sql,conn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@initial",ApplicationUser.FirstName.Substring(0,1) + ApplicationUser.LastName.Substring(0,1));
            cmd.Parameters.AddWithValue("@ddate",DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@schcode",lblSchcode.Text);
            try
                {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                MktLogAdded = true;
                }
            catch (Exception ex)
                {
                MessageBox.Show("Failed to insert Marketing log record.");
                Log.Error("Failed to Marketing log:" + ex.Message);
                //go on we are not stopping the program for this
                }
            finally { cmd.Connection.Close(); }
            this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo,this.Schcode);
            }

        private void btnSaveTeleLog_Click(object sender,EventArgs e) {
            
                  SaveTeleLog();
        
            }

        private void frmMbcCust_FormClosing(object sender,FormClosingEventArgs e) {
            if(DoPhoneLog())
                {
                e.Cancel = true;
                MessageBox.Show("Please enter your customer service log information","Log",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
                }
			var custSaveResult = Save();
			if (custSaveResult.IsError) {
				DialogResult result=MessageBox.Show("Record failed to save. Continue closeing?","Save",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (result == DialogResult.No) {
                    e.Cancel = true;
                    return;
                    }
                
                }
            }

        private void datecontDataGridView_CellDoubleClick(object sender,DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 9)
                {
                  DataGridViewCell cell=(DataGridViewCell) datecontDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = DateTime.Now.ToShortDateString();
                }
           
            }

        private void btnSaveMktLog_Click(object sender,EventArgs e) {
            SaveMktLog();
            }

        private void mktinfoDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //leave
        }

        private void datecontDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //Leave Here;

        }

        private void pg3_Leave(object sender,EventArgs e) {
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

       

        private void button1_Click_1(object sender,EventArgs e) {
            var a = new ScreenPrinter(this);
            a.PrintScreen();

            }

        private void button3_Click(object sender,EventArgs e) {
            var a = 1;
            ScreenPrinter aa = new ScreenPrinter(this);

            }

        private void pg1_Enter(object sender,EventArgs e) {
            if (custBindingSource.Count < 1) {
                this.splitContainer.Panel1.Enabled = false;
                this.splitContainer.Panel2.Enabled = false;
                }
            }

        private void custDataGridView_Enter(object sender,EventArgs e) {
			try {
				this.custTableAdapter.Fill(this.dsCust.cust,this.Schcode);
				SetInvnoSchCode();
			} catch (Exception ex) {
				MbcMessageBox.Error(ex.Message, "");
			}
            
            }

       

        private void custDataGridView_CellDoubleClick(object sender,DataGridViewCellEventArgs e) {
            GoToSales();
            }

        private void contdateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void txtSchname_MouseClick(object sender, MouseEventArgs e)
		{

		}

		private void txtSchname_DoubleClick(object sender, EventArgs e)
		{
			if (ApplicationUser.IsInRole("SA")|| ApplicationUser.IsInRole("Administrator"))
			{
				txtSchname.ReadOnly = false;
			}
		}

		private void frmMbcCust_Paint(object sender, PaintEventArgs e)
		{
			try { this.Text = "MBC Customers-" + txtSchname.Text.Trim() + " (" + this.Schcode.Trim() + ")"; }
			catch
			{

			}
		}

		private void schoutDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			schoutDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void contdateDateTimePicker_ValueChanged_1(object sender, EventArgs e)
		{
			
			contdateDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void initcontDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			initcontDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void sourdateDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			sourdateDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		private void btnNewCustomer_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.AppStarting;
			string body = txtSchname.Text.Trim() + "<br/>" + txtaddress.Text.Trim() + "<br/>" +  txtCity.Text.Trim() + ", " + cmbState.SelectedValue + ' ' + txtZip.Text.Trim() + "<br/><br/>Congratulations to the Jostens Team...Memory Book just signed the following NEW customer in your territory for the " + contryearTextBox.Text + " school year! ";
			string subj = Schcode + " " + txtSchname.Text.Trim() + " " + cmbState.SelectedValue + " NEW SCHOOL By Customer Service Rep " + txtCsRep.Text;
			//string email = "yearbook@memorybook.com;hcantrell@memorybook.com;john.cox@jostens.com;tammy.whitaker@jostens.com";
			string email = "randy@woodalldevelopment.com";
			var emailHelper = new EmailHelper();
			EmailType type = EmailType.Mbc;
			emailHelper.SendOutLookEmail(subj, email, "", body, type);
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
            if (ApplicationUser.IsInRole("SA") || ApplicationUser.IsInRole("Administrator"))
            {
                txtSchname.ReadOnly = false;
            }
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

        private void firstDaySchoolDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            firstDaySchoolDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void rbdateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            rbdateDateTimePicker.Format= DateTimePickerFormat.Short;
        }

        private void xeldateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            xeldateDateTimePicker.Format= DateTimePickerFormat.Short;
        }

        private void btnProdTckt_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show(dataReturned.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var data = (ProdutnTicketModel)dataReturned.Data;
            
            ProdutnTicketModelBindingSource.DataSource = data;
            Cursor.Current = Cursors.WaitCursor;
            reportViewer1.RefreshReport();
            Cursor.Current = Cursors.Default;
           
        }

        private void reportViewer1_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            reportViewer1.PrintDialog();
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

//m.newfname = cust.newfname
//m.newlname = cust.newlname

//m.spec1 = ''

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
                MessageBox.Show(dataReturnedResult.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            var data = (ProductionCheckList)dataReturnedResult.Data;

            ProductionCheckListBindingSource.DataSource = data;
            Cursor.Current = Cursors.WaitCursor;
            reportViewerCheckList.RefreshReport();
            Cursor.Current = Cursors.Default;

        }

        private void reportViewerCheckList_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            reportViewerCheckList.PrintDialog();
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
            if (ApplicationUser.IsInRole("Administrator")|| ApplicationUser.IsInRole("SA"))
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
            if (ApplicationUser.IsInRole("Administrator") || ApplicationUser.IsInRole("SA")) {
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

		private void taxExemptionReceivedDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			taxExemptionReceivedDateTimePicker.Format = DateTimePickerFormat.Short;
		}

		//Nothing below here
	}
    }

