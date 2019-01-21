using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BindingModels;
using BaseClass.Classes;
namespace Mbc5.Forms.MemoryBook
{
    public partial class frmInvoicInq : BaseClass.Forms.bTopBottom
    {
        public frmInvoicInq(UserPrincipal userPrincipal) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
        }
        private void SetConnectionString()
        {
            frmMain frmMain = (frmMain)this.MdiParent;

        }

        private void dtShipDate_ValueChanged(object sender, EventArgs e)
        {
           dtShipDate.Format = DateTimePickerFormat.Long;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //search for bad addresses
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"
                SELECT I.schname AS InvoiceSchoolName,C.schname As CustomerSchname, I.schcode AS SchoolCode
                ,I.BalDue,P.invno As InvoiceNumber
                FROM Cust C Left Join Quotes Q On C.Schcode=Q.Schcode
                Left Join Produtn P On Q.Invno=P.Invno  
                Left Join Invoice I On Q.Invno =I.invno 
                WHERE(P.Shpdate IS NOT NULL )
                AND(I.BalDue > 0)
                AND((RTRIM(C.Schname) != RTRIM(I.Schname)) 
                OR(RTRIM(C.Schaddr) != RTRIM(I.Schaddr)) 
                OR(RTRIM(C.Schstate) != RTRIM(I.Schstate)))
                ORDER BY I.Schname
                ");
         var result = sqlClient.SelectMany<InvoiceCheck>();
         var badRecords = (List <InvoiceCheck>) result;
            if (badRecords!=null && badRecords.Count > 0)
            {
                MessageBox.Show("The following sales records have customer information errors in them and need invoice over rides done on them before you can proceed.", "Bad Address");
                var errorList = new BindingList<InvoiceCheck>(badRecords);
                dgAddressErrors.DataSource = errorList;
            }





       

      
        }
    }
    public class InvoiceCheck
    {
        public string InvoiceSchoolName { get; set; }
        public string CustomerSchname { get; set; }
        public string SchoolCode { get; set; }
        public decimal BalDue { get; set; }
    }
}
