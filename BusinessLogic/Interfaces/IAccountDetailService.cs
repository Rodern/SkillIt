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
	public interface IAccountDetailService
	{
		ObservableCollection<AccountDetail> GetAllAccountDetails();
		ResponseModel AddAccountDetail(AccountDetail accountDetail);
		AccountDetail GetAccountDetail(int userId);
		ResponseModel UpdateAccountDetail(int id, int id2, AccountDetail accountDetail);
	}
}
