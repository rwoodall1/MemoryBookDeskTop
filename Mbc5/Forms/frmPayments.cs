using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass;
using BaseClass.Classes;
using BaseClass.Core;
using BindingModels;
namespace Mbc5.Forms
{
    public partial class frmPayments : BaseClass.Forms.bTopBottom
    {
        public frmPayments(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
        }

        private List<PaymentQuery> PaymentRecords { get; set; }
        public frmMain frmMain { get; set; }
        private void frmPayments_Load(object sender, EventArgs e)
        {
            this.PaymentRecords = new List<PaymentQuery>();
            frmMain frmMain = (frmMain)this.MdiParent;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            paymentBindingSource.Clear();
            var sqlQuery = new SQLCustomClient();
            sqlQuery.ClearParameters();
        string cmdMBCText = @"SELECT P.Invno,P.PmtDate,P.Payment,C.SchName,C.SchEmail,C.ContEmail,C.Schcode 
                                From Cust C
                                LEFT JOIN Quotes Q ON C.Schcode=Q.Schcode
                                LEFT JOIN Paymnt P On Q.Invno=P.Invno
                                WHERE P.PmtDate=@PaymentDate and P.Payment>0
                                Order By P.Invno";
           string cmdMERText= @"SELECT P.Invno,P.PmtDate,P.Payment,C.SchName,C.SchEmail,C.ContEmail,C.Schcode 
                                From MCust C
                                LEFT JOIN MQuotes Q ON C.Schcode=Q.Schcode
                                LEFT JOIN Paymnt P On Q.Invno=P.Invno
                                WHERE P.PmtDate=@PaymentDate and P.Payment>0
                                Order By P.Invno";
            if (rdMemorybook.Checked)
            {
                sqlQuery.CommandText(cmdMBCText);
            }else if (rdMeridian.Checked)
            {
                sqlQuery.CommandText(cmdMERText);
            }
            sqlQuery.AddParameter("@Paymentdate", dbPaymentDate.Date);
            var result=sqlQuery.SelectMany<PaymentQuery>();
            if (result.IsError)
            {
                MbcMessageBox.Error(result.Errors[0].ErrorMessage);
                return;
            }
            this.PaymentRecords = (List<PaymentQuery>)result.Data;
            paymentBindingSource.DataSource = PaymentRecords;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            paymentBindingSource.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var EmailHelper = new EmailHelper();
            foreach(var rec in PaymentRecords)
            {
                if (rec.Print) {
                    string subject = "Payment Received For Invoice #" + rec.Invno.ToString() + " by Jostens";
                    string body = @"A payment was received for Invoice #" + rec.Invno.ToString() + @"
                    in the amount of " + rec.Payment.ToString() + @".<br/> <br/> Please note, you are receiving this notification because we've received your check or
                   online payment. <br/> <br/><br/> We appreciate your business!";
                    var vAddresses = new List<String>();
                    if (!string.IsNullOrEmpty(rec.SchEmail))
                    {
                        vAddresses.Add(rec.SchEmail.Trim());
                    }
                    if (!string.IsNullOrEmpty(rec.ContEmail))
                    {
                        vAddresses.Add(rec.ContEmail.Trim());
                    }
                    var vEmailType = EmailType.Mbc;
                    if (rdMemorybook.Checked)
                    {
                        vEmailType = EmailType.Mbc;
                    }
                    else if (rdMeridian.Checked)
                    {
                        vEmailType = EmailType.Meridian;
                    }
                    else {
                        MbcMessageBox.Warning("Select a company before emailing.", "");
                        return; }
                    EmailHelper.SendOutLookEmail(subject, vAddresses, null, body, vEmailType);
                }
            }

        }

        private void rdMemorybook_CheckedChanged(object sender, EventArgs e)
        {
            paymentBindingSource.Clear();
        }

        private void rdMeridian_CheckedChanged(object sender, EventArgs e)
        {
            paymentBindingSource.Clear();
        }

       
    }
}
