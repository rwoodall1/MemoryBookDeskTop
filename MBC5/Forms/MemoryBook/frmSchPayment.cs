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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            var sqlClient = new SQLCustomClient(ApplicationConfig.OPYConnectionString);
            string cmd = @"Select Id,Schname,Schcode,PONumber,PayDate,Amount
                            ,OrderHeaderGuid,CardHolderName,CardType,CardNumber,PaymentToken
                            ,Reconciled,PaymentCompleted,PaymentCompletedDate,EmailAddress
                            FROM OpySchPayment Where PaymentCompleted=1 AND PayDate>@FromDate and PayDate<@ToDate";

            sqlClient.CommandText(cmd);
            
            sqlClient.AddParameter("@@FromDate", dtFromDate.Value);
            sqlClient.AddParameter("@ToDate", dtToDate.Value);
            var result = sqlClient.SelectMany<SchoolPayment>();
            if(result.IsError)
            {
                Log.Error(result.Errors[0].DeveloperMessage);
            }
            this.All = (List<SchoolPayment>)result.Data;
            this.Reconciled = this.All.FindAll(x => x.Reconciled == true);
            this.UnReconciled = this.All.FindAll(x => x.Reconciled == false);
            bsSchPayments.DataSource =this.All;

        }

        private void frmSchPayment_Load(object sender, EventArgs e)
        {
            this.frmMain = (frmMain)this.MdiParent;
        }
    }
}
