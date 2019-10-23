using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using BaseClass;
using Exceptionless;
namespace Mbc5.Forms
{
    public partial class frmRecSurvey : BaseClass.frmBase
    {
        public frmRecSurvey(UserPrincipal userPrincipal,int Invno,string Company,string vSchcode) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
            this.Invno = Invno;
            this.Company = Company;
            this.Schcode = vSchcode;
        }
        public string Company { get; set; }
       
        private void frmRecSurvey_Load(object sender, EventArgs e)
        {
            if (Invno == null || Invno == 0)
            {
                MbcMessageBox.Warning("Invoice number is missing. ", "");
                tabControl1.Enabled = false; ;
            }
            if (string.IsNullOrEmpty(Company))
            {
                MbcMessageBox.Warning("Company is missing.", "");
                tabControl1.Enabled = false; ;
            }
            if (Company == "MBC")
            {
                try
                {
                    recv2TableAdapter.FillMBC(dsReceiving.recv2, Invno);
                }catch(Exception ex)
                {
                    ex.ToExceptionless()
                        .AddObject(ex)
                        .Submit();
                    MbcMessageBox.Error(ex.Message);
                    tabControl1.Enabled = false; ;
                }
                
            }
            if (Company == "MER")
            {
                try
                {
                    recv2TableAdapter.FillByMER(dsReceiving.recv2, Invno);
                }catch(Exception ex)
                {
                    ex.ToExceptionless()
                       .AddObject(ex)
                       .Submit();
                    MbcMessageBox.Error(ex.Message);
                    tabControl1.Enabled = false; ;
                }
                
            }
            if (recv2BindingSource.Count == 0)
            {
                var sqlClient = new SQLCustomClient();
                sqlClient.CommandText("INSERT INTO RECV2 (Invno,Company,Schcode) Values(@Invno,@Company,@Schcode)");
                sqlClient.AddParameter("@Invno", Invno);
                sqlClient.AddParameter("@Company", Company);
                sqlClient.AddParameter("@Schcode", Schcode);
                var result = sqlClient.Insert();
                if (result.IsError)
                {
                    MbcMessageBox.Error("Error creating record.");
                    tabControl1.Enabled = false; ;
                    return;
                }
                if (Company == "MBC")
                {
                    try
                    {
                        recv2TableAdapter.FillMBC(dsReceiving.recv2, Invno);
                    }
                    catch (Exception ex)
                    {
                        ex.ToExceptionless()
                            .AddObject(ex)
                            .Submit();
                        MbcMessageBox.Error(ex.Message);
                        tabControl1.Enabled = false; ;
                    }

                }
                if (Company == "MER")
                {
                    try
                    {
                        recv2TableAdapter.FillByMER(dsReceiving.recv2, Invno);
                    }
                    catch (Exception ex)
                    {
                        ex.ToExceptionless()
                           .AddObject(ex)
                           .Submit();
                        MbcMessageBox.Error(ex.Message);
                        tabControl1.Enabled = false; ;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            recv2BindingSource.EndEdit();
           var a= recv2TableAdapter.Update(dsReceiving.recv2);
        }
    }
}
