﻿using System;
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
namespace Mbc5.Forms.MixBook
{
    public partial class frmMBOrders : BaseClass.frmBase
    {
        public new frmMain frmMain { get; set; }
        public frmMBOrders(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator" }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
        }
        public frmMBOrders(UserPrincipal userPrincipal,int clientId) : base(new string[] { "SA", "Administrator" }, userPrincipal)
        {
            InitializeComponent();
            this.ApplicationUser = userPrincipal;
            this.OrderId = clientId;
        }

        public int OrderId { get; set; } = 0;
        public UserPrincipal ApplicationUser { get; set; }
        private void MBOrders_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsmixBookOrders.ShipCarriers' table. You can move, or remove it, as needed.
            
            this.frmMain = (frmMain)this.MdiParent;
            SetConnectionString();
            this.Invno = 0;
           
            // TODO: This line of code loads data into the 'lookUp.states' table. You can move, or remove it, as needed.
           
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
                this.tableAdapterManager.UpdateAll(this.dsmixBookOrders);
            }catch(Exception ex) { }
            this.Fill();
            
        }

        public override void Fill()
        {
            try
            {
                this.statesTableAdapter.Fill(this.lookUp.states);
                this.shipCarriersTableAdapter.Fill(this.dsmixBookOrders.ShipCarriers);
                int vIInvno = 0;
                mixBookOrderTableAdapter.Fill(dsmixBookOrders.MixBookOrder, OrderId);
                string vSInvno = ((DataRowView)mixBookOrderBindingSource.Current).Row["Invno"].ToString();
                int.TryParse(vSInvno, out vIInvno);
                this.Invno = vIInvno;
            }catch(Exception ex)
            {
                MbcMessageBox.Error(ex.Message);
            }
        }
        private void SetConnectionString()
        {
            try
            {
               
                this.statesTableAdapter.Connection.ConnectionString =  frmMain.AppConnectionString;
                this.mixBookOrderTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
                this.shipCarriersTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            }catch(Exception ex) {

               
            }

           
        }
        #region Search
        private void OrderIdSearch()
        {
            string vcurrentOrderId = "0";
            try
            {
                vcurrentOrderId = ((DataRowView)mixBookOrderBindingSource.Current).Row["OrdereId"].ToString();
            }
            catch { }
            
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
                        else { MbcMessageBox.Hand("A valid search value was not returned", ""); }


                    }
                }
                catch (Exception ex) { }
            }

        }
        private void ItemIdSearch()
        {
            string vcurrentItemId = "";
            try
            {
                vcurrentItemId = ((DataRowView)mixBookOrderBindingSource.Current).Row["ItemId"].ToString();
            }
            catch { }

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
                vcurrentName = ((DataRowView)mixBookOrderBindingSource.Current).Row["ShipName"].ToString();
            }
            catch { }

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
            if (mixBookOrderDataGridView.CurrentCell.ColumnIndex.Equals(6)|| mixBookOrderDataGridView.CurrentCell.ColumnIndex.Equals(7))
                if (mixBookOrderDataGridView.CurrentCell != null && mixBookOrderDataGridView.CurrentCell.Value != null)
                {
                    
                    try
                    { Process.Start(mixBookOrderDataGridView.CurrentCell.Value.ToString()); }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Url is invalid.");
                    }
                    ;
                }
            if (mixBookOrderDataGridView.CurrentCell.ColumnIndex.Equals(0))
            {
                MessageBox.Show("test");
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
            try
            {
                var value = (int)mixBookOrderDataGridView.CurrentRow.Cells[0].Value;
                this.Invno = value;
            }catch(Exception ex) { }
        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //    this.reportViewer1.DataBindings.Clear();
            //this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsmixBookOrders", mixBookOrderBindingSource));
   
            this.reportViewer1.RefreshReport();
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
            if (e.ColumnIndex == 6 )
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
            sqlClient.CommandText(@"Select MO.Invno,MO.ShipName,MO.ShipAddr,MO.ShipAddr2,MO.ShipCity,MO.ShipState,'*MBX'+CAST(MO.Invno AS varchar)+'YB*' AS BarCode
            ,MO.ShipZip,MO.OrderNumber,MO.ClientOrderId,MO.Copies,Mo.Pages,Mo.Description,Mo.ItemCode,MO.JobId,MO.ItemId, SC.ShipName AS ShipMethod,CD.MxbLocation AS CoverLocation
            FROM MixbookOrder MO
               Inner Join ShipCarriers SC On MO.ShipMethod=SC.ShipAlias
                Left Join CoverDetail CD On MO.Invno=CD.Invno AND CD.DescripId IN (Select TOP 1 DescripId From coverdetail where  COALESCE(mxbLocation,'')!='' AND Invno=MO.Invno  Order by DescripId desc ) Where ClientOrderId=@ClientOrderId");
            sqlClient.AddParameter("@ClientOrderId", vClientOrderId);
            var result = sqlClient.SelectMany<MixbookPackingSlip>();
            if (result.IsError || result.Data == null)
            {
                MbcMessageBox.Error("Failed to retrieve order, packing slip could not be printed");
                return;
            }
            var packingSlipData = (List<MixbookPackingSlip>)result.Data;
            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("dsMxPackingSlip", packingSlipData));
            reportViewer2.RefreshReport();
        }

        private void reportViewer2_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            PrinterSettings printerName = new PrinterSettings();
            string printer = printerName.PrinterName;
            DirectPrint dp = new DirectPrint(); //this is the name of the class added from MSDN

            var result = dp.Export(reportViewer2.LocalReport, printer, true);

            if (result.IsError)
            {
                var errorResult = MessageBox.Show("Printing Error:" + result.Errors[0].ErrorMessage, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            Cursor.Current = Cursors.Default;
        }
    }
}
