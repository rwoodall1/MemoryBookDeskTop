using BaseClass;
using BaseClass.Classes;
using BindingModels;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace Mbc5.Forms.Tukios
{
    public partial class frmTukiosCaseMatch : BaseClass.frmBase
    {
        public frmTukiosCaseMatch(UserPrincipal userPrincipal, frmMain frmMain) : base(new string[] { }, userPrincipal)
        {
            InitializeComponent();
            ApplicationUser = userPrincipal;

        }
        public int CoverCount { get; set; }
        public UserPrincipal ApplicationUser { get; set; }
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
            string _company = TextBox1.Text.Substring(0, 3).ToUpper();
            if (_company != "TUK")
            {
                MbcMessageBox.Information("This is not a Tukios barcode. Please scan another barcode.");
                TextBox1.Clear();
                TextBox1.Focus();
                return;
            }
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
                    string vInvno = TextBox1.Text.Substring(3, TextBox1.Text.Length - 5);
                    var chkResult = CheckStatus(vInvno);
                    if (!chkResult)
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
                    var result = InsertWip(vInvno);
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
            if (TextBox1.Text.Length < 3)
            {
                return;
            }
            try
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
            catch (Exception ex)
            {
                Log.Error("Error removing scan (Invno:" + TextBox1.Text + ") : " + ex.Message);
            }
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
        private bool InsertWip(string vInvno)
        {

            var sqlClient = new SQLCustomClient();
            string cmdText = @"
                                SELECT TO1.ShipName,TO1.ClientOrderId,TO1.Invno,TO1.BookId,TO1.Backing,TO1.ShipMethod,TO1.CoverURL,TO1.BookBlockURL,TO1.Copies As Quantity,P.ProdNo,C.Specovr
                                From TukiosOrder TO1 Left Join Produtn P ON TO1.Invno=P.Invno Left Join Covers C ON TO1.Invno=C.Invno
                                Where TO1.Invno=@Invno
                                ";
            sqlClient.CommandText(cmdText);
            sqlClient.AddParameter("@Invno", vInvno);
            var result = sqlClient.Select<TukiosBarScanModel>();
            if (result.IsError)
            {
                MessageBox.Show(result.Errors[0].ErrorMessage, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Failed to insert wip (casein)" + result.Errors[0].ErrorMessage);
                return false;
            }
            TukiosBarScanModel TukModel = (TukiosBarScanModel)result.Data;

            if (result.Data == null)
            {
                MessageBox.Show("Record was not found.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            WhipCheck(TukModel);
            sqlClient.ClearParameters();
            //war is datetime
            //wir is initials
            string vDeptCode = "49";
            string vWIR = "CI";
            sqlClient.AddParameter("@Invno", vInvno);
            sqlClient.AddParameter("@DescripID", vDeptCode);

            sqlClient.AddParameter("@WIR", vWIR);

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
            sqlClient.CommandText(@"Update TukiosOrder Set BookStatus=@BookStatus where Invno=@Invno");
            sqlClient.AddParameter("@Invno", vInvno);
            sqlClient.AddParameter("@BookStatus", "CaseMatch");
            var updateresult = sqlClient.Update();
            if (updateresult.IsError)
            {
                Log.Error("Failed to update book status:(" + this.Invno.ToString() + ")" + updateresult.Errors[0].DeveloperMessage);
            }

            return true;
        }
        private bool CheckStatus(string vInvno)
        {
            var sqlClient = new SQLCustomClient().CommandText("Select TukiosOrderStatus From TukiosOrder Where Invno=@Invno").AddParameter("@Invno", vInvno);
            var sqlResult = sqlClient.SelectSingleColumn();
            if (sqlResult.IsError)
            {
                Log.Error("Error retrieving Order Status for casein:" + sqlResult.Errors[0].DeveloperMessage);
                return false;

            }
            string vStatus = sqlResult.Data;
            if (vStatus == "Cancelled" || vStatus == "Hold" || vStatus == "Shipped")
            {
                System.IO.Stream str = Properties.Resources.Whistling;
                System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);

                for (var i = 0; i < 3; i++)
                {
                    snd.Play();
                }
                MbcMessageBox.Hand("This order status is " + vStatus + " Notify supervisor", "Status");
                return false;
            }
            return true;


        }
        private void WhipCheck(TukiosBarScanModel TukModel)
        {
            var sqlClient = new SQLCustomClient();
            sqlClient.ClearParameters();
            sqlClient.ReturnSqlIdentityId(true);
            sqlClient.AddParameter("@Invno", this.Invno);
            sqlClient.AddParameter("@DescripID", "29");
            sqlClient.AddParameter("@WAR", DateTime.Now);
            sqlClient.AddParameter("@WIR", "SYS");

            sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                                Begin
                                                INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                                END
                                                ");
            var result12 = sqlClient.Insert();
            if (result12.IsError)
            {

                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert corrective scan.", result12.Errors[0].DeveloperMessage);

            }
            sqlClient.ClearParameters();
            sqlClient.ReturnSqlIdentityId(true);
            sqlClient.AddParameter("@Invno", this.Invno);
            sqlClient.AddParameter("@DescripID", "43");
            sqlClient.AddParameter("@WAR", DateTime.Now);
            sqlClient.AddParameter("@WIR", "SYS");
            ;
            sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                            Begin
                                            INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                            END
                                            ");

            var result112 = sqlClient.Insert();
            if (result112.IsError)
            {

                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert corrective scan.", result112.Errors[0].DeveloperMessage);

            }
            sqlClient.ClearParameters();
            sqlClient.ReturnSqlIdentityId(true);
            sqlClient.AddParameter("@Invno", this.Invno);
            sqlClient.AddParameter("@DescripID", "39");
            sqlClient.AddParameter("@WAR", DateTime.Now);
            sqlClient.AddParameter("@WIR", "SYS");
            sqlClient.CommandText(@" IF NOT EXISTS (Select tmp.Invno,tmp.DescripID from WipDetail tmp WHERE tmp.Invno=@Invno and tmp.DescripID=@DescripID) 
                                            Begin
                                            INSERT INTO WipDetail (DescripID,War,Wir,Invno) VALUES(@DescripID,@WAR,@WIR,@Invno);
                                            END
                                            ");

            var result1123 = sqlClient.Insert();
            if (result1123.IsError)
            {

                Log.WithProperty("Property1", this.ApplicationUser.UserName).Error("Failed to insert corrective scan.", result1123.Errors[0].DeveloperMessage);

            }

        }
    }
}

