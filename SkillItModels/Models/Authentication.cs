using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace SkillItModels.Models
{
	public class Authentication
	{
		public static string AuthenticationKey = "SkillIt Authencation";

		public static string EncryptPassword(string password)
		{
			return Crypto.HashPassword(password);
		}

		public static int GenerateOTP()
		{
			return 344215;
		}
	}
}
