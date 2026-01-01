using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using System.Collections.ObjectModel;

namespace SkillIT_Models.CRUD
{
	public interface ICrud
	{
		ResponseModel Add<T>(dynamic id, dynamic value, skill_it_dbContext DbContext);
		ResponseModel Update<T>(dynamic id, dynamic value, skill_it_dbContext DbContext);
		ResponseModel Delete<T>(dynamic id, skill_it_dbContext DbContext);
		T GetSingle<T>(dynamic id, skill_it_dbContext DbContext);
		ObservableCollection<T> Collection<T>(skill_it_dbContext DbContext);
	}
}
