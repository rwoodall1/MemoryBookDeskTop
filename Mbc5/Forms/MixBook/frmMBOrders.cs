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
                Log.Error(ex, "Failed to update order,INVNO:" + Invno.ToString());
            }
            this.Fill();
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
                Log.Error(ex, "Failed to fill mixbook orders data adapters,INVNO:" + Invno.ToString());
            }
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
                Log.Error(ex, "Failed to set Mixbook orders connection strings");

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
                catch (Exception ex) { Log.Error(ex, "OrderId not found. Mixbook OrderId Search"); }
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
                    Log.Error(ex, "Failed to search Order Id");
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
                catch (Exception ex) { Log.Error(ex, "Failed to search Item Id"); }
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
            catch (Exception ex) { Log.Error(ex, "Failed to search Order Name"); }

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
                        Log.Error(ex, "Url is invalid.");
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
                catch (Exception ex) { Log.Error(ex, "OrderDataGridview Enter Error,INVNO:" + Invno.ToString()); }
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
                Log.Error("Failed to print packing list:" + result.Errors[0].DeveloperMessage);
                return;
            }
            var packingSlipData = (List<MixbookPackingSlip>)result.Data;
            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("dsMxPackingSlip", packingSlipData));
            reportViewer2.RefreshReport();
        }
        private void PrintRemakeTicket(int vInvno)
        {
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"Select MO.Invno,MO.ShipName,MO.ShipAddr,MO.ShipAddr2,MO.ShipCity,MO.ShipState,'*MXB'+CAST(MO.Invno AS varchar)+'YB*' AS BarCode,'Book'As Item
                                    ,MO.ShipZip,MO.OrderNumber,MO.ClientOrderId,MO.Copies,Mo.Pages,Mo.Description,Mo.ItemCode,MO.JobId,MO.ItemId, SC.ShipName AS ShipMethod,WD.MxbLocation As Location,MO.RequestedShipDate
                                    FROM MixbookOrder MO
                                    Left Join ShipCarriers SC On MO.ShipMethod=SC.ShipAlias
                                    Left Join WipDetail WD On MO.Invno=WD.Invno AND WD.DescripId IN (Select TOP 1 DescripId From wipdetail where  COALESCE(mxbLocation,'')!='' AND Invno=MO.Invno  Order by DescripId desc ) 
                                    Where MO.Invno=@Invno
                                    UNION
                                    Select MO.Invno,MO.ShipName,MO.ShipAddr,MO.ShipAddr2,MO.ShipCity,MO.ShipState,'*MXB'+CAST(MO.Invno AS varchar)+'SC*' AS BarCode,'Cover'As Item
                                    ,MO.ShipZip,MO.OrderNumber,MO.ClientOrderId,MO.Copies,Mo.Pages,Mo.Description,Mo.ItemCode,MO.JobId,MO.ItemId, SC.ShipName AS ShipMethod,CD.MxbLocation AS Location,MO.RequestedShipDate
                                    FROM MixbookOrder MO
                                    Left Join ShipCarriers SC On MO.ShipMethod=SC.ShipAlias
                                    Left Join CoverDetail CD On MO.Invno=CD.Invno AND CD.DescripId IN (Select TOP 1 DescripId From coverdetail where  COALESCE(mxbLocation,'')!='' AND Invno=MO.Invno  Order by DescripId desc )
                                    Where MO.Invno=@Invno");
            sqlClient.AddParameter("@Invno", vInvno);
            var result = sqlClient.SelectMany<MixbookRemakeTicket>();
            if (result.IsError || result.Data == null)
            {
                MbcMessageBox.Error("Failed to retrieve order, remake ticket could not be printed");
                Log.Error("Failed to retrieve order, remake ticket could not be printed:" + result.Errors[0].DeveloperMessage);
                return;
            }

            var packingSlipData = (List<MixbookRemakeTicket>)result.Data;
            MixbookRemakeBindingSource.DataSource = packingSlipData;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsMixBookRemakeTkt", MixbookRemakeBindingSource));
            reportViewer1.RefreshReport();
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
                Log.Error("Printing Error:" + result.Errors[0].ErrorMessage);
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
                    Log.Error("Failed to iniated download of files:" + result.Errors[0].DeveloperMessage);
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
                Log.Error("Printing Error:" + result.Errors[0].ErrorMessage);
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
                    Log.Error("Failed to purge order" + deleteResult.Errors[0].DeveloperMessage);
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
                Log.Error("Failed to change hold status:" + result.Errors[0].DeveloperMessage);
                return;
            }
            MbcMessageBox.Exclamation("Status has been changed to " +status);
            Fill();
        }
    }
}
