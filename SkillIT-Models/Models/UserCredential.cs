using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillIT_Models.Models
{
	public class UserCredential
	{
		public UserCredential()
		{
			//RememberMe = false;
		}
		public UserCredential(string email, string password, bool rememberMe, string code)
		{
			Email = email;
			Password = password;
			RememberMe = rememberMe;
			Code = code;
		}
		public string Email { get; set; }
		public string Password { get; set; }
		public bool RememberMe { get; set; }
		public string Code { get; set; }
	}
}
