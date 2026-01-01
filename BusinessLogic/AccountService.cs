using BusinessLogic.Interfaces;
using Newtonsoft.Json;
using SkillIT_Models.CRUD;
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
	public class AccountService : IAccountService
	{
		private readonly skill_it_dbContext DatabaseContext;
		public AccountService(skill_it_dbContext databaseContext)
		{
			this.DatabaseContext = databaseContext;
		}

		public ResponseModel AddAccount(Account account)
		{
			try
			{
				var details = DatabaseContext.Accounts.Where(d => d.AccountId == account.AccountId && d.UserId == account.UserId).ToList();
				if (details.Count > 0) return new(false, "Failed");
				DatabaseContext.Accounts.Add(account);
				DatabaseContext.SaveChanges();
				return new(true, "Success");
			}
			catch(Exception ex)
			{
				return new(false, ex.Message);
			}
		}

		public Account GetUserAccount(long userId)
		{
			return DatabaseContext.Accounts.Where(ac => ac.UserId == userId).ToList().FirstOrDefault();
		}
		public Account GetAccount(long accountId)
		{
			return DatabaseContext.Accounts.Where(ac => ac.AccountId == accountId).ToList().FirstOrDefault();
		}

		public ObservableCollection<Account> GetAllAccounts()
		{
			return new ObservableCollection<Account>(DatabaseContext.Accounts.ToList());
		}

		public ResponseModel UpdateAccount(long id, long id2, Account account)
		{
			var detail = DatabaseContext.Accounts.Where(ac => ac.AccountId == id && ac.UserId == id2).FirstOrDefault();
			try
			{
				if (detail != null && account != null)
				{
					//detail.UserId = id2;
					detail.AccountStatus = account.AccountStatus;
					detail.LoginInfo = account.LoginInfo;
					detail.LoginAttemp = account.LoginAttemp;
					detail.AccountType = account.AccountType;
					detail.User = DatabaseContext.Users.Where(u => u.UserId == id2).ToList().FirstOrDefault();
					detail.LastLogin = account.LastLogin;
					DatabaseContext.Accounts.Update(detail);
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
        #region CreatorServices 
        public ResponseModel CreateCreator(Creator creator)
        {
            return Crud.Create(creator.AuthorId, creator, DatabaseContext);
        }

        public ResponseModel DeleteCreator(long? AuthorId)
        {
            return Crud.Delete<Creator>(AuthorId, DatabaseContext);
        }

        public ResponseModel UpdateCreator(Creator creator)
        {
            return Crud.Update(creator.AuthorId, creator, DatabaseContext);
        }

        public Creator GetCreator(long? AuthorId)
        {
            return Crud.Read<Creator>(AuthorId, DatabaseContext);
        }

        public ObservableCollection<Creator> GetCreators()
        {
            return new(DatabaseContext.Creators.ToList());
        }
		#endregion

		public ResponseModel SendFirstNotifications(User user)
		{
			var account = DatabaseContext.Accounts.FirstOrDefault(a => a.UserId == user.UserId);

			var actions = new ObservableCollection<NotificationAction>()
			{
				new NotificationAction
				{
					Name = "Catalogs",
					Command = "/catalogs"
				},
				new NotificationAction
				{
					Name = "Courses",
					Command = "/courses"
				},
				new NotificationAction
				{
					Name = "Dashboard",
					Command = "/user/dashboard"
				},
			};

			
            Notification notification1 = new()
            {
				AccountId = account.AccountId,
				NotificationGuid = AuthenticationHelper.GenerateGuid(),
				Caption = $"Welcome {user.FirstName} to Skill-IT",
				Details = $"Welcome and thank you for signing up on the Skill-IT website. We're really happy to have you! Checkout the links below.",
				DateCreated = DateTime.UtcNow,
				Actions = JsonConvert.SerializeObject(actions),
				Icon = "notify.png",
			};


            actions = new()
            {
                new()
                {
                    Name = "Dashboard",
                    Command = "/user/dashboard"
                }
            };
            Notification notification2 = new()
            {
				AccountId = account.AccountId,
				NotificationGuid = AuthenticationHelper.GenerateGuid(),
				Caption = $"Actions required {user.FirstName}!",
				Details = $"Please visit your dashboard and complete your profile setup. Thanks",
				DateCreated = DateTime.UtcNow,
				Actions = JsonConvert.SerializeObject(actions),
				Icon = "notify.png",
			};

			actions = new();
            Notification notification3 = new()
            {
				AccountId = account.AccountId,
				NotificationGuid = AuthenticationHelper.GenerateGuid(),
				Caption = $"{user.FirstName} verify email",
				Details = $"Your account is not yet verified. In order to do so please, visit your email provider and check your mails for email and complete the verification.",
				DateCreated = DateTime.UtcNow,
				Actions = JsonConvert.SerializeObject(actions),
				Icon = "notify.png",
			};

			DatabaseContext.Notifications.Add(notification1);
			DatabaseContext.Notifications.Add(notification2);
			DatabaseContext.Notifications.Add(notification3);
			DatabaseContext.SaveChanges();

			return new(true, "Done!");
        }

		public ResponseModel CreateSentMail(Sentmail sentMail)
		{
			return Crud.Create(sentMail.MailId, sentMail, DatabaseContext);
		}
		public Sentmail GetSentMail(int mailId)
		{
			return Crud.Read<Sentmail>(mailId, DatabaseContext);
		}
		public Sentmail GetSentMail(long userId)
		{
			return Crud.Read<Sentmail>(userId, DatabaseContext);
		}
		public Sentmail GetSentMail(long userId, string type)
		{
			return DatabaseContext.Sentmails.FirstOrDefault(_ => _.UserId == userId && _.EmailType == type);
		}


		public Role GetAccountRole(int roleId)
		{
			return DatabaseContext.Roles.Find(roleId);
		}
	}
}
