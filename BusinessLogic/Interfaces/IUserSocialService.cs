﻿using SkillItModels.DatabaseModels;
using SkillItModels.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
	public interface IUserSocialService
	{
		ObservableCollection<UserSocial> GetUserSocials();
		List<UserSocial> GetUserSocialForUser(int userId);
		ResponseModel AddUserSocial(UserSocial userSocial);
		ResponseModel UpdateUserSocial(int id, UserSocial userSocial);
		ResponseModel DeleteUserSocial(int id);
	}
}
