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
	public interface ISkillService
	{
		ObservableCollection<Skill> GetSkills();
		Skill GetSkill(int id);
		ResponseModel AddSkill(Skill skill);
		ResponseModel UpdateSkill(int id, Skill skill);
		ResponseModel DeleteSkill(int id);
	}
}
