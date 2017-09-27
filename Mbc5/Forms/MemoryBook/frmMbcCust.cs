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
using Exceptionless;
using Exceptionless.Models;
using Mbc5.Classes;
using BindingModels;
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
     

        #endregion

        private void frmMbcCust_Load(object sender,EventArgs e) {
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
            this.lkpTypeContTableAdapter.Fill(this.lookUp.lkpTypeCont);
            // TODO: This line of code loads data into the 'dsCust.datecont' table. You can move, or remove it, as needed.
            this.datecontTableAdapter.Fill(this.dsCust.datecont, vSchocode);
            // TODO: This line of code loads data into the 'dsCust.cust' table. You can move, or remove it, as needed.
            this.custTableAdapter.Fill(this.dsCust.cust, vSchocode);
            // TODO: This line of code loads data into the 'lookUp.contpstn' table. You can move, or remove it, as needed.
            this.contpstnTableAdapter.Fill(this.lookUp.contpstn);
            // TODO: This line of code loads data into the 'lookUp.states' table. You can move, or remove it, as needed.
            this.statesTableAdapter.Fill(this.lookUp.states);
            this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, vSchocode);
            SetInvnoSchCode();
        }
        private void btnOracleSrch_Click(object sender, EventArgs e)
		{
			var currentSchool = lblSchcodeVal.Text.Trim();
			if (DoPhoneLog())
			{
				MessageBox.Show("Please enter your customer service log information", "Log", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
			if (!this.Save())
			{
				DialogResult result = MessageBox.Show("Record failed to save. Hit cancel to correct.", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if (result == DialogResult.Cancel)
				{
					return;
				}
			}
			var records = this.custTableAdapter.FillByOracleCode(this.dsCust.cust, txtOracleCodeSrch.Text);
			if (records < 1)
			{
				this.custTableAdapter.Fill(this.dsCust.cust, currentSchool);
				MessageBox.Show("Record was not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text.Trim());
				this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text.Trim());
				TeleGo = false;
			}
			else
			{
				this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text.Trim());
				this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text.Trim());
				TeleGo = false;

			}
			txtOracleCodeSrch.Text = "";
			SetInvnoSchCode();
		}

		private void btnSchoolCode_Click(object sender,EventArgs e) {
            var currentSchool = lblSchcodeVal.Text.Trim();
            if (DoPhoneLog())
                {
                MessageBox.Show("Please enter your customer service log information","Log",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
                }
            if (!this.Save()) {
                DialogResult result = MessageBox.Show("Record failed to save. Hit cancel to correct.","Save",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel) {
                    return;
                    }
                }
            var records = this.custTableAdapter.Fill(this.dsCust.cust,txtSchCodesrch.Text);
            if (records < 1)
                {
                this.custTableAdapter.Fill(this.dsCust.cust,currentSchool);
                MessageBox.Show("Record was not found.","Search",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo,lblSchcodeVal.Text.Trim());
                this.datecontTableAdapter.Fill(this.dsCust.datecont,lblSchcodeVal.Text.Trim());
                TeleGo = false;
                }
            else
                {
                this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo,lblSchcodeVal.Text.Trim());
                this.datecontTableAdapter.Fill(this.dsCust.datecont,lblSchcodeVal.Text.Trim());
                TeleGo = false;
              
                }
            txtSchCodesrch.Text = "";
            SetInvnoSchCode();
            frmMbcCust_Paint(this, null);
        }
        private void btnSchoolSearch_Click(object sender,EventArgs e) {
            var currentSchool = lblSchcodeVal.Text.Trim();
            if (DoPhoneLog()){
                MessageBox.Show("Please enter your customer service log information","Log",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
                }
            if (!this.Save()) {
                DialogResult result = MessageBox.Show("Record failed to save correct and save again.","Save",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
                }
            //var records = this.custTableAdapter.FillBySchname(this.dsCust.cust,txtSchNamesrch.Text);
            var sqlQuery = new SQLQuery();
           var queryString = @"SELECT schcode, schname,schcity,schstate, schzip FROM cust
                              WHERE(schname LIKE @schname + '%')
                              ORDER BY   schcode";
            SqlParameter[] parameters = new SqlParameter[] {
               new SqlParameter("@schname",txtSchNamesrch.Text.Trim())
            };
            var dataResult = sqlQuery.ExecuteReaderAsync<SchoolNameSearchModel>(CommandType.Text, queryString, parameters);
            var records = (List<SchoolNameSearchModel>)dataResult;
         


            if (records.Count < 1)
			{
				this.custTableAdapter.Fill(this.dsCust.cust, currentSchool);
				this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text.Trim());
				this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text.Trim());
				TeleGo = false;
				MessageBox.Show("Record was not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else if (records.Count > 1)
			{
				//more than one record select which one you want
				
				this.Cursor = Cursors.AppStarting;
				//frmSelctCust frmSelectCust = new frmSelctCust(tmpTable);
                frmSelctCust frmSelectCust = new frmSelctCust(records);
                DialogResult result = frmSelectCust.ShowDialog();
				this.Cursor = Cursors.Default;
				if (result != DialogResult.Cancel)
				{
					this.custTableAdapter.Fill(this.dsCust.cust, frmSelectCust.retval);
					this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text.Trim());
					this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text.Trim());
					TeleGo = false;
				}
				else
				{
					//refill normal
					this.custTableAdapter.Fill(this.dsCust.cust,records[0].schcode );
					this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text.Trim());
					this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text.Trim());
					TeleGo = false;
				}
			}

			else
			{
				this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo, lblSchcodeVal.Text.Trim());
				this.datecontTableAdapter.Fill(this.dsCust.datecont, lblSchcodeVal.Text.Trim());
				TeleGo = false;

			}
				txtSchNamesrch.Text = "";
				SetInvnoSchCode();
            frmMbcCust_Paint(this, null);
        }
        #region CrudOperations
        public override bool Save()
        {
			this.txtModifiedBy.Text  = this.ApplicationUser.id;
            bool retval = false;
		
            txtSchname.ReadOnly = true;
            var a = this.ValidateChildren(ValidationConstraints.Enabled);
                var b=this.ValidateChildren(ValidationConstraints.ImmediateChildren);
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                this.custBindingSource.EndEdit();
                try
                {
                    custTableAdapter.Update(dsCust);
                    retval = true;
                }
                catch (DBConcurrencyException dbex)
                {
                    DialogResult result = ExceptionHandler.CreateMessage((DataSets.dsCust.custRow)(dbex.Row), ref dsCust);
                    if (result == DialogResult.Yes) {
                        Save();
                    }
                    else {
                        retval = true;
                    }                  
                }catch(Exception ex) {
                    MessageBox.Show("School record failed to update:" + ex.Message);
                    ex.ToExceptionless()
                   .SetMessage("School record failed to update:" + ex.Message)
                   .Submit();
                    retval = false;
                    }
            }
			this.custTableAdapter.Fill(this.dsCust.cust, this.Schcode);
			return retval;
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
				var result = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, queryString, parameters);
				this.custTableAdapter.Fill(this.dsCust.cust, "038752");//set to cs record                
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
        private void txtCsRep_Validated(object sender,EventArgs e) {
            this.errorProvider1.SetError(this.txtCsRep,string.Empty);
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
		private void AddSalesRecord()
		{
			DialogResult result = MessageBox.Show("Do you wish to add a sales record?", "Add Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				int InvNum = GetInvno();
				if (InvNum != 0)
				{
					var sqlQuery = new SQLQuery();
					//useing hard code until function to generate invno is done
					SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@Invno",InvNum),
					 new SqlParameter("@Schcode",lblSchcodeVal.Text),
					  new SqlParameter("@Contryear", contryearTextBox.Text)
					};
					var strQuery = "INSERT INTO [dbo].[Quotes](Invno,Schcode,Contryear)  VALUES (@Invno,@Schcode,@Contryear)";
					var userResult = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters);
					if (userResult != 1)
					{
						MessageBox.Show("Failed to insert sales record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					SqlParameter[] parameters1 = new SqlParameter[] {
					new SqlParameter("@Invno",InvNum),
					 new SqlParameter("@Schcode",lblSchcodeVal.Text),
					 new SqlParameter("@ProdNo",GetProdNo()),
					  new SqlParameter("@Contryear", contryearTextBox.Text),
					   new SqlParameter("@Company","MBC")
					};
					strQuery = "INSERT INTO [dbo].[produtn](Invno,Schcode,Contryear,Prodno,Company)  VALUES (@Invno,@Schcode,@Contryear,@ProdNo,@Company)";
					var userResult1 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters1);
					if (userResult1 != 1)
					{
						MessageBox.Show("Failed to insert production record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					SqlParameter[] parameters2 = new SqlParameter[] {
					new SqlParameter("@Invno",InvNum),
					 new SqlParameter("@Schcode",lblSchcodeVal.Text),
					 new SqlParameter("@Specovr",GetCoverNumber()),
						 new SqlParameter("@Specinst",GetInstructions() ),
					   new SqlParameter("@Company","MBC")
					};
					strQuery = "Insert into Covers (schcode,invno,company,specovr,Specinst) Values(@Schcode,@Invno,@Company,@Specovr,@Specinst)";
					var userResult2 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters2);
					if (userResult2 != 1)
					{
						MessageBox.Show("Failed to insert covers record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					Save();
					this.custTableAdapter.Fill(this.dsCust.cust, lblSchcodeVal.Text);
				};
			}//not = 0
		}
		private void GoToSales() {

            
                this.Cursor = Cursors.AppStarting;
                     int vInvno = this.Invno;
                    string vSchcode = lblSchcodeVal.Text;

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
            if (this.lblSchcodeVal.Text == "038752") {
                retval = false;

                }
            if (this.TeleGo && this.MktGo) {
                retval = false;

                }
            return retval;
             }
        private int GetInvno()
        {
           
            var sqlQuery = new BaseClass.Classes.SQLQuery();

            SqlParameter[] parameters = new SqlParameter[] {

                    };
            var strQuery = "SELECT Invno FROM Invcnum";
            try
            {
                DataTable userResult = sqlQuery.ExecuteReaderAsync(CommandType.Text, strQuery, parameters);
                DataRow dr = userResult.Rows[0];
                int Invno =(int) dr["Invno"];
                int newInvno = Invno + 1;
                strQuery = "Update Invcnum Set invno=@newInvno";
                SqlParameter[] parameters1 = new SqlParameter[] {
                      new SqlParameter("@newInvno",newInvno),
                    };
                sqlQuery.ExecuteNonQueryAsync(CommandType.Text,strQuery,parameters1);

                return Invno;

            }catch(Exception ex)
            {
                Log.Error("Failed to get invoice number for a new record:" + ex.Message);
                MessageBox.Show("Failed to get invoice number for a new record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;

            }
           
        }
        private string GetProdNo() {
            var sqlQuery = new SQLQuery();
            //useing hard code until function to generate invno is done
            SqlParameter[] parameters = new SqlParameter[] { };
            var strQuery = "Select * from prodnum";
            var result = sqlQuery.ExecuteReaderAsync(CommandType.Text,strQuery,parameters);
            int? prodNum = null;
            try {
                prodNum = Convert.ToInt32(result.Rows[0]["lstprodno"]);
                strQuery = "Update Prodnum Set lstprodno=@lstprodno";
                SqlParameter[] parameters1 = new SqlParameter[] { new SqlParameter("@lstprodno",(prodNum + 1)) };
                var result1 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text,strQuery,parameters1);
                if (result1 != 1) {
                    ExceptionlessClient.Default.CreateLog("Error updating Prodnum table with new value.")
                         .AddTags("New prod number error.")
                         .Submit();

                    }

                } catch (Exception ex) {
                MessageBox.Show("There was an error getting the production number.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                ex.ToExceptionless()
                  .AddTags("MBCWindows")
                  .SetMessage("Error getting production number.")
                  .Submit();

                }

            return prodNum.ToString();

            }
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
        private string GetCoverNumber() {
            var sqlQuery = new SQLQuery();
            //useing hard code until function to generate invno is done
            SqlParameter[] parameters = new SqlParameter[] {};
            var strQuery = "Select * from Spcover";
            var result = sqlQuery.ExecuteReaderAsync(CommandType.Text,strQuery,parameters);
            int? coverNum=null;
            try {
                   coverNum = Convert.ToInt32(result.Rows[0]["speccvno"]);
                  strQuery = "Update Spcover set speccvno=@speccvno";
                SqlParameter[] parameters1 = new SqlParameter[] { new SqlParameter("@speccvno",(coverNum+1)) };
                var result1 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text,strQuery,parameters1);
                if (result1 != 1) {
                    ExceptionlessClient.Default.CreateLog("Error updating Spcover table with new value.")
                         .AddTags("New cover number error.")
                         .Submit();
                         
                    }

                } catch(Exception ex){
                MessageBox.Show("There was an error getting the cover number.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                ex.ToExceptionless()
                  .AddTags("MBCWindows")
                  .SetMessage("Error getting cover number.")
                  .Submit();

                }

            return coverNum.ToString();
            }
        private void GetSetSchcode() {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mbc"].ToString());
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
                    this.lblSchcodeVal.Text = vPreCode + tmpSchcode.ToString();
                    cmd.CommandText = "Update codecnt Set schcode=@schcode";
                    cmd.Parameters.AddWithValue("@schcode",tmpSchcode.ToString());
                    cmd.ExecuteNonQuery();

                    }
                else
                    { this.lblSchcodeVal.Text = "error"; }


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
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mbc"].ToString());
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

                    this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo,lblSchcodeVal.Text.Trim());
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
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.Mbc5ConnectionString);
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

                    this.datecontTableAdapter.Fill(this.dsCust.datecont,lblSchcodeVal.Text);
                    }
                }
            else
                {
                
                    MessageBox.Show("You do not have any records to be saved.","Log",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    
                  
                }
            }
        private void DataRefresh() {
            
                this.custTableAdapter.Fill(this.dsCust.cust,lblSchcodeVal.Text);
                this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo,lblSchcodeVal.Text.Trim());
                this.datecontTableAdapter.Fill(this.dsCust.datecont,lblSchcodeVal.Text.Trim());
                }
        private string GetInstructions()
        {
            string val = "";
            custBindingSource.MoveFirst();//make sure on first row
            DataRowView current = (DataRowView)custBindingSource.Current;
            var invno=current["invno"];
            var sqlQuery = new SQLQuery();
          
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Invno",invno),
                   
                    };
            var strQuery = "Select Specinst from Covers Where Invno=@Invno";
            try { var result = sqlQuery.ExecuteReaderAsync(CommandType.Text, strQuery, parameters);
             val = result.Rows[0][0].ToString(); } catch(Exception ex)
            {

            }
           
            return val;

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
            this.Cursor = Cursors.AppStarting;
            frmEmail frmEmail = new frmEmail(this.ApplicationUser,txtContactEmail.Text,"","");
            frmEmail.MdiParent = this.MdiParent;
            frmEmail.Show();
            this.Cursor = Cursors.Default;
            }

        private void btnEmailCont2_Click(object sender,EventArgs e) {
            this.Cursor = Cursors.AppStarting;
            frmEmail frmEmail = new frmEmail(this.ApplicationUser,txtContact2Email.Text,"","");
            frmEmail.MdiParent = this.MdiParent;
            frmEmail.Show();
            this.Cursor = Cursors.Default;
            }

        private void btnEmailContac3_Click(object sender,EventArgs e) {
            this.Cursor = Cursors.AppStarting;
            frmEmail frmEmail = new frmEmail(this.ApplicationUser,txtContact3Email.Text,"","");
            frmEmail.MdiParent = this.MdiParent;
            frmEmail.Show();
            this.Cursor = Cursors.Default;
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

            SqlConnection conn = new SqlConnection(Properties.Settings.Default.Mbc5ConnectionString );
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
            this.datecontTableAdapter.Fill(this.dsCust.datecont,lblSchcodeVal.Text);

            }

        private void btnAddMarketLog_Click(object sender,EventArgs e) {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mbc"].ToString());
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
            this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo,lblSchcodeVal.Text.Trim());
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
            if (!this.Save()) {
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

        private void mktinfoDataGridView_DataError(object sender,DataGridViewDataErrorEventArgs e) {
            //leave
            }

        private void datecontDataGridView_DataError(object sender,DataGridViewDataErrorEventArgs e) {
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
            this.custTableAdapter.Fill(this.dsCust.cust,this.Schcode);
            }

        private void custDataGridView_RowHeaderMouseDoubleClick(object sender,DataGridViewCellMouseEventArgs e) {
            GoToSales();
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
			schoutDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void contdateDateTimePicker_ValueChanged_1(object sender, EventArgs e)
		{
			
			contdateDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void initcontDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			initcontDateTimePicker.Format = DateTimePickerFormat.Long;
		}

		private void sourdateDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			sourdateDateTimePicker.Format = DateTimePickerFormat.Long;
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


        //Nothing below here
    }
    }

