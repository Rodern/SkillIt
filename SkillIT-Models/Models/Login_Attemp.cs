using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillItModels.Models
{
	public class Login_Attemp
	{
		public Login_Attemp()
		{

		}
		public Login_Attemp(DateTime dateTime, string reason, string status)
		{
			DateTime = dateTime;
			Reason = reason;
			Status = status;
		}

		public DateTime DateTime { get; set; }
		public string Reason { get; set; }
		public string Status { get; set; }
	}
}
