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
	public interface IUserSkillService
	{
		ObservableCollection<UserSkill> GetUserSkills();
		List<UserSkill> GetUserSkillForUser(long userId);
		ResponseModel AddUserSkills(List<UserSkill> userSkills);
		ResponseModel AddUserSkill(UserSkill userSkill);
		ResponseModel UpdateUserSkill(int id, UserSkill userSkill);
		ResponseModel DeleteUserSkill(int id);
	}
}
