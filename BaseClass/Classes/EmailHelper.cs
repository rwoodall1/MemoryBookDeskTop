using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using BaseClass.Classes;
using Exceptionless.Models;
using Exceptionless;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using BindingModels;
namespace BaseClass.Classes
{
    public class EmailHelper
    {
        public EmailHelper()
        {

        }
        public string BuildEmailSystem(string Body)
        {
            var template = @"
              <style>
			    html, body, div, span, applet, object, iframe, h1, h2, h3, h4, h5, h6, p, blockquote, pre, a, abbr, acronym, address, big, cite, code, del, dfn, em, font, img, ins, kbd, q, s, samp, small, strike, strong, sub, sup, tt, var, dl, dt, dd, ol, ul, li, fieldset, form, label, legend, table, caption, tbody, tfoot, thead, tr, th, td {
			    margin:0; padding:0; border:0; outline:0; font-weight:inherit; font-style:inherit; font-family:inherit; font-size:100%; vertical-align:baseline; }
			    td {vertical-align:top}
			    h1,h2,h3,h4,h5,h6,strong {font-weight:bold;} h1,h2,h3,h4,h5,h6 {margin:.25em 0;}
			    h1 {font-size:120%;} h2 {font-size:110.0%;} h3 {font-size:108%;} 	h4 {font-size:100%;}
			    em{font-style:italic}
			    ul {margin:5px 0px 0px 35px;padding-left:0px;} ol {;margin:5px 0px 0px 35px;padding-left:0px;} li {padding-bottom:5px}
			    sup {vertical-align:top}
			    table {border-collapse:collapse;border-spacing:0;}
			    fieldset,img {border:0;}
			    hr{height:1px;margin-bottom:5px;border-width:0px}
			    /* Font Settings *//* 10px=77% | 11px=85% | 12px=93% | 13px=100% | 14px=108% | 15px=116% | 16px=123.1% | 17px=131% | 18px=138.5% | 19px=146.5% | 20px=153.9% | 21px=161.6% | 22px=167% | 23px=174% | 24px=182% | 25px=189% | 26px=197  */
			    body{font:13px/1.231 arial,helvetica,clean,sans-serif;*font-size:small;*font:x-small;}
			    select,input,button,textarea,button{font:85% arial,helvetica,clean,sans-serif;}
			    table{font-size:inherit;font:100%;}
			    pre,code,kbd,samp,tt{font-family:monospace;*font-size:108%;line-height:100%;}
			    /* Template Settings */
			    a, a:visited, a:hover, a:active {color:#652d8a}
			    .right{text-align:right;}
			    .center{text-align:center;}
		    </style>
			<table border='0' cellspacing='0' cellpadding='0' width='1024' align='center' style='max-width: 600px;border:1px solid #333'>
				<tbody>
					<tr>
						<td style='background:#fff;width:10px' width='10'>&nbsp;</td>
						<td style='background:#fff; color:#FFFFFF;padding:10px'><span style='padding:10px;text-align:left;background:#fff; color:#FFFFFF;vertical-align:bottom;font-size:12px;'><a href='https://www.memorybook.com' alt='Lifeline Services' title='Lifeline Services'><img src='http://www.memorybook.com/images/logos/mem_jost_logo280x70.jpg' alt='Memory Book Company' title='Memory Book Company' style='border:0px' border='0' width='141' height='48'></a></span></td>
						<td style='padding:10px;text-align:right;background:#fff; color:#FFFFFF;vertical-align:bottom;font-size:12px;' width='230'>&nbsp;</td>
						<td style='background:#fff;width:10px;' width='10'>&nbsp;</td>
					</tr>
                    <tr><td colspan='4' style='height:20px;background:#5D7B9D'></td></tr>
					<tr>
						<td style='background:#fff;'>&nbsp;</td>
						<td colspan='2' style='padding: 20px;background-color:#FFFFFF;color:#333333'>
							<div style='font-size:18px; line-height:130%;font:arial,helvetica,clean,sans-serif;'>"
                                + Body
                            + @"</div>
						</td>
						<td style='background:#fff;'>&nbsp;</td>
					</tr>
				</tbody>
			</table>
            ";

            return template;
        }
        public string BuildEmailMBC(string Body)
        {
            var template = @"
              <style>
			    html, body, div, span, applet, object, iframe, h1, h2, h3, h4, h5, h6, p, blockquote, pre, a, abbr, acronym, address, big, cite, code, del, dfn, em, font, img, ins, kbd, q, s, samp, small, strike, strong, sub, sup, tt, var, dl, dt, dd, ol, ul, li, fieldset, form, label, legend, table, caption, tbody, tfoot, thead, tr, th, td {
			    margin:0; padding:0; border:0; outline:0; font-weight:inherit; font-style:inherit; font-family:inherit; font-size:100%; vertical-align:baseline; }
			    td {vertical-align:top}
			    h1,h2,h3,h4,h5,h6,strong {font-weight:bold;} h1,h2,h3,h4,h5,h6 {margin:.25em 0;}
			    h1 {font-size:120%;} h2 {font-size:110.0%;} h3 {font-size:108%;} 	h4 {font-size:100%;}
			    em{font-style:italic}
			    ul {margin:5px 0px 0px 35px;padding-left:0px;} ol {;margin:5px 0px 0px 35px;padding-left:0px;} li {padding-bottom:5px}
			    sup {vertical-align:top}
			    table {border-collapse:collapse;border-spacing:0;}
			    fieldset,img {border:0;}
			    hr{height:1px;margin-bottom:5px;border-width:0px}
			    /* Font Settings *//* 10px=77% | 11px=85% | 12px=93% | 13px=100% | 14px=108% | 15px=116% | 16px=123.1% | 17px=131% | 18px=138.5% | 19px=146.5% | 20px=153.9% | 21px=161.6% | 22px=167% | 23px=174% | 24px=182% | 25px=189% | 26px=197  */
			    body{font:13px/1.231 arial,helvetica,clean,sans-serif;*font-size:small;*font:x-small;}
			    select,input,button,textarea,button{font:85% arial,helvetica,clean,sans-serif;}
			    table{font-size:inherit;font:100%;}
			    pre,code,kbd,samp,tt{font-family:monospace;*font-size:108%;line-height:100%;}
			    /* Template Settings */
			    a, a:visited, a:hover, a:active {color:#652d8a}
			    .right{text-align:right;}
			    .center{text-align:center;}
		    </style>
			<table border='0' cellspacing='0' cellpadding='0' width='1024' align='center' style='max-width: 1024px;border:1px solid #333'>
				<tbody>
					<tr>
						<td style='background:#fff;width:10px' width='10'>&nbsp;</td>
						<td style='background:#fff; color:#FFFFFF;padding:10px'><span style='padding:10px;text-align:left;background:#fff; color:#FFFFFF;vertical-align:bottom;font-size:12px;'><a href='https://www.memorybook.com' alt='Lifeline Services' title='Lifeline Services'><img src='http://www.memorybook.com/images/logos/mem_jost_logo280x70.jpg' alt='Lifeline Services' title='Lifeline Services' style='border:0px' border='0' width='141' height='48'></a></span></td>
						<td style='padding:10px;text-align:right;background:#fff; color:#FFFFFF;vertical-align:bottom;font-size:12px;' width='230'>&nbsp;</td>
						<td style='background:#fff;width:10px;' width='10'>&nbsp;</td>
					</tr>
                    <tr><td colspan='4' style='height:20px;background:#5D7B9D'></td></tr>
					<tr>
						<td style='background:#fff;'>&nbsp;</td>
						<td colspan='2' style='padding: 20px;background-color:#FFFFFF;color:#333333'>
							<div style='font-size:18px; line-height:130%;font:arial,helvetica,clean,sans-serif;'>"
                                + Body
                            + @"</div>
						</td>
						<td style='background:#fff;'>&nbsp;</td>
					</tr>
				</tbody>
			</table>
            ";

            return template;
        }
        public string BuildEmailMeridian(string Body)
        {
            var template = @"
              <style>
			    html, body, div, span, applet, object, iframe, h1, h2, h3, h4, h5, h6, p, blockquote, pre, a, abbr, acronym, address, big, cite, code, del, dfn, em, font, img, ins, kbd, q, s, samp, small, strike, strong, sub, sup, tt, var, dl, dt, dd, ol, ul, li, fieldset, form, label, legend, table, caption, tbody, tfoot, thead, tr, th, td {
			    margin:0; padding:0; border:0; outline:0; font-weight:inherit; font-style:inherit; font-family:inherit; font-size:100%; vertical-align:baseline; }
			    td {vertical-align:top}
			    h1,h2,h3,h4,h5,h6,strong {font-weight:bold;} h1,h2,h3,h4,h5,h6 {margin:.25em 0;}
			    h1 {font-size:120%;} h2 {font-size:110.0%;} h3 {font-size:108%;} 	h4 {font-size:100%;}
			    em{font-style:italic}
			    ul {margin:5px 0px 0px 35px;padding-left:0px;} ol {;margin:5px 0px 0px 35px;padding-left:0px;} li {padding-bottom:5px}
			    sup {vertical-align:top}
			    table {border-collapse:collapse;border-spacing:0;}
			    fieldset,img {border:0;}
			    hr{height:1px;margin-bottom:5px;border-width:0px}
			    /* Font Settings *//* 10px=77% | 11px=85% | 12px=93% | 13px=100% | 14px=108% | 15px=116% | 16px=123.1% | 17px=131% | 18px=138.5% | 19px=146.5% | 20px=153.9% | 21px=161.6% | 22px=167% | 23px=174% | 24px=182% | 25px=189% | 26px=197  */
			    body{font:13px/1.231 arial,helvetica,clean,sans-serif;*font-size:small;*font:x-small;}
			    select,input,button,textarea,button{font:85% arial,helvetica,clean,sans-serif;}
			    table{font-size:inherit;font:100%;}
			    pre,code,kbd,samp,tt{font-family:monospace;*font-size:108%;line-height:100%;}
			    /* Template Settings */
			    a, a:visited, a:hover, a:active {color:#652d8a}
			    .right{text-align:right;}
			    .center{text-align:center;}
		    </style>
			<table border='0' cellspacing='0' cellpadding='0' width='1024' align='center' style='max-width: 1024px;border:1px solid #333'>
				<tbody>
					<tr>
						<td style='background:#fff;width:10px' width='10'>&nbsp;</td>
						<td style='background:#fff; color:#FFFFFF;padding:10px'><span style='padding:10px;text-align:left;background:#fff; color:#FFFFFF;vertical-align:bottom;font-size:12px;'><a href='https://meridianplanners.com
' alt='Lifeline Services' title='Lifeline Services'><img src='https://www.memorybook.com/images/logos/JostensLogo.jpg' alt='Lifeline Services' title='Lifeline Services' style='border:0px' border='0' width='141' height='48'></a></span></td>
						<td style='padding:10px;text-align:right;background:#fff; color:#FFFFFF;vertical-align:bottom;font-size:12px;' width='230'>&nbsp;</td>
						<td style='background:#fff;width:10px;' width='10'>&nbsp;</td>
					</tr>
                    <tr><td colspan='4' style='height:20px;background:#5D7B9D'></td></tr>
					<tr>
						<td style='background:#fff;'>&nbsp;</td>
						<td colspan='2' style='padding: 20px;background-color:#FFFFFF;color:#333333'>
							<div style='font-size:18px; line-height:130%;font:arial,helvetica,clean,sans-serif;'>"
                                + Body
                            + @"</div>
						</td>
						<td style='background:#fff;'>&nbsp;</td>
					</tr>
				</tbody>
			</table>
            ";

            return template;
        }
        public bool SendEmail(string Subject, string ToAddresses, string CCAddresses, string Body, EmailType TypeEmail)

        {
            var brandedHtml = "";
            if (TypeEmail == EmailType.Mbc)
            {
                brandedHtml = BuildEmailMBC(Body);
            } else if (TypeEmail == EmailType.Meridian)
            {
                brandedHtml = BuildEmailMeridian(Body);
            }
            else if (TypeEmail == EmailType.System)
            {
                brandedHtml = BuildEmailSystem(Body);
            } else if (TypeEmail == EmailType.System)
            {
                brandedHtml = BuildEmailSystem(Body);
            } else if (TypeEmail == EmailType.Blank) {
                brandedHtml = "";
            } else
            {
                return false;
            }

            var smtpClient = new SmtpClient();
            var mailMessage = new MailMessage
            {
                Subject = Subject,
                Body = brandedHtml,
                IsBodyHtml = true
            };

            mailMessage.To.Add(ToAddresses);
            try {
                smtpClient.Send(mailMessage);
                return true;
            }catch(Exception ex)
            {
                ex.ToExceptionless()
                    .Submit();
                MessageBox.Show("Failed to send email:" + ex.Message);
                return false;
            }
            
        }

        public bool SendEmail(string Subject, List<string> ToAddresses, List<string> CCAddresses, string Body, EmailType TypeEmail) {
            var brandedHtml = "";
            if (TypeEmail == EmailType.Mbc) {
                brandedHtml = BuildEmailMBC(Body);
            } else if (TypeEmail == EmailType.Meridian) {
                brandedHtml = BuildEmailMeridian(Body);
            } else if (TypeEmail == EmailType.System) {
                brandedHtml = BuildEmailSystem(Body);
            } else if (TypeEmail == EmailType.Blank) {
                brandedHtml = "";
            } else {
                return false;
            }

            var smtpClient = new SmtpClient();
            var mailMessage = new MailMessage {
                Subject = Subject,
                Body = brandedHtml,
                IsBodyHtml = true
            };
            if (ToAddresses != null && ToAddresses.Count > 0)
            {
                foreach (var address in ToAddresses)
                {
                    mailMessage.To.Add(address);
                }
            }
            else { return false; }
            if (CCAddresses != null && CCAddresses.Count > 0) { 
                foreach (var address in CCAddresses) {
                    mailMessage.CC.Add(address);
                }
              }
            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                    .Submit();
                MessageBox.Show("Failed to send email:" + ex.Message);
                return false;
            }
        }

        public bool SendEmail(string Subject, List<string> ToAddresses, string CCAddresses, string Body, EmailType TypeEmail, List<OutlookAttachemt> attachments = null) {
            if (ToAddresses == null || ToAddresses.Count<0)
            {
                MessageBox.Show("Email address is empty. Check school and school contacts email addresses.", "Empty Email Address", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            var brandedHtml = "";
            if (TypeEmail == EmailType.Mbc) {
                brandedHtml = BuildEmailMBC(Body);
            } else if (TypeEmail == EmailType.Meridian) {
                brandedHtml = BuildEmailMeridian(Body);
            } else if (TypeEmail == EmailType.System) {
                brandedHtml = BuildEmailSystem(Body);
            } else if (TypeEmail == EmailType.Blank) {
                brandedHtml = "";
            } else {
                return false;
            }

            var smtpClient = new SmtpClient();
            var mailMessage = new MailMessage {
                Subject = Subject,
                Body = brandedHtml,
                IsBodyHtml = true
            };
            foreach (var address in ToAddresses) {
                
                mailMessage.To.Add(address);
            }
            if (CCAddresses!=null)
            {
                mailMessage.To.Add(CCAddresses);
            }
            if (attachments != null && attachments.Count > 0)
                foreach (OutlookAttachemt attachement in attachments)
                {

                    mailMessage.Attachments.Add(new Attachment(attachement.Path));
                }
            try
            {
             smtpClient.Send(mailMessage);
                return true;
            }
            catch (SmtpFailedRecipientException ex)
            {
                ex.ToExceptionless()
                    .AddObject(ex)
                    .Submit();
                if (!string.IsNullOrEmpty(ex.FailedRecipient))
                {
                    MessageBox.Show("Failed to send  email to:" + ex.FailedRecipient+ " Be sure email address is good.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return true;
                }
                
          
            }catch(Exception ex1)
            {
                    ex1.ToExceptionless()
                    .AddObject(ex1)
                    .Submit();
                MessageBox.Show("Failed to send  email:" + ex1.Message);
                return false;
            }
            return true;
        }

        public bool SendEmail(string Subject, string ToAddresses, List<string> CCAddresses, string Body, EmailType TypeEmail, List<string> attachments = null) {
            if (ToAddresses == null || ToAddresses == "")
            {
                MessageBox.Show("Email address is empty. Check school and school contacts email addresses.", "Empty Email Address", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            var brandedHtml = "";
            if (TypeEmail == EmailType.Mbc) {
                brandedHtml = BuildEmailMBC(Body);
            } else if (TypeEmail == EmailType.Meridian) {
                brandedHtml = BuildEmailMeridian(Body);
            } else if (TypeEmail == EmailType.System) {
                brandedHtml = BuildEmailSystem(Body);
            } else if (TypeEmail == EmailType.Blank) {
                brandedHtml = "";
            } else {
                return false;
            }

            var smtpClient = new SmtpClient();
            var mailMessage = new MailMessage {
                Subject = Subject,
                Body = brandedHtml,
                IsBodyHtml = true
            };
            mailMessage.To.Add(ToAddresses);
            foreach (var address in CCAddresses) {
                mailMessage.CC.Add(address);
            }
			if (attachments != null)
			{
				foreach (var attachPath in attachments)
				{
					mailMessage.Attachments.Add(new Attachment(attachPath));
				}
			}
			try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                    .Submit();
                MessageBox.Show("Failed to send email:" + ex.Message);
                return false;
            }
        }
        public bool SendEmail(string Subject, List<string> ToAddresses, string CCAddresses, string Body, EmailType TypeEmail, List<string> attachments = null)
        {
            if (ToAddresses == null || ToAddresses.Count < 0)
            {
                MessageBox.Show("Email address is empty. Check school and school contacts email addresses.", "Empty Email Address", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            var brandedHtml = "";
            if (TypeEmail == EmailType.Mbc)
            {
                brandedHtml = BuildEmailMBC(Body);
            }
            else if (TypeEmail == EmailType.Meridian)
            {
                brandedHtml = BuildEmailMeridian(Body);
            }
            else if (TypeEmail == EmailType.System)
            {
                brandedHtml = BuildEmailSystem(Body);
            }
            else if (TypeEmail == EmailType.Blank)
            {
                brandedHtml = "";
            }
            else
            {
                return false;
            }

            var smtpClient = new SmtpClient();
            var mailMessage = new MailMessage
            {
                Subject = Subject,
                Body = brandedHtml,
                IsBodyHtml = true
            };
            foreach (var address in ToAddresses)
            {
                mailMessage.To.Add(address);
            }

            mailMessage.To.Add(CCAddresses);
            if (attachments != null)
            {
                foreach (var attachPath in attachments)
                {
                    mailMessage.Attachments.Add(new Attachment(attachPath));
                }
            }
            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                    .Submit();
                MessageBox.Show("Failed to send email:" + ex.Message);
                return false;
            }
        }


        public bool SendOutLookEmail(string Subject, string ToAddresses, string CCAddresses, string Body, EmailType TypeEmail,List<OutlookAttachemt> attachments = null) {
            //if (ToAddresses == null ||ToAddresses=="")
            //{
            //    MessageBox.Show("Email address is empty. Check school and school contacts email addresses.", "Empty Email Address", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //}
            var brandedHtml = "";
            if (TypeEmail == EmailType.Mbc) {
                brandedHtml = BuildEmailMBC(Body);
                } else if (TypeEmail == EmailType.Meridian) {
                brandedHtml = BuildEmailMeridian(Body);
                } else if (TypeEmail == EmailType.System) {
                brandedHtml = BuildEmailSystem(Body);
                } else if (TypeEmail == EmailType.Blank) {
                brandedHtml = Body;
                } else {
                return false;
                }
            try {
                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.To = ToAddresses;
                if (!String.IsNullOrEmpty(CCAddresses)) {
                    mailItem.CC = CCAddresses;
                    }

                mailItem.Subject = Subject;
                mailItem.HTMLBody = brandedHtml;
				if(attachments!=null && attachments.Count>0)
				foreach(OutlookAttachemt attachement in attachments)
				{
					mailItem.Attachments.Add(attachement.Path, Outlook.OlAttachmentType.olByValue,1, attachement.Name);
				}
				
                mailItem.Display(true);
                return true;
                }catch(Exception ex) {
                ex.ToExceptionless()
                  .MarkAsCritical()
                  .AddTags("Outlook Error")
                  .Submit();
                MessageBox.Show("Failed to send email:" + ex.Message);
                return false;
                }
            }
        public bool SendOutLookEmail(string Subject,List<string> ToAddresses,List<string> CCAddresses,string Body,EmailType TypeEmail, List<OutlookAttachemt> attachments = null) {
            //if (ToAddresses == null || ToAddresses.Count < 1)
            //{
            //    MessageBox.Show("Email address is empty. Check school and school contacts email addresses.", "Empty Email Address", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //}
            var brandedHtml = "";
            if (TypeEmail == EmailType.Mbc) {
                brandedHtml = BuildEmailMBC(Body);
                } else if (TypeEmail == EmailType.Meridian) {
                brandedHtml = BuildEmailMeridian(Body);
                } else if (TypeEmail == EmailType.System) {
                brandedHtml = BuildEmailSystem(Body);
                } else if (TypeEmail == EmailType.Blank) {
                brandedHtml = "";
                } else {
                return false; ;
                }
            try {
                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                var vToAddresses = "";
                var vCCAddresses = "";
                foreach (var address in ToAddresses) {
                    vToAddresses = vToAddresses + address + ";";
                   
                    }
                    mailItem.To = vToAddresses;
                if (CCAddresses!=null) {
                    foreach (var address in CCAddresses) {
                        vCCAddresses = vCCAddresses + address + ";";

                    }
                }
				if (attachments != null && attachments.Count > 0)
					foreach (OutlookAttachemt attachement in attachments) {
						mailItem.Attachments.Add(attachement.Path, Outlook.OlAttachmentType.olByValue, 1, attachement.Name);
					}
				mailItem.CC =vCCAddresses;
                mailItem.Subject = Subject;
                mailItem.HTMLBody = brandedHtml;
                mailItem.Display(true);
                return true;
                }catch(Exception ex1) {
                ex1.ToExceptionless()
              .MarkAsCritical()
              .AddTags("Outlook Error")
              .Submit();
                MessageBox.Show("Failed to send email:" + ex1.Message);
                return false;
                }
            }
        public bool SendOutLookEmail(string Subject,string ToAddresses,List<string> CCAddresses,string Body,EmailType TypeEmail) {
            var brandedHtml = "";
            //if (ToAddresses == null || ToAddresses =="")
            //{
            //    MessageBox.Show("Email address is empty. Check school and school contacts email addresses.", "Empty Email Address", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //}
            if (TypeEmail == EmailType.Mbc) {
                brandedHtml = BuildEmailMBC(Body);
                } else if (TypeEmail == EmailType.Meridian) {
                brandedHtml = BuildEmailMeridian(Body);
                } else if (TypeEmail == EmailType.System) {
                brandedHtml = BuildEmailSystem(Body);
                } else if (TypeEmail == EmailType.Blank) {
                brandedHtml = "";
                } else {
                return false;
                }
            try {
                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

                
                    mailItem.To =ToAddresses;
                var vCCAddresses = "";
                if (CCAddresses != null && CCAddresses.Count!=0)
                {
                    foreach (var address in CCAddresses)
                    {
                        vCCAddresses = vCCAddresses + address + ";";

                    }
                    mailItem.CC = vCCAddresses;
                }
                mailItem.Subject = Subject;
                mailItem.HTMLBody = brandedHtml;
                mailItem.Display(true);
                return true;
                } catch (Exception ex1) {
                ex1.ToExceptionless()
              .MarkAsCritical()
              .AddTags("Outlook Error")
              .Submit();
                MessageBox.Show("Failed to send email:" + ex1.Message);
                return false;
                }
            }
        public bool SendOutLookEmail(string Subject,List<string> ToAddresses,string CCAddresses,string Body,EmailType TypeEmail) {
            if (ToAddresses == null || ToAddresses.Count < 1)
            {
                MessageBox.Show("Email address is empty. Check school and school contacts email addresses.","Empty Email Address",MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }
            var brandedHtml = "";
            if (TypeEmail == EmailType.Mbc) {
                brandedHtml = BuildEmailMBC(Body);
                } else if (TypeEmail == EmailType.Meridian) {
                brandedHtml = BuildEmailMeridian(Body);
                } else if (TypeEmail == EmailType.System) {
                brandedHtml = BuildEmailSystem(Body);
                } else if (TypeEmail == EmailType.Blank) {
                brandedHtml = "";
                } else {
                return false;
                }
            try {
                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                var vToAddress = "";
                foreach (var address in ToAddresses) {
                    vToAddress = vToAddress + address + ";";
                   
                    }
                    mailItem.To = vToAddress;
                    mailItem.CC =CCAddresses;
                 

                mailItem.Subject = Subject;
                mailItem.HTMLBody = brandedHtml;
                mailItem.Display(true);
                return true;
                } catch (Exception ex1) {
                ex1.ToExceptionless()
              .MarkAsCritical()
              .AddTags("Outlook Error")
              .Submit();
                MessageBox.Show("Failed to send email:" + ex1.Message);
                return false;
                }
            }



        }
}
