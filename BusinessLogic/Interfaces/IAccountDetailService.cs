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
	public interface IAccountDetailService
	{
		ObservableCollection<AccountDetail> GetAllAccountDetails();
		ResponseModel AddAccountDetail(AccountDetail accountDetail);
		AccountDetail GetAccountDetail(long userId);
		ResponseModel UpdateAccountDetail(long id, long id2, AccountDetail accountDetail);
	}
}
