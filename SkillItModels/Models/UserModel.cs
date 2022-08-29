﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillItModels.Models
{
	public class UserModel
	{

		public long UserId { get; set; }
		public string Gender { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime Dob { get; set; }
		public string Address { get; set; }
		public DateTime DateCreated { get; set; }
		public string Phone { get; set; }
		public string ImgBase64 { get; set; }
		public List<Login_Info> LoginInfos { get; set; }
		public List<Login_Attemp> LoginAttemps { get; set; }
	}
}
