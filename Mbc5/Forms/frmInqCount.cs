using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using BaseClass.Core;
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
            if (chkOutPut.Checked)
            {
                saveFileDialog1.Filter = "Comma Seperated Value|*.csv";
                saveFileDialog1.ShowDialog();
            }
                if (Company == "MBC")
            {
                ;
                reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MbcInqReport.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsInq", ReportBindingSource));
                
                basePanel.Visible = true;
                backgroundWorker1.RunWorkerAsync("MBC");
             
            }
            else if (Company == "MER")
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MerInqReport.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsInq", ReportBindingSource));
                basePanel.Visible = true;
                backgroundWorker1.RunWorkerAsync("MER");
              
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
        private ApiProcessingResult GenerateMBCReport()
        {
            var processingResult = new ApiProcessingResult();
            var sqlQuery = new SQLCustomClient();
            sqlQuery.AddParameter("@InqBegin", inqStartDate.Value);
            sqlQuery.AddParameter("@InqEnd", inqEndDate.Value);
            sqlQuery.AddParameter("@ContBegin", contStartDate.Value);
            sqlQuery.AddParameter("@ContEnd", contEndDate.Value);
            sqlQuery.AddParameter("@NotYear", contEndDate.Value);
            sqlQuery.AddParameter("@Contryear", txtContryear.Text.Trim());
            string vSelect = @"Select C.SCHSTATE
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
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Query error, failed to get results.", "Query error, failed to get results.",""));     
                return processingResult; 
            }
            var vRecords = (List<InqCountModel>)result.Data;
            ReportBindingSource.DataSource = vRecords;
            if (!chkOutPut.Checked)
            {
                if (vRecords.Count>1000)
                {

                    var errMsg = "There are " + vRecords.Count.ToString() + " records. This will take an extremely long time to generate a report. Please output data to an excel file.";
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError(errMsg, errMsg, "INFO"));
                    return processingResult;

                }
                
            }
            else{
                //https://www.codingame.com/playgrounds/5197/writing-csv-files-using-c

                
                try
                {
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
                }catch(Exception ex)
                {
                    ex.ToExceptionless()
                        .AddObject(saveFileDialog1)
                        .AddObject(ex)
                        .Submit();
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError(ex.Message, ex.Message, ""));
                    return processingResult;
                }
            }
            return processingResult;
        }
        private ApiProcessingResult GenerateMeridianReport()
        {
            var processingResult = new ApiProcessingResult();
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
            ,B.FplnTot 
            ,D.INITIAL
            ,CONVERT(varchar(50),CONVERT(date,D.DATECONT))AS DATECONT
            ,D.REASON
            ,MC.Description AS Category
            FROM MCust C
            LEFT JOIN CSNames CS ON C.CSREP= CS.Source 
            LEFT JOIN MeridianCategory MC ON C.Category=MC.Val
            LEFT JOIN (SELECT BB.ID, BB.schcode, BB.QTEDATE,BB.FplnTot FROM MBIDS BB Where BB.id 
            In (SELECT MAX(MBIDS.ID)AS ID From MBids Where MBids.schcode=BB.schcode )) B On C.schcode = B.schcode
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
            string cmd = vSelect + vWhere + vOrder;
            sqlQuery.CommandText(cmd);
            var result = sqlQuery.SelectMany<MInqCountModel>();
            if (result.IsError)
            {
                ExceptionlessClient.Default.CreateLog("Inqcount Error")
                    .AddObject(result)
                    .Submit();
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Query error, failed to get results.", "Query error, failed to get results.", ""));
                return processingResult;
            }
            var vRecords = (List<MInqCountModel>)result.Data;
            ReportBindingSource.DataSource = vRecords;
            if (!chkOutPut.Checked)
            {
                if (vRecords.Count > 1000)
                {

                    var errMsg = "There are " + vRecords.Count.ToString() + " records. This will take an extremely long time to generate a report. Please output data to an excel file.";
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError(errMsg, errMsg, "INFO"));
                    return processingResult;

                }

            }
            else
            {
                //https://www.codingame.com/playgrounds/5197/writing-csv-files-using-c


                try
                {
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
                catch (Exception ex)
                {
                    ex.ToExceptionless()
                        .AddObject(saveFileDialog1)
                        .AddObject(ex)
                        .Submit();
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError(ex.Message, ex.Message, ""));
                    return processingResult;
                }
            }
            return processingResult;
        }

        private void reportViewer1_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
            try { reportViewer1.PrintDialog(); } catch (Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
        }

        

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string Arg = e.Argument.ToString();
            if (Arg == "MBC") {
                var result = GenerateMBCReport();
                e.Result = result;
            }
            if (Arg == "MER")
            {
               var result= GenerateMeridianReport();
                e.Result = result;
            }
            System.Threading.Thread.Sleep(2000);
           
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.basePanel.Visible = false;
            ApiProcessingResult result = (ApiProcessingResult)e.Result;
            if (result.IsError  )
            {
               if( result.Errors[0].ErrorCode == "INFO")
                {
                    MbcMessageBox.Information(result.Errors[0].ErrorMessage);
                }
                else
                {
                    MbcMessageBox.Error(result.Errors[0].ErrorMessage);
                }

            }
            else
            {
                if (!chkOutPut.Checked)
                {
                    this.reportViewer1.RefreshReport();
                }

            }
        }
    }
}
