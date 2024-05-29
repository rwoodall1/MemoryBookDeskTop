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
using Equin.ApplicationFramework;
using Mbc5.Classes;
namespace Mbc5.Forms.MixBook
{
    public partial class frmScrubExemptions : BaseClass.frmBase
    {
        public frmScrubExemptions(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator"}, userPrincipal)
        {
            InitializeComponent();
        }
        public UserPrincipal ApplicationUser { get; set; }
        public frmMain frmMain { get; set; }
        private void frmScrubExemptions_Load(object sender, EventArgs e)
        {
            Fill();
        }
        private void Fill()
        {
            var sqlClient = new SQLCustomClient(ApplicationConfig.DefaultConnectionString);
            sqlClient.CommandText("Select Id,SubmittedCity,UpsCity From ScrubExemptions order by SubmittedCity ");
            var sqlResult=sqlClient.SelectMany<Exemption>();
            if (sqlResult.IsError)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to get exemptions:" + sqlResult.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Failed to get exemptions:" + sqlResult.Errors[0].DeveloperMessage);
                return;
            }
            var vExemptions =(List<Exemption>)sqlResult.Data;
            BindingListView<Exemption> exemptions = new BindingListView<Exemption>(vExemptions);
            bsExemptions.DataSource = exemptions;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //save
            var sqlClient = new SQLCustomClient(ApplicationConfig.DefaultConnectionString).CommandText("Update ScrubExemptions Set SubmittedCity=@SubmittedCity,UpsCity=@UpsCity Where Id=@Id");
            sqlClient.AddParameter("@SubmittedCity",txtSubmittedCity.Text);
            sqlClient.AddParameter("@UpsCity",txtUpsCity.Text);
            sqlClient.AddParameter("@Id",lblId.Text);
            var updateResult = sqlClient.Update();
            if (updateResult.IsError)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update ScrubExemption:" + updateResult.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Failed to update ScrubExemption:" + updateResult.Errors[0].DeveloperMessage);
                return;
            }
            Fill();
            MbcMessageBox.Information("Record Updated.");
        }

        private  void  bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var sqlClient = new SQLCustomClient(ApplicationConfig.DefaultConnectionString).CommandText("Delete From ScrubExemptions  Where Id=@Id");
           
            sqlClient.AddParameter("@Id", lblId.Text);
            var updateResult = sqlClient.Delete();
            if (updateResult.IsError)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to delete record from ScrubExemption:" + updateResult.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Failed to delete record from ScrubExemptions:" + updateResult.Errors[0].DeveloperMessage);
                return;
            }
            MbcMessageBox.Information("Record Deleted.");
            Fill();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            var sqlClient = new SQLCustomClient(ApplicationConfig.DefaultConnectionString).CommandText("Insert INTO ScrubExemptions (SubmittedCity,Upscity) VALUES('','') ");

            var insertResult = sqlClient.Insert();
            if (insertResult.IsError)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert record for ScrubExemption:" + insertResult.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Failed to insert record for ScrubExemption:" + insertResult.Errors[0].DeveloperMessage);
                return;
            }
     
            Fill();
            int vId = 0;
            int.TryParse(insertResult.Data, out vId);
            try
            {
                bsExemptions.Position= bsExemptions.Find("Id", vId);
            }
            catch (Exception ex){ }
         
        }
    }
   
}
