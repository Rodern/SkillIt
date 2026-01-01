using BusinessLogic.Interfaces;
using Newtonsoft.Json;
using SkillIT_Models.CRUD;
using SkillIT_Models.Data;
using SkillIT_Models.Entities.Core;
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
		private readonly ApplicationDbContext DatabaseContext;
		public AccountService(ApplicationDbContext databaseContext)
		{
			this.DatabaseContext = databaseContext;
		}

		public ResponseModel AddAccount(Account account)
		{
			try
			{
				var details = DatabaseContext.Accounts.Where(d => d.Id == account.Id && d.UserId == account.UserId).ToList();
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
			return DatabaseContext.Accounts.Where(ac => ac.Id == accountId).ToList().FirstOrDefault();
		}

		public ObservableCollection<Account> GetAllAccounts()
		{
			return new ObservableCollection<Account>(DatabaseContext.Accounts.ToList());
		}

		public ResponseModel UpdateAccount(long id, long id2, Account account)
		{
			var detail = DatabaseContext.Accounts.Where(ac => ac.Id == id && ac.UserId == id2).FirstOrDefault();
			try
			{
				if (detail != null && account != null)
				{
					//detail.UserId = id2;
				detail.Status = account.Status;
				detail.LoginInfo = account.LoginInfo;
				detail.LoginAttempt = account.LoginAttempt;
					detail.AccountType = account.AccountType;
					detail.User = DatabaseContext.Users.Where(u => u.Id == id2).ToList().FirstOrDefault();
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
            try
            {
                if (creator == null) return new(false, "CreatorNull");
                if (DatabaseContext.Creators.Find(creator.Id) != null) return new(false, "CreatorExists");
                DatabaseContext.Creators.Add(creator);
                DatabaseContext.SaveChanges();
                return new(true, "Success");
            }
            catch (Exception ex)
            {
                return new(false, $"Failed: {ex.Message}");
            }
        }

        public ResponseModel DeleteCreator(long? AuthorId)
        {
            try
            {
                var creator = DatabaseContext.Creators.Find(AuthorId);
                if (creator == null) return new(false, "CreatorNotFound");
                DatabaseContext.Creators.Remove(creator);
                DatabaseContext.SaveChanges();
                return new(true, "Success");
            }
            catch (Exception ex)
            {
                return new(false, $"Failed: {ex.Message}");
            }
        }

        public ResponseModel UpdateCreator(Creator creator)
        {
            try
            {
                if (creator == null) return new(false, "CreatorNull");
                var existing = DatabaseContext.Creators.Find(creator.Id);
                if (existing == null) return new(false, "CreatorNotFound");
                DatabaseContext.Entry(existing).CurrentValues.SetValues(creator);
                DatabaseContext.SaveChanges();
                return new(true, "Success");
            }
            catch (Exception ex)
            {
                return new(false, $"Failed: {ex.Message}");
            }
        }

        public Creator GetCreator(long? AuthorId)
        {
            return DatabaseContext.Creators.Find(AuthorId);
        }

        public ObservableCollection<Creator> GetCreators()
        {
            return new(DatabaseContext.Creators.ToList());
        }
		#endregion

		public ResponseModel SendFirstNotifications(User user)
		{
			var account = DatabaseContext.Accounts.FirstOrDefault(a => a.UserId == user.Id);

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
				AccountId = account.Id,
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
				AccountId = account.Id,
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
				AccountId = account.Id,
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

		public ResponseModel CreateSentMail(SentMail sentMail)
		{
			try
			{
				if (sentMail == null) return new(false, "SentMailNull");
				if (DatabaseContext.SentMails.Find(sentMail.Id) != null) return new(false, "SentMailExists");
				DatabaseContext.SentMails.Add(sentMail);
				DatabaseContext.SaveChanges();
				return new(true, "Success");
			}
			catch (Exception ex)
			{
				return new(false, $"Failed: {ex.Message}");
			}
		}
		public SentMail GetSentMail(int mailId)
		{
			return DatabaseContext.SentMails.Find(mailId);
		}
		public SentMail GetSentMail(long userId)
		{
			return DatabaseContext.SentMails.Find(userId);
		}
		public SentMail GetSentMail(long userId, string type)
		{
			if (Enum.TryParse<EmailSentType>(type, out var emailType))
			{
				return DatabaseContext.SentMails.FirstOrDefault(_ => _.UserId == userId && _.EmailType == emailType);
			}
			return null;
		}

		public Role GetAccountRole(int roleId)
		{
			return DatabaseContext.Roles.Find(roleId);
		}
	}
}
