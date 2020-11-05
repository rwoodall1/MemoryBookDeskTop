using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mbc5.Classes;
using BaseClass;
using System.Media;
using BaseClass.Classes;
using BindingModels;
namespace Mbc5.Forms.MixBook
{
    public partial class frmCaseMatch : BaseClass.frmBase
    {
        public frmCaseMatch(UserPrincipal userPrincipal, frmMain frmMain) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();

        }
        public int CoverCount { get; set; }
        private void Button2_Click(object sender, EventArgs e)
        {
            Button2.BackColor = Color.Green;
            Button3.BackColor = Color.Transparent;
            this.BackColor = SystemColors.Control;
            TextBox1.Focus();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (CoverCount == 0)
            {
                MbcMessageBox.Information("You Must Scan a Cover first");
                TextBox1.Focus();
            }

            Button3.BackColor = Color.Green;
            Button2.BackColor = Color.Transparent;
            this.BackColor = SystemColors.Control;
            TextBox1.Focus();
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (chkRemoveScan.Checked)
            {
                RemoveScan();
                return;
            }
            if (Button2.BackColor != Color.Green && Button3.BackColor != Color.Green)
            {
                MbcMessageBox.Information("Please select either Scan Covers or Scan Book Blocks");
            }
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                return;
            }
            if (Button2.BackColor == Color.Green && TextBox1.Text.Substring(TextBox1.Text.Length - 2, 2) == "SC")
            {
                listBox1.Items.Add(TextBox1.Text);
                CoverCount += 1;
                TextBox1.Clear();
                TextBox1.Focus();
                listBox1.Refresh();
            }
            else if (Button2.BackColor == Color.Green)
            {
                MbcMessageBox.Information("This is not a Cover barcode. Please scan another Cover.");
                TextBox1.Clear();
                TextBox1.Focus();
                listBox1.Refresh();
            }

            if (Button3.BackColor == Color.Green && TextBox1.Text.Substring(TextBox1.Text.Length - 2, 2) == "YB")//Is book
            {
                if (TextBox1.Text.Substring(0, TextBox1.Text.Length - 2) == listBox1.Items[0].ToString().Substring(0, listBox1.Items[0].ToString().Length - 2))//matches first cover in list
                {
                    var result = InsertWip();
                    if (result)
                    {
                        listBox1.Items.RemoveAt(0);
                        CoverCount -= 1;
                        if (CoverCount == 0)
                        {
                            Button3.BackColor = Color.Transparent;
                        }
                        TextBox1.Clear();
                        TextBox1.Focus();
                        listBox1.Refresh();
                    }
                }
                else
                {
                    //does not match first cover in list
                    Button3.BackColor = Color.Red;
                    System.IO.Stream str = Properties.Resources.Whistling;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);

                    for (var i = 0; i < 3; i++)
                    {
                        snd.Play();
                    }
                    MbcMessageBox.Stop("DO NOT PROCEED. BOOK DOES NOT MATCH COVER", "Warning");
                    this.BackColor = Color.Gray;
                }

            }
            else if (Button3.BackColor == Color.Green)
            {
                MbcMessageBox.Information("This is not a Book barcode. Please scan another Book.");
                TextBox1.Clear();
                TextBox1.Focus();
                listBox1.Refresh();
            }
        }
        private void RemoveScan()
        {
            string vInvno = TextBox1.Text.Substring(3, TextBox1.Text.Length - 5);

            var sqlClient = new SQLCustomClient();
            string cmdText = @"
                            Delete from WipDetail Where Invno=@Invno and DescripId=@DescripId
                            ";
            sqlClient.CommandText(cmdText);
            string vDeptCode = "49";
            sqlClient.AddParameter("@Invno", vInvno);
            sqlClient.AddParameter("@DescripID", vDeptCode);
            var result = sqlClient.Delete();
            if (result.IsError)
            {
                MessageBox.Show("Failed to remove scan:" + result.Errors[0].DeveloperMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Failed to remove scan:" + result.Errors[0].DeveloperMessage);
                return;
            }
            chkRemoveScan.Checked = false;
            TextBox1.Clear();
            TextBox1.Focus();
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                TextBox1.Focus();
            }
            else
            {
                listBox1.Items.RemoveAt(0);
                CoverCount -= 1;
                TextBox1.Focus();
            }

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                TextBox1.Focus();
            }
            else
            {
                listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                CoverCount -= 1;
                TextBox1.Focus();
            }
        }
        private bool InsertWip()
        {
            string vInvno = TextBox1.Text.Substring(3, TextBox1.Text.Length - 5);
            var sqlClient = new SQLCustomClient();
            string cmdText = @"
                            SELECT M.ShipName,M.ClientOrderId,M.ItemId,M.JobId,M.Invno,M.Backing,M.ShipMethod,M.CoverPreviewUrl,M.BookPreviewUrl,M.Copies As Quantity,P.ProdNo,C.Specovr
                            From MixBookOrder M Left Join Produtn P ON M.Invno=P.Invno Left Join Covers C ON M.Invno=C.Invno
                            Where M.Invno=@Invno
                            ";
            sqlClient.CommandText(cmdText);
            sqlClient.AddParameter("@Invno", vInvno);
            var result = sqlClient.Select<MixBookBarScanModel>();
            if (result.IsError)
            {
                MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Failed to insert wip (casein)" + result.Errors[0].ErrorMessage);
                return false;
            }
            MixBookBarScanModel MbxModel = (MixBookBarScanModel)result.Data;

            if (result.Data == null)
            {
                MessageBox.Show("Record was not found.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            sqlClient.ClearParameters();
            //war is datetime
            //wir is initials
            string vDeptCode = "49";
            string vWIR = "CI";
            sqlClient.AddParameter("@Invno", vInvno);
            sqlClient.AddParameter("@DescripID", vDeptCode);

            sqlClient.AddParameter("@WIR", vWIR);
            sqlClient.AddParameter("@Jobno", MbxModel.JobId);
            sqlClient.CommandText(@"Update WIPDetail SET
                                WAR=GetDate(),WIR =@WIR WHERE Invno=@Invno AND DescripID=@DescripID ");

            var mxResult2 = sqlClient.Update();
            if (mxResult2.IsError)
            {
                MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Failed to update scan." + mxResult2.Errors[0].DeveloperMessage);
                return false;
            }
            sqlClient.ClearParameters();
            sqlClient.ReturnSqlIdentityId(true);
            sqlClient.AddParameter("@Invno", vInvno);
            sqlClient.AddParameter("@DescripID", vDeptCode);
            sqlClient.AddParameter("@WIR", vWIR);
            sqlClient.AddParameter("@Jobno", MbxModel.JobId);
            sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                    Begin
                                    INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,GETDATE(),@WIR,@Invno);
                                    END
                                    ");

            var result2 = sqlClient.Insert();
            if (result2.IsError)
            {
                MessageBox.Show("Failed to insert scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Failed to insert scan." + result2.Errors[0].DeveloperMessage);
                return false;
            }
            sqlClient.ClearParameters();
            sqlClient.CommandText(@"Update MixbookOrder Set CoverStatus=@BookStatus where Invno=@Invno");
            sqlClient.AddParameter("@Invno", this.Invno);
            sqlClient.AddParameter("@BookStatus", "CaseMatch");
            sqlClient.Update();
            return true;
        }
    }
}
