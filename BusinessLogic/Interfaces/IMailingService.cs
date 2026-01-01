using SkillIT_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
	public interface IMailingService
	{
		Task<ResponseModel> SendConfirmEmailTemplate(string email, string ac_email, string link);
		Task<ResponseModel> SendCourseCompletedEmail(string email, string courseName, DateTime completionDate, string link, string ux_email, string feedbackLink);
		Task<ResponseModel> SendCourseRegisteredEmail(string email, string courseName, DateTime startDate, string link, string ux_email, string feedbackLink);
		ResponseModel SendResetEmailTemplate(string email, string link);
		public ResponseModel SendMail(string email, string subject, string message, string sender);
		Task<ResponseModel> SendWelcomeEmail(string name, string email);
		ResponseModel SendMailWithInFoMaill(string email, string subject, string message, string sender);
		ResponseModel SendMailWithSupportMaill(string email, string subject, string message, string sender);
        Task SendMailUsingSendGridAsync(string recipientEmail, string fullName, string subject, string message, string sender, string senderName);
    }
}
