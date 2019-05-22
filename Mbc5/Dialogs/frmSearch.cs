using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseClass.Classes;
using BaseClass;
namespace Mbc5.Forms.MemoryBook {
	public partial class frmSearch : Form {
		public frmSearch(string vSearchType, string vForm, string vcurrentSearchValue) {
			this.SearchType = vSearchType.ToUpper();
			this.ReturnForm = vForm.ToUpper();
			currentSearchValue = vcurrentSearchValue.Trim();
			InitializeComponent();

			//SearchType:
			//Schcode
			//Schname
			//Jobno
			//Invoice
			//Production

		}
		private int CurrentIndex { get; set; }
		private string SearchType { get; set; }
		private string ReturnForm { get; set; }
		private List<SchcodeSearch> CustCode { get; set; }
		private List<SchnameSearch> CustName { get; set; }
		public string ReturnValue { get; set; }

		private string currentSearchValue;

		private void frmSearch_Load(object sender, EventArgs e) {
			this.Cursor = Cursors.AppStarting;

			var sqlclient = new SQLCustomClient();
			string cmdtext = "";
			switch (SearchType) {
				case "SCHCODE":
					this.Text = "School code Search";
					switch (ReturnForm) {
						case "CUST":
							cmdtext = @"Select C.Schcode,C.Schname,C.Contryear,C.SchZip,C.SchState From Cust C Order By Schcode";
							sqlclient.CommandText(cmdtext);
							var result = sqlclient.SelectMany<SchcodeSearch>();
							var Cust = (List<SchcodeSearch>)result.Data;
							this.CustCode = Cust;
							bsData.DataSource = this.CustCode;
							break;
						case "SALES":
							cmdtext = @"Select Q.Schcode,C.Schname,Q.Invno,C.SchZip,C.SchState From QUOTES Q LEFT JOIN Cust C On Q.Schcode=C.Schcode Order By Schcode";
							break;
						case "PRODUCTION":
							cmdtext = @"Select C.Schcode,C.Schname,Q.Contryear,P.ProdNo,Q.Invno From Cust Order By Schcode";
							break;
						case "BIDS":
							cmdtext = @"Select Schcode,Schname,Contryear From Cust Order By Schcode";
							break;
						default:
							MbcMessageBox.Hand("Search is not implemented here.", "");

							break;

					}
					break;
				case "SCHNAME":
					this.Text = "School Name Search";
					switch (ReturnForm) {
						case "CUST":
							cmdtext = @"Select C.Schname,C.Schcode,C.Contryear,C.SchZip,C.SchState From Cust C Order By Schname";
							sqlclient.CommandText(cmdtext);
							var result = sqlclient.SelectMany<SchnameSearch>();
							var Cust = (List<SchnameSearch>)result.Data;
							this.CustName = Cust;
							dgSearch.DataSource = this.CustName;
							dgSearch.Select();
							txtSearch.Select();

							break;
						case "SALES":
							break;
						case "PRODUCTION":
							break;
						case "BIDS":
							break;

					}
					break;
				case "JOBNO":
					this.Text = "Job # Search";
					switch (ReturnForm) {
						case "CUST":
							break;
						case "SALES":
							break;
						case "PRODUCTION":
							break;


					}
					break;
				case "INVOICE":
					this.Text = "Invoice # Search";
					switch (ReturnForm) {
						case "CUST":
							break;
						case "SALES":
							break;
						case "PRODUCTION":
							break;

					}
					break;
				case "PRODUCTION":
					switch (ReturnForm) {
						case "CUST":
							break;
						case "SALES":
							break;
						case "PRODUCTION":
							break;
						case "COVERS":
							break;


					}
					break;


			}
			this.Cursor = Cursors.Default;

			//txtSearch.Text = currentSearchValue;


			//Search(currentSearchValue);

		}
		private void Search(string value) {
			int vIndex;
			switch (SearchType) {

				case "SCHCODE":
					vIndex = this.CustCode.FindIndex(vcust => vcust.Schcode.ToString().Trim().ToUpper().StartsWith(value.ToUpper()));
					try {
						if (vIndex != -1) {

							dgSearch.Rows[vIndex].Selected = true;
							dgSearch.FirstDisplayedScrollingRowIndex = vIndex;

							CurrentIndex = vIndex;

						}
					} catch (Exception ex) {

					}

					break;
				case "SCHNAME":
					vIndex = this.CustName.FindIndex(vcust => vcust.Schname.ToString().Trim().ToUpper().StartsWith(value.ToUpper()));
					try {
						if (vIndex != -1) {

							dgSearch.Rows[vIndex].Selected = true;
							dgSearch.FirstDisplayedScrollingRowIndex = vIndex;

							CurrentIndex = vIndex;

						}
					} catch (Exception ex) {

					}
					break;


			}



		}


		private void textBox1_TextChanged(object sender, EventArgs e) {

			Search(txtSearch.Text);
		}

		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
			if (e.KeyChar == 13) {
				this.DialogResult = DialogResult.OK;
				if (SearchType == "SCHCODE" && ReturnForm == "CUST") {
					this.ReturnValue = dgSearch.Rows[CurrentIndex].Cells[0].Value.ToString();
				} else if (SearchType == "SCHNAME" && ReturnForm == "CUST") {
					//search on schname return code though
					this.ReturnValue = dgSearch.Rows[CurrentIndex].Cells[1].Value.ToString();

				}





				this.Close();

			}

		}

		private void dgSearch_RowEnter(object sender, DataGridViewCellEventArgs e) {
			txtSearch.Text = dgSearch.Rows[e.RowIndex].Cells[0].Value.ToString();
			CurrentIndex = e.RowIndex;
		}

		private void dgSearch_KeyPress(object sender, KeyPressEventArgs e) {
			//tabs 1 row so take row back off
			//if (e.KeyChar == 13) {
			//	this.DialogResult = DialogResult.OK;

			//	this.ReturnValue = dgSearch.Rows[CurrentIndex - 1].Cells[0].Value.ToString();

			//	this.Close();

			//}
		}
	
		private void txtSearch_KeyDown(object sender, KeyEventArgs e){
			//		if (e.KeyCode == Keys.Down) {
			//var a = CurrentIndex;
			//			dgSearch.Select();

			//			dgSearch.SelectedRows[a].Selected = true;
			//		}
			//	}
		}
		public class SchcodeSearch {
			public string Schcode { get; set; }
			public string Schname { get; set; }
			public string Contryear { get; set; }
		}
		public class SchnameSearch {
			public string Schname { get; set; }
			public string Schcode { get; set; }

			public string Contryear { get; set; }
		}
	}
}
