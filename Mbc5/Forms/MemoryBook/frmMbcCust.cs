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
    public partial class frmMbcCust : BaseClass.Forms.bTopBottom
    {
        public frmMbcCust(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MbcCS"}, userPrincipal)
        {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
        }
        private UserPrincipal ApplicationUser { get; set; }
        private void frmMbcCust_Load(object sender, EventArgs e)
        {
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
      



        }

        private void btnSchoolCode_Click(object sender, EventArgs e)
        { 
            var records = this.custTableAdapter.Fill(this.dsCust.cust, txtSchCodesrch.Text);
            if (records < 1)
            {
                MessageBox.Show("Record was not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.datecontTableAdapter.Fill(this.dsCust.datecont, txtSchCode.Text.Trim());
            }
        }
        private void btnSchoolSearch_Click(object sender, EventArgs e)
        {
            var records = this.custTableAdapter.FillBySchname(this.dsCust.cust, txtSchNamesrch.Text);
            if (records < 1)
            {
                MessageBox.Show("Record was not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.datecontTableAdapter.Fill(this.dsCust.datecont, txtSchCode.Text.Trim());
            }
        }
        #region CrudOperations
        public override void Save()
        {
            txtSchname.ReadOnly = true;
            this.ValidateChildren(ValidationConstraints.Enabled);
            this.custBindingSource.EndEdit();
            try
            {
              custTableAdapter.Update(dsCust);
            }catch(DBConcurrencyException dbex)
            {
                DialogResult response = MessageBox.Show(CreateMessage((DataSets.dsCust.custRow)(dbex.Row)),                    "Concurrency Exception", MessageBoxButtons.YesNo);
                ProcessDialogResult(response);
            }catch(Exception ex)
            {
                Log.Fatal("Error Updating cust table:" + ex.Message);
                MessageBox.Show("An error was thrown while attempting to update the customer table.");
            }
           
        }
       
        public override void Add()
        {
            dsCust.Clear();
           DataRowView newrow = (DataRowView)custBindingSource.AddNew();
            GetSetSchcode();
            txtSchname.ReadOnly = false;
            
        }
        public override void Delete()
        {
            
        }
        public override void Cancel()
        {
            
        }
        #region ConcurrencyProcs
        private string CreateMessage(DataSets.dsCust.custRow cr)
        {
            return
                "Database Current Data: " + GetRowData(GetCurrentRowInDB(cr), DataRowVersion.Default) + "\n \n" +
                "Database Original: " + GetRowData(cr, DataRowVersion.Original) + "\n \n" +
                "Your Data: " + GetRowData(cr, DataRowVersion.Current) + "\n \n" +
                "Do you still want to update the database with the proposed value?";
        }


        //--------------------------------------------------------------------------
        // This method loads a temporary table with current records from the database
        // and returns the current values from the row that caused the exception.
        //--------------------------------------------------------------------------
        private DataSets.dsCust.custDataTable tempCustomersDataTable =
            new DataSets.dsCust.custDataTable();

        private DataSets.dsCust.custRow GetCurrentRowInDB(DataSets.dsCust.custRow RowWithError)
        {
            this.custTableAdapter.Fill(tempCustomersDataTable, RowWithError.schcode);

            DataSets.dsCust.custRow currentRowInDb =
                tempCustomersDataTable.FindByschcode(RowWithError.schcode);

            return currentRowInDb;
        }


        //--------------------------------------------------------------------------
        // This method takes a CustomersRow and RowVersion 
        // and returns a string of column values to display to the user.
        //--------------------------------------------------------------------------
        private string GetRowData(DataSets.dsCust.custRow custRow, DataRowVersion RowVersion)
        {
            string rowData = "";

            for (int i = 0; i < custRow.ItemArray.Length; i++)
            {
                rowData = rowData + custRow[i, RowVersion].ToString().Trim() + " ";
            }
            return rowData;
        }
        private void ProcessDialogResult(DialogResult response)
        {
            switch (response)
            {
                case DialogResult.Yes:
                    dsCust.Merge(tempCustomersDataTable, true, MissingSchemaAction.Ignore);
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
        private void txtCsRep_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtCsRep, string.Empty);
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
            //bool cancel = false;
            //if (yb_sthTextBox.Text!="Y" || !string.IsNullOrEmpty(this.yb_sthTextBox.Text.Trim()))
            //{
            //    //This control fails validation: Name cannot be empty.
            //    cancel = true;
            //    this.errorProvider1.SetError(this.yb_sthTextBox, "Value must be empty or Y.");
            //}
            //e.Cancel = cancel;
        }

        private void yb_sthTextBox_Validated(object sender, EventArgs e)
        {
            //this.errorProvider1.SetError(this.yb_sthTextBox, string.Empty);
        }

        private void shiptocontTextBox_Validated(object sender, EventArgs e)
        {
            //this.errorProvider1.SetError(this.shiptocontTextBox, string.Empty);
        }

        private void shiptocontTextBox_Validating(object sender, CancelEventArgs e)
        {
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
        private void GetSetSchcode()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mbc"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT precode,schcode from codecnt ", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
           

            try
            {

               
                string vPreCode = null;
                string vSchcode= null;
                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    vPreCode = rdr["precode"].ToString();
                    vSchcode = rdr["schcode"].ToString();
               
                }
                rdr.Close();
                int tmpSchcode = 0;
                if(Int32.TryParse(vSchcode,out tmpSchcode))
                {
                   tmpSchcode += 1;
                   this.txtSchCode.Text = vPreCode + tmpSchcode.ToString();
                    cmd.CommandText = "Update codecnt Set schcode=@schcode";
                    cmd.Parameters.AddWithValue("@schcode",tmpSchcode.ToString());
                    cmd.ExecuteNonQuery();

                }
                else { this.txtSchCode.Text = "error"; }
                
              
            }

            catch (Exception ex)
            {
                Log.Fatal("Failed to get new schcode:" + ex.Message);
                MessageBox.Show("Error generating school code.","School Code Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;

            }
            finally { cmd.Connection.Close(); }
           

        }

        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Add();
        }

        private void btnWebsite_Click(object sender, EventArgs e)
        {
            try {Process.Start(txtWebsite.Text); }catch(Exception ex)
            {
                MessageBox.Show("Url is invalid.");
            }
            
        }

       
        private void btnInterOffice_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            frmEmail frmEmail = new frmEmail(this.ApplicationUser,"","Inter Office Memo", inofficeTextBox.Text);
            frmEmail.MdiParent =this.MdiParent;
            frmEmail.Show();
            this.Cursor = Cursors.Default;
        }

        private void btnSchoolEmail_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            frmEmail frmEmail = new frmEmail(this.ApplicationUser,txtSchEmail.Text, "", "");
            frmEmail.MdiParent = this.MdiParent;
            frmEmail.Show();
            this.Cursor = Cursors.Default;
        }

        private void btnEmailContact_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            frmEmail frmEmail = new frmEmail(this.ApplicationUser, txtContactEmail.Text, "", "");
            frmEmail.MdiParent = this.MdiParent;
            frmEmail.Show();
            this.Cursor = Cursors.Default;
        }

        private void btnEmailCont2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            frmEmail frmEmail = new frmEmail(this.ApplicationUser, txtContact2Email.Text, "", "");
            frmEmail.MdiParent = this.MdiParent;
            frmEmail.Show();
            this.Cursor = Cursors.Default;
        }

        private void btnEmailContac3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            frmEmail frmEmail = new frmEmail(this.ApplicationUser, txtContact3Email.Text, "", "");
            frmEmail.MdiParent = this.MdiParent;
            frmEmail.Show();
            this.Cursor = Cursors.Default;
        }

        private void datecontDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //string a = "";
           
        }

        private void commentListBox_DoubleClick(object sender, EventArgs e)
        {
            string val = commentListBox.GetItemText(commentListBox.SelectedItem);
            txtReason.Text = val;
            
            txtReason.Select(); 
          
           
        }

        private void txtReason_Leave(object sender, EventArgs e)
        {
           datecontDataGridView.Select();
         this.BindingContext[this.datecontDataGridView.DataSource].EndCurrentEdit();
           datecontDataGridView.Refresh();
            datecontDataGridView.Parent.Refresh();
        }

       
    }
}
