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
namespace Mbc5.Forms.MemoryBook
{
	public partial class frmSearch : Form {
		public frmSearch(string vSearchType, string vForm) {
			this.SearchType = vSearchType.ToUpper();
			this.ReturnForm = vForm.ToUpper();
			InitializeComponent();
			
			//SearchType:
			//Schcode
			//Schname
			//Jobno
			//Invoice
			//Production

		}
		private string SearchType{get;set;}
		private string ReturnForm { get; set; }
		public List<CustSearch> Cust { get; set; }

		private void frmSearch_Load(object sender, EventArgs e) {
			var sqlclient = new SQLCustomClient();
			string cmdtext = "";
			switch (SearchType) {
				case "SCHCODE":
					switch (ReturnForm) {
						case "CUST":
							cmdtext = @"Select C.Schcode,C.Schname,C.Contryear,C.SchZip,C.SchState From Cust Order By Schcode";
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
						    Me
							break;

					}
						break;
				case "SCHNAME":
					switch (ReturnForm) {
						case "CUST":
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
			
			sqlclient.CommandText(cmdtext);
			var result = sqlclient.SelectMany<CustSearch>();
			var Cust = (List<CustSearch>)result.Data;
			this.Cust = Cust;
			dgSearch.DataSource = this.Cust;

		}
		private void Search(string value) {


			var vIndex = this.Cust.FindIndex(vcust => vcust.Schcode.ToString().StartsWith(value));
			var a = this.Cust[vIndex];
			if (vIndex != -1) {
				dgSearch.Rows[vIndex].Selected = true;
				dgSearch.FirstDisplayedScrollingRowIndex = vIndex;

			}

		}
		private void button1_Click(object sender, EventArgs e) {
			var sqlclient = new SQLCustomClient();
			var cmdtext = @"Select Schcode,Schname,Contryear From Cust Order By Schcode";
			sqlclient.CommandText(cmdtext);
			var result = sqlclient.SelectMany<CustSearch>();
			var Cust = (List<CustSearch>)result.Data;
			this.Cust = Cust;
			dgSearch.DataSource = this.Cust;


		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {


		}

		private void textBox1_TextChanged(object sender, EventArgs e) {

			Search(textBox1.Text);
		}
	}
	public class CustSearch {
		public string Schcode { get; set; }
		public string Schname { get; set; }
		public string Contryear { get; set; }
	}
}
