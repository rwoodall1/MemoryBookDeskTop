using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass;
using BaseClass.Classes;
using Exceptionless;

namespace Mbc5.Dialogs
{
    public partial class frmTeleLogModify : BaseClass.Forms.bTopBottom
    {
        public frmTeleLogModify(int vLogId)
        {
            LogId = vLogId;
            InitializeComponent();
        }
        public frmTeleLogModify()
        {
         
            InitializeComponent();
        }

        private void datecontBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.datecontBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsDateCont);

        }

        private int LogId=0;

        private void frmTeleLogModify_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lookUp.lkpMktReference' table. You can move, or remove it, as needed.
            this.lkpMktReferenceTableAdapter.Fill(this.lookUp.lkpMktReference);
            // TODO: This line of code loads data into the 'lookUp.lkpTypeCont' table. You can move, or remove it, as needed.
            this.lkpTypeContTableAdapter.Fill(this.lookUp.lkpTypeCont);
            // TODO: This line of code loads data into the 'lookUp.lkpPromotions' table. You can move, or remove it, as needed.
            this.lkpPromotionsTableAdapter.Fill(this.lookUp.lkpPromotions);
            var sqlquery = new SQLCustomClient();
            sqlquery.CommandText(@"Select Schcode,DateCont,Reason,Initial,Contact,TypeCont,NxtDays,CallCont,CallTime,Priority,Company,TechCall,Id Where Id=@Id");
            sqlquery.AddParameter("@Id",LogId);
            var contactResult=sqlquery.Select<TelephonLogRecord>();
            if (contactResult.IsError)
            {
                MbcMessageBox.Error("Failed to retrieve Telephone Log record","");
                ExceptionlessClient.Default.CreateLog("Failed to retrieve Telephone Log record")
                      .AddObject(contactResult)
                        .Submit();


            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
    public class TelephonLogRecord
    {
        public string Schcode { get; set; }
        public DateTime Datecont { get; set; }
        public string Reason { get; set; }
        public string Initials { get; set; }
        public string Contact { get; set; }
        public string TypeContact { get; set; }
        public int NxtDays { get; set; }
        public bool CallCont { get; set; }
        public int CallTime { get; set; }
        public int Priority { get; set; }
        public string Company { get; set; }
        public bool TechCall { get; set; }
        public int Id { get; set; }



    }
}
