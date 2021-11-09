using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseClass.Classes;
using Mbc5.Dialogs;
using Mbc5.Classes;
using BaseClass;
using System.Diagnostics;
using Microsoft.Reporting.WinForms;
using BindingModels;
using System.Drawing.Printing;
using NLog;
namespace Mbc5.Forms.MixBook
{
    public partial class frmMBOrders : BaseClass.frmBase
    {
        public frmMain frmMain { get; set; }
        public frmMBOrders(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator", "MixBook" }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
        }
        public frmMBOrders(UserPrincipal userPrincipal, int clientId) : base(new string[] { "SA", "Administrator", "MixBook" }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
            this.OrderId = clientId;
        }

        public int OrderId { get; set; } = 0;
        public UserPrincipal ApplicationUser { get; set; }
        private void MBOrders_Load(object sender, EventArgs e)
        {
            if (this.ApplicationUser.UserName.ToUpper() == "TAMMY" || this.ApplicationUser.UserName.ToUpper() == "HILARY") 
            {
                this.pnlRemake.Visible = true;
            }
            this.pnlOrder.Enabled = false;
            this.frmMain = (frmMain)this.MdiParent;
            this.btnEdit.Enabled = ApplicationUser.IsInRole("MixBook") ? false : true;
            btnDownloadFiles.Enabled = ApplicationUser.IsInRole("MixBook") ? false : true;
            SetConnectionString();
            this.Invno = 0;
            if (OrderId > 0)
            {
                Fill();
            }
        }

        private void mixBookOrderBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.mixBookOrderBindingSource.EndEdit();

                this.mixBookOrderTableAdapter.Update(dsmixBookOrders.MixBookOrder);
                this.pnlOrder.Enabled = false;
            }
            catch (Exception ex)
            {
                // var a = dsmixBookOrders.Tables["MixBookOrder"].GetErrors();
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Failed to update order,INVNO:" + Invno.ToString());
            }
            this.Fill();
        }

        
        private void SetConnectionString()
        {
            try
            {
                this.statesTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
                this.mixBookOrderTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
                this.shipCarriersTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
                
            }
            catch (Exception ex)
            {
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Failed to set Mixbook orders connection strings");

            }
        }
        #region Search
        private void OrderIdSearch()
        {
            string vcurrentOrderId = "0";
            if (mixBookOrderBindingSource.Current!=null)
            {
                try
                {
                    vcurrentOrderId = ((DataRowView)mixBookOrderBindingSource.Current).Row["ClientOrderId"].ToString();
                }
                catch (Exception ex) { Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "OrderId not found. Mixbook OrderId Search"); }
            }
            

            frmSearch frmSearch = new frmSearch("OrderId", "MixBook", vcurrentOrderId);
            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    var retOrderId = frmSearch.ReturnValue.OrderId;            //values preserved after close
                    
                    if (string.IsNullOrEmpty(retOrderId))
                    {
                        BaseClass.MbcMessageBox.Hand("A search value was not returned", "Error");
                    }
                    else
                    {
                        int iOrderId = 0;
                        if (int.TryParse(retOrderId, out iOrderId))
                        {
                           
                           
                            this.OrderId = iOrderId;
                            Fill();   
                        }
                        else
                        {
                            MbcMessageBox.Hand("A valid search value was not returned", "");

                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Failed to search Order Id");
                }
            }

        }
        private void ItemIdSearch()
        {
            string vcurrentItemId = "";
            if (mixBookOrderBindingSource.Current!=null) {
                try
                {
                    if (mixBookOrderBindingSource.Current!=null) {
                        vcurrentItemId = ((DataRowView)mixBookOrderBindingSource.Current).Row["ItemId"].ToString();
                    }
                }
                catch (Exception ex) { Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Failed to search Item Id"); }
            }

            frmSearch frmSearch = new frmSearch("ITEMID", "MixBook", vcurrentItemId);
            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                var retOrderId = frmSearch.ReturnValue.OrderId;            //values preserved after close
                if (string.IsNullOrEmpty(retOrderId))
                {
                    BaseClass.MbcMessageBox.Hand("A search value was not returned", "Error");
                }
                else
                {
                    int iOrderId = 0;
                    if (int.TryParse(retOrderId, out iOrderId))
                    {
                        this.OrderId = iOrderId;
                        Fill();
                    }
                    else { MbcMessageBox.Hand("A valid search value was not returned", ""); }
                }
            }
        }
        private void OrderNameSearch()
        {
            string vcurrentName = "";
            try
            {
                if (mixBookOrderBindingSource.Current!=null) {
                    vcurrentName = ((DataRowView)mixBookOrderBindingSource.Current).Row["ShipName"].ToString(); }
            }
            catch (Exception ex) { Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Failed to search Order Name"); }

            frmSearch frmSearch = new frmSearch("SHIPNAME", "MixBook", vcurrentName);
            var result = frmSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                var retOrderId = frmSearch.ReturnValue.OrderId;            //values preserved after close
                if (string.IsNullOrEmpty(retOrderId))
                {
                    BaseClass.MbcMessageBox.Hand("A search value was not returned", "Error");
                }
                else
                {
                    int iOrderId = 0;
                    if (int.TryParse(retOrderId, out iOrderId))
                    {
                        this.OrderId = iOrderId;
                        Fill();
                    }
                    else { MbcMessageBox.Hand("A valid search value was not returned", ""); }
                }
            }
        }

        #endregion
        #region "Methods"
        private void Remake(string remakeType)
        {
            string vreasonCode = "";
            InputBox.Show("Reason Code", "Enter a reason code",ref vreasonCode);

            if (string.IsNullOrEmpty(vreasonCode))
            {
                MbcMessageBox.Stop("Invalid reason code","Reason Code");
                return;
            }
            if (vreasonCode.Length > 2)
            {
                MbcMessageBox.Stop("Invalid Reason Code", "Reason Code");
                return;
            }
            int vReason = 0;
            if (!int.TryParse(vreasonCode, out vReason))
            {
                MbcMessageBox.Error("Invalid reason code.");
                return;
            }
            string vQuantity = "";
            InputBox.Show("Quantity", "Number of remakes", ref vQuantity);

            if (string.IsNullOrEmpty(vQuantity))
            {
                MbcMessageBox.Stop("Enter a quantity", "Quantity");
                return;
            }
            int vRemakeQuantity = 0;
            if (!int.TryParse(vQuantity, out vRemakeQuantity))
            {
                MbcMessageBox.Error("Invalid Quantity");
                return;
            }
            if (vRemakeQuantity == 0)
            {
                MbcMessageBox.Error("Quantity can not be zero");
                return;
            }
            
            var sqlClient = new SQLCustomClient();
           
            //insure we have correct invno, should already be set
            if (this.Invno.ToString() != invnoLabel1.Text.Trim())
            {
                MbcMessageBox.Stop("The invoice number does not match the system invoice number. Re-search the record and try again.", "Invoice# Error");
                return;
            }
             
            if (remakeType == "CVR")
            {
                sqlClient.ClearParameters();
                sqlClient.CommandText(@"Delete From COVERDETAIL Where INVNO=@Invno");
                sqlClient.AddParameter("@Invno", this.Invno);

                var deleteResult = sqlClient.Delete();
                if (deleteResult.IsError)
                {
                    MbcMessageBox.Error("Failed to remove cover scans for this order. Try again or contact a supervisor.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to remove cover scans for this order. Try again or contact a supervisor." + deleteResult.Errors[0].DeveloperMessage);
                    return;
                }

                sqlClient.ClearParameters();
                sqlClient.CommandText(@"UPDATE COVERS SET  Reprntdte=GETDATE(),FullRemake=@FullRemake,remake=1,RemakeReason=@RemakeReason,persondest=@persondest,specinst=@Memo +' | ' + CAST(COALESCE(specinst,'') as varchar) Where INVNO=@Invno");
                string vmemo = "Remake issued by:" + ApplicationUser.UserName.ToUpper() + " on " + DateTime.Now.ToString();
                sqlClient.AddParameter("@Memo", vmemo);
                sqlClient.AddParameter("FullRemake", vRemakeQuantity);
                sqlClient.AddParameter("@persondest", ApplicationUser.UserName.ToUpper());
                sqlClient.AddParameter("@Invno", this.Invno);
                if (vReason == 0)
                {
                    MbcMessageBox.Error("Invalid reason code.");
                    return;
                }
                sqlClient.AddParameter("@RemakeReason", vReason);
                var updateResult = sqlClient.Update();
                if (updateResult.IsError)
                {
                    MbcMessageBox.Error("Failed to update cover reprint date.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update cover reprint date:" + updateResult.Errors[0].DeveloperMessage);
                    return;
                }

                sqlClient.ClearParameters();
                sqlClient.CommandText(@"Update MixbookOrder SET CoverStatus='',CurrentCoverLoc='' where Invno=@Invno");
                sqlClient.AddParameter("@Invno", Invno);
                var updateResult11 = sqlClient.Update();
                if (updateResult11.IsError)
                {
                    MbcMessageBox.Error("Failed to update Order remake data.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update Mixbook Order Remake Data SC:" + updateResult11.Errors[0].DeveloperMessage);
                    return;
                }
                vreasonCode=null;
                vQuantity = null;
            }
            else if (remakeType == "BK")
            {
                sqlClient.ClearParameters();
                sqlClient.CommandText(@"Delete From WIPDETAIL Where INVNO=@Invno");
                sqlClient.AddParameter("@Invno", this.Invno);
                var deleteResult = sqlClient.Delete();
                if (deleteResult.IsError)
                {
                    MbcMessageBox.Error("Failed to remove wip scans for this order. Try again or contact a supervisor.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to remove wip scans for this order:" + deleteResult.Errors[0].DeveloperMessage);
                    return;
                }

                sqlClient.ClearParameters();
                string vmemo = "Remake issued by:" + ApplicationUser.UserName.ToUpper() +" on "+DateTime.Now.ToString();
                sqlClient.CommandText(@"UPDATE WIP SET  RmbTo=GETDATE(),RmbTot=@RmbTot,iinit=@iinit,RemakeReason=@RemakeReason,WipMemo=@Memo + ' | ' + CAST(COALESCE(WipMemo,' ') as varchar) Where INVNO=@Invno");
                sqlClient.AddParameter("@iinit", ApplicationUser.UserName.ToUpper());
                sqlClient.AddParameter("@Invno", this.Invno);
                sqlClient.AddParameter("@RmbTot", vRemakeQuantity);
                sqlClient.AddParameter("@Memo", vmemo);
                if (vReason == 0)
                {
                    MbcMessageBox.Error("Invalid reason code.");
                    return;
                }
                sqlClient.AddParameter("@RemakeReason", vReason);
                var updateResult = sqlClient.Update();
                if (updateResult.IsError)
                {
                    MbcMessageBox.Error("Failed to update wip remake date.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update wip remake date:" + updateResult.Errors[0].DeveloperMessage);
                    return;
                }

                sqlClient.ClearParameters();
                sqlClient.CommandText(@"Update MixbookOrder SET BookStatus='',CurrentBookLoc='',RemakeTicketPrinted=0 where Invno=@Invno");
                sqlClient.AddParameter("@Invno", Invno);
                var updateResul1t = sqlClient.Update();
                if (updateResul1t.IsError)
                {
                    MbcMessageBox.Error("Failed to update Order remake data.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to update Mixbook Order Remake Data YB:" + updateResul1t.Errors[0].DeveloperMessage);
                    return;
                }

            }
            vreasonCode = null;
            vQuantity = null;
        }
        public override void Fill()
        {
            pnlOrder.Enabled = false;
            if (OrderId == 0)
            {
                dsmixBookOrders.MixBookOrder.Clear();
                return;
            }
            try
            {
                this.statesTableAdapter.Fill(this.lookUp.states);
                this.shipCarriersTableAdapter.Fill(this.dsmixBookOrders.ShipCarriers);
                int vIInvno = 0;
                mixBookOrderTableAdapter.Fill(dsmixBookOrders.MixBookOrder, OrderId);
                string vSInvno = ((DataRowView)mixBookOrderBindingSource.Current).Row["Invno"].ToString();
                int.TryParse(vSInvno, out vIInvno);
                this.Invno = vIInvno;
            }
            catch (Exception ex)
            {
                MbcMessageBox.Error(ex.Message);
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Failed to fill mixbook orders data adapters,INVNO:" + Invno.ToString());
            }
        }
        private void PrintJobTicket()
        {
            
            var value =((DataRowView)mixBookOrderBindingSource.Current).Row["Invno"].ToString();
                var sqlClient = new SQLCustomClient().CommandText(@"
                Select Invno,ClientOrderId,
                ShipName,RequestedShipDate,
                SUBSTRING(CAST(Invno as varchar),1,7)+'   X'+SUBSTRING(CAST(Invno as varchar),8,LEN(CAST(Invno as varchar))-7) AS DSInvno,
                (Select Sum(Copies) from mixbookorder where Clientorderid=MO.clientOrderid )As NumToShip,
                Description,
                Copies,Pages,
                Backing,OrderReceivedDate,
                ProdInOrder,'*MXB'+CAST(Invno as varchar)+'SC*' AS SCBarcode,
                '*MXB'+CAST(Invno as varchar)+'YB*' AS YBBarcode
                From MixBookOrder MO  Where Invno=@Invno
            "); 

                sqlClient.AddParameter("@Invno", value);

                var result = sqlClient.Select<JobTicketQuery>();
                if (result.IsError)
                {
                    MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to retieve orders for JobTicketQuery:" + result.Errors[0].DeveloperMessage);
                    return;
                }
                var jobData = (JobTicketQuery)result.Data;
                if (jobData!=null)
                {
                    reportViewer3.LocalReport.DataSources.Clear();
                    JobTicketQueryBindingSource.DataSource = jobData;

                reportViewer3.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", JobTicketQueryBindingSource));
                    reportViewer3.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixbookJobTicketSingle.rdlc";
                    this.reportViewer3.RefreshReport();
                }
                else
                {
                    MbcMessageBox.Hand("There were no records found to print.", "No Records");
                }
            }
        private void PrintPackingList(int vClientOrderId)
        {
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Select MO.Invno,MO.ShipName,MO.ShipAddr,MO.ShipAddr2,MO.ShipCity,MO.ShipState,'*MXB'+CAST(MO.Invno AS varchar)+'YB*' AS BarCode
                                ,MO.ShipZip,MO.OrderNumber,MO.ClientOrderId,MO.Copies,Mo.Pages,Mo.Description,Mo.ItemCode,MO.JobId,MO.ItemId, SC.ShipName AS ShipMethod,SC.Carrier,CD.MxbLocation AS CoverLocation,WD.MxbLocation As BookLocation
                                FROM MixbookOrder MO
                                Left Join ShipCarriers SC On MO.ShipMethod=SC.ShipAlias
                                Left Join CoverDetail CD On MO.Invno=CD.Invno AND CD.DescripId IN (Select TOP 1 DescripId From coverdetail where  COALESCE(mxbLocation,'')!='' AND Invno=MO.Invno  Order by DescripId desc )
                                Left Join WipDetail WD On MO.Invno=WD.Invno AND WD.DescripId IN (Select TOP 1 DescripId From wipdetail where  COALESCE(mxbLocation,'')!='' AND Invno=MO.Invno  Order by DescripId desc ) 
                                Where ClientOrderId=@ClientOrderId");
            sqlClient.AddParameter("@ClientOrderId", vClientOrderId);
            var result = sqlClient.SelectMany<MixbookPackingSlip>();
            if (result.IsError || result.Data == null)
            {
                MbcMessageBox.Error("Failed to retrieve order, packing slip could not be printed");
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to print packing list:" + result.Errors[0].DeveloperMessage);
                return;
            }
            var packingSlipData = (List<MixbookPackingSlip>)result.Data;
            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixBookPkgList.rdlc";
            reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("dsMxPackingSlip", packingSlipData));
            reportViewer2.RefreshReport();
        }
        private void PrintRemakeTicket(int vInvno)
        {

            var sqlClient = new SQLCustomClient().CommandText(@"
                Select MO.Invno,ClientOrderId,
                SUBSTRING(CAST(MO.Invno as varchar),1,7)+'   X'+SUBSTRING(CAST(Mo.Invno as varchar),8,LEN(CAST(Mo.Invno as varchar))-7) AS DSInvno,
                 MO.ShipName,MO.RequestedShipDate,MO.Description,MO.Copies,MO.Pages,MO.Backing,MO.OrderReceivedDate,MO.ProdInOrder,'*MXB'+CAST(MO.Invno as varchar)+'SC*' AS SCBarcode,
                    (Select Sum(Copies) from mixbookorder where Clientorderid=MO.clientOrderid )As NumToShip,
                 '*MXB'+CAST(MO.Invno as varchar)+'YB*' AS YBBarcode,W.Rmbto AS RemakeDate,W.Rmbtot As RemakeTotal
                    From MixBookOrder MO LEFT JOIN WIP W ON MO.Invno=W.INVNO
                Where MO.Invno=@Invno
            ");
            sqlClient.AddParameter("@Invno", vInvno);
            var result = sqlClient.Select<RemakeTicketQuery>();
            if (result.IsError)
            {
                MbcMessageBox.Error("Failed to retrieve order, remake ticket could not be printed");
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to retrieve order, remake ticket could not be printed:" + result.Errors[0].DeveloperMessage);
                return;
            }
            if (result.Data == null)
            {
                MbcMessageBox.Error("There are no records availble to print.");
                return;
            }

            var remakeData = (RemakeTicketQuery)result.Data;
            reportViewer3.LocalReport.DataSources.Clear();
            MixbookRemakeBindingSource.DataSource = remakeData;
            reportViewer3.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", MixbookRemakeBindingSource));
            reportViewer3.LocalReport.ReportEmbeddedResource = "Mbc5.Reports.MixBookRemakeTicketSingle.rdlc";
            this.reportViewer3.RefreshReport();
        }
        private void SetJobTicketPrinted()
        {

            var sqlClient = new SQLCustomClient().CommandText(@"Update MixbookOrder Set JobTicketPrinted=@SetJobTicketPrinted Where Invno=@Invno");
           

                var vInvno = this.Invno.ToString();
                sqlClient.ClearParameters();
                sqlClient.AddParameter("@Invno", vInvno);
                sqlClient.AddParameter("@SetJobTicketPrinted", 1);
                var updateResult = sqlClient.Update();
            
        }
        private void SetRemakeTicketPrinted()
        {
            var sqlClient = new SQLCustomClient().CommandText(@"Update MixbookOrder Set RemakeTicketPrinted=@RemakeTicketPrinted Where Invno=@Invno");
           

                var vInvno = this.Invno.ToString();
                sqlClient.ClearParameters();
                sqlClient.AddParameter("@Invno", vInvno);
                sqlClient.AddParameter("@RemakeTicketPrinted", 1);
                var updateResult = sqlClient.Update();
        
        }
        #endregion


        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            OrderIdSearch();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OrderNameSearch();
        }

        private void mixBookOrderBindingSource_PositionChanged(object sender, EventArgs e)
        {
            int vIInvno = 0;
            string vSInvno = ((DataRowView)mixBookOrderBindingSource.Current).Row["Invno"].ToString();
            int.TryParse(vSInvno, out vIInvno);
            this.Invno = vIInvno;
        }

        private void mixBookOrderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mixBookOrderDataGridView.CurrentCell.ColumnIndex.Equals(6) || mixBookOrderDataGridView.CurrentCell.ColumnIndex.Equals(7))
                if (mixBookOrderDataGridView.CurrentCell != null && mixBookOrderDataGridView.CurrentCell.Value != null)
                {
                    try
                    { Process.Start(mixBookOrderDataGridView.CurrentCell.Value.ToString()); }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Url is invalid.");
                        Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "Url is invalid.");
                    }
                }
            if (mixBookOrderDataGridView.CurrentCell.ColumnIndex.Equals(0))
            {

            }

        }

        private void mixBookOrderDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            int vInvno = this.Invno;
            string vSchcode = "01";
            frmProdutn frmProdutn = new frmProdutn(this.ApplicationUser, vInvno, vSchcode);
            frmProdutn.MdiParent = this.MdiParent;
            frmProdutn.Show();
            this.Cursor = Cursors.Default;
        }

        private void mixBookOrderDataGridView_Enter(object sender, EventArgs e)
        {
            if (mixBookOrderDataGridView.CurrentRow!=null) {
                try
                {
                    var value = (int)mixBookOrderDataGridView.CurrentRow.Cells[1].Value;
                    this.Invno = value;
                }
                catch (Exception ex) { Log.WithProperty("Property1", this.ApplicationUser.UserName).Error(ex, "OrderDataGridview Enter Error,INVNO:" + Invno.ToString()); }
            }
        }
        private void itemIdToolStripBtn_Click(object sender, EventArgs e)
        {
            ItemIdSearch();
        }

        private void shipMethodComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void shipMethodComboBox_DropDown(object sender, EventArgs e)
        {
            MbcMessageBox.Information("Check WIP screen to be sure 'Binding' has not been scanned.");
        }

        private void mixBookOrderDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                e.Value = "Cover.pdf";
            }
            if (e.ColumnIndex == 7)
            {
                e.Value = "Book.pdf";
            }
        }

        private void btnMixbookPkgList_Click(object sender, EventArgs e)
        {
           
            int vClientOrderId = 0;
            int.TryParse(orderIdLabel1.Text, out vClientOrderId);
            if (vClientOrderId == 0)
            {
                MbcMessageBox.Error("Client Id is not in proper format");
                return;
            }
            PrintPackingList(vClientOrderId);
        }
       
        private void reportViewer2_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            PrinterSettings printerName = new PrinterSettings();
            string printer = printerName.PrinterName;
            DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN

            var result = dp.Export(reportViewer2.LocalReport, printer, 1, false);

            if (result.IsError)
            {
                var errorResult = MessageBox.Show("Printing Error:" + result.Errors[0].ErrorMessage, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Printing Error:" + result.Errors[0].ErrorMessage);
            }

            Cursor.Current = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pnlOrder.Enabled == true)
            {
                pnlOrder.Enabled = false;
            }
            else { pnlOrder.Enabled = true; }

        }

        private void btnDownloadFiles_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(orderIdLabel1.Text))
            {
                var sqlClient = new SQLCustomClient();
                sqlClient.CommandText(@"Update MixbookOrder Set FilesDownloaded=0 where ClientOrderId=@ClientOrderId");
                sqlClient.AddParameter("@ClientOrderId", orderIdLabel1.Text);
                var result = sqlClient.Update();
                if (result.IsError)
                {
                    MbcMessageBox.Error("Failed to iniated download of files, try again or contact developer.");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to iniated download of files:" + result.Errors[0].DeveloperMessage);
                    return;
                }
            }
        }

        private void btnRemake_Click(object sender, EventArgs e)
        {
            int vInvno = 0;
            int.TryParse(invnoLabel1.Text, out vInvno);
            if (Invno == 0)
            {
                MbcMessageBox.Error("Invoice number is not valid");
                return;
            }
            PrintRemakeTicket(vInvno);
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            PrinterSettings printerName = new PrinterSettings();
            string printer = printerName.PrinterName;
            DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN

            var result = dp.Export(reportViewer1.LocalReport, printer, 1, false);

            if (result.IsError)
            {
                var errorResult = MessageBox.Show("Printing Error:" + result.Errors[0].ErrorMessage, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Printing Error:" + result.Errors[0].ErrorMessage);
            }
            Cursor.Current = Cursors.Default;
        }

        private void purgeStripButton2_Click(object sender, EventArgs e)
        {
            if (orderIdLabel1.Text == "") { return; }

            var dialogResult = MessageBox.Show("This will remove all traces of this record from the system, are you sure you want to do this?", "Purge", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dialogResult == DialogResult.Yes)
            {

                var sqlClient = new SQLCustomClient();
                sqlClient.CommandText(@"Delete From MixbookOrder Where ClientOrderId=@ClientOrderId");
                sqlClient.AddParameter("@ClientOrderId", orderIdLabel1.Text);
                var deleteResult = sqlClient.Delete();
                if (deleteResult.IsError)
                {
                    MbcMessageBox.Error("Failed to purge order");
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to purge order" + deleteResult.Errors[0].DeveloperMessage);
                    return;
                }
                sqlClient.ClearParameters();
                sqlClient.CommandText("Delete From Produtn Where MxbClientOrderId=@ClientOrderId");
                sqlClient.AddParameter("@ClientOrderId", orderIdLabel1.Text);
                var deleteResult1 = sqlClient.Delete();
                if (deleteResult1.IsError)
                {
                    MbcMessageBox.Error("Failed to purge Production record.");
                    return;
                }
                sqlClient.ClearParameters();
                sqlClient.CommandText("Delete From WipDetail Where Invno=@Invno");
                sqlClient.AddParameter("@Invno", orderIdLabel1.Text.Substring(0, 7));
                var deleteResult11 = sqlClient.Delete();
                if (deleteResult11.IsError)
                {
                    MbcMessageBox.Error("Failed to purge Wip records.");
                    return;
                }
                sqlClient.ClearParameters();
                sqlClient.CommandText("Delete From CoverDetail Where Invno=@Invno");
                sqlClient.AddParameter("@Invno", orderIdLabel1.Text.Substring(0, 7));
                var deleteResult111 = sqlClient.Delete();
                if (deleteResult111.IsError)
                {
                    MbcMessageBox.Error("Failed to purge cover records.");
                    return;
                }
                MbcMessageBox.Information("Order has been purged");
                this.OrderId = 0;
                Fill();
            }
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(invnoLabel1.Text)|| string.IsNullOrEmpty(mixbookOrderStatusLabel2.Text))
            {
                return;
            }
            var sqlClient = new SQLCustomClient();
            string status = "";
            if (mixbookOrderStatusLabel2.Text=="Hold")
            {
                sqlClient.AddParameter("@OrderStatus","In Process");
                status = "In Process";
            }
            else if(mixbookOrderStatusLabel2.Text == "In Process")
            {
                sqlClient.AddParameter("@OrderStatus", "Hold");
                status = "Hold";

            }
            else
            {
                MbcMessageBox.Information("Status can not be changed if Cancelled or Shipped.");
                return;
            }
         
            sqlClient.CommandText("Update MixbookOrder Set MixbookOrderStatus=@OrderStatus Where Invno=@Invno");
            sqlClient.AddParameter("@Invno", invnoLabel1.Text);
                 var result = sqlClient.Update();
            if (result.IsError)
            {
                MbcMessageBox.Error("Failed to change status:" + result.Errors[0].DeveloperMessage);
                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to change hold status:" + result.Errors[0].DeveloperMessage);
                return;
            }
            MbcMessageBox.Exclamation("Status has been changed to " +status);
            Fill();
        }

        private void cmdJobTicket_Click(object sender, EventArgs e)
        {
            PrintJobTicket();
        }

        private void reportViewer3_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            if (reportViewer3.LocalReport.ReportEmbeddedResource == "Mbc5.Reports.MixbookJobTicketSingle.rdlc")
            {
                try
                {

                    if (reportViewer3.PrintDialog() != DialogResult.Cancel)
                    {
                        SetJobTicketPrinted();
                    }
                }
                catch (Exception ex) {
                    Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("PrintJobTicketSingle" + ex.Message);
                }
            }
            else
            {
                //Remake Ticket
                if (reportViewer3.PrintDialog() != DialogResult.Cancel)
                {
                    SetRemakeTicketPrinted();
                }
            }
        }

        private void pnlOrder_EnabledChanged(object sender, EventArgs e)
        {
            foreach (Control c in   this.pnlOrder.Controls)
            {
               if(c is TextBox||c is ComboBox||c is CustomControls.DateBox)
                {
                    c.BackColor = Color.White;
                }
            }

        }

        private void btnCvrRemake_Click(object sender, EventArgs e)
        {
            Remake("CVR");
        }

        private void btnBkRemake_Click(object sender, EventArgs e)
        {
            Remake("BK");
        }

       
    }
}
