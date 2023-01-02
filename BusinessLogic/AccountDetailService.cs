using BusinessLogic.Interfaces;
using Newtonsoft.Json;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class AccountDetailService : IAccountDetailService
	{
		private readonly skill_it_dbContext DatabaseContext;
		public AccountDetailService(skill_it_dbContext databaseContext)
		{
			this.DatabaseContext = databaseContext;
		}

		public ResponseModel AddAccountDetail(AccountDetail accountDetail)
		{
			try
			{
				var details = DatabaseContext.AccountDetails.Where(d => d.AccountId == accountDetail.AccountId && d.UserId == accountDetail.UserId).ToList();
				if (details.Count > 0) return new(false, "Failed");
				DatabaseContext.AccountDetails.Add(accountDetail);
				DatabaseContext.SaveChanges();
				return new(true, "Success");
			}
			catch(Exception ex)
			{
				return new(false, ex.Message);
			}
		}

		public AccountDetail GetAccountDetail(long userId)
		{
			return DatabaseContext.AccountDetails.Where(ac => ac.UserId == userId).ToList().FirstOrDefault();
		}

		public ObservableCollection<AccountDetail> GetAllAccountDetails()
		{
			return new ObservableCollection<AccountDetail>(DatabaseContext.AccountDetails.ToList());
		}

		public ResponseModel UpdateAccountDetail(long id, long id2, AccountDetail accountDetail)
		{
			var detail = DatabaseContext.AccountDetails.Where(ac => ac.AccountId == id && ac.UserId == id2).FirstOrDefault();
			try
			{
				if (detail != null && accountDetail != null)
				{
					//detail.UserId = id2;
					detail.AccountStatus = accountDetail.AccountStatus;
					detail.LoginInfo = accountDetail.LoginInfo;
					detail.LoginAttemp = accountDetail.LoginAttemp;
					detail.AccountType = accountDetail.AccountType;
					detail.User = DatabaseContext.Users.Where(u => u.UserId == id2).ToList().FirstOrDefault();
					detail.LastLogin = accountDetail.LastLogin;
					DatabaseContext.AccountDetails.Update(detail);
					DatabaseContext.SaveChanges();
					return new(true, "Success");
				}
				return new(false, "Failed");
			}
			catch(Exception ex)
			{
				return new(false, ex.Message);
			}
		}
	}
}
