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
using BindingModels;
using Microsoft.Reporting.WinForms;
using System.IO;
using CsvHelper;
namespace Mbc5.Forms
{
    public partial class frmInqCount : BaseClass.frmBase
    {
        public frmInqCount(UserPrincipal userPrincipal,string company ) : base(new string[] { "SA", "Administrator", "MbcCS","MerCS" }, userPrincipal)
        {
            Company = company;
            InitializeComponent();
        }
        public string Company { get; set; }

        private void frmInqCount_Load(object sender, EventArgs e)
        {
            this.Text = Company+" "+this.Text;


           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Company == "MBC")
            {
                GenerateMBCReport();
            }
            else if (Company == "MER")
            {
                GenerateMeridianReport();
            }

        }

        private void chkInquiry_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInquiry.Checked)
            {
                pnlInquiry.Enabled = true;
            }
            else
            {
                pnlInquiry.Enabled = false;
            }
        }

        private void chkContact_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContact.Checked) {
                pnlContact.Enabled = true;
            } else {
                pnlContact.Enabled = false; }
        }
        private void GenerateMBCReport()
        {
            var sqlQuery = new SQLCustomClient();
            sqlQuery.AddParameter("@InqBegin", inqStartDate.Value);
            sqlQuery.AddParameter("@InqEnd", inqEndDate.Value);
            sqlQuery.AddParameter("@ContBegin", contStartDate.Value);
            sqlQuery.AddParameter("@ContEnd", contEndDate.Value);
            sqlQuery.AddParameter("@NotYear", contEndDate.Value);
            sqlQuery.AddParameter("@Contryear", txtContryear.Text.Trim());
            string vSelect = @"Select TOP 10 C.SCHSTATE
            ,C.SCHCODE
             ,C.SCHNAME
            ,CS.CSNAME AS CSNAME
            ,CONVERT(varchar(50),CONVERT(date,C.SOURDATE)) AS SOURDATE 
            ,CONVERT(varchar(50),CONVERT(date,C.INITCONT)) AS INITCONT
            ,C.SCHNAME AS SCHNAM
            ,RTrim(C.contfname) +' '+RTrim(C.contlname) as Contname
            ,C.contemail as Email1
            ,C.bcontemail as Email2
            ,C.CONTRYEAR
            ,RTrim(C.Stage)
            ,C.SCHSTATE
            ,CONVERT(varchar(50),CONVERT(date,B.QTEDATE))AS QTEDATE
            ,B.ADJBEF
            ,D.INITIAL
            ,CONVERT(varchar(50),CONVERT(date,D.DATECONT))AS DATECONT
            ,D.REASON
            FROM Cust C
            LEFT JOIN CSNames CS ON C.CSREP= CS.Source   
            LEFT JOIN (SELECT BB.ID, BB.schcode, BB.QTEDATE,BB.ADJBEF FROM BIDS BB Where BB.id 
            In (SELECT MAX(BIDS.ID)AS ID From Bids Where Bids.schcode=BB.schcode )) B On C.schcode = B.schcode
            LEFT join (SELECT DC.SCHCODE,CONVERT(date,DC.DATECONT)AS DATECONT,DC.INITIAL,DC.REASON From DATECONT DC WHERE DC.Id 
            IN (SELECT MAX(DATECONT.Id) AS id FROM DATECONT Where DATECONT.Schcode=DC.Schcode)) D on B.SCHCODE=D.SCHCODE";
            string vWhere = @" WHERE C.CONTRYEAR !=@Contryear";

            if (chkInquiry.Checked && chkContact.Checked)
            {
                vWhere += @" AND ((C.SOURDATE >= @InqBegin and C.SOURDATE <=@InqEnd)
                OR ( C.INITCONT >= @ContBegin AND C.INITCONT <= @ContEnd))";
            }
            else if (chkInquiry.Checked && !chkContact.Checked)
            {
                vWhere += @" AND (C.SOURDATE >= @InqBegin and C.SOURDATE <=@InqEnd)";
            }
            else if (!chkInquiry.Checked && chkContact.Checked)
            {
                vWhere += @" AND ( C.INITCONT >= @ContBegin AND C.INITCONT <= @ContEnd)";
            }
            string vOrder = " Order BY CSNAME,C.SCHSTATE,C.SCHNAME";
            string cmd = vSelect + vWhere+vOrder;
            sqlQuery.CommandText(cmd);
            var result = sqlQuery.SelectMany<InqCountModel>();
            if (result.IsError)
            {
                ExceptionlessClient.Default.CreateLog("Inqcount Error")
                    .AddObject(result)
                    .Submit();
                MbcMessageBox.Error("Query error, failed to get results.");
                return;
            }
            var vRecords = (List<InqCountModel>)result.Data;
            ReportBindingSource.DataSource = vRecords;
            if (!chkOutPut.Checked)
            {
                this.reportViewer1.RefreshReport();
            }
            else{
                //https://www.codingame.com/playgrounds/5197/writing-csv-files-using-c

                saveFileDialog1.Filter = "Comma Seperated Value|*.csv";
               saveFileDialog1.ShowDialog();
                //using (var mem = new MemoryStream())
                using (var writer = new StreamWriter(saveFileDialog1.FileName))
                using (var csvWriter = new CsvWriter(writer))
                {
                    csvWriter.Configuration.Delimiter = ",";
                    //csvWriter.Configuration.HasHeaderRecord = true;
                   // csvWriter.Configuration.AutoMap<InqCountModel>();

                    //csvWriter.WriteHeader<InqCountModel>();
                    csvWriter.WriteRecords(vRecords);

                    writer.Flush();
                  
                  
                }
            }

        }
        private void GenerateMeridianReport()
        {

        }

        private void reportViewer1_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
            try { reportViewer1.PrintDialog(); } catch (Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Excel|*.xls";
            var a= saveFileDialog1.ShowDialog();
         
        }
    }
}
