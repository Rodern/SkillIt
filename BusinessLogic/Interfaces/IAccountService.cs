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
	public interface IAccountService
	{
		ObservableCollection<Account> GetAllAccounts();
		ResponseModel AddAccount(Account account);
        Account GetUserAccount(long userId);
		ResponseModel UpdateAccount(long id, long id2, Account account);
		Sentmail GetSentMail(int mailId);
		Sentmail GetSentMail(long userId);
		Sentmail GetSentMail(long userId, string type);
		ResponseModel CreateSentMail(Sentmail sentMail);
        Role GetAccountRole(int roleId);
        Account GetAccount(long accountId);
        ResponseModel SendFirstNotifications(User user);
    }
}
