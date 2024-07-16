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

namespace Mbc5.Forms.MemoryBook {
	public partial class frmReceivingCard : BaseClass.Forms.bTopBottom {
		public frmReceivingCard(UserPrincipal userPrincipal, string vschcode,int vInvno) : base(new string[] { "SA", "Administrator", "MbcCS" }, userPrincipal) {
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
		INSERT INTO RCard (Schcode,Schname,Schemail,Contemail,ContFname,ContLname,Bcontemail,BContFname,BContLname,CContemail,
Insck,NoCopies,NoPages,Story,Supplement,Peyn,Mlamination,Glamination,OurSupp,YirSchool,SdlStich,TotalSoldOnline,TotalDollarsOnline,
Freebooks,Hdbky_n,casey_n,Foilck,Spirck,AllClrck,Persnlz,ProdNo,Invno,KitReceivedDate,CoverType,CoverDesc,DeadLine,DcDesc1,
DcDesc2,Foiling,IndivPic,Mk,DieCut,Guardte,EstDate,FrontCvr,FrontCvr2,FrontCvin,BackCvrin,Back,Name,Add1,Add2,City,State,
Zip,Clrpgck,App,ContractYear,IsFrontCvr,IsInside,IsInsbkcvr,IsBack,Baldue,Payments,DateCreated,CK1,CK2,CK3,CK4,CK8,CK7)

		
Select 
C.Schcode
,C.Schname
,C.SchEmail
,C.ContEmail
,C.ContFname
,C.ContLname
,C.BContEmail
,C.BContFname
,C.BContLname
,C.CContemail
,Q.Insck
,Q.NoCopies
,Q.NoPages
,Q.Story
,Q.Supplements
,Q.Peyn
,Q.MLamination 
,Q.Layn
,Q.OurSupp
,Q.YirSchool
,Q.SdlStich
,Q.TotalSoldOnline
,Q.TotalDollarsOnline,
Q.Freebooks
,Q.hdbky_n 
,Q.casey_n 
,Q.Foilck
,Q.Spirck
,Q.AllClrck
,P.Persnlz
,P.ProdNo,P.Invno,P.KitRecvd
,P.CoverType,P.CoverDesc
,IIF(P.dedMade!='Y'
,P.Dedayin,null) AS DeadLine,P.Dcdesc1
,P.DcDesc2,
P.Foiling,P.Indivpic
,P.Mk,P.Diecut
,IIF(P.dedMade='Y',P.Cstsvcdte,null)AS Guardte
,IIF(P.dedMade !='Y',P.Cstsvcdte,null)AS EstDate
,CV.[desc] 
,CV.desc1a
,CV.Desc2
,CV.Desc3,CV.Desc4,C.ShippingName,
C.ShippingAddr
,C.ShippingAddr2
,C.ShippingCity
,C.ShippingState,C.ShippingZipCode
,P.colorpgs,CV.App,Q.contryear
, IIF(COALESCE ([desc], '') = '', 0, 1) AS IsFrontCvr,IIF(COALESCE (CV.desc2, '') = '', 0, 1)AS IsInside,
IIF(COALESCE (CV.desc3, '') = '', 0, 1)AS IsInsbkcvr 
,IIF(COALESCE (CV.desc4, '') = '', 0, 1)AS IsBack
,I.Baldue,(Select SUM(payment)+SUM(adjmnt) FROM Paymnt WHERE Invno=@Invno)As Payment,GETDATE()
,IIF(P.dedMade='Y',1,0)AS Ck1
,IIF(P.dedMade='N',1,0)AS Ck2
,IIF((Select SUM(payment)+SUM(adjmnt) FROM Paymnt WHERE Invno=@Invno)>0,1,0)AS Ck3
,IIF(Baldue>0,1,0)AS Ck4
,IIF((Select LEN(CoverDesc) from produtn where invno=@Invno)>0,1,0)AS Ck8
,1 as Ck7

FROM Cust C
				LEFT JOIN Quotes Q On C.Schcode=Q.Schcode
				LEFT JOIN Invoice I On Q.invno=I.invno
				LEFT JOIN Produtn P ON Q.Invno=P.Invno
				LEFT JOIN Covers CV On Q.Invno=CV.Invno
				
				Where P.Invno=@Invno
			");
			var result = sqlClient.Insert();
			if (result.IsError) {
				MbcMessageBox.Error(result.Errors[0].DeveloperMessage, "");
				return;
			}
            this.UpdateRcardOpy(result.Data,Invno);
            try {
				//data is sorted descending by datecreated, then Invno descending
				rCardTableAdapter.Fill(dsRcard.RCard, Invno);
				EnableControls(this);

			} catch (Exception ex) {
               
				MbcMessageBox.Error(ex.Message, "");

			}

		}
		
		

		private void toolStripButton3_ClickAsync(object sender, EventArgs e) {
            EmailPdf();
        }
        private async void EmailPdf()
        {
            var result = await CreatePdf(this.Invno.ToString());
            if (result.IsError)
            {
                MbcMessageBox.Error("Failed to create pdf:"+result.Errors[0].ErrorMessage);
               
                return;
            }
            var emailHelper = new EmailHelper();
            string subject ="From Memory Book Company: confirmation card for "+ lblSchcode.Text.Trim() + " "+ schnameLabel1.Text.Trim()
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
                var emailResult = emailHelper.SendOutLookEmail(subject, addresses, new List<string>(), body, EmailType.Mbc, attachments);
                if (!emailResult)
                {
                    MbcMessageBox.Error("Failed to create email for receiving card.");

                }
            }catch(Exception ex)
            {

            }
        }
        private async Task<ApiProcessingResult<string>> CreatePdf(string vInvno)
        {
            var processingResult = new ApiProcessingResult<string>();
            //https://stackoverflow.com/questions/2684221/creating-a-pdf-from-a-rdlc-report-in-the-background

            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            //string HIJRA_TODAY = "01/10/1435";
            // ReportParameter[] param = new ReportParameter[3];
            //param[0] = new ReportParameter("CUSTOMER_NUM", CUSTOMER_NUMTBX.Text);
            //param[1] = new ReportParameter("REF_CD", REF_CDTB.Text);
            //param[2] = new ReportParameter("HIJRA_TODAY", HIJRA_TODAY);
            try
            {
                this.reportViewer1.LocalReport.Refresh();
                byte[] bytes = this.reportViewer1.LocalReport.Render(
                "PDF",
                null,
                out mimeType,
                out encoding,
                out extension,
                out streamIds,
                out warnings);
                var vPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                var newPath = vPath.Substring(0, vPath.IndexOf("Mbc5") + 4) + "\\tmp\\" + vInvno + "ReceivingCard.pdf";
                using (FileStream fs = new FileStream(newPath, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Dispose();
                }
                processingResult.Data = newPath;
            }
            catch (Exception ex)
            {
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError(ex.Message, ex.Message, ""));
            }
            return processingResult;
        }
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

		//private void Delete(object sender, EventArgs e) {
		//	//if (rCardBindingSource.Count > 0) {
		//	//	DataRowView dr = (DataRowView)rCardBindingSource.Current;
		//	//	var vId = (int)dr["id"];
		//	//	try {
		//	//		rCardTableAdapter.Delete(vId);
		//	//		if (rCardBindingSource.Count == 0) {
		//	//			DisableControls(this);
		//	//		}
		//	//	} catch (Exception ex) { MbcMessageBox.Error(ex.Message, ""); }
		//	//}
		//}

		private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e) {
            //add abillity to bring in OPY data

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

    private void toolStripButton5_Click(object sender, EventArgs e)
    {
    var sqlClient = new SQLCustomClient(ApplicationConfig.DefaultConnectionString);
    sqlClient.AddParameter("@Invno", Invno);
           
   sqlClient.CommandText(@"
Update RCard  
Set Schcode=data11.Schcode
,Schname=data11.Schname
,Schemail=data11.Schemail
,Contemail=data11.Contemail
,ContFname=data11.ContFname
,ContLname=data11.ContLname
,Bcontemail=data11.Bcontemail
,BContFname=data11.BContFname
,BContLname=data11.BContLname 
,CContemail=data11.CContemail 
,Insck=data11.Insck 
,NoCopies=data11.NoCopies 
,NoPages=data11.NoPages 
,Story=data11.Story
,Supplement=data11.Supplements 
,Peyn=data11.Peyn 
,Mlamination=data11.Mlamination 
,Glamination=data11.Layn
,OurSupp=data11.OurSupp
,YirSchool=data11.YirSchool
,SdlStich=data11.SdlStich 
,TotalSoldOnline=data11.TotalSoldOnline
,TotalDollarsOnline=data11.TotalDollarsOnline
,Freebooks=data11.Freebooks 
,Hdbky_n=data11.Hdbky_n
,casey_n=data11.casey_n
,Foilck=data11.Foilck 
,Spirck=data11.Spirck
,AllClrck=data11.AllClrck 
,Persnlz=data11.Persnlz 
,ProdNo=data11.ProdNo 
,Invno=data11.Invno 
,KitReceivedDate=data11.KitRecvd 
,CoverType=data11.CoverType
,CoverDesc=data11.CoverDesc
,DeadLine=data11.DeadLine 
,DcDesc1=data11.DcDesc1 
,DcDesc2=data11.DcDesc2 
,Foiling=data11.Foiling 
,IndivPic=data11.IndivPic 
,Mk=data11.Mk 
,DieCut=data11.DieCut
,Guardte=data11.Guardte
,EstDate=data11.EstDate 
,FrontCvr=data11.IsFrontCvr 
,FrontCvr2=data11.IsInside
,FrontCvin=data11.IsInside 
,BackCvrin=data11.IsInsbkcvr
,Back=data11.IsBack 
,Name=data11.ShippingName 
,Add1=data11.ShippingAddr 
,Add2=data11.ShippingAddr2 
,City=data11.ShippingCity
,State=data11.ShippingState 
,Zip=data11.ShippingZipCode
,Clrpgck=data11.colorpgs 
,App=data11.App 
,ContractYear=data11.contryear 
,IsFrontCvr=data11.IsFrontCvr 
,IsInside=data11.IsInside 
,IsInsbkcvr=data11.IsInsbkcvr 
,IsBack=data11.IsBack 
,Baldue=data11.Baldue 
,Payments=data11.Payment
,CK1=data11.CK1
,CK2=data11.CK2
,CK3=data11.CK3
,CK4=data11.CK4
,Ck7=data11.Ck7
,Ck8=data11.Ck8
FROM(		
Select 
C.Schcode
,C.Schname
,C.SchEmail
,C.ContEmail
,C.ContFname
,C.ContLname
,C.BContEmail
,C.BContFname
,C.BContLname
,C.CContemail
,Q.Insck
,Q.NoCopies
,Q.NoPages
,Q.Story
,Q.Supplements
,Q.Peyn
,Q.MLamination 
,Q.Layn
,Q.OurSupp
,Q.YirSchool
,Q.SdlStich
,Q.TotalSoldOnline
,Q.TotalDollarsOnline
,Q.Freebooks
,Q.hdbky_n 
,Q.casey_n 
,Q.Foilck
,Q.Spirck
,Q.AllClrck
,P.Persnlz
,P.ProdNo,P.Invno,P.KitRecvd
,P.CoverType
,P.CoverDesc
,IIF(P.dedMade!='Y'
,P.Dedayin,null) AS DeadLine,P.Dcdesc1
,P.DcDesc2,
P.Foiling,P.Indivpic
,P.Mk
,P.Diecut
,IIF(P.dedMade='Y',P.Cstsvcdte,null)AS Guardte
,IIF(P.dedMade !='Y',P.Cstsvcdte,null)AS EstDate
,IIF(P.dedMade='Y',1,0)AS Ck1
,IIF(P.dedMade='N',1,0)AS Ck2
,IIF((Select SUM(payment)+SUM(adjmnt) FROM Paymnt WHERE Invno=@Invno)>0,1,0)AS Ck3
,IIF(Baldue>0,1,0)AS Ck4
,IIF((Select LEN(CoverDesc) from produtn where invno=102067)>0,1,0)AS Ck8
,1 as Ck7
,CV.[desc] 
,CV.desc1a
,CV.Desc2
,CV.Desc3,CV.Desc4
,C.ShippingName,
C.ShippingAddr
,C.ShippingAddr2
,C.ShippingCity
,C.ShippingState,C.ShippingZipCode
,P.colorpgs
,CV.App
,Q.contryear

,IIF(COALESCE ([desc], '') = '', 0, 1) AS IsFrontCvr
 ,IIF(COALESCE (CV.desc2, '') = '', 0, 1)AS IsInside
 ,IIF(COALESCE (CV.desc3, '') = '', 0, 1)AS IsInsbkcvr 
,IIF(COALESCE (CV.desc4, '') = '', 0, 1)AS IsBack
,I.Baldue
,(Select SUM(payment)+SUM(adjmnt) FROM Paymnt WHERE Invno=102067)As Payment

FROM Cust C
LEFT JOIN Quotes Q On C.Schcode=Q.Schcode
				LEFT JOIN Invoice I On Q.invno=I.invno
				LEFT JOIN Produtn P ON Q.Invno=P.Invno
				LEFT JOIN Covers CV On Q.Invno=CV.Invno
				Where P.Invno=@Invno

) AS data11
				where Rcard.Invno=@Invno
			");
            var result = sqlClient.Update();
            if (result.IsError)
            {
                MbcMessageBox.Error(result.Errors[0].DeveloperMessage, "");
                return;
            }
            var recId = ((DataRowView)rCardBindingSource.Current).Row["Id"].ToString();
            this.UpdateRcardOpy(recId, Invno);
            try
            {
                //data is sorted descending by datecreated, then Invno descending
                rCardTableAdapter.Fill(dsRcard.RCard, Invno);
                EnableControls(this);

            }
            catch (Exception ex)
            {

                MbcMessageBox.Error(ex.Message, "");

            }
           
            

        }
        private void UpdateRcardOpy(string recId,int Invno)
        {
            var sqlClient = new SQLCustomClient(ApplicationConfig.OPYConnectionString);
            sqlClient.AddParameter("@Invno", Invno);
            sqlClient.CommandText("Select TotalBookSold,DollarsCollected FROM OpyProducts Where Invno=@Invno");
            var selectResult = sqlClient.Select<OPYData>();
            if (selectResult.IsError)
            {
                MbcMessageBox.Error("Failed to get OPY data for receiving card:" + selectResult.Errors[0].ErrorMessage);
                return;
            }
            var opyData = (OPYData)selectResult.Data;
            if (opyData == null)
            {
                MbcMessageBox.Information("No OPY data found for receiving card.");
                return;
            }
            sqlClient.ClearParameters();
            sqlClient = null;
            var sqlClient1 = new SQLCustomClient(ApplicationConfig.DefaultConnectionString);
            sqlClient1.AddParameter("@Id", recId);
            sqlClient1.AddParameter("@TotalSoldOnline", opyData.TotalBookSold);
            sqlClient1.AddParameter("@TotalDollarsOnline", opyData.DollarsCollected);
            sqlClient1.CommandText("Update RCard Set TotalSoldOnline=@TotalSoldOnline,TotalDollarsOnline=@TotalDollarsOnline Where Id=@Id");
            var updateResult = sqlClient1.Update();
            if (updateResult.IsError)
            {
                Log.Error("Failed to update receiving card with OPY data:" + updateResult.Errors[0].DeveloperMessage);
                MbcMessageBox.Error("Failed to update receiving card with OPY data:" + updateResult.Errors[0].ErrorMessage);
                return;
            }
        }
    }
}
