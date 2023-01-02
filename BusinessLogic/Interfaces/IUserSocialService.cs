using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
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
		List<UserSocial> GetUserSocialForUser(long userId);
		ResponseModel AddUserSocial(UserSocial userSocial);
		ResponseModel UpdateUserSocial(int id, UserSocial userSocial);
		ResponseModel DeleteUserSocial(int id);
	}
}
