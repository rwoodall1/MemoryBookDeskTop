using System;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using BaseClass.Classes;
using System.Data.Sql;
using System.Data.SqlClient;
using Mbc5.Classes;
using Mbc5.LookUpForms;
using BindingModels;
using Exceptionless;
using Exceptionless.Models;
using Outlook= Microsoft.Office.Interop.Outlook;
using System.IO;
using System.Reflection;
using BaseClass;
using BaseClass.Core;
using Mbc5.Dialogs;


namespace Mbc5.Forms.MemoryBook
{
    public partial class frmSales : BaseClass.frmBase, INotifyPropertyChanged
    {

        private bool startup = true;
        private string SchoolZipCode { get; set; }

        public frmSales(UserPrincipal userPrincipal, int invno, string schcode) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal)
        {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Invno = invno;
            this.Schcode = schcode;

        }
        public frmSales(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal)
        {
            InitializeComponent();
            this.DisableControls(this);
           
            EnableControls(btnPoSrch);
            EnableControls(txtPoSrch);
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ApplicationUser = userPrincipal;
            this.Invno = 0;
            this.Schcode = null;

        }
        public frmMain frmMain { get; set; }
        private void SetConnectionString()
        {
            this.frmMain = (frmMain)this.MdiParent;
            this.FormConnectionString = frmMain.AppConnectionString;
            this.custTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.quotesTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.paymntTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.invdetailTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.invCustTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.invHstTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.invoiceTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.xtraTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;

        }
        private void frmSales_Load(object sender, EventArgs e)
        {
            pg1.AutoScroll = false;

            this.SetConnectionString();
            lblPCEach.DataBindings.Add("Text", this, "PrcEa", false, DataSourceUpdateMode.OnPropertyChanged);//bind 
            lblPCTotal.DataBindings.Add("Text", this, "PrcTot", false, DataSourceUpdateMode.OnPropertyChanged);//bind
            Fill();
            if (ApplicationUser.Roles.Contains("SA") || ApplicationUser.Roles.Contains("Administrator"))
            {
                this.dp1descComboBox.ContextMenuStrip = this.mnuEditLkUp;
            }

            CalculateEach();
            BookCalc();
            txtBYear.Focus();
            startup = false;

        }

        private void btnPoSrch_Click(object sender, EventArgs e)
        {
            if (txtPoSrch.Text.Length<1)
            {
                MbcMessageBox.Information("Enter data to search on.", "");
                return;
            }
            var sqlQuery = new SQLQuery();
            string querystring = "Select schcode,invno from Quotes where PoNum=@PoNum";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@PoNum",txtPoSrch.Text.Trim())
            };
            DataTable result = sqlQuery.ExecuteReaderAsync(CommandType.Text, querystring, parameters);
            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    //only one row so just set variabls
                    this.Invno = Convert.ToInt32(row["invno"]);
                    this.Schcode = row["schcode"].ToString();
                    this.Fill();
                    DataRowView current = (DataRowView)quotesBindingSource.Current;
                    this.Invno = current["Invno"] == DBNull.Value ? 0 : (int)current["Invno"];

                    EnableAllControls(this);
                }
            }
            else
            {
                MessageBox.Show("No records were found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            frmSales_Paint(this, null);
        }

        #region "Properties"
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private Decimal nPrcTot = 0;
        private Decimal nPrcEach = 0;
        private UserPrincipal ApplicationUser { get; set; }
        public Decimal PrcTot
        {
            get { return nPrcTot; }
            set
            {
                nPrcTot = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("PrcTot"));
            }
        }
        public Decimal PrcEa
        {
            get { return nPrcEach; }
            set
            {
                nPrcEach = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("PrcEach"));
            }
        }
        public Decimal SalesTax { get; set; } = 0;
        public Decimal TaxRate { get; set; } = 0;
        public List<Price> Pricing { get; set; }
        public BookOptionPrice BookOptionPricing { get; set; }
        public List<XtraInvoiceGrid> XrtaInvoicesGridData { get; set; }
        public XtraInvoicePrint XrtaInvoicePrint { get; set; }
        public List<XtraInvoiceDetailPrint> XrtaInvoiceDetailsPrint { get; set; }
        public string CurPriceYr { get; set; } = null;
        private bool StartUp { get; set; }
        #endregion
        #region "Methods"
        private void SetNoticeLabels()
        {
            try
            {
                DataRowView dr = (DataRowView)quotesBindingSource.Current;
                bool vHoldPayment = dr.Row.IsNull("holdpmt") ? false : (bool)dr.Row["holdpmt"];
                lblIncollections.Visible = vHoldPayment;
                bool vshpdate = dr.Row.IsNull("shpdate");
                lblShipped.Visible = !vshpdate;
            }catch(Exception ex)
            {

            }

        }
        private void ReminderEmails(string type)
        {
            if (type == "Half")
            {
                    var schname = ((DataRowView)custBindingSource.Current).Row["schname"].ToString().Trim();
                    var vKitRecvDate1 = (DateTime)((DataRowView)quotesBindingSource.Current).Row["kitrecvd"];
                    var vKitRecvDate = vKitRecvDate1.ToString("d");
                    string vPin = ((DataRowView)custBindingSource.Current).Row["PIN"].ToString().Trim();
                    var vPdfGenerator = new PdfAttachementGenerator();
                    var result = vPdfGenerator.GenerateAttachement(this.reportViewer1, schname + " INVOICE.pdf");
                    if (result.IsError)
                    {
                        MbcMessageBox.Error(result.Errors[0].ErrorMessage, "");
                        return;
                    }
                    var newPath = result.Data;
                    var emailHelper = new EmailHelper();
                    string sub = "Memory Book Payment Reminder";
                    string body = @"Your book was submitted on " + vKitRecvDate + @". Just a reminder a payment for your order is due within 10 business days of your book submission date.
                    If you are not paying in full a half payment or a Purchase Order for the entire amount will need to be submitted. I have attached an invoice.<br/><br/>
                    You may pay by credit card  <a href=https://pay.memorybook.com>Memorybook</a> or submit a check. If you are paying online you need:</br> 
                    Account Code:<b>" + Schcode + "</b> School PIN:<b>" + vPin + "</b><br/><br/><br/>Please contact your representative if you have any questions. Thank you!";
                    List<OutlookAttachemt> Attachements = new List<OutlookAttachemt>();
                    OutlookAttachemt Attachement = new OutlookAttachemt() { Name = Schcode + "Flyer.pdf", Path = newPath };
                    Attachements.Add(Attachement);
                    string Address = ((DataRowView)custBindingSource.Current).Row["contemail"].ToString().Trim();
                    emailHelper.SendOutLookEmail(sub, Address, null, body, EmailType.Mbc, Attachements);
            }
            else if (type == "NoPaymentRec5")
            {
                var schname = ((DataRowView)custBindingSource.Current).Row["schname"].ToString().Trim();
                var vKitRecvDate1 = (DateTime)((DataRowView)quotesBindingSource.Current).Row["kitrecvd"];
                var vKitRecvDate = vKitRecvDate1.ToString("d");
                string vPin = ((DataRowView)custBindingSource.Current).Row["PIN"].ToString().Trim();
                var vPdfGenerator = new PdfAttachementGenerator();
                var result = vPdfGenerator.GenerateAttachement(this.reportViewer1, schname + " INVOICE.pdf");
                if (result.IsError)
                {
                    MbcMessageBox.Error(result.Errors[0].ErrorMessage, "");
                    return;
                }
                var newPath = result.Data;
                var emailHelper = new EmailHelper();
                string sub = "Memory Book Payment Reminder";
                string body = @"Your book was submitted on " + vKitRecvDate + @" and your account received the 5% payment in full discount. Just a reminder the 5% full payment discount is forfeited when a full payment is not received within 10 business days of book submission.
                I have attached an invoice.<br/><br/>
                You may pay by credit card  <a href=https://pay.memorybook.com>Memorybook</a> or submit a check. If you are paying online you need:</br> 
                Account Code:<b>" + Schcode + "</b> School PIN:<b>" + vPin + "</b><br/><br/><br/>Please contact your representative if you have any questions. Thank you!";
                List<OutlookAttachemt> Attachements = new List<OutlookAttachemt>();
                OutlookAttachemt Attachement = new OutlookAttachemt() { Name = Schcode + "Flyer.pdf", Path = newPath };
                Attachements.Add(Attachement);
                string Address = ((DataRowView)custBindingSource.Current).Row["contemail"].ToString().Trim();
                emailHelper.SendOutLookEmail(sub, Address, null, body, EmailType.Mbc, Attachements);

            }
            else if (type == "Removing5")
            {
                var schname = ((DataRowView)custBindingSource.Current).Row["schname"].ToString().Trim();
                var vKitRecvDate1 = (DateTime)((DataRowView)quotesBindingSource.Current).Row["kitrecvd"];
                var vKitRecvDate = vKitRecvDate1.ToString("d");
                string vPin = ((DataRowView)custBindingSource.Current).Row["PIN"].ToString().Trim();
                var vPdfGenerator = new PdfAttachementGenerator();
                var result = vPdfGenerator.GenerateAttachement(this.reportViewer1, schname + " INVOICE.pdf");
                if (result.IsError)
                {
                    MbcMessageBox.Error(result.Errors[0].ErrorMessage, "");
                    return;
                }
                var newPath = result.Data;
                var emailHelper = new EmailHelper();
                string sub = "Memory Book Payment Reminder";
                string body = @"Your book was submitted on " + vKitRecvDate + @" and your account received the 5% payment in full discount. The 5% full payment discount is forfeited when a full payment is not received within 10 business days of book submission. <br/>
                Unfortunately, payment was not received.  A revised invoice is attached.
                You may pay by credit card  via <a href=https://pay.memorybook.com>Memorybook</a> or submit a check. If you are paying online you need:</br> 
                Account Code:<b>" + Schcode + "</b> School PIN:<b>" + vPin + "</b><br/><br/><br/>Please contact your representative if you have any questions. Thank you!";
                List<OutlookAttachemt> Attachements = new List<OutlookAttachemt>();
                OutlookAttachemt Attachement = new OutlookAttachemt() { Name = Schcode + "Flyer.pdf", Path = newPath };
                Attachements.Add(Attachement);
                string Address = ((DataRowView)custBindingSource.Current).Row["contemail"].ToString().Trim();
                emailHelper.SendOutLookEmail(sub, Address, null, body, EmailType.Mbc, Attachements);
            }

        }
        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }
            con.Enabled = false;
        }
        private void EnableControls(Control con)
        {
            if (con != null)
            {
                con.Enabled = true;
                EnableControls(con.Parent);
            }
        }
        private void EnableAllControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                EnableAllControls(c);
            }
            con.Enabled = true;
        }
        //Payment Tab
        private void SetCrudButtons()
        {
            btnSavePayment.Enabled = paymntBindingSource.Count > 0;
            btnDelete.Enabled = paymntBindingSource.Count > 0;
            btnEdit.Enabled = paymntBindingSource.Count > 0;
            if (paymntBindingSource.Count < 1)
            {
                txtPaypoamt.Enabled = false;
                txtInitials.Enabled = false;
                calpmtdate.Enabled = false;
                txtCheckNo.Enabled = false;
                txtMethod.Enabled = false;
                txtPayment.Enabled = false;
                txtRefund.Enabled = false;
                txtAdjustment.Enabled = false;
                txtCompensation.Enabled = false;
                txtCompReason.Enabled = false;
            }
        }
        private void NewPayment()
        {
            txtPaypoamt.Enabled = true;
            txtInitials.Enabled = true;
            calpmtdate.Enabled = true;
            txtCheckNo.Enabled = true;
            txtMethod.Enabled = true;
            txtPayment.Enabled = true;
            txtRefund.Enabled = true;
            txtAdjustment.Enabled = true;
            txtCompensation.Enabled = true;
            txtCompReason.Enabled = true;
            paymntBindingSource.AddNew();

            DataRowView current = (DataRowView)paymntBindingSource.Current;
            current["Invno"] = lblInvoice.Text;
            current["Code"] = this.Schcode;
            SetCrudButtons();
        }
        private ApiProcessingResult<bool> SavePayment()
        {
            var processingResult = new ApiProcessingResult<bool>();
            if (paymntBindingSource.Count > 0)
            {
                if (this.ValidatePayment())
                {

                    try
                    {
                        this.paymntBindingSource.EndEdit();
                        this.paymntTableAdapter.Update(dsInvoice.paymnt);
                        this.paymntTableAdapter.Fill(dsInvoice.paymnt, Convert.ToInt32(lblInvoice.Text));
                        this.CalculatePayments();
                        txtPaypoamt.Enabled = false;
                        txtInitials.Enabled = false;
                        calpmtdate.Enabled = false;
                        txtCheckNo.Enabled = false;
                        txtMethod.Enabled = false;
                        txtPayment.Enabled = false;
                        txtRefund.Enabled = false;
                        txtAdjustment.Enabled = false;
                        txtCompensation.Enabled = false;
                        txtCompReason.Enabled = false;

                    }
                    catch (DBConcurrencyException ex1)
                    {
                        MbcMessageBox.Hand("Another user has updated this record, your copy is not current. Your data is being reverted, Please re-enter your data.", "Concurrency Error");
                        this.Fill();
                        string errmsg = "Concurrency violation" + Environment.NewLine + ex1.Row.ItemArray[0].ToString();

                        processingResult.IsError = true;
                        processingResult.Errors.Add(new ApiProcessingError(errmsg, errmsg, ""));

                    }
                    catch (Exception ex)
                    {
                        processingResult.IsError = true;
                        processingResult.Errors.Add(new ApiProcessingError("Payment failed to update:" + ex.Message, "Payment failed to update:" + ex.Message, ""));

                    }
                }
                else
                {
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError("Payment failed to validate.", "Payment failed to validate.", ""));
                }
            }
            return processingResult;
        }
        private bool DeletePayment()
        {
            bool retval = true;
            DialogResult messageResult = MessageBox.Show("This will delete the current line item payment. Do you want to proceed?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (messageResult == DialogResult.Yes)
            {
                DataRowView current = (DataRowView)paymntBindingSource.Current;
                var Id = current["Id"];

                var sqlQuery = new SQLQuery();
                var queryString = "Delete  From  paymnt where Id=@Id ";
                SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Id",Id)
            };
                var result = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, queryString, parameters);
                CalculatePayments();
                this.paymntTableAdapter.Fill(dsInvoice.paymnt, Convert.ToInt32(lblInvoice.Text));

                if (result == 0) { retval = false; }
                SetCrudButtons();
            }
            return retval;

        }
        private void CancelPayment()
        {
            paymntBindingSource.CancelEdit();
            txtPaypoamt.Enabled = false;
            txtInitials.Enabled = false;
            calpmtdate.Enabled = false;
            txtCheckNo.Enabled = false;
            txtMethod.Enabled = false;
            txtPayment.Enabled = false;
            txtRefund.Enabled = false;
            txtAdjustment.Enabled = false;
            txtCompensation.Enabled = false;
            txtCompReason.Enabled = false;
            errorProvider1.Clear();
        }
        private void EditPayment()
        {
            txtPaypoamt.Enabled = true;
            txtInitials.Enabled = true;
            calpmtdate.Enabled = true;
            txtCheckNo.Enabled = true;
            txtMethod.Enabled = true;
            txtPayment.Enabled = true;
            txtRefund.Enabled = true;
            txtAdjustment.Enabled = true;
            txtCompensation.Enabled = true;
            txtCompReason.Enabled = true;

        }
        private bool CalculatePayments()
        {
           return CalculatePayments(lblInvoice.Text);
        }
       private bool CalculatePayments(string invoiceNumber)
        {
            bool retval = false;
            decimal? paymentTotals = 0;
            if (string.IsNullOrEmpty(invoiceNumber))
            {
                return retval;
            }
            var SqlQuery = new SQLQuery();
            var cmdText = @"SELECT ISNULL(SUM(ISNULL(payment, 0) + ISNULL(refund, 0) + ISNULL(adjmnt, 0)),0) AS paymentresult
                         FROM paymnt where Invno=@Invno";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Invno",invoiceNumber) };
            var result = SqlQuery.ExecuteReaderAsync(CommandType.Text, cmdText, parameters);
            //paymentTotals =(decimal)this.paymntTableAdapter.SumPayment(Convert.ToInt32(lblInvoice.Text));
            try
            {

                paymentTotals = (decimal)result.Rows[0]["paymentresult"];
                cmdText = @"Update invoice set payments=@payments,baldue=invtot-@payments  where Invno=@Invno ";
                SqlParameter[] parameters1 = new SqlParameter[] {
                new SqlParameter("@Invno",invoiceNumber),
                new SqlParameter("@payments",paymentTotals)};
                var a = SqlQuery.ExecuteNonQueryAsync(CommandType.Text, cmdText, parameters1);
                this.invoiceTableAdapter.Fill(dsInvoice.invoice, Convert.ToInt32(lblInvoice.Text));
                retval = true;
            }
            catch (Exception ex)
            {

            }
            return retval;
        }
        //Invoice
        private bool DeleteInvoice()
        {
            bool retval = true;
            DialogResult messageResult = MessageBox.Show("This will delete the current invoice. Any payments related to this invoice will remain. Do you want to proceed?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (messageResult == DialogResult.Yes)
            {
                var sqlQuery = new SQLQuery();
                var queryString = "Delete  From Invoice where Invno=@Invno ";
                SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Invno",lblInvoice.Text)
            };
                var result = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, queryString, parameters);
                queryString = "Delete  From InvDetail where Invno=@Invno ";
                SqlParameter[] parameters1 = new SqlParameter[] {
                new SqlParameter("@Invno",lblInvoice.Text)
            };
                try
                {
                    //use same parameter
                    var result1 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, queryString, parameters1);
                    if (result1 == 0 || result == 0) { retval = false; }

                    this.invoiceTableAdapter.Fill(dsInvoice.invoice, Convert.ToInt32(lblInvoice.Text));
                    this.invdetailTableAdapter.Fill(dsInvoice.invdetail, Convert.ToInt32(lblInvoice.Text));
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "");
                }

                this.Fill();
            }
            return retval;
        }
        private bool CreateInvoice()
        {
            bool retval = true;
            var connection = new SqlConnection(this.FormConnectionString);
            string cmdText = "";
            var command = new SqlCommand(cmdText, connection);

            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@invno", lblInvoice.Text);
            try
            {
                connection.Open();
                var trans = connection.BeginTransaction();
                command.Transaction = trans;
                //command.Parameters.AddWithValue("@invno",lblInvoice.Text);
                cmdText = "Update Quotes set invoiced=1 where invno=@invno";
                command.CommandText = cmdText;
                command.ExecuteNonQuery();
                cmdText = @"Insert into Invoice (Invno,schcode,qtedate,nopages,nocopies,book_ea,source,contfname,contlname
                            ,ponum,invtot,baldue,contryear,allclrck,freebooks,SalesTax,BeforeTaxTotal,Schname,schaddr,schaddr2
                            ,schcity,schstate,schzip,DateCreated,DateModified,ModifiedBy) VALUES(@invno,@schcode,@qtedate,@nopages
                            ,@nocopies,@book_each,@source,@contfname,@contlname,@ponum,@invtot,@baldue,@contryear,@allclrck,@freebooks
                            ,@SalesTax,@BeforeTaxTotal,@Schname,@InvoiceAddr,@InvoiceAddr2,@InvoiceCity,@InvoiceState,@InvoiceZipCode,GETDATE(),GETDATE(),@ModifiedBy)";
                

                command.CommandText = cmdText;
                command.Parameters.Clear();
                decimal vtax = 0;
                decimal.TryParse(lblSalesTax.Text.Replace("$", "").Replace(",", ""), out vtax);
                decimal vtotal = 0;
                decimal.TryParse(lblFinalTotPrc.Text.Replace("$", "").Replace(",", ""), out vtotal);
                decimal vBeforeTaxTotal = vtotal - vtax;
                var aa = lblPriceEach.Text.Replace("$", "");
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@invno",lblInvoice.Text),
                    new SqlParameter("@schcode",this.Schcode ),
                    new SqlParameter("@qtedate",dteQuote.Value ),
                    new SqlParameter("@nopages",txtNoPages.Text ),
                    new SqlParameter("@nocopies",txtNocopies.Text ),
                    new SqlParameter("@book_each",lblPriceEach.Text.Replace("$","").Replace(",","")),
                    new SqlParameter("@source",txtSource.Text.Trim() ),
                    new SqlParameter("@ponum",txtPoNum.Text.Trim()),
                    new SqlParameter("@contfname",((DataRowView)custBindingSource.Current).Row.IsNull("contfname")?"":((DataRowView)custBindingSource.Current).Row["contfname"].ToString().Trim()),
                    new SqlParameter("@contlname",((DataRowView)custBindingSource.Current).Row.IsNull("contlname")?"":((DataRowView)custBindingSource.Current).Row["contlname"].ToString().Trim()),
                    new SqlParameter("@SalesTax",lblSalesTax.Text.Replace("$","").Replace(",","")),
                    new SqlParameter("@BeforeTaxTotal",vBeforeTaxTotal),
                    new SqlParameter("@invtot",lbladjbef.Text.Replace("$","").Replace(",","") ),
                    new SqlParameter("@baldue",lbladjbef.Text.Replace("$","").Replace(",","") ),
                    new SqlParameter("@contryear",txtYear.Text),
                    new SqlParameter("@allclrck",chkAllClr.Checked),
                    new SqlParameter("@freebooks",txtfreebooks.Text ),
                    new SqlParameter("@ModifiedBy",txtModifiedByInv.Text),
                    new SqlParameter("@Schname",((DataRowView)this.custBindingSource.Current).Row["schname"].ToString().Trim()),
                    new SqlParameter("@InvoiceAddr",((DataRowView)custBindingSource.Current).Row.IsNull("InvoiceAddr")?"": ((DataRowView)this.custBindingSource.Current).Row["InvoiceAddr"].ToString().Trim() ),
                    new SqlParameter("@InvoiceAddr2",((DataRowView)custBindingSource.Current).Row.IsNull("InvoiceAddr2")?"":((DataRowView)this.custBindingSource.Current).Row["InvoiceAddr2"].ToString().Trim()),
                    new SqlParameter("@InvoiceCity",((DataRowView)custBindingSource.Current).Row.IsNull("InvoiceCity")?"":((DataRowView)this.custBindingSource.Current).Row["InvoiceCity"].ToString().Trim()),
                    new SqlParameter("@InvoiceState",((DataRowView)custBindingSource.Current).Row.IsNull("InvoiceState")?"":((DataRowView)this.custBindingSource.Current).Row["InvoiceState"].ToString().Trim() ),
                    new SqlParameter("@InvoiceZipCode",((DataRowView)custBindingSource.Current).Row.IsNull("InvoiceZipCode")?"":((DataRowView)this.custBindingSource.Current).Row["InvoiceZipCode"].ToString().Trim().Substring(0,5))
              };
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                cmdText = "Insert Into Invdetail (descr,price,discpercent,invno,schcode,DateCreated,DateModified,ModifiedBy) Values(@descr,@price,@discpercent,@invno,@schcode,GETDATE(),GETDATE(),@ModifiedBy)";
                var Details = GetDetailRecords(lblInvoice.Text);
                command.CommandText = cmdText;
                if (Details.Count > 0)
                {
                    foreach (var row in Details)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@descr", row.descr.Trim());
                        command.Parameters.AddWithValue("@price", row.price);
                        command.Parameters.AddWithValue("@discpercent", row.discpercent);
                        command.Parameters.AddWithValue("@invno", row.invno);
                        command.Parameters.AddWithValue("@schcode", row.schoolcode);
                        command.Parameters.AddWithValue("@ModifiedBy", txtModifiedByInvdetail.Text);
                        try
                        {
                            command.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            ex.ToExceptionless()
                                .AddTags("CreateInvoice")
                                .AddObject(command)
                                .MarkAsCritical()
                                .Submit();
                            command.Transaction.Rollback();
                            MessageBox.Show("There was an error creating the invoice.", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            retval = false;
                            return retval;


                        }

                    }
                    command.Transaction.Commit();
                    MessageBox.Show("Invoice has been created.", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //no detail records so just commit header.
                    command.Transaction.Commit();
                    MessageBox.Show("Invoice has been created.", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CalculatePayments();

            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                                .AddTags("CreateInvoice")
                                .AddObject(command)
                                .MarkAsCritical()
                                .Submit();
                command.Transaction.Rollback();
                MessageBox.Show("There was an error creating the invoice.", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                retval = false;

            }
            finally { connection.Close(); }
            return retval;
        }
        private List<InvoiceDetailBindingModel> GetDetailRecords(string invno)
        {
            int vinvno = 0;
            decimal per;
            if (!int.TryParse(lblInvoice.Text, out vinvno))
            {
                MessageBox.Show("Could not create invoice because invoice number is not available.");
                return null;
            }

            var Details = new List<InvoiceDetailBindingModel>();
            if (true)
            {
                //add base alway true
                string baseDescrip;
                if (chkAllClr.Checked)
                {
                    baseDescrip = " All color book with " + txtNoPages.Text + " Pages and " + txtNocopies.Text + " Copies";
                }
                else
                {
                    baseDescrip = "Black and White book with " + txtNoPages.Text + " Pages and " + txtNocopies.Text + " Copies";
                }
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = baseDescrip,
                    discpercent = "",
                    price = Convert.ToDecimal(lblBookTotal.Text.Replace("$", "")),
                    schoolcode = this.Schcode
                };
                Details.Add(rec);

            }



            if (chkHardBack.Checked)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "Hard Back (sewn)",
                    discpercent = "",
                    price = Convert.ToDecimal(lblHardbackAmt.Text),
                    schoolcode = this.Schcode
                };
                Details.Add(rec);

            }

            if (chkCaseBind.Checked)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "Case Binding (glued)",
                    discpercent = "",
                    price = Convert.ToDecimal(lblCaseamt.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if (chkPerfBind.Checked)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "Perfect Bind",
                    discpercent = "",
                    price = Convert.ToDecimal(lblPerfbindAmt.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if (chkSpiral.Checked)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "Spiral Bind",
                    discpercent = "",
                    price = Convert.ToDecimal(lblSpiralAmt.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if (chkSaddlStitch.Checked)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "Soft Cover Stapled",
                    discpercent = "",
                    price = Convert.ToDecimal(lblSaddleAmt.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if (chkProfessional.Checked)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "Professional",
                    discpercent = "",
                    price = Convert.ToDecimal(lblProfAmt.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if (chkConv.Checked)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "Convenient",
                    discpercent = "",
                    price = Convert.ToDecimal(lblConvAmt.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if (chkYir.Checked)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "Flashbax",
                    discpercent = "",
                    price = Convert.ToDecimal(lblYir.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if (chkStory.Checked)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "Our Story",
                    discpercent = "",
                    price = Convert.ToDecimal(lblStoryAmount.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }

            if (chkMLaminate.Checked)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "Matte Laminate",
                    discpercent = "",
                    price = Convert.ToDecimal(lblMLaminateAmt.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if (chkGlossLam.Checked)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "Gloss Laminate",
                    discpercent = "",
                    price = Convert.ToDecimal(lblLaminateAmt.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if ((String.IsNullOrEmpty(lblSpeccvrtot.Text) ? 0 : Convert.ToDecimal(lblSpeccvrtot.Text)) > 0)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "Special Cover",
                    discpercent = "",
                    price = Convert.ToDecimal(lblSpeccvrtot.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if ((String.IsNullOrEmpty(txtFoilAd.Text) ? 0 : Convert.ToDecimal(txtFoilAd.Text)) > 0)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "Foil (Additional)",
                    discpercent = "",
                    price = Convert.ToDecimal(txtFoilAd.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }

            if ((String.IsNullOrEmpty(txtClrTot.Text) ? 0 : Convert.ToDecimal(txtClrTot.Text)) != 0)
            {

                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = txtClrDesc.Text,
                    discpercent = "",
                    price = Convert.ToDecimal(txtClrTot.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if ((String.IsNullOrEmpty(txtMisc.Text) ? 0 : Convert.ToDecimal(txtMisc.Text)) != 0)
            {

                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = txtMdesc.Text,
                    discpercent = "",
                    price = Convert.ToDecimal(txtMisc.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if ((String.IsNullOrEmpty(txtDesc1amt.Text) ? 0 : Convert.ToDecimal(txtDesc1amt.Text)) != 0)
            {

                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = txtDesc1.Text,
                    discpercent = "",
                    price = Convert.ToDecimal(txtDesc1amt.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if ((String.IsNullOrEmpty(txtDesc3tot.Text) ? 0 : Convert.ToDecimal(txtDesc3tot.Text)) != 0)
            {

                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = txtDesc3.Text,
                    discpercent = "",
                    price = Convert.ToDecimal(txtDesc3tot.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if ((String.IsNullOrEmpty(txtDesc4tot.Text) ? 0 : Convert.ToDecimal(txtDesc4tot.Text)) != 0)
            {

                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = txtDesc4.Text,
                    discpercent = "",
                    price = Convert.ToDecimal(txtDesc4tot.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }

            if ((String.IsNullOrEmpty(lbldisc1.Text) ? 0 : Convert.ToDecimal(lbldisc1.Text)) != 0)
            {
                per = String.IsNullOrEmpty(txtDisc.Text) ? 0 : Convert.ToDecimal(txtDisc.Text);
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = dp1descComboBox.SelectedValue == null ? "" : dp1descComboBox.SelectedValue.ToString(),
                    discpercent = (per * 100).ToString() + "% Discount",
                    price = Convert.ToDecimal(lbldisc1.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if (chkDc2.Checked)
            {
                per = String.IsNullOrEmpty(txtDp2.Text) ? 0 : Convert.ToDecimal(txtDp2.Text);
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "Full pay w/page submission",
                    discpercent = (per * 100).ToString() + "% Discount",
                    price = String.IsNullOrEmpty(lbldisc2.Text) ? 0 : Convert.ToDecimal(lbldisc2.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if ((String.IsNullOrEmpty(lblDisc3.Text) ? 0 : Convert.ToDecimal(lblDisc3.Text)) > 0)
            {
                per = String.IsNullOrEmpty(dp3ComboBox.Text) ? 0 : Convert.ToDecimal(dp3ComboBox.Text);
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = txtDp3Desc.Text,
                    discpercent = (per * 100).ToString() + "% Discount",
                    price = Convert.ToDecimal(lblDisc3.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if (chkMsStandard.Checked)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "My Story With Picture Personalization",
                    discpercent = "",
                    price = String.IsNullOrEmpty(lblMsTot.Text) ? 0 : Convert.ToDecimal(lblMsTot.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if ((String.IsNullOrEmpty(lblperstotal.Text) ? 0 : Convert.ToDecimal(lblperstotal.Text)) > 0)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "Personalization",
                    discpercent = "",
                    price = Convert.ToDecimal(lblperstotal.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if ((String.IsNullOrEmpty(lblIconTot.Text) ? 0 : Convert.ToDecimal(lblIconTot.Text)) > 0)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = "Icons",
                    discpercent = "",
                    price = Convert.ToDecimal(lblIconTot.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if ((String.IsNullOrEmpty(txtCredits.Text) ? 0 : Convert.ToDecimal(txtCredits.Text)) != 0)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = cred_etcTextBox.Text,
                    discpercent = "",
                    price = Convert.ToDecimal(txtCredits.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if ((String.IsNullOrEmpty(txtCredits2.Text) ? 0 : Convert.ToDecimal(txtCredits2.Text)) != 0)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = cred_etcTextBox1.Text,
                    discpercent = "",
                    price = Convert.ToDecimal(txtCredits2.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if ((String.IsNullOrEmpty(txtOtherChrg.Text) ? 0 : Convert.ToDecimal(txtOtherChrg.Text)) > 0)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = textBox5.Text,
                    discpercent = "",
                    price = Convert.ToDecimal(txtOtherChrg.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            if ((String.IsNullOrEmpty(txtOtherChrg2.Text) ? 0 : Convert.ToDecimal(txtOtherChrg2.Text)) > 0)
            {
                var rec = new InvoiceDetailBindingModel
                {
                    invno = vinvno,
                    descr = desc22TextBox.Text,
                    discpercent = "",
                    price = Convert.ToDecimal(txtOtherChrg2.Text),
                    schoolcode = this.Schcode
                };

                Details.Add(rec);

            }
            return Details;
        }
        //Sales
        private ApiProcessingResult SaveSales()
        {
            var processingResult = new ApiProcessingResult();

            this.quotesBindingSource.EndEdit();

            if (quotesBindingSource.Count > 0)
            {
                if (ValidSales())
                {

                    try
                    {
                        this.Validate();
                        this.quotesBindingSource.EndEdit();
                        var a = quotesTableAdapter.Update(dsSales.quotes);
                        //must refill so we get updated time stamp so concurrency is not thrown
                        this.Fill();
                        UpdateProductionCopyPages();//updates production with number of copies and pages

                    }
                    catch (DBConcurrencyException ex1)
                    {
                       // MbcMessageBox.Hand("Another user has updated this record, your copy is not current. Your data is being reverted, Please re-enter your data.", "Concurrency Error");
                        this.Fill();
                        //DialogResult result = ExceptionHandler.CreateMessage((DataSets.dsSales.quotesRow)(ex1.Row), ref dsSales);
                        //if (result == DialogResult.Yes)
                        //{
                        //    Save();
                        //}
                        processingResult.IsError = true;
                        processingResult.Errors.Add(new ApiProcessingError("Another user has updated this record, your copy is not current. Your data is being reverted, Please re - enter your data.", "Another user has updated this record, your copy is not current. Your data is being reverted, Please re-enter your data.", ""));
                    }
                    catch (Exception ex)
                    {


                        processingResult.IsError = true;
                        processingResult.Errors.Add(new ApiProcessingError(ex.Message, ex.Message, ""));
                    }
                }
                else
                {
                    processingResult.IsError = true;
                    processingResult.Errors.Add(new ApiProcessingError("Sales record failed to validate.", "Sales record failed to validate.", ""));
                }
            }
            return processingResult;
        }
        private bool DeleteSale()
        {
            bool retval = true;
            DialogResult messageResult = MessageBox.Show("This will delete the current sale record. All related invoices and payments must be removed first. Do you want to proceed?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (messageResult == DialogResult.Yes)
            {
                var sqlQuery = new SQLQuery();
                var queryString = "Delete  From Quotes where Invno=@Invno ";
                SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Invno",lblInvoice.Text)
            };
                var result = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, queryString, parameters);
                if (result == 1)
                {
                    this.Invno = 0;
                    this.Fill();
                }
                else { retval = false; }
            }
            if (String.IsNullOrEmpty(lblInvoice.Text) || lblInvoice.Text == "0")
            {
                this.DisableControls(this);
               
                EnableControls(btnPoSrch);
                EnableControls(txtPoSrch);
            }
            return retval;
        }
        private void CalculateEach()
        {
            if (!donotchargeschoolsalestaxCheckBox.Checked)
            {
                //this.TaxRate = this.GetTaxRate();
            } else {
               // this.TaxRate = 0;
            }
           


            this.lblTaxRateValue.Text = this.TaxRate.ToString();
            if (String.IsNullOrEmpty(txtBYear.Text))
            {

                lblBookTotal.Text = (0 * 0).ToString("c");
                lblProftotalPrc.Text = (0 * 0).ToString("c");
                lblPriceEach.Text = (0 * 0).ToString("c");
                lblprofprice.Text = 0.ToString("c");
                return;
            }
            //Don't calculate until fill is done.
            decimal thePrice = 0;
            if (!startup)
            {
                if (quotesBindingSource.Count > 0)
                {
                    if (!ValidateCopies() || !ValidatePageCount())
                    {
                        return;
                    }
                    string vPage = "Pg" + txtNoPages.Text;
                    int copies;
                    int calcCopies;
                    var result = int.TryParse(txtNocopies.Text, out copies);
                    if (copies < 100)//min is 100 for calculating
                    {
                        calcCopies = 100;
                    }
                    else { calcCopies = copies; }
                    if (!result)
                    {
                        MessageBox.Show("Copies is not a numeral.");
                        return;
                    }

                    var lowCopies = 0;
                    if (copies > 125)
                    {
                        lowCopies = copies - 25;
                    }
                    else
                    {
                        lowCopies = 100;
                    }
                    if (copies > 1800)
                    {
                        MessageBox.Show("Copies are more than the maximum that can be calculated. Contact your supervisor, quantity is being reset at 1800.", "Copies", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtNocopies.Text = "1800";
                        lowCopies = 1800;
                        calcCopies = 1800;
                    }

                    if (this.Pricing == null || CurPriceYr != txtBYear.Text)
                    {
                        GetBookPricing();
                        if (this.Pricing == null)
                        {
                            MessageBox.Show("Pricing was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Log.Error("Pricing was not found:Year-" + txtBYear.Text);
                            return;
                        }
                    }

                    //var vPricingRow = Pricing.Where(a => a.Copies >= lowCopies && a.Copies <= copies).ToList();
                    //var aprice = vPricingRow.Select(x => x.GetType().GetProperty("Pg12").GetValue(x));

                    var vBookPrice = Pricing.Where(a => a.Copies >= lowCopies && a.Copies <= calcCopies).Select(x => x.GetType().GetProperty(vPage).GetValue(x)).ToList();
                    if (vBookPrice.Count < 1)
                    {
                        return;
                    }
                    decimal vFoundPrice = (decimal)vBookPrice[0];
                    decimal vdiscountamount = 1;
                    if (cmbYrDiscountAmt.SelectedIndex > 0)
                    {
                        decimal promAmt = 0;
                        bool proAmtResult = decimal.TryParse(cmbYrDiscountAmt.SelectedItem.ToString(), out promAmt);

                        vdiscountamount = 1 - promAmt;
                    }
                    vFoundPrice = vFoundPrice * vdiscountamount;
                    lblPriceEach.Text = vFoundPrice.ToString("c");

                    if (String.IsNullOrEmpty(txtPriceOverRide.Text) || txtPriceOverRide.Text == "0.00" || txtPriceOverRide.Text == "$0.00" || txtPriceOverRide.Text == "0")
                    {
                        try
                        {
                            string price = lblPriceEach.Text.Replace("$", "");//must strip dollar sign
                            thePrice = System.Convert.ToDecimal(price);

                            lblBookTotal.Text = (thePrice * copies).ToString("c");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Book price is not in a decimal value.");
                        }
                    }
                    else
                    {
                        try
                        {
                            string price = txtPriceOverRide.Text.Replace("$", "");//must strip dollar sign
                            thePrice = System.Convert.ToDecimal(price);
                            lblBookTotal.Text = (thePrice * copies).ToString("c");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Book price is not in a decimal value.");
                        }

                    }
                    //original book thePrice
                    var theTotal = System.Convert.ToDecimal(lblBookTotal.Text.Replace("$", ""));

                    decimal profTotal = 0;
                    decimal conTotal = 0;
                    result = decimal.TryParse(lblProfAmt.Text.Replace("$", ""), out profTotal);
                    result = decimal.TryParse(lblConvAmt.Text.Replace("$", ""), out conTotal);
                    decimal vprofprce = thePrice + ((conTotal / copies) + (profTotal / copies));
                    lblprofprice.Text = vprofprce.ToString("c");

                    lblProftotalPrc.Text = (vprofprce * copies).ToString("c");
                     BookCalc();
                }
            }

        }
        private void CalcInk()
        {


        }
        private void BookCalc()
        {
            // removes old tax calc
            this.TaxRate = 0;
            //
            decimal vbookTotal=0;
            decimal vBookCalcTax = 0;
            try
            {
                //errors when refilling and this is called before values refreshed
                vbookTotal = System.Convert.ToDecimal(lblBookTotal.Text.Replace("$", ""));
                vBookCalcTax = this.TaxRate * vbookTotal;
            }
            catch (Exception ex)
            {

                return;
            }
            if (!startup)
            {
                if (quotesBindingSource.Count > 0)
                {
                    if (!ValidateCopies() || !ValidatePageCount())
                    {
                        return;
                    }
                    if (BookOptionPricing == null) { GetBookOptionPricing(); }
                    if (CurPriceYr != txtBYear.Text) { CalculateEach(); }
                    int numberOfCopies = 0;
                    int numberOfPages = 0;
                    var parseresult = int.TryParse(txtNocopies.Text, out numberOfCopies);
                    var parseresult1 = int.TryParse(txtNoPages.Text, out numberOfPages);
                    if (!parseresult)
                    {
                        MessageBox.Show("Number of copies is not valid!", "Copies", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!parseresult1)
                    {
                        MessageBox.Show("Number of pages is not valid!", "Pages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (this.BookOptionPricing != null && CurPriceYr == txtBYear.Text)
                    {

                        //Hardback
                        decimal HardBack = 0;
                        if (chkHardBack.Checked)
                        {
                            HardBack = BookOptionPricing.Hardbk * numberOfCopies;
                            vBookCalcTax += (HardBack * this.TaxRate);
                            lblHardbackAmt.Text = HardBack.ToString();
                            CalcInk();
                        }
                        else
                        {
                            lblHardbackAmt.Text = "0.00";

                            HardBack = 0;
                        }
                        //Casebind
                        decimal Casebind = 0;
                        if (chkCaseBind.Checked)
                        {
                            Casebind = BookOptionPricing.Customized * numberOfCopies;
                            vBookCalcTax += (Casebind * this.TaxRate);
                            lblCaseamt.Text = Casebind.ToString();
                            CalcInk();
                        }
                        else
                        {
                            lblCaseamt.Text = "0.00";
                            Casebind = 0;
                        }
                        //Check if harback and case both not checked
                        if (!chkHardBack.Checked && !chkCaseBind.Checked)
                        {
                            CalcInk();
                        }
                        //Perfect Bind
                        decimal Perfectbind = 0;
                        if (chkPerfBind.Checked)
                        {
                            Perfectbind = BookOptionPricing.Perfectbind * numberOfCopies;
                            vBookCalcTax += (Perfectbind * this.TaxRate);
                            lblPerfbindAmt.Text = Perfectbind.ToString();

                        }
                        else
                        {
                            lblPerfbindAmt.Text = "0.00";
                            Perfectbind = 0;
                        }
                        //Spiral
                        decimal Spiral = 0;
                        if (chkSpiral.Checked)
                        {
                            Spiral = (BookOptionPricing.Spiral * numberOfCopies);
                            vBookCalcTax += (Spiral * this.TaxRate);
                            lblSpiralAmt.Text = Spiral.ToString();
                        }
                        else
                        {
                            lblSpiralAmt.Text = "0.00";
                            Spiral = 0;
                        }
                        //SaddleStitch
                        decimal SaddleStitch = 0;
                        if (chkSaddlStitch.Checked)
                        {
                            SaddleStitch = (BookOptionPricing.SaddleStitch * numberOfCopies);
                            vBookCalcTax += (SaddleStitch * this.TaxRate);
                            lblSaddleAmt.Text = SaddleStitch.ToString();

                        }
                        else
                        {
                            lblSaddleAmt.Text = "0.00";
                            SaddleStitch = 0;
                        }

                        //Professional
                        decimal Professional = 0;
                        if (chkProfessional.Checked)
                        {
                            Professional = (BookOptionPricing.Professional * numberOfPages);
                            vBookCalcTax += (Professional * this.TaxRate);
                            lblProfAmt.Text = Professional.ToString();

                        }
                        else
                        {
                            lblProfAmt.Text = "0.00";
                            Professional = 0;
                        }

                        //Convenient
                        decimal Convenient = 0;
                        if (chkConv.Checked)
                        {
                            Convenient = (BookOptionPricing.Convenient * numberOfPages);
                            vBookCalcTax += (Convenient * this.TaxRate);
                            lblConvAmt.Text = Convenient.ToString();

                        }
                        else
                        {
                            lblConvAmt.Text = "0.00";
                            Convenient = 0;
                        }
                        //Yir
                        decimal Yir = 0;
                        if (chkYir.Checked)
                        {
                            Yir = (BookOptionPricing.Ink * numberOfCopies);
                            vBookCalcTax += (Yir * this.TaxRate);
                            lblYir.Text = Yir.ToString();
                        }
                        else
                        {
                            lblYir.Text = "0.00";
                            Yir = 0;
                        }
                        //our story
                        decimal Story = 0;
                        if (chkStory.Checked)
                        {
                            Story = (BookOptionPricing.Story * numberOfCopies);
                            vBookCalcTax += (Story * this.TaxRate);
                            lblStoryAmount.Text = Story.ToString();
                        }
                        else
                        {
                            lblStoryAmount.Text = "0.00";
                            Story = 0;
                        }


                        //Gloss
                        decimal Gloss = 0;
                        if (chkGlossLam.Checked)
                        {
                            if (chkHardBack.Checked || chkCaseBind.Checked)
                            {
                                lblLaminateAmt.Text = "0.00";
                                Gloss = 0;
                            }
                            else
                            {
                                Gloss = (BookOptionPricing.Lamination * numberOfCopies);
                                vBookCalcTax += (Gloss * this.TaxRate);
                                lblLaminateAmt.Text = Gloss.ToString();
                            }
                        }
                        else
                        {
                            lblLaminateAmt.Text = "0.00";
                            Gloss = 0;
                        }
                        //foilamt/msStory
                        decimal Foil = 0;
                        int MsCopies = 0;
                        var result = int.TryParse(txtMsQty.Text, out MsCopies);

                        if (chkMsStandard.Checked)
                        {
                            if (result)
                            {
                                foilamtTextBox.Text = BookOptionPricing.Foil.ToString("0.00");
                                Foil = (BookOptionPricing.Foil * MsCopies);
                                vBookCalcTax += (Foil * this.TaxRate);
                                lblMsTot.Text = Foil.ToString("0.00");
                            }
                            else
                            {
                                lblMsTot.Text = "0.00";
                                foilamtTextBox.Text = "0.00";
                            }
                        }
                        else
                        {
                            lblMsTot.Text = "0.00";
                            foilamtTextBox.Text = "0.00";
                        }
                        //Lam
                        decimal Laminationsft = 0;
                        if (chkMLaminate.Checked)
                        {
                            Laminationsft = (BookOptionPricing.Laminationsft * numberOfCopies);
                            vBookCalcTax += (Laminationsft * this.TaxRate);
                            lblMLaminateAmt.Text = Laminationsft.ToString();

                        }
                        else
                        {
                            lblMLaminateAmt.Text = "0.00";
                            Laminationsft = 0;
                        }
                        //convert rest of info from strings to decimals for calculations
                        bool vParseResult;
                        decimal BookTotal = 0;
                        decimal SpecCvrTot = 0;
                        decimal FoilTot = 0;
                        decimal ClrPgTot = 0;
                        decimal MiscTot = 0;
                        decimal Desc1Tot = 0;
                        decimal Desc3Tot = 0;
                        decimal Desc4Tot = 0;

                        vParseResult = decimal.TryParse(lblBookTotal.Text.ToString().Replace("$", ""), out BookTotal);
                        vParseResult = decimal.TryParse(lblSpeccvrtot.Text, out SpecCvrTot);
                        vParseResult = decimal.TryParse(txtFoilAd.Text, out FoilTot);
                        vParseResult = decimal.TryParse(txtClrTot.Text, out ClrPgTot);
                        vParseResult = decimal.TryParse(txtMisc.Text, out MiscTot);
                        vParseResult = decimal.TryParse(txtDesc1amt.Text, out Desc1Tot);
                        vParseResult = decimal.TryParse(txtDesc3tot.Text, out Desc3Tot);
                        vParseResult = decimal.TryParse(txtDesc4tot.Text, out Desc4Tot);
                        vBookCalcTax += (this.TaxRate * (SpecCvrTot + FoilTot + ClrPgTot + MiscTot + Desc1Tot + Desc3Tot + Desc4Tot));
                        //old way of sales tax
                       // this.SalesTax = Math.Round(vBookCalcTax, 2, MidpointRounding.AwayFromZero);                    
                        //this.lblSalesTax.Text = this.SalesTax.ToString("c");

                        decimal SubTotal = (BookTotal + HardBack + Casebind + Perfectbind + Spiral + SaddleStitch + Professional + Convenient + Yir + Story + Gloss + Laminationsft + SpecCvrTot + FoilTot + ClrPgTot + MiscTot + Desc1Tot + Desc3Tot + Desc4Tot);

                        lblsubtot.Text = SubTotal.ToString("c");
                        //calculate after subtotal
                        decimal disc1 = 0;
                        decimal disc2 = 0;
                        decimal disc3 = 0;
                        decimal msTot = 0;
                        decimal persTot = 0;
                        decimal iconTot = 0;
                        decimal vTax = 0;
                        vParseResult = decimal.TryParse(lbldisc1.Text, out disc1);
                        vParseResult = decimal.TryParse(lbldisc2.Text, out disc2);
                        vParseResult = decimal.TryParse(lblDisc3.Text, out disc3);
                        vParseResult = decimal.TryParse(lblMsTot.Text, out msTot);
                        vParseResult = decimal.TryParse(lblperstotal.Text, out persTot);
                        vParseResult = decimal.TryParse(lblIconTot.Text, out iconTot);
                        //Old way of taxes
                        //var a = (disc1 * this.TaxRate);
                        //vBookCalcTax += (disc1 * this.TaxRate);
                        //vBookCalcTax += (disc2 * this.TaxRate);
                        //vBookCalcTax += (disc3 * this.TaxRate);
                        //vBookCalcTax += (msTot * this.TaxRate);
                        //vBookCalcTax += (persTot * this.TaxRate);
                        //vBookCalcTax += (iconTot * this.TaxRate);
                        //this.SalesTax = Math.Round(vBookCalcTax, 2, MidpointRounding.AwayFromZero);
                       // this.lblSalesTax.Text = this.SalesTax.ToString("c");
                       //new tax cal
                        vParseResult = decimal.TryParse(lblSalesTax.Text.Replace("$", ""), out vTax);
                        SubTotal += (disc1 + disc2 + disc3 + msTot + persTot + iconTot);
                        if (!donotchargeschoolsalestaxCheckBox.Checked)
                        {
                            vTax = GetTax(SubTotal);
                            this.lblSalesTax.Text = vTax.ToString("$0.00");
                        }
                        else
                        {
                            vTax = 0;
                            this.lblSalesTax.Text = vTax.ToString("$0.00");
                            lblTaxRateValue.Text = "$.00";
                        }
                      


                        //----------------------------------------------------------



                        lblFinalTotPrc.Text = SubTotal.ToString("$0.00");
                        txtFinalbookprc.Text = ((SubTotal) / numberOfCopies).ToString("c");
                        //other charges and credies
                        decimal credit1 = 0;
                        decimal credit2 = 0;
                        decimal otherchrg1 = 0;
                        decimal otherchrg2 = 0;
                        vParseResult = decimal.TryParse(txtCredits.Text, out credit1);
                        vParseResult = decimal.TryParse(txtCredits2.Text, out credit2);
                        vParseResult = decimal.TryParse(txtOtherChrg.Text, out otherchrg1);
                        vParseResult = decimal.TryParse(txtOtherChrg2.Text, out otherchrg2);
                        lbladjbef.Text = (SubTotal + credit1 + credit2 + otherchrg1 + otherchrg2 + vTax).ToString("c");

                    }
                }
            }
        }
        private void GetBookPricing()
        {
            if (String.IsNullOrEmpty(txtBYear.Text))
            {
                errorProvider1.SetError(txtBYear, "");

                errorProvider1.SetError(txtBYear, "Please enter a  base price year.");
                return;
            }
            this.CurPriceYr = txtBYear.Text;


            SqlConnection conn = new SqlConnection(this.FormConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * From Pricing where Type=@Type and yr=@Yr order by copies", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Yr", txtBYear.Text);//base price yr
            if (chkAllClr.Checked)
            {
                cmd.Parameters.AddWithValue("@Type", "Color");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Type", "Base");
            }


            List<Price> PriceList = new List<Price>();

            try
            {

                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Price vprice = new Price()
                    {
                        Copies = rdr.GetInt32(rdr.GetOrdinal("Copies")),

                        Pg12 = rdr["Pg12"] == DBNull.Value ? 0 : (decimal)rdr["Pg12"],
                        Pg16 = rdr["Pg16"] == DBNull.Value ? 0 : (decimal)rdr["Pg16"],
                        Pg20 = rdr["Pg20"] == DBNull.Value ? 0 : (decimal)rdr["Pg20"],
                        Pg24 = rdr["Pg24"] == DBNull.Value ? 0 : (decimal)rdr["Pg24"],
                        Pg28 = rdr["Pg28"] == DBNull.Value ? 0 : (decimal)rdr["Pg28"],
                        Pg32 = rdr["Pg32"] == DBNull.Value ? 0 : (decimal)rdr["Pg32"],
                        Pg36 = rdr["Pg36"] == DBNull.Value ? 0 : (decimal)rdr["Pg36"],
                        Pg40 = rdr["Pg40"] == DBNull.Value ? 0 : (decimal)rdr["Pg40"],
                        Pg44 = rdr["Pg44"] == DBNull.Value ? 0 : (decimal)rdr["Pg44"],
                        Pg48 = rdr["Pg48"] == DBNull.Value ? 0 : (decimal)rdr["Pg48"],
                        Pg52 = rdr["Pg52"] == DBNull.Value ? 0 : (decimal)rdr["Pg52"],
                        Pg56 = rdr["Pg56"] == DBNull.Value ? 0 : (decimal)rdr["Pg56"],
                        Pg60 = rdr["Pg60"] == DBNull.Value ? 0 : (decimal)rdr["Pg60"],
                        Pg64 = rdr["Pg64"] == DBNull.Value ? 0 : (decimal)rdr["Pg64"],
                        Pg68 = rdr["Pg68"] == DBNull.Value ? 0 : (decimal)rdr["Pg68"],
                        Pg72 = rdr["Pg72"] == DBNull.Value ? 0 : (decimal)rdr["Pg72"],
                        Pg76 = rdr["Pg76"] == DBNull.Value ? 0 : (decimal)rdr["Pg76"],
                        Pg80 = rdr["Pg80"] == DBNull.Value ? 0 : (decimal)rdr["Pg80"],
                        Pg84 = rdr["Pg84"] == DBNull.Value ? 0 : (decimal)rdr["Pg84"],
                        Pg88 = rdr["Pg88"] == DBNull.Value ? 0 : (decimal)rdr["Pg88"],
                        Pg92 = rdr["Pg92"] == DBNull.Value ? 0 : (decimal)rdr["Pg92"],
                        Pg96 = rdr["Pg96"] == DBNull.Value ? 0 : (decimal)rdr["Pg96"],
                        Pg100 = rdr["Pg100"] == DBNull.Value ? 0 : (decimal)rdr["Pg100"],
                        Pg104 = rdr["Pg104"] == DBNull.Value ? 0 : (decimal)rdr["Pg104"],
                        Pg108 = rdr["Pg108"] == DBNull.Value ? 0 : (decimal)rdr["Pg108"],
                        Pg112 = rdr["Pg112"] == DBNull.Value ? 0 : (decimal)rdr["Pg112"],
                        Pg116 = rdr["Pg116"] == DBNull.Value ? 0 : (decimal)rdr["Pg116"],
                        Pg120 = rdr["Pg120"] == DBNull.Value ? 0 : (decimal)rdr["Pg120"],
                        Pg124 = rdr["Pg124"] == DBNull.Value ? 0 : (decimal)rdr["Pg124"],
                        Pg128 = rdr["Pg128"] == DBNull.Value ? 0 : (decimal)rdr["Pg128"],
                        Pg132 = rdr["Pg132"] == DBNull.Value ? 0 : (decimal)rdr["Pg132"],
                        Pg136 = rdr["Pg136"] == DBNull.Value ? 0 : (decimal)rdr["Pg136"],
                        Pg140 = rdr["Pg140"] == DBNull.Value ? 0 : (decimal)rdr["Pg140"],
                        Pg144 = rdr["Pg144"] == DBNull.Value ? 0 : (decimal)rdr["Pg144"],
                        Pg148 = rdr["Pg148"] == DBNull.Value ? 0 : (decimal)rdr["Pg148"],
                        Pg152 = rdr["Pg152"] == DBNull.Value ? 0 : (decimal)rdr["Pg152"],
                        Pg156 = rdr["Pg156"] == DBNull.Value ? 0 : (decimal)rdr["Pg156"],
                        Pg160 = rdr["Pg160"] == DBNull.Value ? 0 : (decimal)rdr["Pg160"],
                        Pg164 = rdr["Pg164"] == DBNull.Value ? 0 : (decimal)rdr["Pg164"],
                        Pg168 = rdr["Pg168"] == DBNull.Value ? 0 : (decimal)rdr["Pg168"],
                        Pg172 = rdr["Pg172"] == DBNull.Value ? 0 : (decimal)rdr["Pg172"],
                        Pg176 = rdr["Pg176"] == DBNull.Value ? 0 : (decimal)rdr["Pg176"],
                        Pg180 = rdr["Pg180"] == DBNull.Value ? 0 : (decimal)rdr["Pg180"],
                        Pg184 = rdr["Pg184"] == DBNull.Value ? 0 : (decimal)rdr["Pg184"],
                        Pg188 = rdr["Pg188"] == DBNull.Value ? 0 : (decimal)rdr["Pg188"],
                        Pg192 = rdr["Pg192"] == DBNull.Value ? 0 : (decimal)rdr["Pg192"],
                        Pg196 = rdr["Pg196"] == DBNull.Value ? 0 : (decimal)rdr["Pg196"],
                        Pg200 = rdr["Pg200"] == DBNull.Value ? 0 : (decimal)rdr["Pg200"],
                        Pg204 = rdr["Pg204"] == DBNull.Value ? 0 : (decimal)rdr["Pg204"],
                        Pg208 = rdr["Pg208"] == DBNull.Value ? 0 : (decimal)rdr["Pg208"],
                        Pg212 = rdr["Pg212"] == DBNull.Value ? 0 : (decimal)rdr["Pg212"],
                        Pg216 = rdr["Pg216"] == DBNull.Value ? 0 : (decimal)rdr["Pg216"],
                        Pg220 = rdr["Pg220"] == DBNull.Value ? 0 : (decimal)rdr["Pg220"],
                        Pg224 = rdr["Pg224"] == DBNull.Value ? 0 : (decimal)rdr["Pg224"],
                        Pg228 = rdr["Pg228"] == DBNull.Value ? 0 : (decimal)rdr["Pg228"],
                        Pg232 = rdr["Pg232"] == DBNull.Value ? 0 : (decimal)rdr["Pg232"],
                        Pg236 = rdr["Pg236"] == DBNull.Value ? 0 : (decimal)rdr["Pg236"],
                        Pg240 = rdr["Pg240"] == DBNull.Value ? 0 : (decimal)rdr["Pg240"],
                        Pg244 = rdr["Pg244"] == DBNull.Value ? 0 : (decimal)rdr["Pg244"],
                        Pg248 = rdr["Pg248"] == DBNull.Value ? 0 : (decimal)rdr["Pg248"],
                        Pg252 = rdr["Pg252"] == DBNull.Value ? 0 : (decimal)rdr["Pg252"],
                        Pg256 = rdr["Pg256"] == DBNull.Value ? 0 : (decimal)rdr["Pg256"],
                        Pg260 = rdr["Pg260"] == DBNull.Value ? 0 : (decimal)rdr["Pg260"],
                        Pg264 = rdr["Pg264"] == DBNull.Value ? 0 : (decimal)rdr["Pg264"],
                        Pg268 = rdr["Pg268"] == DBNull.Value ? 0 : (decimal)rdr["Pg268"],
                        Pg272 = rdr["Pg272"] == DBNull.Value ? 0 : (decimal)rdr["Pg272"],
                        Pg276 = rdr["Pg276"] == DBNull.Value ? 0 : (decimal)rdr["Pg276"],
                        Pg280 = rdr["Pg280"] == DBNull.Value ? 0 : (decimal)rdr["Pg280"],
                        Pg284 = rdr["Pg284"] == DBNull.Value ? 0 : (decimal)rdr["Pg284"],
                        Pg288 = rdr["Pg288"] == DBNull.Value ? 0 : (decimal)rdr["Pg288"],
                        Pg292 = rdr["Pg292"] == DBNull.Value ? 0 : (decimal)rdr["Pg292"],
                        Pg296 = rdr["Pg296"] == DBNull.Value ? 0 : (decimal)rdr["Pg296"],
                        Pg300 = rdr["Pg300"] == DBNull.Value ? 0 : (decimal)rdr["Pg300"],
                        Pg304 = rdr["Pg304"] == DBNull.Value ? 0 : (decimal)rdr["Pg304"],
                        Pg308 = rdr["Pg308"] == DBNull.Value ? 0 : (decimal)rdr["Pg308"],
                        Pg312 = rdr["Pg312"] == DBNull.Value ? 0 : (decimal)rdr["Pg312"],
                        Pg316 = rdr["Pg316"] == DBNull.Value ? 0 : (decimal)rdr["Pg316"],
                        Pg320 = rdr["Pg320"] == DBNull.Value ? 0 : (decimal)rdr["Pg320"],
                        Pg324 = rdr["Pg324"] == DBNull.Value ? 0 : (decimal)rdr["Pg324"],
                        Pg328 = rdr["Pg328"] == DBNull.Value ? 0 : (decimal)rdr["Pg328"],
                        Pg332 = rdr["Pg332"] == DBNull.Value ? 0 : (decimal)rdr["Pg332"]
                        //Pg336 = rdr.GetDecimal(rdr.GetOrdinal("Pg336")),
                        //Pg340 = rdr.GetDecimal(rdr.GetOrdinal("Pg340")),
                        //Pg344 = rdr.GetDecimal(rdr.GetOrdinal("Pg344")),
                        //Pg348 = rdr.GetDecimal(rdr.GetOrdinal("Pg348")),
                        //Pg352 = rdr.GetDecimal(rdr.GetOrdinal("Pg352")),
                        //Pg356 = rdr.GetDecimal(rdr.GetOrdinal("Pg356")),
                        //Pg360 = rdr.GetDecimal(rdr.GetOrdinal("Pg360"))

                    };
                    PriceList.Add(vprice);

                    this.Pricing = PriceList;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal("Failed to retrieve pricing:" + ex.Message);
                MessageBox.Show("There was an error retrieving pricing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void GetBookOptionPricing()
        {
            this.CurPriceYr = txtBYear.Text;
            SqlConnection conn = new SqlConnection(FormConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * From BookOptionPricing where yr=@Yr", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Yr", txtBYear.Text);//base price yr

            try
            {

                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BookOptionPrice vOptionPrice = new BookOptionPrice()
                    {
                        Yr = rdr.GetOrdinal("Yr").ToString(),
                        Case = rdr.GetDecimal(rdr.GetOrdinal("Case")),
                        Professional = rdr.GetDecimal(rdr.GetOrdinal("Professional")),
                        Convenient = rdr.GetDecimal(rdr.GetOrdinal("Convenient")),
                        Specialcvr = rdr.GetDecimal(rdr.GetOrdinal("Specialcvr")),
                        Lamination = rdr.GetDecimal(rdr.GetOrdinal("Lamination")),
                        Perfectbind = rdr.GetDecimal(rdr.GetOrdinal("Perfectbind")),
                        Customized = rdr.GetDecimal(rdr.GetOrdinal("Customized")),
                        Hardbk = rdr.GetDecimal(rdr.GetOrdinal("Hardbk")),
                        Foil = rdr.GetDecimal(rdr.GetOrdinal("Foil")),
                        Ink = rdr.GetDecimal(rdr.GetOrdinal("Ink")),
                        Spiral = rdr.GetDecimal(rdr.GetOrdinal("Spiral")),
                        Theme = rdr.GetDecimal(rdr.GetOrdinal("Theme")),
                        Story = rdr.GetDecimal(rdr.GetOrdinal("Story")),
                        Yir = rdr.GetDecimal(rdr.GetOrdinal("Yir")),
                        Supplement = rdr.GetDecimal(rdr.GetOrdinal("Supplement")),
                        Laminationsft = rdr.GetDecimal(rdr.GetOrdinal("Laminationsft"))

                    };
                    this.BookOptionPricing = vOptionPrice;

                }
            }
            catch (Exception ex)
            {
                Log.Fatal("Error retrieving Book Option Pricing" + ex.Message);
                MessageBox.Show("There was an error retrieving Book Option Pricing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (this.BookOptionPricing == null)
            {
                MessageBox.Show("Book Option pricing for this contract year was not found. Contact your supervisor.");
            }

        }

        //OnlinePay
        private void SetOnlinePayOptions(string textboxname, string checkboxname, bool vcheck)
        {
            List<TextBox> vControls = new List<TextBox>();
            List<CheckBox> vControls1 = new List<CheckBox>();
            vControls.Add(this.txtInkPersAmt);
            vControls.Add(this.txtInkTxtOnly);
            vControls.Add(this.txtFoilIcons);
            vControls.Add(this.txtFoilTxt);
            vControls.Add(this.txtPicPers);
            vControls1.Add(this.chkInkPers);
            vControls1.Add(this.chkInkTxt);
            vControls1.Add(this.chkFoilIcons);
            vControls1.Add(this.chkFoiltxt);
            vControls1.Add(this.chkPicPers);

            foreach (TextBox ctr in vControls)
            {
                if (vcheck == true)
                {
                    if (ctr.Name != textboxname)
                    {
                        ctr.Enabled = false;
                        ctr.Text = "0.00";
                    }
                    else { ctr.Enabled = true; }
                }
                else
                {
                    ctr.Text = "0.00";
                    ctr.Enabled = false;
                }
            }
            foreach (CheckBox ctr1 in vControls1)
            {
                if (vcheck == true)
                {
                    if (ctr1.Name != checkboxname)
                    {
                        ctr1.Enabled = false;

                    }
                    else { ctr1.Enabled = true; }

                }
                else
                {

                    ctr1.Enabled = true;

                }


            }

        }
        private void CalcOnlineTotals()
        {

            if (basicamounTextBox1.Text != null && basicamounTextBox1.Text != "0.00" && basicamounTextBox1.Text != "")
            {
                lblOprcperbk.Text = basicamounTextBox1.Text;
            }
            else
            {
                lblOprcperbk.Text = "0.00";

            }

            if (txtInkPersAmt.Text != null && txtInkPersAmt.Text != "0.00" && txtInkPersAmt.Text != "")
            {
                txtOprcperbk2.Text = txtInkPersAmt.Text;
                return;
            }
            else
            {
                txtOprcperbk2.Text = "0.00";

            }
            if (txtInkTxtOnly.Text != null && txtInkTxtOnly.Text != "0.00" && txtInkTxtOnly.Text != "")
            {
                txtOprcperbk2.Text = txtInkTxtOnly.Text;
                return;
            }
            else
            {
                txtOprcperbk2.Text = "0.00";

            }

            if (txtFoilIcons.Text != null && txtFoilIcons.Text != "0.00" && txtFoilIcons.Text != "")
            {
                txtOprcperbk2.Text = txtFoilIcons.Text;
                return;
            }
            else
            {
                txtOprcperbk2.Text = "0.00";

            }
            if (txtFoilTxt.Text != null && txtFoilTxt.Text != "0.00" && txtFoilTxt.Text != "")
            {
                txtOprcperbk2.Text = txtFoilTxt.Text;
                return;
            }
            else
            {
                txtOprcperbk2.Text = "0.00";

            }

            if (txtPicPers.Text != null && txtPicPers.Text != "0.00" && txtPicPers.Text != "")
            {
                txtOprcperbk2.Text = txtFoilTxt.Text;
                return;
            }
            else
            {
                txtOprcperbk2.Text = "0.00";

            }

        }

        //General
        private void SetCodeInvno()
        {
            if (quotesBindingSource.Count > 0)
            {
                DataRowView current = (DataRowView)quotesBindingSource.Current;
                this.Schcode = current["schcode"].ToString();
                this.Invno = Convert.ToInt32(current["invno"]);
                var vKitrecvd = "";
                if (!((DataRowView)quotesBindingSource.Current).Row.IsNull("kitrecvd"))
                {
                    ((DataRowView)quotesBindingSource.Current).Row["kitrecvd"].ToString();
                }

                booktypeTextBox.ReadOnly = string.IsNullOrEmpty(vKitrecvd);
            }
        }
        private void Fill()
        {
            if (!string.IsNullOrEmpty(Schcode))
            {
                try
                {
                    custTableAdapter.Fill(dsSales.cust, Schcode);

                  
                    this.SchoolZipCode = ((DataRowView)this.custBindingSource.Current).Row["schzip"].ToString().Trim();
                    if (this.SchoolZipCode.Length > 5)
                    {
                        this.SchoolZipCode = this.SchoolZipCode.Substring(0, 5);
                    }
                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "");
                }

            }
            if (Invno != 0)
            {
                try
                {
                    quotesTableAdapter.FillByInvno(dsSales.quotes, Invno);
                    xtraTableAdapter.Fill(dsExtra.xtra, Invno);
                    
                  
                }catch(Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "");
                }

            }
            CalculateEach();
            BookCalc();
            SetCodeInvno();
            txtModifiedBy.Text = this.ApplicationUser.id;
            txtModifiedByInv.Text = this.ApplicationUser.id;
            txtModifiedByInvdetail.Text = this.ApplicationUser.id;
            txtModifiedByPay.Text = this.ApplicationUser.id;
            SetNoticeLabels();
        }
        public override ApiProcessingResult<bool> Save()
        {
            return Save(true);
        }

        public ApiProcessingResult<bool> Save(bool showSuccessMsg)
        {
            var processingResult = new ApiProcessingResult<bool>();
            this.Cursor = Cursors.WaitCursor;
            txtModifiedBy.Text = this.ApplicationUser.id;
            txtModifiedByInv.Text = this.ApplicationUser.id;
            txtModifiedByInvdetail.Text = this.ApplicationUser.id;
            txtModifiedByPay.Text = this.ApplicationUser.id;

            switch (tabSales.SelectedIndex)
            {
                case 0:
                case 1:
                    {
                        var salesResult = SaveSales();
                        if (salesResult.IsError)
                        {
                            MbcMessageBox.Error("Sales record failed to save:" + salesResult.Errors[0].ErrorMessage, "");
                            processingResult.IsError = true;
                        }
                        else
                        {
                            if (showSuccessMsg)
                            {
                                MbcMessageBox.Exclamation("Sales record has been saved.", "Sales Record");
                            }
                        }

                        break;
                    }


                case 2:
                    MessageBox.Show("This function is not available in the invoice tab.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 3:
                    var result = SavePayment();
                    if (result.IsError)
                    {
                        MbcMessageBox.Error("Payment record failed to save:" + result.Errors[0].ErrorMessage, "");
                        processingResult.IsError = true;
                    }
                    else
                    {
                        if (showSuccessMsg)
                        {
                            MbcMessageBox.Exclamation("Payment record has been saved.", "Payment Record");
                        }
                    }

                    break;

            }
            this.Cursor = Cursors.Default;

            return processingResult;
        }
        public override bool Add()
        {
            txtModifiedBy.Text = this.ApplicationUser.id;
            txtModifiedByInv.Text = this.ApplicationUser.id;
            txtModifiedByInvdetail.Text = this.ApplicationUser.id;
            txtModifiedByPay.Text = this.ApplicationUser.id;
            switch (tabSales.SelectedIndex)
            {
                case 0:
                case 1:
                    {
                        MessageBox.Show("This function is not available in the sales screen tab. Add a sales record from the customer screen.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }


                case 2:
                    MessageBox.Show("This function is not available in the invoice tab.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 3:
                    NewPayment();
                    break;

            }
            return true;
        }
        public override void Delete()
        {
            txtModifiedBy.Text = this.ApplicationUser.id;
            txtModifiedByInv.Text = this.ApplicationUser.id;
            txtModifiedByInvdetail.Text = this.ApplicationUser.id;
            txtModifiedByPay.Text = this.ApplicationUser.id;
            switch (tabSales.SelectedIndex)
            {
                case 0:
                case 1:
                    {
                        DeleteSale();
                        break;
                    }
                case 2:
                    DeleteInvoice();
                    break;
                case 3:
                    DeletePayment();
                    break;

            }
        }
        public override void Cancel()
        {
            CancelPayment();
            quotesBindingSource.CancelEdit();
            invdetailBindingSource.CancelEdit();
            invoiceBindingSource.CancelEdit();
        }
        public void UpdateProductionCopyPages()
        {
            int numBooks;
            int freeBooks = 0;
            var result = int.TryParse(this.txtNocopies.Text, out numBooks);
            var result1 = int.TryParse(this.txtfreebooks.Text, out freeBooks);
            if (result)
            {
                if (!string.IsNullOrEmpty(txtYear.Text))
                {
                    numBooks += 2 + freeBooks;
                }
                else
                {
                    numBooks += 2;
                }


                var sqlQuery = new SQLQuery();
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Invno",this.Invno),
                     new SqlParameter("@NoCopies",numBooks),
                     new SqlParameter("@NoPages",this.txtNoPages.Text),
                    };
                var strQuery = "Update produtn set NoCopies=@NoCopies, NoPages=@NoPages where Invno=@Invno";
                try { var updateResult = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters); } catch (Exception ex) { MbcMessageBox.Error("Failed to update production copies:" + ex.Message, ""); }

            }
        }
        #endregion
        #region CalcEvents
        private void chkHardBack_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkAllClr_Click(object sender, EventArgs e)
        {
            GetBookPricing();
            CalculateEach();
            BookCalc();
        }

        private void chkPromo_Click(object sender, EventArgs e)
        {
            CalculateEach();
        }

        private void txtBYear_Leave(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtBYear, "");
            if (String.IsNullOrEmpty(txtBYear.Text))
            {
                // errorProvider1.Clear();
                errorProvider1.SetError(txtBYear, "Please enter a  base price year.");
            }
            GetBookPricing();
            GetBookOptionPricing();
            CalculateEach();
        }
        private void txtNoPages_Leave(object sender, EventArgs e)
        {


            CalculateEach();
            BookCalc();


        }

        private void txtNocopies_Leave(object sender, EventArgs e)
        {

            CalculateEach();
            BookCalc();


        }

        private void txtPriceOverRide_Leave(object sender, EventArgs e)
        {
            CalculateEach();
            BookCalc();
        }

        private void cmbYrDiscountAmt_Leave(object sender, EventArgs e)
        {

        }

        private void chkCaseBind_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkPerfBind_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkSpiral_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkSaddlStitch_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkProfessional_Click(object sender, EventArgs e)
        {


            BookCalc();
        }

        private void chkConv_Click(object sender, EventArgs e)
        {

            BookCalc();
        }

        private void chkYir_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkStory_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkGlossLam_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void chkMLaminate_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtSpecCvrEa_Leave(object sender, EventArgs e)
        {
            decimal spcEach;
            int copies;
            bool result = decimal.TryParse(txtSpecCvrEa.Text, out spcEach);
            bool result2 = int.TryParse(txtNocopies.Text, out copies);
            if (result && result2)
            {
                lblSpeccvrtot.Text = (copies * spcEach).ToString();
            }
            else { lblSpeccvrtot.Text = ""; }
            BookCalc();

        }

        private void txtMisc_Leave(object sender, EventArgs e)
        {
            var a = String.Format("{0:0.00}", txtMisc.Text);
            BookCalc();
        }

        private void txtDesc1amt_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtDesc3tot_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtDesc4tot_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtClrTot_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtDisc_Leave(object sender, EventArgs e)
        {

            decimal discountpercent = 0;
            decimal subtot = 0;
            bool vParseResult = decimal.TryParse(txtDisc.Text, out discountpercent);
            bool vParseResult1 = decimal.TryParse(lblsubtot.Text.Replace("$", ""), out subtot);
            if (vParseResult && vParseResult1)
            {
                var discountprice = (subtot * discountpercent) - ((subtot * discountpercent) * 2);
                lbldisc1.Text = discountprice.ToString("0.00");
                BookCalc();
            }
            else
            {
                lbldisc1.Text = "0.00";
                BookCalc();
            }

        }

        private void chkDc2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDc2.Checked)
            {
                txtDp2.Text = ".05";
                decimal discountpercent = 0;
                decimal subtot = 0;
                bool vParseResult = decimal.TryParse(txtDp2.Text, out discountpercent);
                bool vParseResult1 = decimal.TryParse(lblsubtot.Text.Replace("$", ""), out subtot);
                if (vParseResult && vParseResult1)
                {
                    var discountprice = (subtot * discountpercent) - ((subtot * discountpercent) * 2);
                    lbldisc2.Text = discountprice.ToString("0.00");
                    BookCalc();
                }
                else
                {
                    txtDp2.Text = "0.00";
                    lbldisc2.Text = "0.00";
                    BookCalc();
                }

            }
            else
            {
                txtDp2.Text = "0.00";
                lbldisc2.Text = "0.00";
                BookCalc();
            }
        }

        private void txtDp2_Leave(object sender, EventArgs e)
        {
            if (chkDc2.Checked)
            {

                decimal discountpercent = 0;
                decimal subtot = 0;
                bool vParseResult = decimal.TryParse(txtDp2.Text, out discountpercent);
                bool vParseResult1 = decimal.TryParse(lblsubtot.Text.Replace("$", ""), out subtot);
                if (vParseResult && vParseResult1)
                {
                    var discountprice = (subtot * discountpercent) - ((subtot * discountpercent) * 2);
                    lbldisc2.Text = discountprice.ToString("0.00");
                    BookCalc();
                }
                else
                {
                    txtDp2.Text = "0.00";
                    lbldisc2.Text = "0.00";
                    BookCalc();
                }

            }
            else
            {
                txtDp2.Text = "0.00";
                lbldisc2.Text = "0.00";
                BookCalc();
            }
        }

        private void dp3ComboBox_Leave(object sender, EventArgs e)
        {
            if (dp3ComboBox.SelectedItem == null) { dp3ComboBox.SelectedItem = ".000"; }
            decimal discountpercent = 0;
            decimal subtot = 0;
            bool vParseResult = decimal.TryParse(dp3ComboBox.SelectedItem.ToString(), out discountpercent);
            bool vParseResult1 = decimal.TryParse(lblsubtot.Text.Replace("$", ""), out subtot);
            if (vParseResult && vParseResult1)
            {
                var discountprice = (subtot * discountpercent) - ((subtot * discountpercent) * 2);
                lblDisc3.Text = discountprice.ToString("0.00");
                BookCalc();
            }


        }

        private void chkMsStandard_Click(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtMsQty_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void perscopiesTextBox_Leave(object sender, EventArgs e)
        {
            int number = 0;
            int number1 = 0;
            decimal prc = 0;
            bool result = int.TryParse(perscopiesTextBox.Text, out number);
            bool result3 = int.TryParse(txtIconCopies.Text, out number1);
            bool result2 = decimal.TryParse(persamountTextBox.Text, out prc);
            if (result && result2)
            {
                lblperstotal.Text = (number * prc).ToString("0.00");
                BookCalc();
            }
            else
            {
                lblperstotal.Text = "0.00";
                BookCalc();
            }
            txtNumtoPers.Text = (number1 + number).ToString();

        }

        private void persamountTextBox_Leave(object sender, EventArgs e)
        {
            int number = 0;
            decimal prc = 0;
            bool result = int.TryParse(perscopiesTextBox.Text, out number);
            bool result2 = decimal.TryParse(persamountTextBox.Text, out prc);
            if (result && result2)
            {
                lblperstotal.Text = (number * prc).ToString("0.00");
                BookCalc();
            }
            else
            {
                lblperstotal.Text = "0.00";
                BookCalc();
            }
        }

        private void txtCredits_Leave(object sender, EventArgs e)
        {
            decimal credit1 = 0;
            bool result = decimal.TryParse(txtCredits.Text, out credit1);
            if (credit1 > 0)
            {
                txtCredits.Text = (0 - credit1).ToString("0.00");
            }

            BookCalc();
        }

        private void txtCredits2_Leave(object sender, EventArgs e)
        {
            decimal credit2 = 0;
            bool result = decimal.TryParse(txtCredits2.Text, out credit2);
            if (credit2 > 0)
            {
                txtCredits2.Text = (0 - credit2).ToString("0.00");
            }
            BookCalc();
        }

        private void txtOtherChrg_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void txtOtherChrg2_Leave(object sender, EventArgs e)
        {
            BookCalc();
        }

        #endregion

        #region Validation
        private bool ValidatePayment()
        {
            bool retval = true;
            if (txtInitials.Enabled == true)
            {
                errorProvider1.SetError(txtInitials, "");

                if (String.IsNullOrEmpty(txtInitials.Text))
                {
                    errorProvider1.SetError(txtInitials, "Please enter your initials.");
                    retval = false;
                    return retval;
                }
            }
            bool result = true;
            decimal val = 0;
            if (!String.IsNullOrEmpty(txtPayment.Text))
            {
                result = Decimal.TryParse(txtPayment.Text, out val);
                errorProvider1.SetError(txtPayment, "");
                if (!result)
                {

                    errorProvider1.SetError(txtPayment, "Value must be a Decimal.");
                }

            }
            else if (!String.IsNullOrEmpty(txtRefund.Text))
            {
                result = Decimal.TryParse(txtRefund.Text, out val);
                errorProvider1.SetError(txtRefund, "");
                if (!result)
                {

                    errorProvider1.SetError(txtRefund, "Value must be a Decimal.");
                }

            }
            else if (!String.IsNullOrEmpty(txtAdjustment.Text))
            {
                result = Decimal.TryParse(txtAdjustment.Text, out val);
                errorProvider1.SetError(txtAdjustment, "");
                if (!result)
                {

                    errorProvider1.SetError(txtAdjustment, "Value must be a Decimal.");
                }


            }
            else if (!String.IsNullOrEmpty(txtCompensation.Text))
            {
                result = Decimal.TryParse(txtCompensation.Text, out val);
                errorProvider1.SetError(txtCompensation, "");
                if (!result)
                {

                    errorProvider1.SetError(txtCompensation, "Value must be a Decimal.");
                }

            }

            return retval;
        }
        private bool ValidatePageCount()
        {
            bool retval = true;
            errorProvider1.SetError(txtNoPages, "");
            if (String.IsNullOrEmpty(txtNoPages.Text))
            {

                retval = false;

            }
            int count;
            var result = int.TryParse(txtNoPages.Text, out count);
            //non numeric
            if (!result)
            {
                errorProvider1.SetError(txtNoPages, "Please enter a number.");
                retval = false;
            }
            //Check over 360
            if (count > 360)
            {
                errorProvider1.SetError(txtNoPages, "Calculations are limited to 360 pages!");
                retval = false;
            }
            //check divisible by 4
            var mod = (count % 4);
            if (mod != 0 || count < 12)
            {
                errorProvider1.SetError(txtNoPages, "Pages must be 12 or greater and divisible by 4!");
                retval = false;
            }

            //If CaseBind
            if (chkCaseBind.Checked && (count < 40 || count > 120))
            {
                errorProvider1.SetError(txtNoPages, "Case Bind pages must between 40 and 120!");
                retval = false;
            }

            if (count > 84 && chkSaddlStitch.Checked)
            {
                errorProvider1.SetError(txtNoPages, "Saddle Stitch must be 84 pages or less!");
                retval = false;
            }

            if (retval == false)
            {
                lblBookTotal.Text = (0 * 0).ToString("c");
                lblProftotalPrc.Text = (0 * 0).ToString("c");
                lblPriceEach.Text = (0 * 0).ToString("c");
                lblprofprice.Text = 0.ToString("c");
            }

            return retval;
        }
        private bool ValidateCopies()
        {

            bool retval = true;
            if (!startup)
            {
                errorProvider1.SetError(txtNocopies, "");
                int count;
                var result = int.TryParse(txtNocopies.Text, out count);
                //non numeric
                if (!result || count == 0)
                {
                    errorProvider1.SetError(txtNocopies, "Please enter a number.");
                    retval = false;
                }
                if (count > 1800)
                {
                    errorProvider1.SetError(txtNocopies, "Number exceeds maximun quantity. Contact your supervisor.");
                    retval = false;
                }
                if (retval == false)
                {
                    lblBookTotal.Text = (0 * 0).ToString("c");
                    lblProftotalPrc.Text = (0 * 0).ToString("c");
                    lblPriceEach.Text = (0 * 0).ToString("c");
                    lblprofprice.Text = 0.ToString("c");
                }

            }
            return retval;

        }
        private bool ValidSales()
        {
            bool retval = true;

            retval = ValidatePageCount();
            if (!retval) { return retval; }
            retval = ValidateCopies();
            if (!retval) { return retval; }
            retval = this.ValidateChildren();
            if (!retval) { return retval; }
            retval = this.Validate();
            return retval;
        }
        //online pay
        private void basicamounTextBox1_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(basicamounTextBox1, "");
            if (tabSales.SelectedIndex == 1)
            {
                if (String.IsNullOrEmpty(basicamounTextBox1.Text))
                {
                    basicamounTextBox1.Text = "0.00";
                }
                string price = basicamounTextBox1.Text.Replace("$", "");//must strip dollar sign
                decimal val;
                var result = decimal.TryParse(price, out val);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(basicamounTextBox1, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
        }
        private void txtFoilIcons_Validating(object sender, CancelEventArgs e)
        {

        }
        private void txtInkPersAmt_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtInkPersAmt, "");
            if (tabSales.SelectedIndex == 1)
            {
                if (String.IsNullOrEmpty(txtInkPersAmt.Text))
                {
                    txtInkPersAmt.Text = "0.00";
                }
                string price = txtInkPersAmt.Text.Replace("$", "");//must strip dollar sign
                decimal val;
                var result = decimal.TryParse(price, out val);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtInkPersAmt, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
        }

        private void txtInkTxtOnly_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtInkTxtOnly, "");
            if (tabSales.SelectedIndex == 1)
            {
                if (String.IsNullOrEmpty(txtInkTxtOnly.Text))
                {
                    txtInkTxtOnly.Text = "0.00";
                }
                string price = txtInkTxtOnly.Text.Replace("$", "");//must strip dollar sign
                decimal val;
                var result = decimal.TryParse(price, out val);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtInkTxtOnly, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
        }

        private void txtFoilTxt_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtFoilIcons, "");
            if (tabSales.SelectedIndex == 1)
            {
                if (String.IsNullOrEmpty(txtFoilTxt.Text))
                {
                    txtFoilTxt.Text = "0.00";
                }
                string price = txtFoilTxt.Text.Replace("$", "");//must strip dollar sign
                decimal val;
                var result = decimal.TryParse(price, out val);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtFoilTxt, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
        }

        private void txtPicPers_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtPicPers, "");
            if (tabSales.SelectedIndex == 1)
            {
                if (String.IsNullOrEmpty(txtPicPers.Text))
                {
                    txtPicPers.Text = "0.00";
                }
                string price = txtPicPers.Text.Replace("$", "");//must strip dollar sign
                decimal val;
                var result = decimal.TryParse(price, out val);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtPicPers, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
        }

        private void txtLuvLineAmt_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtLuvLineAmt, "");
            if (tabSales.SelectedIndex == 1)
            {
                if (String.IsNullOrEmpty(txtLuvLineAmt.Text))
                {
                    txtLuvLineAmt.Text = "0.00";
                }
                string price = txtLuvLineAmt.Text.Replace("$", "");//must strip dollar sign
                decimal val;
                var result = decimal.TryParse(price, out val);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtLuvLineAmt, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
        }

        private void txtFullAd_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtFullAd, "");
            if (tabSales.SelectedIndex == 1)
            {
                if (String.IsNullOrEmpty(txtFullAd.Text))
                {
                    txtFullAd.Text = "0.00";
                }
                string price = txtFullAd.Text.Replace("$", "");//must strip dollar sign
                decimal val;
                var result = decimal.TryParse(price, out val);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtFullAd, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
        }

        private void txtHaldfAd_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtHaldfAd, "");
            if (tabSales.SelectedIndex == 1)
            {
                if (String.IsNullOrEmpty(txtHaldfAd.Text))
                {
                    txtHaldfAd.Text = "0.00";
                }
                string price = txtHaldfAd.Text.Replace("$", "");//must strip dollar sign
                decimal val;
                var result = decimal.TryParse(price, out val);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtHaldfAd, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
        }

        private void txtQuarterAd_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtQuarterAd, "");
            if (tabSales.SelectedIndex == 1)
            {
                if (String.IsNullOrEmpty(txtQuarterAd.Text))
                {
                    txtQuarterAd.Text = "0.00";
                }
                string price = txtQuarterAd.Text.Replace("$", "");//must strip dollar sign
                decimal val;
                var result = decimal.TryParse(price, out val);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtQuarterAd, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
        }

        private void txtEighthAd_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(txtEighthAd, "");
            if (tabSales.SelectedIndex == 1)
            {
                if (String.IsNullOrEmpty(txtEighthAd.Text))
                {
                    txtEighthAd.Text = "0.00";
                }
                string price = txtEighthAd.Text.Replace("$", "");//must strip dollar sign
                decimal val;
                var result = decimal.TryParse(price, out val);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtEighthAd, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
        }

        private void totalsoldonlineTextBox_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(totalsoldonlineTextBox, "");
            if (tabSales.SelectedIndex == 1)
            {
                if (String.IsNullOrEmpty(totalsoldonlineTextBox.Text))
                {
                    totalsoldonlineTextBox.Text = "0";
                }

                int val;
                var result = int.TryParse(totalsoldonlineTextBox.Text, out val);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(totalsoldonlineTextBox, "Please enter a integer.");
                    e.Cancel = true;

                }
            }
        }

        private void totalpersonlineTextBox_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(totalpersonlineTextBox, "");
            if (tabSales.SelectedIndex == 1)
            {
                if (String.IsNullOrEmpty(totalpersonlineTextBox.Text))
                {
                    totalpersonlineTextBox.Text = "0";
                }

                int val;
                var result = int.TryParse(totalpersonlineTextBox.Text, out val);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(totalpersonlineTextBox, "Please enter a integer.");
                    e.Cancel = true;

                }
            }
        }

        private void totaldollarsonlineTextBox_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(totaldollarsonlineTextBox, "");
            if (tabSales.SelectedIndex == 1)
            {
                if (String.IsNullOrEmpty(totaldollarsonlineTextBox.Text))
                {
                    totaldollarsonlineTextBox.Text = "0.00";
                }
                string price = totaldollarsonlineTextBox.Text.Replace("$", "");//must strip dollar sign
                decimal val;
                var result = decimal.TryParse(price, out val);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(totaldollarsonlineTextBox, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
        }

        private void totallovelinesTextBox_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(totallovelinesTextBox, "");
            if (tabSales.SelectedIndex == 1)
            {
                if (String.IsNullOrEmpty(totallovelinesTextBox.Text))
                {
                    totallovelinesTextBox.Text = "0";
                }

                int val;
                var result = int.TryParse(totallovelinesTextBox.Text, out val);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(totallovelinesTextBox, "Please enter a integer.");
                    e.Cancel = true;

                }
            }
        }

        private void totaladsTextBox_Validating(object sender, CancelEventArgs e)
        {

        }

        //end online sales
        private void txtInitials_Validating(object sender, CancelEventArgs e)
        {

            if (this.tabSales.SelectedIndex == 3 && txtInitials.Enabled == true)
            {
                errorProvider1.SetError(txtInitials, "");
                if (String.IsNullOrEmpty(txtInitials.Text))
                {
                    errorProvider1.SetError(txtInitials, "Please enter your initials.");
                    e.Cancel = true;

                }
            }
        }
        private void txtBYear_Validating(object sender, CancelEventArgs e)
        {

            errorProvider1.SetError(txtBYear, "");
            int numeral;
            var result = int.TryParse(txtBYear.Text, out numeral);
            //non numeric
            if (!result || numeral == 0 || String.IsNullOrEmpty(txtBYear.Text))
            {
                errorProvider1.SetError(txtBYear, "Please enter a  base price year.");
                e.Cancel = true;
                return;
            }


        }

        private void txtYear_Validating(object sender, CancelEventArgs e)
        {

            errorProvider1.SetError(txtYear, "");
            int numeral;
            var result = int.TryParse(txtYear.Text, out numeral);
            //non numeric
            if (!result || numeral == 0 || String.IsNullOrEmpty(txtYear.Text))
            {
                errorProvider1.SetError(txtYear, "Please enter a year.");
                e.Cancel = true;

            }
        }
        private void txtClrNumber_Validating(object sender, CancelEventArgs e)
        {
            //might have letters
            //if (!String.IsNullOrEmpty(txtClrNumber.Text))
            //{
            //    
            //    errorProvider1.Clear();
            //    int numeral;
            //    var result = int.TryParse(txtClrNumber.Text, out numeral);
            //    //non numeric
            //    if (!result)
            //    {
            //        errorProvider1.SetError(txtBYear, "Please enter a number.");
            //        e.Cancel = true;
            //      
            //    }
            //}
        }

        private void txtSpecCvrEa_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSpecCvrEa.Text))
            {

                errorProvider1.SetError(txtSpecCvrEa, "");
                decimal numeral;
                var result = decimal.TryParse(txtSpecCvrEa.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtSpecCvrEa, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
        }

        private void txtFoilAd_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFoilAd.Text))
            {

                errorProvider1.SetError(txtFoilAd, "");
                decimal numeral;
                var result = decimal.TryParse(txtFoilAd.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtFoilAd, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
        }

        private void txtDisc_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtDisc.Text))
            {
                txtDisc.Text = "0";
            }
            if (!String.IsNullOrEmpty(txtDisc.Text))
            {

                errorProvider1.SetError(txtDisc, "");
                decimal numeral;
                var result = decimal.TryParse(txtDisc.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtDisc, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
        }

        private void txtDp2_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtDp2.Text))
            {
                txtDp2.Text = "0";
            }
            if (!String.IsNullOrEmpty(txtDp2.Text))
            {

                errorProvider1.SetError(txtDp2, "");
                decimal numeral;
                var result = decimal.TryParse(txtDp2.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtDp2, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
        }

        private void txtMsQty_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtMsQty.Text))
            {
                txtMsQty.Text = "0";
            }
            if (!String.IsNullOrEmpty(txtMsQty.Text))
            {

                errorProvider1.SetError(txtMsQty, "");
                int numeral;
                var result = int.TryParse(txtMsQty.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtMsQty, "Please enter a number.");
                    e.Cancel = true;

                }
            }
        }

        private void perscopiesTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(perscopiesTextBox.Text))
            {
                perscopiesTextBox.Text = "0";
            }
            if (!String.IsNullOrEmpty(perscopiesTextBox.Text))
            {

                errorProvider1.SetError(perscopiesTextBox, "");
                int numeral;
                var result = int.TryParse(perscopiesTextBox.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(perscopiesTextBox, "Please enter a number.");
                    e.Cancel = true;

                }
            }
        }

        private void persamountTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(persamountTextBox.Text))
            {
                persamountTextBox.Text = "0";
            }
            if (!String.IsNullOrEmpty(persamountTextBox.Text))
            {

                errorProvider1.SetError(persamountTextBox, "");
                decimal numeral;
                var result = decimal.TryParse(persamountTextBox.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(persamountTextBox, "Please enter a number.");
                    e.Cancel = true;

                }
            }
        }

        private void txtNumtoPers_Validating(object sender, CancelEventArgs e)
        {

            if (String.IsNullOrEmpty(txtNumtoPers.Text))
            {
                txtNumtoPers.Text = "0";
            }
            if (!String.IsNullOrEmpty(txtNumtoPers.Text))
            {

                errorProvider1.SetError(txtNumtoPers, "");
                decimal numeral;
                var result = decimal.TryParse(txtNumtoPers.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtNumtoPers, "Please enter a number.");
                    e.Cancel = true;

                }
            }
        }

        private void freebooksTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtfreebooks.Text))
            {
                txtfreebooks.Text = "0";
            }

            if (!String.IsNullOrEmpty(txtfreebooks.Text))
            {

                errorProvider1.SetError(txtfreebooks, "");
                int numeral;
                var result = int.TryParse(txtfreebooks.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtfreebooks, "Please enter a number.");
                    e.Cancel = true;

                }
            }
        }

        private void txtClrTot_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtClrTot.Text))
            {
                txtClrTot.Text = "0";
            }
            if (!String.IsNullOrEmpty(txtClrTot.Text))
            {

                errorProvider1.SetError(txtClrTot, "");
                decimal numeral;
                var result = decimal.TryParse(txtClrTot.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtClrTot, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
            else
            {
                txtClrTot.Text = "0";
            }
        }

        private void txtMisc_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMisc.Text))
            {

                errorProvider1.SetError(txtMisc, "");
                decimal numeral;
                var result = decimal.TryParse(txtMisc.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtMisc, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
            else
            {
                txtMisc.Text = "0";
            }
        }

        private void txtDesc1amt_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDesc1amt.Text))
            {

                errorProvider1.SetError(txtDesc1amt, "");
                decimal numeral;
                var result = decimal.TryParse(txtDesc1amt.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtDesc1amt, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
            else
            {
                txtDesc1amt.Text = "0";
            }
        }

        private void txtDesc3tot_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDesc3tot.Text))
            {

                errorProvider1.SetError(txtDesc3tot, "");
                decimal numeral;
                var result = decimal.TryParse(txtDesc3tot.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtDesc3tot, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
            else
            {
                txtDesc3tot.Text = "0";
            }
        }

        private void txtDesc4tot_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDesc4tot.Text))
            {

                errorProvider1.SetError(txtDesc4tot, "");
                decimal numeral;
                var result = decimal.TryParse(txtDesc4tot.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtDesc4tot, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
            else
            {
                txtDesc4tot.Text = "0";
            }
        }

        private void txtCredits_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCredits.Text))
            {

                errorProvider1.SetError(txtCredits, "");
                decimal numeral;
                var result = decimal.TryParse(txtCredits.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtCredits, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
            else
            {
                txtCredits.Text = "0.00";
            }
        }

        private void txtCredits2_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCredits2.Text))
            {

                errorProvider1.SetError(txtCredits2, "");
                decimal numeral;
                var result = decimal.TryParse(txtCredits2.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtCredits2, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
            else
            {
                txtCredits2.Text = "0.00";
            }
        }

        private void txtOtherChrg_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtOtherChrg.Text))
            {

                errorProvider1.SetError(txtOtherChrg, "");
                decimal numeral;
                var result = decimal.TryParse(txtOtherChrg.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtOtherChrg, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
            else
            {
                txtOtherChrg.Text = "0";
            }
        }

        private void txtOtherChrg2_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtOtherChrg2.Text))
            {

                errorProvider1.SetError(txtOtherChrg2, "");
                decimal numeral;
                var result = decimal.TryParse(txtOtherChrg2.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtOtherChrg2, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
            else
            {
                txtOtherChrg2.Text = "0";
            }
        }

        private void saletaxTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(saletaxTextBox.Text))
            {

                errorProvider1.SetError(saletaxTextBox, "");
                decimal numeral;
                var result = decimal.TryParse(saletaxTextBox.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(saletaxTextBox, "Please enter a decimal amount.");
                    e.Cancel = true;

                }
            }
        }

        private void txtPriceOverRide_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPriceOverRide.Text))
            {
                errorProvider1.SetError(txtPriceOverRide, "");
                if (!String.IsNullOrEmpty(txtPriceOverRide.Text))
                {
                    string price = txtPriceOverRide.Text.Replace("$", "");//must strip dollar sign
                    decimal val;
                    var result = decimal.TryParse(price, out val);
                    //non numeric
                    if (!result)
                    {
                        errorProvider1.SetError(txtPriceOverRide, "Please enter a decimal amount.");
                        e.Cancel = true;

                    }
                }
            }
        }

        private void txtreqcoverCopies_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtreqcoverCopies.Text))
            {

                errorProvider1.SetError(txtreqcoverCopies, "");
                int numeral;
                var result = int.TryParse(txtreqcoverCopies.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtreqcoverCopies, "Please enter a numeral.");
                    e.Cancel = true;

                }
            }
        }

        #endregion

        private void lblSchoolName_Paint(object sender, PaintEventArgs e)
        {
            try { this.Text = "Sales-" + lblSchoolName.Text.Trim() + " (" + this.Schcode.Trim() + ")"; }
            catch
            {

            }

        }

        private void editLookUpItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LkpDiscount frmDiscount = new LkpDiscount(this.ApplicationUser);
            this.Cursor = Cursors.AppStarting;
            frmDiscount.MdiParent = this.MdiParent;
            frmDiscount.Show();
            this.Cursor = Cursors.Default;
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            //Check if invoice exist to see what to do.
            var saveResult = Save(false);
            if (saveResult.IsError)
            {
                return;
            }
            var sqlQuery = new SQLQuery();
            var queryString = "SELECT Invno From Invoice where Invno=@Invno ";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Invno",lblInvoice.Text)
            };
            DataTable result = new DataTable();
            try
            {
                result = sqlQuery.ExecuteReaderAsync(CommandType.Text, queryString, parameters);
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error(ex.Message, "");
                return;
            }

            //refill to keep concurrency correct
            if (result.Rows.Count > 0)
            {
                DialogResult invoiceresult = MessageBox.Show("There is already an invoice created, do you want to overwrite the current invoice", "Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (invoiceresult == DialogResult.Yes)
                {
                    if (DeleteInvoice())
                    {
                        CreateInvoice();
                        this.Fill();
                    }
                }

            }
            else
            {

                txtModifiedBy.Text = this.ApplicationUser.id;
                txtModifiedByInv.Text = this.ApplicationUser.id;
                txtModifiedByInvdetail.Text = this.ApplicationUser.id;
                txtModifiedByPay.Text = this.ApplicationUser.id;
                CreateInvoice();
                this.Fill();
            }
        }

        private void txtIconCopies_Leave(object sender, EventArgs e)
        {
            int number = 0;
            int number1 = 0;
            decimal prc = 0;
            bool result = int.TryParse(perscopiesTextBox.Text, out number);
            bool result3 = int.TryParse(txtIconCopies.Text, out number1);

            bool result2 = decimal.TryParse(txtIconamt.Text, out prc);
            if (result && result2)
            {
                lblIconTot.Text = (number * prc).ToString("0.00");
                BookCalc();
            }
            else
            {
                lblIconTot.Text = "0.00";
                BookCalc();
            }
            txtNumtoPers.Text = (number1 + number).ToString();
        }
        private void oppicpersCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            SetOnlinePayOptions(this.txtPicPers.Name, this.chkPicPers.Name, chkPicPers.Checked);
        }

        private void luvlinesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!luvlinesCheckBox.Checked)
            {
                txtLuvLineAmt.Text = "0.00";
                txtLuvLineAmt.Enabled = false;
            }
            else
            {
                txtLuvLineAmt.Enabled = true;
            }
        }

        private void chkInkPers_CheckedChanged(object sender, EventArgs e)
        {
            SetOnlinePayOptions(this.txtInkPersAmt.Name, chkInkPers.Name, chkInkPers.Checked);
        }

        private void chkInkTxt_CheckedChanged(object sender, EventArgs e)
        {
            SetOnlinePayOptions(this.txtInkTxtOnly.Name, chkInkTxt.Name, chkInkTxt.Checked);

        }

        private void chkFoilIcons_CheckedChanged(object sender, EventArgs e)
        {
            SetOnlinePayOptions(this.txtFoilIcons.Name, chkFoilIcons.Name, chkFoilIcons.Checked);
        }

        private void chkFoiltxt_CheckedChanged(object sender, EventArgs e)
        {
            SetOnlinePayOptions(this.txtFoilTxt.Name, chkFoiltxt.Name, chkFoiltxt.Checked);
        }



        private void chkAllowAds_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllowAds.Checked)
            {
                txtFullAd.Enabled = true;
                txtHaldfAd.Enabled = true;
                txtQuarterAd.Enabled = true;
                txtEighthAd.Enabled = true;

            }
            else
            {
                txtFullAd.Enabled = false;
                txtHaldfAd.Enabled = false;
                txtQuarterAd.Enabled = false;
                txtEighthAd.Enabled = false;

                txtFullAd.Text = "0.00";
                txtHaldfAd.Text = "0.00";
                txtQuarterAd.Text = "0.00";
                txtEighthAd.Text = "0.00";
            }
        }

        private void bascippCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var vcheck = bascippCheckBox.Checked;
            List<TextBox> vControls = new List<TextBox>();
            List<CheckBox> vControls1 = new List<CheckBox>();
            vControls.Add(this.txtInkPersAmt);
            vControls.Add(this.txtInkTxtOnly);
            vControls.Add(this.txtFoilIcons);
            vControls.Add(this.txtFoilTxt);
            vControls.Add(this.txtPicPers);
            vControls1.Add(this.chkInkPers);
            vControls1.Add(this.chkInkTxt);
            vControls1.Add(this.chkFoilIcons);
            vControls1.Add(this.chkFoiltxt);
            vControls1.Add(this.chkPicPers);

            foreach (TextBox ctr in vControls)
            {

                if (vcheck == true)
                {
                    if (ctr.Name != bascippCheckBox.Name)
                    {
                        ctr.Enabled = false;
                        ctr.Text = "0.00";
                    }
                    else { ctr.Enabled = true; }
                }
                else
                {
                    ctr.Text = "0.00";
                    ctr.Enabled = false;
                }
            }
            foreach (CheckBox ctr1 in vControls1)
            {
                if (vcheck == true)
                {
                    if (ctr1.Name != bascippCheckBox.Name)
                    {
                        ctr1.Checked = false;
                        ctr1.Enabled = false;


                    }
                    else
                    {
                        ctr1.Enabled = true;
                    }

                }
                else
                {

                    ctr1.Enabled = true;

                }
            }
        }

        private void basicamounTextBox1_Leave(object sender, EventArgs e)
        {
            CalcOnlineTotals();
        }

        private void chkInkPers_Paint(object sender, PaintEventArgs e)
        {

        }



        private void txtInkPersAmt_Leave(object sender, EventArgs e)
        {
            CalcOnlineTotals();
        }

        private void txtInkTxtOnly_Leave(object sender, EventArgs e)
        {
            CalcOnlineTotals();
        }

        private void txtFoilIcons_Leave(object sender, EventArgs e)
        {
            CalcOnlineTotals();
        }

        private void txtFoilTxt_Leave(object sender, EventArgs e)
        {
            CalcOnlineTotals();
        }

        private void txtPicPers_Leave(object sender, EventArgs e)
        {
            CalcOnlineTotals();
        }


        private void lblProfAmt_TextChanged(object sender, EventArgs e)
        {
            CalculateEach();
        }

        private void lblConvAmt_TextChanged(object sender, EventArgs e)
        {
            CalculateEach();
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            DeleteInvoice();

        }

        private void btnOnlineAgreement_Click(object sender, EventArgs e)
        {
            List<string> address = new List<string>();
            address.Add("randy@305spin.com");
            address.Add("randy@woodalldevelopment.com");
            EmailHelper a = new EmailHelper();
            a.SendOutLookEmail("test", address, "", "This is a test.", EmailType.Mbc);


        }

        private void btnNewPayment_Click(object sender, EventArgs e)
        {
            NewPayment();
        }

        private void tabSales_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (this.tabSales.SelectedIndex == 3)
            {
                var paymentResult = SavePayment();
                if (paymentResult.IsError)
                {
                    e.Cancel = true;
                }
            }
            if (this.tabSales.SelectedIndex == 0 || this.tabSales.SelectedIndex == 1)
            {
                var salesResult = SaveSales();
                if (salesResult.IsError)
                {
                    e.Cancel = true;
                }
            }
            //if(this.tabSales.SelectedIndex == 1)
            //{
            //    MessageBox.Show("Do you want to save the online sales record? This will also save anything entered or changed on the sales tab.")
            //}
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelPayment();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditPayment();

        }

        private void btnSavePayment_Click(object sender, EventArgs e)
        {
            SavePayment();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletePayment();
        }

        private void pg4_Enter(object sender, EventArgs e)
        {
            this.paymntTableAdapter.Fill(dsInvoice.paymnt, Convert.ToInt32(lblInvoice.Text));
            SetCrudButtons();
        }

        private void pg3_Enter(object sender, EventArgs e)
        {
            try
            {
                this.invoiceTableAdapter.Fill(dsInvoice.invoice, Convert.ToInt32(lblInvoice.Text));
                //this.invCustTableAdapter.Fill(dsInvoice.cust, Schcode);
                this.invdetailTableAdapter.Fill(dsInvoice.invdetail, Convert.ToInt32(lblInvoice.Text));
                lblPayments.Text = this.paymntTableAdapter.SumPayment(Convert.ToInt32(lblInvoice.Text)).ToString();
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error("Failed to retrieve invoice information.", "");
                return;
            }
            


        }



        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            quotesBindingSource.MoveNext();

        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            quotesBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            quotesBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            quotesBindingSource.MoveLast();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        private void frmSales_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (tabSales.SelectedIndex)
            {
                case 0:
                case 1:
                    var salesResult = SaveSales();
                    if (salesResult.IsError)
                    {
                        var result = MessageBox.Show("Sales record could not be saved. Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                    break;
                case 3:
                    var paymentResult = SavePayment();
                    if (paymentResult.IsError)
                    {
                        var result = MessageBox.Show("Payment record could not be saved. Continue closing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                    break;
            }
        }

        private void frmSales_Paint(object sender, PaintEventArgs e)
                 {
            try { this.Text = "Sales-" + lblSchoolName.Text.Trim() + " (" + this.Schcode.Trim() + ")"; }
            catch
            {

            }
        }

        private void cmbYrDiscountAmt_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateEach();
            BookCalc();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();

        }

        private void reportViewer1_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
            try { reportViewer1.PrintDialog(); } catch (Exception ex) { MbcMessageBox.Error(ex.Message, ""); }

        }
        private decimal GetTaxRateOld()
        {
            if (this.SchoolZipCode == null)
            {
                return 0;
            }
            var a = this.SchoolZipCode.Trim();
            decimal val = 0;
            var sqlQuery = new SQLQuery();
            string querystring = "SELECT Rate FROM SaleTax where ZipCode=@ZipCode";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Zipcode",this.SchoolZipCode)
            };
            var result = sqlQuery.ExecuteReaderAsync<TaxRate>(CommandType.Text, querystring, parameters);
            if (result != null)
            {
                var vRateList = (List<TaxRate>)result;
                val = vRateList[0].Rate;

            }
            return val;
        }
        private decimal GetTax(decimal vAmount)
        {
            var vschname = ((DataRowView)custBindingSource.Current).Row["schname"].ToString().Trim();
            var vaddress = ((DataRowView)custBindingSource.Current).Row["InvoiceAddr"].ToString().Trim();
            var vaddress2 = ((DataRowView)custBindingSource.Current).Row["InvoiceAddr2"].ToString().Trim();
            var vcity = ((DataRowView)custBindingSource.Current).Row["InvoiceCity"].ToString().Trim();
            var vState = ((DataRowView)custBindingSource.Current).Row["InvoiceState"].ToString().Trim();
            var vzipCode = ((DataRowView)custBindingSource.Current).Row["InvoiceZipCode"].ToString().Trim();
            var vTaxingInfo = new AvaSalesTaxingInfo()
            {
                CompanyName = vschname,
                Address = vaddress,
                Address2 = vaddress2,
                City = vcity,
                State = vState,
                ZipCode = vzipCode,
                TaxableAmount = vAmount
            };

           var totalTaxCharged= TaxService.CaclulateTax(vTaxingInfo);
            lblTaxRateValue.Text = (totalTaxCharged / vAmount).ToString("0.0000");
            return totalTaxCharged;
        }

        private void donotchargeschoolsalestaxCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.CalculateEach();
            BookCalc();
        }

        private void pg1_Click(object sender, EventArgs e)
        {

        }

        private void txtIconamt_Leave(object sender, EventArgs e)
        {
            int number = 0;
            decimal prc = 0;
            bool result = int.TryParse(txtIconCopies.Text, out number);
            bool result2 = decimal.TryParse(txtIconamt.Text, out prc);
            if (result && result2)
            {
                lblIconTot.Text = (number * prc).ToString("0.00");
                BookCalc();
            }
            else
            {
                lblIconTot.Text = "0.00";
                BookCalc();
            }
        }

        private void txtIconCopies_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPoSrch_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmSales_Shown(object sender, EventArgs e)
        {
            tabSales.Visible = true;
        }

        private void chkHardBack_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnCreateWIP_Click(object sender, EventArgs e)
        {
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"
			Select Q.Invno AS QuoteInvno,Q.Schcode,P.Invno AS ProdutnInvno,C.Invno AS CoversInvno,W.Invno AS WipInvno 
			From Quotes Q
				LEFT JOIN Produtn P ON Q.Invno=P.Invno
				Left Join Covers C ON Q.Invno=C.Invno
				Left Join Wip W On Q.Invno=W.Invno
			Where Q.Invno=@Invno
			");
            sqlClient.AddParameter("@Invno", this.Invno);
            var checkResult = sqlClient.Select<WipUpdateCheck>();
            if (checkResult.IsError)
            {
                MessageBox.Show("Database error, failed to update wip.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var resultData = (WipUpdateCheck)checkResult.Data;
            var strQuery = "";
            var sqlQuery = new SQLQuery();
            if (resultData.ProdutnInvno == null)
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Invno",this.Invno),
                     new SqlParameter("@Schcode",this.Schcode),
                     new SqlParameter("@ProdNo",this.frmMain.GetProdNo()),
                      new SqlParameter("@Contryear", txtYear.Text),
                       new SqlParameter("@Company","MBC")
                    };
                strQuery = "INSERT INTO [dbo].[produtn](Invno,Schcode,Contryear,Prodno,Company)  VALUES (@Invno,@Schcode,@Contryear,@ProdNo,@Company)";
                var userResult1 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters);
                if (userResult1 != 1)
                {
                    MessageBox.Show("Failed to insert production record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            if (resultData.CoversInvno == null)
            {
                string val = "";
                //custBindingSource.MoveFirst();//make sure on first row
                DataRowView current = (DataRowView)custBindingSource.Current;
                string instructions = current["spcinst"].ToString();


                SqlParameter[] parameters2 = new SqlParameter[] {
                    new SqlParameter("@Invno",this.Invno),
                     new SqlParameter("@Schcode",this.Schcode),
                     new SqlParameter("@Specovr",frmMain.GetCoverNumber()),
                         new SqlParameter("@Specinst",instructions),
                       new SqlParameter("@Company","MBC")
                    };
                strQuery = "Insert into Covers (schcode,invno,company,specovr,Specinst) Values(@Schcode,@Invno,@Company,@Specovr,@Specinst)";
                var userResult2 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters2);
                if (userResult2 != 1)
                {
                    MessageBox.Show("Failed to insert covers record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }
            if (resultData.WipInvno == null)
            {
                SqlParameter[] parameters3 = new SqlParameter[] {
                    new SqlParameter("@Invno",this.Invno),
                     new SqlParameter("@Schcode",this.Schcode),

                    };
                strQuery = "Insert into Wip (schcode,invno) Values(@Schcode,@Invno)";
                var Result3 = sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters3);
                if (Result3 != 1)
                {
                    MessageBox.Show("Failed to insert wip record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }
            MessageBox.Show("WIP records updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void chkStory_Click_1(object sender, EventArgs e)
        {
            BookCalc();
        }

        private void cred_etcTextBox_Validating(object sender, CancelEventArgs e)
        {

        }

        private void foilamtTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(foilamtTextBox.Text))
            {
                foilamtTextBox.Text = "0";
            }
            if (!String.IsNullOrEmpty(foilamtTextBox.Text))
            {

                errorProvider1.SetError(foilamtTextBox, "");
                decimal numeral;
                var result = decimal.TryParse(foilamtTextBox.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(foilamtTextBox, "Please enter a number.");
                    e.Cancel = true;

                }
            }
        }

        private void txtIconamt_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtIconamt.Text))
            {
                txtIconamt.Text = "0";
            }
            if (!String.IsNullOrEmpty(txtIconamt.Text))
            {

                errorProvider1.SetError(txtIconamt, "");
                decimal numeral;
                var result = decimal.TryParse(txtIconamt.Text, out numeral);
                //non numeric
                if (!result)
                {
                    errorProvider1.SetError(txtIconamt, "Please enter a number.");
                    e.Cancel = true;

                }
            }
        }

        private void frmSales_Activated(object sender, EventArgs e)
        {
            try { frmMain.ShowSearchButtons(this.Name); } catch { }
        }

        private void frmSales_Deactivate(object sender, EventArgs e)
        {
            try { frmMain.HideSearchButtons(); } catch { }
        }
        public override void SchCodeSearch()
        {
            var saveResult = this.Save();
            if (saveResult.IsError)
            {

                return;
            }


            var currentSchool = this.Schcode;
            frmSearch frmSearch = new frmSearch("Schcode", "SALES", Schcode);

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                //values preserved after close

                try
                {
                    this.Invno = frmSearch.ReturnValue.Invno;
                    this.Schcode = frmSearch.ReturnValue.Schcode;
                    if (string.IsNullOrEmpty(Schcode))
                    {
                        MbcMessageBox.Hand("A search value was not returned", "Error");
                        return;
                    }
                    this.Fill();
                    DataRowView current = (DataRowView)quotesBindingSource.Current;

                    this.Invno = current["Invno"] == DBNull.Value ? 0 : Convert.ToInt32(current["Invno"]);
                    this.Schcode = current["Schcode"].ToString();
                    EnableAllControls(this);

                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }

                frmSales_Paint(this, null);
                this.Cursor = Cursors.Default;
            }
        }
        public override void SchnameSearch()
        {
            var saveResult = this.Save();
            if (saveResult.IsError)
            {

                return;
            }
            DataRowView currentrow = (DataRowView)custBindingSource.Current;
            var schname = currentrow["schname"].ToString();

            frmSearch frmSearch = new frmSearch("Schname", "SALES", schname);

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                //values preserved after close

                try
                {
                    this.Invno = frmSearch.ReturnValue.Invno;
                    this.Schcode = frmSearch.ReturnValue.Schcode;
                    if (string.IsNullOrEmpty(Schcode))
                    {
                        MbcMessageBox.Hand("A search value was not returned", "Error");
                        return;
                    }
                    this.Fill();
                    DataRowView current = (DataRowView)quotesBindingSource.Current;

                    this.Invno = current["Invno"] == DBNull.Value ? 0 : Convert.ToInt32(current["Invno"]);
                    this.Schcode = current["Schcode"].ToString();
                    EnableAllControls(this);

                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }

                frmSales_Paint(this, null);
                this.Cursor = Cursors.Default;
            }



        }
        public override void OracleCodeSearch()
        {
            var saveResult = this.Save();
            if (saveResult.IsError)
            {

                return;
            }
            DataRowView currentrow = (DataRowView)custBindingSource.Current;
            var oraclecode = currentrow["oraclecode"].ToString();

            frmSearch frmSearch = new frmSearch("OracleCode", "SALES", oraclecode);

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                //values preserved after close

                try
                {
                    this.Invno = frmSearch.ReturnValue.Invno;
                    this.Schcode = frmSearch.ReturnValue.Schcode;
                    if (string.IsNullOrEmpty(Schcode))
                    {
                        MbcMessageBox.Hand("A search value was not returned", "Error");
                        return;
                    }
                    this.Fill();
                    DataRowView current = (DataRowView)quotesBindingSource.Current;

                    this.Invno = current["Invno"] == DBNull.Value ? 0 : Convert.ToInt32(current["Invno"]);
                    this.Schcode = current["Schcode"].ToString();
                    EnableAllControls(this);

                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                frmSales_Paint(this, null);

                this.Cursor = Cursors.Default;
            }
        }
        public override void InvoiceNumberSearch()
        {
            var invno ="0";
            var saveResult = this.Save();
            if (saveResult.IsError)
            {

                return;
            }
            DataRowView currentrow = (DataRowView)quotesBindingSource.Current;
            if (currentrow!=null)
            {
                invno = currentrow["invno"].ToString();
            }
            frmSearch frmSearch = new frmSearch("INVNO", "SALES", invno);

            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                //values preserved after close

                try
                {
                    this.Invno = frmSearch.ReturnValue.Invno;
                    this.Schcode = frmSearch.ReturnValue.Schcode;
                    if (string.IsNullOrEmpty(Schcode))
                    {
                        MbcMessageBox.Hand("A search value was not returned", "Error");
                        return;
                    }
                    this.Fill();
                    DataRowView current = (DataRowView)quotesBindingSource.Current;

                    this.Invno = current["Invno"] == DBNull.Value ? 0 : Convert.ToInt32(current["Invno"]);
                    this.Schcode = current["Schcode"].ToString();
                    EnableAllControls(this);

                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                frmSales_Paint(this, null);

                this.Cursor = Cursors.Default;
            }
        }
        public override void JobNoSearch()
        {

            var saveResult = this.Save();
            if (saveResult.IsError)
            {

                return;
            }

            DataRowView currentrow = (DataRowView)quotesBindingSource.Current;
            var invno = currentrow["invno"].ToString();


            frmSearch frmSearch = new frmSearch("JOBNO", "SALES", "");



            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                //values preserved after close

                try
                {
                    this.Invno = frmSearch.ReturnValue.Invno;
                    this.Schcode = frmSearch.ReturnValue.Schcode;
                    if (string.IsNullOrEmpty(Schcode))
                    {
                        MbcMessageBox.Hand("A search value was not returned", "Error");
                        return;
                    }

                    this.Fill();
                    DataRowView current = (DataRowView)quotesBindingSource.Current;

                    this.Invno = current["Invno"] == DBNull.Value ? 0 : Convert.ToInt32(current["Invno"]);
                    this.Schcode = current["Schcode"].ToString();
                    EnableAllControls(this);

                }
                catch (Exception ex)
                {
                    MbcMessageBox.Error(ex.Message, "Error");
                    return;

                }
                frmSales_Paint(this, null);

                this.Cursor = Cursors.Default;
            }



        }


        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            var xtraInvoiceNumber = GetNewInvno();
            lblXtraInvoiceNo.Text = xtraInvoiceNumber.ToString();

            pnlInvoice.Visible = true;

            CalculateXtraInvoice();

        }
        private int GetNewInvno()
        {

            var sqlQuery = new BaseClass.Classes.SQLQuery();

            SqlParameter[] parameters = new SqlParameter[] {

                    };
            var strQuery = "SELECT Invno FROM Invcnum";
            try
            {
                DataTable userResult = sqlQuery.ExecuteReaderAsync(CommandType.Text, strQuery, parameters);
                DataRow dr = userResult.Rows[0];
                int Invno = (int)dr["Invno"];
                int newInvno = Invno + 1;
                strQuery = "Update Invcnum Set invno=@newInvno";
                SqlParameter[] parameters1 = new SqlParameter[] {
                      new SqlParameter("@newInvno",newInvno),
                    };
                sqlQuery.ExecuteNonQueryAsync(CommandType.Text, strQuery, parameters1);

                return Invno;

            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                       .SetMessage("Failed to get invoice number for a new record");

                MessageBox.Show("Failed to get invoice number for a new record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;

            }

        }
        private void CalculateXtraInvoice()
        {
            DataRowView current = (DataRowView)quotesBindingSource.Current;
            var vTaxRate = this.TaxRate;
            lblBookPrice.Text = extrbkprcTextBox1.Text;
            lblInvoiceTaxRate.Text = vTaxRate.ToString("0.000");
            decimal vBookPrice = 0;
        
            decimal vTaxTotal = 0;
            decimal vShipping = 0;
            int quantity = 0;
           
            decimal.TryParse(lblBookPrice.Text, out vBookPrice);
          
            decimal.TryParse(txtShippingCharges.Text, out vShipping);
            int.TryParse(txtQuantity.Text, out quantity);
            lblBookTotalValue.Text = (quantity * vBookPrice).ToString();
            vTaxTotal = ((quantity * vBookPrice) * vTaxRate);
            lblTaxTotal.Text = vTaxTotal.ToString("0.00");
            lblInvoiceTotal.Text = ((quantity * vBookPrice) + vTaxTotal + vShipping).ToString("0.00");
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            CalculateXtraInvoice();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            CalculateXtraInvoice();
        }

        private void lblBookPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateXtraInvoice();
        }

        private void schooltaxrateLabel2_TextChanged(object sender, EventArgs e)
        {
            CalculateXtraInvoice();
        }

        private void btnAddExtra_Click(object sender, EventArgs e)
        {

            var sqlquery = new SQLCustomClient();
            if (xtraBindingSource.Count == 0)
            {

                //insert
                var currentRow = (DataRowView)quotesBindingSource.Current;
                var price = currentRow["fbkprc"] == DBNull.Value ? 0 : Convert.ToDecimal(currentRow["fbkprc"]);
                var cmdtext = @"Insert into Xtra (SalesInvno,Schcode,Year,Extrbkprc) values(@SalesInvno,@Schcode,@Year,@Extrbkprc)";
                sqlquery.CommandText(cmdtext);
                sqlquery.AddParameter("@SalesInvno", this.Invno);
                sqlquery.AddParameter("@Schcode", this.Schcode);
                sqlquery.AddParameter("@Year", lblinvoiceYear.Text);
                sqlquery.AddParameter("@Extrbkprc", price);
                var result = sqlquery.Insert();
                if (result.IsError)
                {
                    MbcMessageBox.Error(result.Errors[0].ErrorMessage, "");
                    return;
                }
                try {xtraTableAdapter.Fill(dsExtra.xtra, Invno); } catch(Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
                this.EnableAllControls(tabSales.SelectedTab);
            }
            else
            {
                //update
                var cmdtext = @"Update Xtra 
                                    SET 
                                    [extrabooks] = @extrabooks
                                    ,[exunfinish] = @exunfinish
                                    ,[extrbkshpd] =@extrbkshpd
                                    ,[exreplshpd] = @exreplshpd
                            
                                    ,[extrbktot] = @extrbktot
                                    ,[exonhand] = @exonhand
                                    ,[extrbkprc] = @extrbkprc
                                    ,[xnotes] = @xnotes
                                    ,[room] = @room
                                    ,[shelf] = @shelf
                                    ,[rack] = @rack
                                
                                Where SalesInvno=@SalesInvno";

                sqlquery.AddParameter("@SalesInvno", Invno);
                sqlquery.AddParameter("@extrabooks", extrabooksTextBox.Text==""?"0": extrabooksTextBox.Text);
                sqlquery.AddParameter("@exunfinish", exunfinishTextBox.Text == "" ? "0" : exunfinishTextBox.Text);
                sqlquery.AddParameter("@extrbkshpd", extrbkshpdTextBox.Text == "" ? "0" : extrbkshpdTextBox.Text);
                sqlquery.AddParameter("@exreplshpd", exreplshpdTextBox.Text == "" ? "0" : exreplshpdTextBox.Text);
                
                sqlquery.AddParameter("@extrbktot", this.Schcode);
                sqlquery.AddParameter("@exonhand", lblOnHand.Text == "" ? "0" : lblOnHand.Text);
                sqlquery.AddParameter("@extrbkprc", extrbkprcTextBox1.Text== "" ? "0" : extrbkprcTextBox1.Text);
                sqlquery.AddParameter("@xnotes", xnotesTextBox.Text);
                sqlquery.AddParameter("@room", roomTextBox.Text);
                sqlquery.AddParameter("@shelf", shelfTextBox.Text);
                sqlquery.AddParameter("@rack", rackTextBox.Text);
                sqlquery.CommandText(cmdtext);
                var result = sqlquery.Update();
                if (result.IsError)
                {
                    MbcMessageBox.Error(result.Errors[0].ErrorMessage, "");
                    return;
                }

            }
        }

        private void tabSales_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (this.tabSales.SelectedIndex == 4)
            {
                if (xtraBindingSource.Count == 0)
                {
                    this.DisableControls(tabSales.SelectedTab);
                    this.EnableControls(btnAddExtra);
                }
                else
                {
                    //getinvoices
                    var sqlquery = new SQLCustomClient();
                    var cmdtext = @"Select X.SalesInvno AS SalesInvoice, I.Invno AS Invoice,CAST(I.qtedate AS date)AS InvoiceDate,I.nocopies AS Quantity,I.InvTot As Total From Xtra X 
                                    Left Join Sales_ExtraInvoice SX ON X.SalesInvno=SX.SalesInvoice
                                     Left Join Invoice I ON SX.XtraInvoice=I.Invno 
                                        Where SX.SalesInvoice=@Invno";
                    sqlquery.CommandText(cmdtext);
                    sqlquery.AddParameter("@Invno",Invno);
                   var xtraResult=sqlquery.SelectMany<XtraInvoiceGrid>();
                    if (xtraResult.IsError)
                    {
                        MbcMessageBox.Information("Failed to get Xtra Invoices", "");
                        return;
                    }
                    var vXtra = (List<XtraInvoiceGrid>)xtraResult.Data;
                    this.XrtaInvoicesGridData = vXtra;
                    XtraInvoiceBindingSource.DataSource = this.XrtaInvoicesGridData;
                    grdXtraInvoice.DataSource = XtraInvoiceBindingSource;

                }
            }
        }

        private void btnInvSrch_Click(object sender, EventArgs e)
        {

        }

        private void extrbkshpdTextBox_Leave(object sender, EventArgs e)
        {
            CalculateXtra();


        }
        private void CalculateXtra()
        {
            int vXtraBooks = 0;
            int vShippedBooks = 0;
            int vReplacementBooks = 0;
            int.TryParse(extrabooksTextBox.Text, out vXtraBooks);
            int.TryParse(extrbkshpdTextBox.Text, out vShippedBooks);
            int.TryParse(exreplshpdTextBox.Text, out vReplacementBooks);
            lblOnHand.Text = (vXtraBooks - (vShippedBooks + vReplacementBooks)).ToString();
        }

        private void extrabooksTextBox_Leave(object sender, EventArgs e)
        {
            CalculateXtra();
        }

        private void exreplshpdTextBox_Leave(object sender, EventArgs e)
        {
            CalculateXtra();
        }

        

        private void txtShippingCharges_Leave(object sender, EventArgs e)
        {
            CalculateXtraInvoice();
        }

        private void dpDateShipped_ValueChanged(object sender, EventArgs e)
        {
            dpDateShipped.Format = DateTimePickerFormat.Short;
        }

        private void btnApplyInvoice_Click(object sender, EventArgs e)
        {


            errorProvider1.SetError(txtQuantity, "");
            int vInvoiceQty = 0;
            int vInventoryQty = 0;
            int.TryParse(txtQuantity.Text, out vInvoiceQty);
            int.TryParse(lblOnHand.Text, out vInventoryQty);
            if (vInventoryQty == 0)
            {
                errorProvider1.SetError(txtQuantity, "There is no inventory to invoice.");
                return;
            }

            if (vInvoiceQty > vInventoryQty)
            {
                errorProvider1.SetError(txtQuantity, "Invoice quantity is greater than inventory quantity.");
               
                return;

            }


            var sqlquery = new SQLCustomClient();

            try
            {


                string cmdText = @"Insert into Invoice (Invno,schcode,qtedate,nopages,nocopies,book_ea,source,invtot,baldue,contryear,allclrck,SalesTax,BeforeTaxTotal,Schname,Schaddr,Schaddr2,schcity,Schstate,Schzip,DateCreated,DateModified,ModifiedBy) 
                    VALUES(@invno,@schcode,@qtedate,@nopages,@nocopies,@book_each,@source,@invtot,@baldue,@contryear,@allclrck,@SalesTax,@BeforeTaxTotal,@Schname,@Schaddr,@Schaddr2,@Schcity,@Schstate,@Schzip,GETDATE(),GETDATE(),@ModifiedBy)";
                sqlquery.CommandText(cmdText);
                sqlquery.AddParameter("@invno", lblXtraInvoiceNo.Text);
                sqlquery.AddParameter("@schcode", this.Schcode);
                sqlquery.AddParameter("@qtedate", DateTime.Now);
                sqlquery.AddParameter("@nopages", txtNoPages.Text);
                sqlquery.AddParameter("@nocopies", txtQuantity.Text);
                sqlquery.AddParameter("@book_each", lblBookPrice.Text.Replace("$", "").Replace(",", ""));
                sqlquery.AddParameter("@source", "");
                sqlquery.AddParameter("@invtot", lblInvoiceTotal.Text.Replace("$", "").Replace(",", ""));
                sqlquery.AddParameter("@baldue", lblInvoiceTotal.Text.Replace("$", "").Replace(",", ""));
                sqlquery.AddParameter("@contryear", lblinvoiceYear.Text);
                sqlquery.AddParameter("@allclrck", chkAllClr.Checked);
                sqlquery.AddParameter("@freebooks", 0);
                sqlquery.AddParameter("@SalesTax", lblTaxTotal.Text.Replace("$", "").Replace(",", ""));
                sqlquery.AddParameter("@BeforeTaxTotal", lblBookTotalValue.Text.Replace("$", "").Replace(",", ""));
                sqlquery.AddParameter("@Schname", ((DataRowView)this.custBindingSource.Current).Row["schname"].ToString().Trim());
                sqlquery.AddParameter("@Schaddr", ((DataRowView)this.custBindingSource.Current).Row["schaddr"].ToString().Trim());
                sqlquery.AddParameter("@Schaddr2", ((DataRowView)this.custBindingSource.Current).Row["schaddr2"].ToString().Trim());
                sqlquery.AddParameter("@Schcity", ((DataRowView)this.custBindingSource.Current).Row["schcity"].ToString().Trim());
                sqlquery.AddParameter("@Schstate", ((DataRowView)this.custBindingSource.Current).Row["schstate"].ToString().Trim());
                sqlquery.AddParameter("@Schzip", ((DataRowView)this.custBindingSource.Current).Row["schzip"].ToString().Trim());
                sqlquery.AddParameter("@ModifiedBy", txtModifiedByInv.Text);
                var result = sqlquery.Insert();
                if (result.IsError)
                {


                    MessageBox.Show("There was an error creating the invoice.", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                MessageBox.Show("Invoice has been created.", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sqlquery.ClearParameters();
                sqlquery.CommandText("Insert Into Sales_ExtraInvoice (SalesInvoice,XtraInvoice) Values(@SalesInvoice,@XtraInvoice)");
                sqlquery.AddParameter("@SalesInvoice", this.Invno);
                sqlquery.AddParameter("@XtraInvoice", lblXtraInvoiceNo.Text);
                var result1 = sqlquery.Insert();
                if (result.IsError)
                {

                    MessageBox.Show("There was an error creating a table link, please notify IT immediately.", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                string baseDescrip;
                if (chkAllClr.Checked)
                {
                    baseDescrip = " All color book with " + txtNoPages.Text + " Pages and " + txtNocopies.Text + " Copies";
                }
                else
                {
                    baseDescrip = "Black and White book with " + txtNoPages.Text + " Pages and " + txtNocopies.Text + " Copies";
                }
                var price = Convert.ToDecimal(lblBookTotalValue.Text.Replace("$", ""));
                sqlquery.ClearParameters();
                sqlquery.CommandText(@"INSERT INTO InvDetail (schcode,invno,descr,price,DateCreated,DateModified, ModifiedBy) 
                                       Values(@schcode,@invno,@descr,@price,GetDate(),GetDate(),@ModifiedBy)");
                sqlquery.AddParameter("@schcode", this.Schcode);
                sqlquery.AddParameter("@invno", lblXtraInvoiceNo.Text);
                sqlquery.AddParameter("@descr", baseDescrip);
                sqlquery.AddParameter("@price",price);

                sqlquery.AddParameter("@ModifiedBy", txtModifiedByInv.Text);
                var detailResult=sqlquery.Insert();
                if (detailResult.IsError) {MbcMessageBox.Error("Failed to insert invoice detail record. Contact IT.",""); }
                CalculatePayments(lblXtraInvoiceNo.Text);

            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                                .AddTags("CreateInvoice")
                                .AddObject(ex)
                                .MarkAsCritical()
                                .Submit();

                MessageBox.Show("There was an error creating the invoice.", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            finally { }
            CleanUpExtraInvoiceScreen();
            tabSales_Selecting(sender, null);
        }

           private void CleanUpExtraInvoiceScreen()
        {
            //adjust inventory
            var sqlquery = new SQLCustomClient();
            string cmdText = @"Update Xtra Set exonhand=exonhand-@extrbkshpd,extrbkshpd=extrbkshpd+@extrbkshpd where SalesInvno=@SalesInvno";
            sqlquery.CommandText(cmdText);
            sqlquery.AddParameter("@SalesInvno",Invno);
           
            sqlquery.AddParameter("@extrbkshpd",txtQuantity.Text);
            var result=sqlquery.Update();
            if (result.IsError)
            {
                MbcMessageBox.Error("Failed to update inventory.", "");
            }

            lblBookPrice.Text = "0.00";
            lblInvoiceTaxRate.Text ="0.00";
            txtQuantity.Text = "0";
            lblBookTotalValue.Text ="0.00";
            
            lblTaxTotal.Text = "0.00";
            lblInvoiceTotal.Text = "0.00";
            pnlInvoice.Visible = false;
            xtraTableAdapter.Fill(dsExtra.xtra, Invno);

        }

        private void btnCancelXtraInvoice_Click(object sender, EventArgs e)
        {
            lblBookPrice.Text = "0.00";
            lblInvoiceTaxRate.Text = "0.00";
            txtQuantity.Text = "0";
            lblBookTotalValue.Text = "0.00";

            lblTaxTotal.Text = "0.00";
            lblInvoiceTotal.Text = "0.00";
            pnlInvoice.Visible = false;
        }

        private void btnPrintXInvoice_Click(object sender, EventArgs e)
        {
            var vInvno ="0";
            try {
                    var vIndex = grdXtraInvoice.CurrentCell.RowIndex;
                    vInvno = grdXtraInvoice.Rows[vIndex].Cells[1].Value.ToString(); }
            catch (Exception ex)
            {
                MbcMessageBox.Information("Please select a invoice to be printed.", "");
                return;
            }

            var sqlquery = new SQLCustomClient();
            string cmdInvoice = @"Select invno,CAST(qtedate as date)AS qtedate,ponum,BeforeTaxTotal,SalesTax,invtot,payments From Invoice where Invno=@Invno";
            string cmdInvoiceDetail = @"Select schcode,invno,descr,price,discpercent from invdetail where Invno=@Invno ";
            sqlquery.CommandText(cmdInvoice);
            sqlquery.AddParameter("@Invno", vInvno);
            var invoiceResult = sqlquery.Select<XtraInvoicePrint>();
            if (invoiceResult.IsError)
            {
                MbcMessageBox.Error("Could not retrieve invoice information.", "");
                return;
            }
            this.XrtaInvoicePrint =(XtraInvoicePrint)invoiceResult.Data;
            bsxtraPrintInvoice.DataSource = this.XrtaInvoicePrint;

            sqlquery.ClearParameters();
            sqlquery.CommandText(cmdInvoiceDetail);
            sqlquery.AddParameter("@Invno", vInvno);
    
            var invoiceDetailResult = sqlquery.SelectMany<XtraInvoiceDetailPrint>();
            if (invoiceDetailResult.IsError)
            {
                MbcMessageBox.Error("Could not retrieve invoice detail information.", "");
                return;
            }
            this.XrtaInvoiceDetailsPrint=(List<XtraInvoiceDetailPrint>)invoiceDetailResult.Data;
            if (this.XrtaInvoiceDetailsPrint == null)
            {
                var vList = new List<XtraInvoiceDetailPrint>();
            }

            bsxtraPrintDetailInvoice.DataSource = this.XrtaInvoiceDetailsPrint;
         
            //refresh report
            this.reportViewer2.RefreshReport();


        }
        private void txtQuantity_Leave_1(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtQuantity, "");
            int vInvoiceQty = 0;
            int vInventoryQty = 0;
            int.TryParse(txtQuantity.Text, out vInvoiceQty);
            int.TryParse(lblOnHand.Text, out vInventoryQty);
            if (vInventoryQty == 0)
            {
                errorProvider1.SetError(txtQuantity, "There is no inventory to invoice.");
           
            }

            if (vInvoiceQty > vInventoryQty)
            {
                errorProvider1.SetError(txtQuantity, "Invoice quantity is greater than inventory quantity.");

          

            }



            CalculateXtraInvoice();
        }

        private void reportViewer2_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            try { reportViewer2.PrintDialog(); } catch (Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
        }

        private void dteQuote_ValueChanged(object sender, EventArgs e)
        {
            dteQuote.Format = DateTimePickerFormat.Short;
        }

        private void pg2_Click(object sender, EventArgs e)
        {

        }

        private void frmSales_KeyPress(object sender, KeyPressEventArgs e)
        {
            //set KeyPriview to True first.
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.KeyChar = (char)Keys.Tab;
                SendKeys.Send(e.KeyChar.ToString());//send the keystroke to the form.
            }

            //if ((e.KeyChar == '\r'))
            //{
            //    e.KeyChar = '\t';
            //    SendKeys.Send(e.KeyChar.ToString());
            //}
        }

        private void booktypeTextBox_Leave(object sender, EventArgs e)
        {
            var vKitrecvd = ((DataRowView)quotesBindingSource.Current).Row["kitrecvd"].ToString();

        }

        private void booktypeTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                List<string> roles =new List<string>() {"SA","Adminstratro"};
                if (ApplicationUser.IsInOneOfRoles(roles))
                {
                    booktypeTextBox.ReadOnly = false;
                }
            }
        }

        private void btnPrntInvoice_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void agreedteDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            agreedteDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void onlinecutoDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            onlinecutoDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void adcutoDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            adcutoDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            var emailHelper = new EmailHelper();
            string vsub = "Advisor Log In's for Online Parent Pay and Promotional Materials";
            string vSchcode = ((DataRowView)quotesBindingSource.Current).Row["schcode"].ToString().Trim();
            string vInvno = ((DataRowView)quotesBindingSource.Current).Row["invno"].ToString().Trim();
            string vJobNo = ((DataRowView)quotesBindingSource.Current).Row["jobno"].ToString().Trim();
            string vContEmail = ((DataRowView)custBindingSource.Current).Row.IsNull("contemail") ?"":((DataRowView)custBindingSource.Current).Row["contemail"].ToString().Trim(); 
            string vBContemail = ((DataRowView)custBindingSource.Current).Row.IsNull("bcontemail") ? "" : ((DataRowView)custBindingSource.Current).Row["bcontemail"].ToString().Trim(); 
            string vCContEmail = ((DataRowView)custBindingSource.Current).Row.IsNull("ccontemail") ? "" : ((DataRowView)custBindingSource.Current).Row["ccontemail"].ToString().Trim();
            List<string> vEmailList = new List<string>();
            if (!string.IsNullOrEmpty(vContEmail))
            {
                vEmailList.Add(vContEmail);
            }
            if (!string.IsNullOrEmpty(vBContemail))
            {
                vEmailList.Add(vBContemail);
            }
            if (!string.IsNullOrEmpty(vCContEmail))
            {
                vEmailList.Add(vCContEmail);
            }

                string vBody = @"Below please find your Online Pay Advisor access information. You can copy and paste the link below into a browser to take you to the advisor log in page. http://www.shop.memorybook.com/admin/ <br/>
                <br/>&nbsp&nbsp School Code:<b>" + vSchcode+ @"</b><br/>
                &nbsp&nbsp Password:<b>" + vInvno + @"</b><br/> <br/>
                  &nbsp&nbsp*Create the drop down list of teachers - when individuals go to order they can select their grade and teacher <br/> 
                  &nbsp&nbsp*Search for orders by order ID or Student name<br/>
                  &nbsp&nbsp*Generate a report of all orders and order information <br/><br/>
                You can order your online pay flyers and customize them by pasting the following link; https://coverorders.memorybook.com/login <br/><br/>
                User Name:<b>" + vJobNo+ @"</b><br/>
                Password:<b>Adviser</b> </br><br/> <br/>
                Once you are logged into the order center then click on yearbook promotional materials and then online pay fliers. Here you will be able to customize your flier, proof and approve it.<br/> 
                 <br/> &nbsp&nbsp*Enter school name<br/>
                 &nbsp&nbsp *Enter your Pay Code " + vSchcode+ @"<br/>
                 &nbsp&nbsp *Enter the amount you would like to charge per book<br/>
                  &nbsp&nbsp *Enter online order cutoff date<br/>
                  &nbsp&nbsp *You can also customize the text at the bottom of the flyer to include your contact information.<br/>
                You may also order additional promotional materials at this time through the order center.<br/><br/>Thank you.";

                emailHelper.SendOutLookEmail(vsub,vEmailList,null, vBody,EmailType.Mbc);


        }

        private void btnPrintAgreement_Click(object sender, EventArgs e)
        {
            decimal vtax = 0;
            decimal.TryParse(lblSalesTax.Text.Replace("$", "").Replace(",", ""), out vtax);
            decimal vtotal = 0;
            decimal.TryParse(lblFinalTotPrc.Text.Replace("$", "").Replace(",", ""), out vtotal);
            DataRowView currentrow = (DataRowView)custBindingSource.Current;
            var vSchname = currentrow["schname"].ToString();
            var AgreementHeader = new OnlineAgreementHeader()
            {
                Invno = Invno,
                PoNumber = txtPoNum.Text,
                SchCode=Schcode,
                NoCopies=txtNocopies.Text==""?"0": txtNocopies.Text,
                BeforeTaxTotal = vtotal,
                SalesTax = vtax,
                Invtot = vtotal,
                QuoteDate = dteQuote.Value,
                SchName = vSchname,
                ContactFirstName = ((DataRowView)custBindingSource.Current).Row["contfname"].ToString().Trim(),
                ContactLastName = ((DataRowView)custBindingSource.Current).Row["contlname"].ToString().Trim(),
                SchAddress = ((DataRowView)custBindingSource.Current).Row["InvoiceAddr"].ToString().Trim(),
                SchAddress2 = ((DataRowView)custBindingSource.Current).Row["InvoiceAddr2"].ToString().Trim(),
                SchCity = ((DataRowView)custBindingSource.Current).Row["InvoiceCity"].ToString().Trim(),
                SchState = ((DataRowView)custBindingSource.Current).Row["InvoiceState"].ToString().Trim(),
                SchZipCode = ((DataRowView)custBindingSource.Current).Row["InvoiceZipCode"].ToString().Trim()
            };
                bsAgreementHeader.DataSource = AgreementHeader;
                var AgreementDetails= GetDetailRecords(Invno.ToString());
                bsAgreementDetails.DataSource = AgreementDetails;
            reportViewer3.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.OnlineAgreement.rdlc";
            reportViewer3.LocalReport.DataSources.Clear();
            reportViewer3.LocalReport.DataSources.Add(new ReportDataSource("dsItemDetails",bsAgreementDetails));
            reportViewer3.LocalReport.DataSources.Add(new ReportDataSource("dsHeader", bsAgreementHeader));
            reportViewer3.LocalReport.DataSources.Add(new ReportDataSource("dsOnlinePay", quotesBindingSource));
            reportViewer3.RefreshReport();
            
        }

        private void reportViewer3_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            //try { reportViewer3.PrintDialog(); } catch(Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
           
        }

        private void btnPrntFlyer_Click(object sender, EventArgs e)
        {
            reportViewer3.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.OnlineFlyer.rdlc";
            reportViewer3.LocalReport.DataSources.Clear();
            reportViewer3.LocalReport.DataSources.Add(new ReportDataSource("dsOnlineFlyer", bsOnlineFlyer));
            //set data
                var vFlyerData = new OnlineFlyer()
                {
                    SchName = ((DataRowView)custBindingSource.Current).Row["schname"].ToString().Trim(),
                    SchCode = Schcode,
                    BasicPrice = lblOprcperbk.Text,
                    PersonalizedPrice = txtOprcperbk2.Text,
                    HasPersonalized =(chkInkPers.Checked||chkInkTxt.Checked||chkFoiltxt.Checked||chkFoilIcons.Checked||chkPicPers.Checked),
                    HasLoveLine =luvlinesCheckBox.Checked,
                    LoveLineAmt=txtLuvLineAmt.Text ,
                    HasAds=chkAllowAds.Checked ,
                    EighthAdAmt=txtEighthAd.Text ,
                    QuarterAdAmt=txtQuarterAd.Text ,
                    HalfAdAmt=txtHaldfAd.Text ,
                    FullAdAmt=txtFullAd.Text ,
                    OnlineCutoff=onlinecutoDateTimePicker.Value,
                    AdCutoff=adcutoDateTimePicker.Value
                };
                bsOnlineFlyer.DataSource = vFlyerData;

                var vPdfGenerator = new PdfAttachementGenerator();
                var result=vPdfGenerator.GenerateAttachement(reportViewer3, Schcode + "Flyer.pdf");
            if (result.IsError)
            {
                MbcMessageBox.Error(result.Errors[0].ErrorMessage, "");
                return;
            }
           var newPath = result.Data;
              var emailHelper = new EmailHelper();
                    string sub = "Online Pay Flyers";
                    string body = "Attached are Online Pay Flyers that you can copy and send out to parents.";
                    List<OutlookAttachemt> Attachements = new List<OutlookAttachemt>();
                    OutlookAttachemt Attachement = new OutlookAttachemt() { Name = Schcode + "Flyer.pdf", Path = newPath };
                    Attachements.Add(Attachement);
                    string Address=((DataRowView)custBindingSource.Current).Row["contemail"].ToString().Trim();
                    emailHelper.SendOutLookEmail(sub,Address, null, body, EmailType.Mbc,Attachements);

        }

        private void btnNoPayPo_Click(object sender, EventArgs e)
        {
            ReminderEmails("Half");
        }

        private void btnPaymentNotRec_Click(object sender, EventArgs e)
        {
            ReminderEmails("NoPaymentRec5");
           
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ReminderEmails("Removing5");
        }

        private void holdpmtCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetNoticeLabels();
        }




        //Nothing below here
    }
    public class XtraInvoiceGrid
    {
        public decimal SalesInvoice { get; set; }
        public int Invoice { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
    public class XtraInvoicePrint
    {
        public int invno { get; set; }
        public DateTime qtedate { get; set; }
        public string ponum { get; set; }
        public decimal BeforeTaxTotal { get; set; }
        public decimal SalesTax { get; set; }
        public decimal invtot { get; set; }
        public decimal payments { get; set; }
    }
    public class XtraInvoiceDetailPrint
    {
        public decimal invno { get; set; }
        public string schcode { get; set; }
        public string descr { get; set; }
        public decimal price { get; set; }
        public string discpercent { get; set; }
    }

}


    
