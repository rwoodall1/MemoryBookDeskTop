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


namespace Mbc5.Forms.MemoryBook {
    public partial class frmMbcCust : BaseClass.Forms.bTopBottom ,INotifyPropertyChanged {
           private bool vMktGo = false;
        private string vSchcode = null;
        private int vInvno = 0;
          
        public frmMbcCust(UserPrincipal userPrincipal) : base(new string[] { "SA","Administrator","MbcCS" },userPrincipal) {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;

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
        
     

        #endregion

        private void frmMbcCust_Load(object sender,EventArgs e) {

             this.chkMktComplete.DataBindings.Add("Checked",this,"MktGo",false,DataSourceUpdateMode.OnPropertyChanged);//bind check box to property of form

            if (!ApplicationUser.Roles.Contains("MbcCS"))
                {
                TeleGo = true;
                MktGo = true;
                }
           

            
            // TODO: This line of code loads data into the 'lookUp.lkpPromotions' table. You can move, or remove it, as needed.
            this.lkpPromotionsTableAdapter.Fill(this.lookUp.lkpPromotions);
            // TODO: This line of code loads data into the 'lookUp.lkpMktReference' table. You can move, or remove it, as needed.
            this.lkpMktReferenceTableAdapter.Fill(this.lookUp.lkpMktReference);
            // TODO: This line of code loads data into the 'lookUp.lkpComments' table. You can move, or remove it, as needed.
            this.lkpCommentsTableAdapter.Fill(this.lookUp.lkpComments);
            // TODO: This line of code loads data into the 'lookUp.lkpTypeCont' table. You can move, or remove it, as needed.
            this.lkpTypeContTableAdapter.Fill(this.lookUp.lkpTypeCont);
            // TODO: This line of code loads data into the 'dsCust.datecont' table. You can move, or remove it, as needed.
            this.datecontTableAdapter.Fill(this.dsCust.datecont,"038752");
            // TODO: This line of code loads data into the 'dsCust.cust' table. You can move, or remove it, as needed.
            this.custTableAdapter.Fill(this.dsCust.cust,"038752");
            // TODO: This line of code loads data into the 'lookUp.contpstn' table. You can move, or remove it, as needed.
            this.contpstnTableAdapter.Fill(this.lookUp.contpstn);
            // TODO: This line of code loads data into the 'lookUp.states' table. You can move, or remove it, as needed.
            this.statesTableAdapter.Fill(this.lookUp.states);
            this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo,"038752");
            SetInvnoSchCode();

            }

        private void btnSchoolCode_Click(object sender,EventArgs e) {
            if (this.lblSchcodeVal.Text != "038752" && (!this.TeleGo || !this.MktGo))
                {
                MessageBox.Show("Please enter your customer service log information","Log",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
                }
            var records = this.custTableAdapter.Fill(this.dsCust.cust,txtSchCodesrch.Text);
            if (records < 1)
                {
                MessageBox.Show("Record was not found.","Search",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            else
                {
                this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo,lblSchcodeVal.Text.Trim());
                this.datecontTableAdapter.Fill(this.dsCust.datecont,lblSchcodeVal.Text.Trim());
                TeleGo = false;
              
                }
            }
        private void btnSchoolSearch_Click(object sender,EventArgs e) {
            if(this.lblSchcodeVal.Text!="038752" && (!this.TeleGo || !this.MktGo)){
                MessageBox.Show("Please enter your customer service log information","Log",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
                }
            var records = this.custTableAdapter.FillBySchname(this.dsCust.cust,txtSchNamesrch.Text);
            if (records < 1)
                {
                MessageBox.Show("Record was not found.","Search",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            else
                {
                this.mktinfoTableAdapter.Fill(this.dsMktInfo.mktinfo,lblSchcodeVal.Text.Trim());
                this.datecontTableAdapter.Fill(this.dsCust.datecont,lblSchcodeVal.Text.Trim());
                TeleGo = false;
               
                }
            }
        #region CrudOperations
      
        #region ConcurrencyProcs
        private string CreateMessage(DataSets.dsCust.custRow cr) {
            return
                "Database Current Data: " + GetRowData(GetCurrentRowInDB(cr),DataRowVersion.Default) + "\n \n" +
                "Database Original: " + GetRowData(cr,DataRowVersion.Original) + "\n \n" +
                "Your Data: " + GetRowData(cr,DataRowVersion.Current) + "\n \n" +
                "Do you still want to update the database with the proposed value?";
            }


        //--------------------------------------------------------------------------
        // This method loads a temporary table with current records from the database
        // and returns the current values from the row that caused the exception.
        //--------------------------------------------------------------------------
        private DataSets.dsCust.custDataTable tempCustomersDataTable =
            new DataSets.dsCust.custDataTable();

        private DataSets.dsCust.custRow GetCurrentRowInDB(DataSets.dsCust.custRow RowWithError) {
            this.custTableAdapter.Fill(tempCustomersDataTable,RowWithError.schcode);

            DataSets.dsCust.custRow currentRowInDb =
                tempCustomersDataTable.FindByschcode(RowWithError.schcode);

            return currentRowInDb;
            }


        //--------------------------------------------------------------------------
        // This method takes a CustomersRow and RowVersion 
        // and returns a string of column values to display to the user.
        //--------------------------------------------------------------------------
        private string GetRowData(DataSets.dsCust.custRow custRow,DataRowVersion RowVersion) {
            string rowData = "";

            for (int i = 0; i < custRow.ItemArray.Length; i++)
                {
                rowData = rowData + custRow[i,RowVersion].ToString().Trim() + " ";
                }
            return rowData;
            }
        private void ProcessDialogResult(DialogResult response) {
            switch (response)
                {
                case DialogResult.Yes:
                    dsCust.Merge(tempCustomersDataTable,true,MissingSchemaAction.Ignore);
                    Save();
                    break;

                case DialogResult.No:
                    dsCust.Merge(tempCustomersDataTable);
                    MessageBox.Show("Update cancelled");
                    break;
                }
            }
        #endregion
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

        private void txtCsRep_Validating(object sender,CancelEventArgs e) {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtCsRep.Text.Trim()))
                {
                //This control fails validation: Name cannot be empty.
                cancel = true;
                this.errorProvider1.SetError(this.txtCsRep,"Sales rep is required.");
                }
            e.Cancel = cancel;
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
        private void yb_sthTextBox_Validating(object sender,CancelEventArgs e) {
            //bool cancel = false;
            //if (yb_sthTextBox.Text!="Y" || !string.IsNullOrEmpty(this.yb_sthTextBox.Text.Trim()))
            //{
            //    //This control fails validation: Name cannot be empty.
            //    cancel = true;
            //    this.errorProvider1.SetError(this.yb_sthTextBox, "Value must be empty or Y.");
            //}
            //e.Cancel = cancel;
            }

        private void yb_sthTextBox_Validated(object sender,EventArgs e) {
            //this.errorProvider1.SetError(this.yb_sthTextBox, string.Empty);
            }

        private void shiptocontTextBox_Validated(object sender,EventArgs e) {
            //this.errorProvider1.SetError(this.shiptocontTextBox, string.Empty);
            }

        private void shiptocontTextBox_Validating(object sender,CancelEventArgs e) {
            //bool cancel = false;
            //var a = !string.IsNullOrEmpty(this.shiptocontTextBox.Text.Trim());
            //if (shiptocontTextBox.Text != "Y" || !string.IsNullOrEmpty(this.shiptocontTextBox.Text.Trim()))
            //{
            //    //This control fails validation: Name cannot be empty.
            //    cancel = true;
            //    this.errorProvider1.SetError(this.shiptocontTextBox, "Value must be empty or Y.");
            //}
            //e.Cancel = cancel;
            }
        #endregion
        #region Methods
        private void SetInvnoSchCode()
        {
            this.Schcode = lblSchcodeVal.Text;
            int val = 0;
            bool parsed = Int32.TryParse(lblInvno.Text, out val);
            if (parsed)
            {
                this.Invno = val;
            }
        }
        public override void Save() {
            txtSchname.ReadOnly = true;
            this.ValidateChildren(ValidationConstraints.Enabled);
            this.custBindingSource.EndEdit();
            try
                {
                custTableAdapter.Update(dsCust);
                }
            catch (DBConcurrencyException dbex)
                {
                DialogResult response = MessageBox.Show(CreateMessage((DataSets.dsCust.custRow)(dbex.Row)),"Concurrency Exception",MessageBoxButtons.YesNo);
                ProcessDialogResult(response);
                }
            catch (Exception ex)
                {
                Log.Fatal("Error Updating cust table:" + ex.Message);
                MessageBox.Show("An error was thrown while attempting to update the customer table.");
                }

            }
        public override void Add() {
            dsCust.Clear();
            DataRowView newrow = (DataRowView)custBindingSource.AddNew();
            GetSetSchcode();
            txtSchname.ReadOnly = false;

            }
        public override void Delete() {

            }
        public override void Cancel() {

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

            this.ValidateChildren();
            DataTable EditedRecs = dsCust.datecont.GetChanges();
            if (EditedRecs != null)
                {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mbc"].ToString());
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

        #endregion
        private void button1_Click(object sender,EventArgs e) {
            this.Save();
            }

        private void button2_Click(object sender,EventArgs e) {
            this.Add();
            }

        private void btnWebsite_Click(object sender,EventArgs e) {
            try
                { Process.Start(txtWebsite.Text); }
            catch (Exception ex)
                {
                MessageBox.Show("Url is invalid.");
                }

            }


        private void btnInterOffice_Click(object sender,EventArgs e) {
            this.Cursor = Cursors.AppStarting;
            frmEmail frmEmail = new frmEmail(this.ApplicationUser,"","Inter Office Memo",inofficeTextBox.Text);
            frmEmail.MdiParent = this.MdiParent;
            frmEmail.Show();
            this.Cursor = Cursors.Default;
            }

        private void btnSchoolEmail_Click(object sender,EventArgs e) {
            this.Cursor = Cursors.AppStarting;
            frmEmail frmEmail = new frmEmail(this.ApplicationUser,txtSchEmail.Text,"","");
            frmEmail.MdiParent = this.MdiParent;
            frmEmail.Show();
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

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mbc"].ToString());
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
            if(lblSchcodeVal.Text!="038752" &&(!TeleGo || !MktGo))
                {
                e.Cancel = true;
                MessageBox.Show("Please enter your customer service log information","Log",MessageBoxButtons.OK,MessageBoxIcon.Stop);
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

        private void contdateDateTimePicker_CloseUp(object sender,EventArgs e) {
           DialogResult result=MessageBox.Show("Do you wish to add a sales record?","Add Record",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                {
                var sqlQuery = new BaseClase.Classes.SQLQuery();
                //useing hard code until function to generate invno is done
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Invno",1111),
                     new SqlParameter("@Schcode",lblSchcodeVal.Text),
                      new SqlParameter("@Contryear", contryearTextBox.Text)
                    };
                var strQuery = "INSERT INTO [dbo].[Quotes](Invno,Schcode,Contryear)  VALUES (@Invno,@Schcode,@Contryear)";
                var userResult = sqlQuery.ExecuteNonQueryAsync(CommandType.Text,strQuery,parameters);
                if (userResult!=1){
                    MessageBox.Show("Failed to insert sales record.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                this.custTableAdapter.Fill(this.dsCust.cust,lblSchcodeVal.Text);
                };
            
            }







        //Nothing below here
        }
    }

