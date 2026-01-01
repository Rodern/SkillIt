using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillIT_Models.Models
{
	public enum AccountStatus
	{
		Suspended,
		Unverified,
		Verified,
		Banned
	}
	public enum Level
	{
		Beginner,
		Amateur,
		Intermediate,
		Professional,
		GodLevel
	}

	public class Account_Status
	{
		public Account_Status()
		{

		}
		public static string WelcomeEmail { get; set; } = "welcome_email";
		public static string ResetPasswordEmail { get; set; } = "reset_password";
		public static string ConfirmationEmail { get; set; } = "verify_email";
		public static string CourseRegisteredEmail { get; set; } = "course_registered";
		public static string CourseCompletedEmail { get; set; } = "course_completed";
	}
}
