using SkillItModels.DatabaseModels;
using SkillItModels.Models;
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
		List<UserSkill> GetUserSkillForUser(int userId);
		ResponseModel AddUserSkills(List<UserSkill> userSkills);
		ResponseModel UpdateUserSkill(int id, UserSkill userSkill);
		ResponseModel DeleteUserSkill(int id);
	}
}
