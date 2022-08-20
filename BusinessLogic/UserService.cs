using System.Collections.ObjectModel;
using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SkillItModels.DatabaseModels;
using SkillItModels.Models;

namespace BusinessLogic
{
	public class UserService: IUserService
	{
		private readonly skill_it_dbContext DatabaseContext;
		public AccountStatus AccountStatus = new AccountStatus();
		public UserService(skill_it_dbContext skill_It_DbContext)
		{
			this.DatabaseContext = skill_It_DbContext;
		}

		public ObservableCollection<User> GetAllUsers()
		{
			var users = DatabaseContext.Users.ToList();
			return new ObservableCollection<User>(users);
		}

		public ResponseModel CheckEmailExistence(string email)
		{
			bool ItExists = DatabaseContext.Users.ToList().Any(x => x.Email == email);
			if (ItExists == true) return new(true, "EmailExists");
			return new(false, "EmailNotExisting");
		}

		public ResponseModel AddUser(UserModel userModel)
		{
			var users = DatabaseContext.Users.Where(u => u.UserId == userModel.UserId).ToList();
			try
			{
				if (users.Count == 0)
				{
					User user = new()
					{
						UserId = userModel.UserId,
						Address = userModel.Address,
						DateCreated = userModel.DateCreated,
						Email = userModel.Email,
						FirstName = userModel.FirstName,
						LastName = userModel.LastName,
						Password = Authentication.EncryptPassword(userModel.Password),
						Dob = userModel.Dob,
						Phone = userModel.Phone,
						Username = userModel.Username,
						UserSkillId = userModel.UserSkillId,
						UserSocialId = userModel.UserSocialId
					};

					AccountDetail accountDetail = new AccountDetail
					{
						UserId = user.UserId,
						AccountStatus = "not_verified",
						LoginInfo = JsonConvert.SerializeObject(userModel.LoginInfos),
						LoginAttemp = JsonConvert.SerializeObject(userModel.LoginAttemps),
						User = user,
						LastLogin = DateTime.Now
					};

					DatabaseContext.AccountDetails.Add(accountDetail);
					DatabaseContext.Users.Add(user);
					DatabaseContext.SaveChanges();
					return new(true, "Success");
				}
				return new(false, "Failed: UserExists");
			}
			catch (Exception ex)
			{
				return new(false, ex.Message);
			}
		}

		public User GetUser(int id)
		{
			var user = DatabaseContext.Users.Where(u => u.UserId == id).FirstOrDefault();
			if(user != null)
			{
				return user;
			}
			return new();
		}

		public ResponseModel UpdateUser(int id, UserModel userModel)
		{
			try
			{
				var user = DatabaseContext.Users.Where(u => u.UserId == id).FirstOrDefault();
				if (user != null)
				{
					user.Username = userModel.Username;
					user.Address = userModel.Address;
					user.DateCreated = userModel.DateCreated;
					user.Email = userModel.Email;
					user.FirstName = userModel.FirstName;
					user.LastName = userModel.LastName;
					user.Password = userModel.Password;
					user.Dob = userModel.Dob;
					user.Phone = userModel.Phone;
					user.UserSkillId = userModel.UserSkillId;
					user.UserSocialId = userModel.UserSocialId;
					DatabaseContext.Users.Update(user);
					DatabaseContext.SaveChanges();
					return new(true, "Success");
				}
				return new(false, "NotFound");
			}
			catch (Exception ex)
			{
				return new(false, ex.Message);
			}
		}
	}
}
