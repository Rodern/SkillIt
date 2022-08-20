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
	public interface ISocialService
	{
		ObservableCollection<Social> GetSocials();
		Social GetSocial(int id);
		ResponseModel AddSocial(Social social);
		ResponseModel UpdateSocial(int id, Social social);
		ResponseModel DeleteSocial(int id);
	}
}
