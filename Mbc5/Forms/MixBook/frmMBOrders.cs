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
        
        public int OrderId { get; set; }
        public UserPrincipal ApplicationUser { get; set; }
        private void MBOrders_Load(object sender, EventArgs e)
        {
            this.frmMain = (frmMain)this.MdiParent;
            SetConnectionString();
            this.Invno = 0;
            SetConnectionString();
            // TODO: This line of code loads data into the 'lookUp.states' table. You can move, or remove it, as needed.
            try { this.statesTableAdapter.Fill(this.lookUp.states); } catch (Exception ex)
            {
                MbcMessageBox.Error("Failed to load States dropdown");
            }


           
        }
        private void SetConnectionString()
        {
           
            statesTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            mixBookOrderTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
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
            int vIInvno = 0;
            mixBookOrderTableAdapter.Fill(dsmixBookOrders.MixBookOrder, OrderId);
          string vSInvno  = ((DataRowView)mixBookOrderBindingSource.Current).Row["Invno"].ToString();
            int.TryParse(vSInvno, out vIInvno);
            this.Invno = vIInvno;
        }
        private void SetConnectionString()
        {
            frmMain frmMain = (frmMain)this.MdiParent;
            this.statesTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            this.mixBookOrderTableAdapter.Connection.ConnectionString = frmMain.AppConnectionString;
            

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
            if (mixBookOrderDataGridView.CurrentCell.ColumnIndex.Equals(5)|| mixBookOrderDataGridView.CurrentCell.ColumnIndex.Equals(6))
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
    }
}
