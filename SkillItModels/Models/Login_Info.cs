using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillItModels.Models
{
	public class Login_Info
	{
		public Login_Info()
		{

		}
		public Login_Info(string longitude, string latitude, DateTime dateTime, bool isOnline, bool isLoggedOut, string ip, string deviceName)
		{
			Longitude = longitude;
			Latitude = latitude;
			DateTime = dateTime;
			IsOnline = isOnline;
			IsLoggedOut = isLoggedOut;
			Ip = ip;
			DeviceName = deviceName;
		}

		public string Longitude { get; set; }
		public string Latitude { get; set; }
		public DateTime DateTime { get; set; }
		public bool IsOnline { get; set; }
		public bool	IsLoggedOut { get; set; }
		public string Ip { get; set; }
		public string DeviceName { get; set; }
	}
}
