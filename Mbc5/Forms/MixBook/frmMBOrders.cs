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
namespace Mbc5.Forms.MixBook
{
    public partial class frmMBOrders : BaseClass.frmBase
    {
        public frmMBOrders(UserPrincipal userPrincipal) : base(new string[] { "SA", "Administrator" }, userPrincipal)
        {
            InitializeComponent();
        }
        
        public int OrderId { get; set; }
        private void MBOrders_Load(object sender, EventArgs e)
        {
            this.Invno = 0;
            // TODO: This line of code loads data into the 'lookUp.states' table. You can move, or remove it, as needed.
            try { this.statesTableAdapter.Fill(this.lookUp.states); } catch (Exception ex)
            {
                MbcMessageBox.Error("Failed to load States dropdown");
            }


        }
        private void mixBookOrderBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.mixBookOrderBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsmixBookOrders);
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
                    } else { MbcMessageBox.Hand("A valid search value was not returned", ""); }


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
    }
}
