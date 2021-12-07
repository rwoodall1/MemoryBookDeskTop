using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using BaseClass;
using BindingModels;
namespace Mbc5.Forms.MixBook
{
    public partial class frmEventLog : BaseClass.frmBase
    {
        public frmEventLog(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator"}, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
        }
        public frmMain frmMain { get; set; }
        public UserPrincipal ApplicationUser { get; set; }
        private void frmEventLog_Load(object sender, EventArgs e)
        {
            this.frmMain = (frmMain)this.MdiParent;
        }
        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            
            mixbookEventLogModelBindingSource.Clear();
            LoadData();
        }
        private void LoadData()
        {
            int vClientOrderId = 0;
            if (int.TryParse(txtClientOrderId.Text, out vClientOrderId))
            {
                string vJobid = "Mixbook_" + vClientOrderId.ToString();
               var sqlClient = new SQLCustomClient();
                sqlClient.CommandText("Select JobId,DateCreated,StatusChangedTo,Notified,NotificationXML FROM MixBookEventLog WHERE JobId=@Jobid");

                sqlClient.AddParameter("@Jobid",vJobid);
                var result=sqlClient.SelectMany<MixbookEventLogModel>();
                if (result.IsError)
                {
                    Log.Error(result.Errors[0].DeveloperMessage);
                    MbcMessageBox.Error("Failed to retrieve Event Logs");
                }
                var vData=(List<MixbookEventLogModel>)result.Data;
                if (vData==null || vData.Count<1)
                {
                    MbcMessageBox.Information("No Records were found.", "Records");
                    return;
                }
               mixbookEventLogModelBindingSource.DataSource = vData;
            }
            else
            {
                MbcMessageBox.Exclamation("Enter a valid numeric Order Id");
            }
                
        }

       
    }
}
