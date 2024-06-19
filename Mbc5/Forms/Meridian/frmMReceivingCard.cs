using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using BaseClass.Classes;
using BaseClass;
using Mbc5.Classes;
using System.Collections;
using Core;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using BindingModels;
using Exceptionless;
namespace Mbc5.Forms.MemoryBook {
	public partial class frmMReceivingCard : BaseClass.Forms.bTopBottom {
		public frmMReceivingCard(UserPrincipal userPrincipal, string vschcode,int vInvno) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal) {
			InitializeComponent();
			this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.ApplicationUser = userPrincipal;
			this.Schcode = vschcode;
			this.Invno = vInvno;
		}
		private UserPrincipal ApplicationUser { get; set; }

		private void frmReceivingCard_Load(object sender, EventArgs e) {
			try {
				//data is sorted descending by datecreated, then Invno descending
				rCardTableAdapter.Fill(dsRcard.RCard,this.Invno);
				//if (rCardBindingSource.Count != 0 && Invno!=0) {
				//	var pos=rCardBindingSource.Find("Invno", Invno);
				//	if (pos > -1) {
						
				//		rCardBindingSource.Position = pos;
				//	}
				//}
				if (rCardBindingSource.Count == 0) {
					DisableControls(this);
				}
			}catch(Exception ex) {

				MbcMessageBox.Error(ex.Message, "");

			}

		}
		private void rCardBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
			this.Validate();
			this.rCardBindingSource.EndEdit();
			rCardTableAdapter.Update(this.dsRcard);

		}

		

		

		private void toolStripButton4_Click(object sender, EventArgs e) {
			//new
			var sqlClient = new SQLCustomClient(ApplicationConfig.DefaultConnectionString);
			sqlClient.AddParameter("@Invno", Invno);
			sqlClient.CommandText(@"
				INSERT INTO RCard (Schcode,Schname,Schemail,Contemail,ContFname,ContLname,Bcontemail,BContFname,BContLname,
					Wallch,DuraGlz,StdPg,IdPouch,VPA,VPB,BookMark,HallPass,QtyStud,QtyTeacher,NoCopies,NoPages,SchType,CK5,Persnlz,ProdNo,Invno,KitReceivedDate,CoverType,CoverDesc,DeadLine,DcDesc1,
					DcDesc2,Foiling,IndivPic,Mk,DieCut,CK1,Guardte,CK2,EstDate,FrontCvr,FrontCvr2,FrontCvin,BackCvrin,Back,Name,Add1,Add2,City,State,
					Zip,Clrpgck,App,ContractYear,IsFrontCvr,IsInside,IsInsbkcvr,IsBack,CK4,Baldue,Payments,CK3,DateCreated
					)
		
				Select  C.Schcode,C.Schname,C.SchEmail,C.ContEmail,C.ContFname,C.ContLname,C.BContEmail,C.BContFname,C.BContLname,
				 IIf(Q.wallchqty>0,1,0),IIF(Q.duraglzqty>0,1,0),IIF(Q.stttitpgqty>0,1,0),IIF(Q.idpouchqty>0,1,0),IIf(Q.vpaqty>0,1,0),IIf(Q.vpbqty>0,1,0),IIF(Q.bmarkqty>0,1,0),IIf(Q.hallpqty>0,1,0),Q.QtyStud,Q.QtyTeacher,Q.QtyTot,Q.NoPages,Q.ProdCode,IIF(COALESCE (Q.Prodcode,'',Q.Prodcode)='',0,1),P.Persnlz,P.ProdNo,P.Invno,P.KitRecvd,P.CoverType,P.CoverDesc,IIF(P.dedMade!='Y',P.Dedayin,null) AS DeadLine,P.Dcdesc1,P.DcDesc2,
				P.Foiling,P.Indivpic,P.Mk,P.Diecut,IIF(P.dedMade='Y',1,0),IIF(P.dedMade='Y',P.Cstsvcdte,null)AS Guardte,IIF(P.dedMade='Y',0,1),IIF(P.dedMade !='Y',P.Cstsvcdte,null)AS EstDate,CV.[desc],CV.desc1a,CV.Desc2,CV.Desc3,CV.Desc4,C.ShpName,
				C.ShpAddr,C.ShpAddr2,C.ShpCity,C.ShpState,C.ShpZip,P.colorpgs,CV.App,Q.contryear, IIF(COALESCE ([desc], '') = '', 0, 1) AS IsFrontCvr,IIF(COALESCE (CV.desc2, '') = '', 0, 1)AS IsInside,
				IIF(COALESCE (CV.desc3, '') = '', 0, 1)AS IsInsbkcvr ,IIF(COALESCE (CV.desc4, '') = '', 0, 1)AS IsBack,IIF(I.Baldue>0,1,0),I.Baldue,(Select SUM(payment)+SUM(adjmnt) FROM Paymnt WHERE Invno=@Invno)As Payment,IIF((Select SUM(payment)+SUM(adjmnt) FROM Paymnt WHERE Invno=@Invno)>0,1,0),GETDATE()

				FROM MCust C
					LEFT JOIN MQuotes Q On C.Schcode=Q.Schcode
					LEFT JOIN MerInvoice I On Q.invno=I.invno
					LEFT JOIN Produtn P ON Q.Invno=P.Invno
					LEFT JOIN Covers CV On Q.Invno=CV.Invno
					
				Where P.Invno=@Invno
			");
			var result = sqlClient.Insert();
			if (result.IsError) {
				MbcMessageBox.Error(result.Errors[0].DeveloperMessage, "");
				return;
			}
			try {
				//data is sorted descending by datecreated, then Invno descending
				rCardTableAdapter.Fill(dsRcard.RCard, Invno);
				EnableControls(this);

			} catch (Exception ex) {
                ex.ToExceptionless()
                    .AddObject(ex)
                    .Submit();
				MbcMessageBox.Error(ex.Message, "");

			}

		}
		
		

		private void toolStripButton3_ClickAsync(object sender, EventArgs e) {
            EmailPdf();
        }
        private async void EmailPdf()
        {
            var pdfCreator = new PdfAttachementGenerator();
            var result=pdfCreator.GenerateAttachement(reportViewer1, "");
            //var result = await CreatePdf(this.Invno.ToString());
            if (result.IsError)
            {
                MbcMessageBox.Error("Failed to create pdf:"+result.Errors[0].ErrorMessage);
                ExceptionlessClient.Default.CreateLog("Create Receiving Card Pdf")
                    .AddObject(result)
                    .Submit();
                return;
            }
            var emailHelper = new EmailHelper();
            string subject = "Meridian Order Confirmation " + lblSchcode.Text.Trim() + " "+ schnameLabel1.Text.Trim()
            ;
            string body = @"This is your final order confirmation, please see attached for order details.<br/><br/>
                        If anything is incorrect or needs to be changed please do not reply to this email, contact your customer service representative.<br/><br/>
                        Changes must be requested within 24 hours.</br>If you do not have Adobe Reader to view your pdf you can download it for free here.<a href= http://get.adobe.com/reader/>Adobe Pdf<a/>";

            var dr = (DataRowView)rCardBindingSource.Current;
            List<string> addresses = new List<string>();
            try
            {
                if (!string.IsNullOrEmpty(dr.Row["Schemail"].ToString()))
                {
                    addresses.Add(dr.Row["Schemail"].ToString());
                }
                if (!string.IsNullOrEmpty(dr.Row["Contemail"].ToString()))
                {
                    addresses.Add(dr.Row["Contemail"].ToString());
                }
                if (!string.IsNullOrEmpty(dr.Row["Bcontemail"].ToString()))
                {
                    addresses.Add(dr.Row["Bcontemail"].ToString());
                }
                if (!string.IsNullOrEmpty(dr.Row["CContemail"].ToString()))
                {
                    addresses.Add(dr.Row["CContemail"].ToString());
                }
                var attachments = new List<OutlookAttachemt>();
                var attachment = new OutlookAttachemt()
                {
                    Path = result.Data,
                    Name = Invno.ToString() + "ReceivingCard.pdf"
                };
                attachments.Add(attachment);
                var emailResult = emailHelper.SendOutLookEmail(subject, addresses, new List<string>(), body, EmailType.Meridian, attachments);
                if (!emailResult)
                {
                    MbcMessageBox.Error("Failed to create email for receiving card.");

                }
            }catch(Exception ex)
            {

            }
        }
        //private async Task<ApiProcessingResult<string>> CreatePdf(string vInvno)
        //{
        //    var processingResult = new ApiProcessingResult<string>();
        //    //https://stackoverflow.com/questions/2684221/creating-a-pdf-from-a-rdlc-report-in-the-background

        //    Warning[] warnings;
        //    string[] streamIds;
        //    string mimeType = string.Empty;
        //    string encoding = string.Empty;
        //    string extension = string.Empty;
        //    //string HIJRA_TODAY = "01/10/1435";
        //    // ReportParameter[] param = new ReportParameter[3];
        //    //param[0] = new ReportParameter("CUSTOMER_NUM", CUSTOMER_NUMTBX.Text);
        //    //param[1] = new ReportParameter("REF_CD", REF_CDTB.Text);
        //    //param[2] = new ReportParameter("HIJRA_TODAY", HIJRA_TODAY);
        //    try
        //    {
        //        this.reportViewer1.LocalReport.Refresh();
        //        byte[] bytes = this.reportViewer1.LocalReport.Render(
        //        "PDF",
        //        null,
        //        out mimeType,
        //        out encoding,
        //        out extension,
        //        out streamIds,
        //        out warnings);
        //        var vPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        //        var newPath = vPath.Substring(0, vPath.IndexOf("Mbc5") + 4) + "\\tmp\\" + vInvno + "ReceivingCard.pdf";
        //        using (FileStream fs = new FileStream(newPath, FileMode.Create))
        //        {
        //            fs.Write(bytes, 0, bytes.Length);
        //            fs.Dispose();
        //        }
        //        processingResult.Data = newPath;
        //    }
        //    catch (Exception ex)
        //    {
        //        processingResult.IsError = true;
        //        processingResult.Errors.Add(new ApiProcessingError(ex.Message, ex.Message, ""));
        //    }
        //    return processingResult;
        //}
		private void toolStripButton1_Click(object sender, EventArgs e) {
			//print
			this.reportViewer1.RefreshReport();
		}

		private void DisableControls(Control con) {
			foreach (Control c in con.Controls) {
				if(c.Name== "bnRcard") {
					c.Enabled = true;
				} else {c.Enabled = false; }
				
			}
			//con.Enabled = false;
		}
		private void EnableControls(Control con) {
			foreach (Control c in con.Controls) {
				 c.Enabled = true; 

			}
		}

		

		private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e) {
			try {
				rCardTableAdapter.Update(dsRcard);
				if (rCardBindingSource.Count == 0) {
								DisableControls(this);
							}
				}catch (Exception ex) { MbcMessageBox.Error(ex.Message,""); }
		
		}

		private void toolStripButton2_Click(object sender, EventArgs e) {
			try {
				rCardBindingSource.EndEdit();
				var a=rCardTableAdapter.Update(dsRcard);
				
			} catch (Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
		}

		private void reportViewer1_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e) {
			try {
				reportViewer1.PrintDialog();
			} catch (Exception ex) {

			}
		}
	}
}
