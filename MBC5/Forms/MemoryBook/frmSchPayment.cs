using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using Mbc5.Classes;
using BindingModels;
using static BindingModels.OpyBindingModels;
using Core;

using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

using System.Reflection;
using BaseClass;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Outlook;
using System.Net.Security;

namespace Mbc5.Forms.MemoryBook
{
    public partial class frmSchPayment : BaseClass.frmBase
    {
        public frmSchPayment(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal)
        {
            
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;

        }
        private UserPrincipal ApplicationUser { get; set; }
        public new frmMain frmMain { get; set; }
       
        private List<SchoolPayment> All { set; get; }
        private List<SchoolPayment> Reconciled { set; get; }
        private List<SchoolPayment> UnReconciled { set; get; }
        private void frmSchPayment_Load(object sender, EventArgs e)
        {

            
            if (!ApplicationUser.Roles.Contains("Administrator") && !ApplicationUser.Roles.Contains("SA") && !ApplicationUser.Roles.Contains("Supervisor"))
            {
                MbcMessageBox.Information("You do not have permission to access this form.");
                this.BeginInvoke(new MethodInvoker(this.Close));
            }
            this.frmMain = (frmMain)this.MdiParent;
            dtFromDate.Value = DateTime.Now.AddDays(-14);
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            var sqlClient = new SQLCustomClient(ApplicationConfig.OPYConnectionString);
            string cmd = @"Select Id,Schname,Schcode,PONumber,PayDate,Amount
                            ,OrderHeaderGuid,CardHolderName,CardType,CardNumber,PaymentToken
                            ,Reconciled,PaymentCompleted,PaymentCompletedDate,EmailAddress
                            FROM OpySchPayment Where PaymentCompleted=1 AND PayDate>@FromDate and PayDate<@ToDate";

            sqlClient.CommandText(cmd);
            
            sqlClient.AddParameter("@FromDate", dtFromDate.Value);
            sqlClient.AddParameter("@ToDate", dtToDate.Value);
            var result = sqlClient.SelectMany<SchoolPayment>();
            if(result.IsError)
            {
                Log.Error(result.Errors[0].DeveloperMessage);
            }
            if (result.Data==null)
            {
                MbcMessageBox.Information("No records were found.");
                return;
            }
            this.All = (List<SchoolPayment>)result.Data;
            this.SetFilterData();
            bsSchPayments.DataSource =this.All;
           
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAll.Checked)
            {
                bsSchPayments.DataSource = this.All;
            }
        }

        private void rbReconciled_CheckedChanged(object sender, EventArgs e)
        {
            if(rbReconciled.Checked)
            {
                bsSchPayments.DataSource = this.Reconciled;
            }
        }

        private void rbUnreconciled_CheckedChanged(object sender, EventArgs e)
        {
            if(rbUnreconciled.Checked)
            {
                bsSchPayments.DataSource = this.UnReconciled;
            }
        }

   

        private void SetRowReconciled(bool recval,int Id)
        {
            var sqlClient = new SQLCustomClient(ApplicationConfig.OPYConnectionString);
            sqlClient.CommandText("Update OpySchPayment Set Reconciled=@Reconciled Where Id=@Id");
            sqlClient.AddParameter("@Id", Id);
            sqlClient.AddParameter("@Reconciled", recval);
            var result = sqlClient.Update();
            if (result.IsError)
            {
                Log.Error(result.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Error Updating");
            }
            var rec=  this.All.Find(x => x.Id == Id);
            rec.Reconciled = recval;
            this.SetFilterData();
        }

     private void SetFilterData()
        {
            this.Reconciled = this.All.FindAll(x => x.Reconciled == true);
            this.UnReconciled = this.All.FindAll(x => x.Reconciled == false);
            

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
          
            
        }

        private void dgSchPay_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //leave
        }

        private void dgSchPay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgSchPay_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            
          
        }

        private void dgSchPay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrecs=bsSchPayments.Count-1;
            
            
            if (e.ColumnIndex==0) {
                if (e.RowIndex<numrecs) { 
                    
                    SendKeys.Send("{ENTER}"); } else {  SendKeys.Send("{TAB}"); }

            }
           //testing
            //var checkbox = dgSchPay.Rows[0].Cells[0].Value;
            //var row = (SchoolPayment)bsSchPayments.Current;
            //var data = (List<SchoolPayment>)bsSchPayments.DataSource;
        }

        private void dgSchPay_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgSchPay.EndEdit();
                
                var row = (SchoolPayment)bsSchPayments.Current;
                if (row != null)
                {
                    SetRowReconciled(row.Reconciled, row.Id);
                }
            }
            //testing
            //var checkbox = dgSchPay.Rows[0].Cells[0].Value;
         
            //var data = (List<SchoolPayment>)bsSchPayments.DataSource;
        
        }
    }
}
