using BusinessLogic.Interfaces;
using Microsoft.JSInterop;
using SkillIT_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;
using Ubiety.Dns.Core;
using SendGrid;
using SendGrid.Helpers.Mail;
using Newtonsoft.Json;

namespace BusinessLogic
{
	public class MailingService: IMailingService
	{
		private readonly IJSRuntime JsRuntime;
		public MailingService(IJSRuntime jsRuntime)
		{
			JsRuntime = jsRuntime;
		}

        #region Emailers
        public async Task<ResponseModel> SendWelcomeEmail(string name, string email)
		{
			string emailTemplate = await JsRuntime.InvokeAsync<string>("getWelcomeEmailTemplate", name);

			var response = SendMail(email, "Welcome to Skill-IT Educate", emailTemplate, SiteSettings.AccountHelperEmail);
			return response;
		}

		public async Task<ResponseModel> SendConfirmEmailTemplate(string email, string ac_email, string link)
		{
			string emailTemplate = await JsRuntime.InvokeAsync<string>("getConfirmEmailTemplate", link, ac_email, email);

			var response = SendMail(email, "Please confirm email", emailTemplate, SiteSettings.AccountHelperEmail);
			return response;
		}

		public  ResponseModel SendResetEmailTemplate(string email, string link)
		{
			string emailTemplate = JsRuntime.InvokeAsync<string>("getResetEmailTemplate", link).Result;

			var response = SendMail(email, "Password reset request", emailTemplate, SiteSettings.AccountHelperEmail);
			return response;
		}

		public async Task<ResponseModel> SendCourseRegisteredEmail(string email, string courseName, DateTime startDate, string link, string ux_email, string feedbackLink)
		{
			string emailTemplate = await JsRuntime.InvokeAsync<string>("getCourseRegisteredEmail", courseName, startDate.ToString("f"), link, ux_email, feedbackLink);

			var response = SendMail(email, "Course registered!", emailTemplate, SiteSettings.AccountHelperEmail);
			return response;
		}

		public async Task<ResponseModel> SendCourseCompletedEmail(string email, string courseName, DateTime completionDate, string link, string ux_email, string feedbackLink)
		{
			string emailTemplate = await JsRuntime.InvokeAsync<string>("getCourseCompletedEmail", courseName, completionDate.ToString("f"), link, ux_email, feedbackLink);

			var response = SendMail(email, "Course completed!", emailTemplate, SiteSettings.AccountHelperEmail);
			return response;
		}
        #endregion

        public ResponseModel SendMailWithInFoMaill(string email, string subject, string message, string sender) 
		{
			MailMessage mailMessage = new();
			SmtpClient smtpClient = new();
			mailMessage.From = new MailAddress(sender, "Skill-IT Info");
			mailMessage.To.Add(email);
			mailMessage.Subject = subject;
			mailMessage.IsBodyHtml = true;
			mailMessage.Body = message;
			smtpClient.Host = SiteSettings.SecureMailServer;
			string gmailProvider = "gmail.com";
			if (sender.Contains(gmailProvider))
			{
				try
				{
					smtpClient.Port = SiteSettings.SMTP_Port_If_Google;
					smtpClient.Credentials = new System.Net.NetworkCredential(sender, SiteSettings.AccountHelperEmailPassword);
					smtpClient.EnableSsl = true;
					smtpClient.Send(mailMessage);
					return new(true, "Email Sent successfully");
				}
				catch (Exception ex)
				{
					return new(false, "<BR><BR>* Please double check the From Address and Password to confirm that both of them are correct. <br> Further details "+ex.Message);
					//Response.Write("<BR><BR>If you are using gmail smtp to send email for the first time, please refer to this KB to setup your gmail account: http://www.smarterasp.net/support/kb/a1546/send-email-from-gmail-with-smtp-authentication-but-got-5_5_1-authentication-required-error.aspx?KBSearchID=137388");
				}
			}
			else
			{
				try
				{
					smtpClient.Port = SiteSettings.SMTP_Port1;
					smtpClient.Credentials = new System.Net.NetworkCredential(sender, SiteSettings.AccountHelperEmailPassword);
					smtpClient.EnableSsl = false;
					smtpClient.Send(mailMessage);
					return new(true, "Email Sent successfully");
				}
				catch (Exception ex)
				{
					return new(false, "<BR><BR>* Please double check the From Address and Password to confirm that both of them are correct. <br> Further details " + ex.Message);
				}
			}
		}

		public ResponseModel SendMailWithSupportMaill(string email, string subject, string message, string sender) 
		{
			MailMessage mailMessage = new();
			SmtpClient smtpClient = new();
			mailMessage.From = new MailAddress(sender, "Skill-IT Support");
			mailMessage.To.Add(email);
			mailMessage.Subject = subject;
			mailMessage.IsBodyHtml = true;
			mailMessage.Body = message;
			smtpClient.Host = SiteSettings.SecureMailServer;
			string gmailProvider = "gmail.com";
			if (sender.Contains(gmailProvider))
			{
				try
				{
					smtpClient.Port = SiteSettings.SMTP_Port_If_Google;
					smtpClient.Credentials = new System.Net.NetworkCredential(sender, SiteSettings.AccountHelperEmailPassword);
					smtpClient.EnableSsl = true;
					smtpClient.Send(mailMessage);
					return new(true, "Email Sent successfully");
				}
				catch (Exception ex)
				{
					return new(false, "<BR><BR>* Please double check the From Address and Password to confirm that both of them are correct. <br> Further details "+ex.Message);
					//Response.Write("<BR><BR>If you are using gmail smtp to send email for the first time, please refer to this KB to setup your gmail account: http://www.smarterasp.net/support/kb/a1546/send-email-from-gmail-with-smtp-authentication-but-got-5_5_1-authentication-required-error.aspx?KBSearchID=137388");
				}
			}
			else
			{
				try
				{
					smtpClient.Port = SiteSettings.SMTP_Port1;
					smtpClient.Credentials = new System.Net.NetworkCredential(sender, SiteSettings.AccountHelperEmailPassword);
					smtpClient.EnableSsl = false;
					smtpClient.Send(mailMessage);
					return new(true, "Email Sent successfully");
				}
				catch (Exception ex)
				{
					return new(false, "<BR><BR>* Please double check the From Address and Password to confirm that both of them are correct. <br> Further details " + ex.Message);
				}
			}
		}


        public async Task SendMailUsingSendGridAsync(string recipientEmail, string fullName, string subject, string message, string sender, string senderName)
		{
            var apiKey = SiteSettings.SendGrid_SMTP_API;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(sender, senderName);
            //var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(recipientEmail, fullName);
            var plainTextContent = "";
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            //return new(true, JsonConvert.SerializeObject(response));
		}


        public ResponseModel SendMail(string email, string subject, string message, string sender) 
		{
			MailMessage mailMessage = new();
			SmtpClient smtpClient = new();
			mailMessage.From = new MailAddress(sender, "Skill-IT Account Helper");
			mailMessage.To.Add(email);
			mailMessage.Subject = subject;
			mailMessage.IsBodyHtml = true;
			mailMessage.Body = message;
			smtpClient.Host = SiteSettings.SecureMailServer;
			string gmailProvider = "gmail.com";
			if (sender.Contains(gmailProvider))
			{
				try
				{
					smtpClient.Port = SiteSettings.SMTP_Port_If_Google;
					smtpClient.Credentials = new System.Net.NetworkCredential(sender, SiteSettings.AccountHelperEmailPassword);
					smtpClient.EnableSsl = true;
					smtpClient.Send(mailMessage);
					return new(true, "Email Sent successfully");
				}
				catch (Exception ex)
				{
					return new(false, "<BR><BR>* Please double check the From Address and Password to confirm that both of them are correct. <br> Further details "+ex.Message);
					//Response.Write("<BR><BR>If you are using gmail smtp to send email for the first time, please refer to this KB to setup your gmail account: http://www.smarterasp.net/support/kb/a1546/send-email-from-gmail-with-smtp-authentication-but-got-5_5_1-authentication-required-error.aspx?KBSearchID=137388");
				}
			}
			else
			{
				try
				{
					smtpClient.Port = SiteSettings.SMTP_Port1;
					smtpClient.Credentials = new System.Net.NetworkCredential(sender, SiteSettings.AccountHelperEmailPassword);
					smtpClient.EnableSsl = false;
					smtpClient.Send(mailMessage);
					return new(true, "Email Sent successfully");
				}
				catch (Exception ex)
				{
					return new(false, "<BR><BR>* Please double check the From Address and Password to confirm that both of them are correct. <br> Further details " + ex.Message);
				}
			}
		}
	}
}
