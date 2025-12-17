using BaseClass;
using BaseClass.Classes;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
namespace Mbc5.Dialogs
{
    public partial class frmPrintBatches : Form
    {
        public frmPrintBatches(string _company)
        {
            InitializeComponent();
            Company = _company;
            //MXB Mixbook
            //JPX JPIX
            Log = LogManager.GetLogger(GetType().FullName);
        }
        protected Logger Log { get; set; }
        private BindingList<PrintBatch> Data { get; set; }
        private string Company { get; set; }
        private void frmPrintBatches_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            string cmd = "";
            switch (Company)
            {
                case "MXB":
                    cmd = @"Select Top(10) Cast(JobPrintBatch As varchar)As JobPrintBatch,max(JobPrintDate) As JobPrintDate ,count(JobPrintBatch) as NumberTickets From MixBookOrder
                                                            Where JobTicketPrinted=1
                                                            Group By JobPrintBatch order by Max(JobPrintDate) desc";
                    break;
                case "JPX":
                    cmd = @"Select Top(10) RequestId AS JobPrintBatch,max(DateReceived) As JobPrintDate, count(RequestId) as NumberTickets From JPIXOrders
                                                            Where PTicketPrinted = 1
                                                            Group By RequestId order by Max(DateReceived) desc";
                    break;
                default:
                    MbcMessageBox.Error("Company not supported for resetting print jobs.");
                    return;

            }

            var sqlClient = new SQLCustomClient().CommandText(cmd);
            var jobResult = sqlClient.SelectMany<PrintBatch>();
            if (jobResult.IsError)
            {
                Log.Error("Failed to get JobPrintBatch for resetting print jobs:" + jobResult.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Failed to get JobPrintBatch for resetting print jobs.");
                return;
            }
            var vlist = (List<PrintBatch>)jobResult.Data;
            if (vlist == null)
            {
                MbcMessageBox.Information("There are no batch numbers available to reset.");
                return;
            }

            var Data = new BindingList<PrintBatch>(vlist);
            bindingSource1.DataSource = Data;
            dataGridView1.DataSource = bindingSource1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtBatch.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                Log.Error("Failed to get batch number:" + ex.Message);
                MbcMessageBox.Error("Failed to get batch number");
                return;
            }
        }

        private void txtBatch_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtBatch, "");

            if (string.IsNullOrEmpty(txtBatch.Text))
            {


                errorProvider1.SetError(txtBatch, "Batch number can not be blank.");
                e.Cancel = true;
            }
            int vbatch = 0;
            if (Company == "MBX")
            {
                if (!int.TryParse(txtBatch.Text, out vbatch))
                {
                    errorProvider1.SetError(txtBatch, "Batch number must be all numeric.");
                    e.Cancel = true;
                }
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            switch (Company)
            {
                case "MXB":
                    ResetMixBook();
                    break;
                case "JPX":
                    ResetJpix();
                    break;

            }


        }
        protected void ResetMixBook()
        {
            int vbatch = 0;
            if (int.TryParse(txtBatch.Text, out vbatch))
            {
                var sqlClient = new SQLCustomClient();
                sqlClient.CommandText(@"Update MixbookOrder Set JobTicketPrinted=0,BookStatus=NULL where JobPrintBatch=@JobPrintBatch ");
                sqlClient.AddParameter("@JobPrintBatch", txtBatch.Text);
                var result = sqlClient.Update();
                if (result.IsError)
                {
                    Log.Error("Failed to update JobTicketPrinted:" + result.Errors[0].DeveloperMessage);
                    MbcMessageBox.Error("Failed to update JobTicketPrinted");
                    return;
                }
            }
            else
            {
                MbcMessageBox.Hand("Batch number must be all numeric.", "Invalid Batch Number");
                return;
            }
            this.Close();
        }
        protected void ResetJpix()
        {
            string vbatch = "";

            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Update JPIXOrders Set PticketPrinted=0,OrderStatus=NULL where RequestId=@JobPrintBatch ");
            sqlClient.AddParameter("@JobPrintBatch", txtBatch.Text);
            var result = sqlClient.Update();
            if (result.IsError)
            {
                Log.Error("Failed to update JobTicketPrinted:" + result.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Failed to update JobTicketPrinted");
                return;
            }


            this.Close();
        }
    }

    public class PrintBatch
    {
        public string JobPrintBatch { get; set; }
        public DateTime JobPrintDate { get; set; }
        public int NumberTickets { get; set; }
    }

}
