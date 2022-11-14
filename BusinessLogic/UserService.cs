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
		private readonly SkillItModels.DatabaseModels.skillit_dbContext DatabaseContext;
		public AccountStatus AccountStatus = new AccountStatus();
		public UserService(SkillItModels.DatabaseModels.skillit_dbContext skill_It_DbContext)
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
						Gender = userModel.Gender,
						Image = userModel.Image
					};

					AccountDetail accountDetail = new AccountDetail
					{
						UserId = user.UserId,
						AccountStatus = "not_verified",
						LoginInfo = JsonConvert.SerializeObject(userModel.LoginInfos),
						LoginAttemp = JsonConvert.SerializeObject(userModel.LoginAttemps),
						AccountType	= "user",
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

		public User GetUser(long id)
		{
			var user = DatabaseContext.Users.Where(u => u.UserId == id).FirstOrDefault();
			if(user != null)
			{
				return user;
			}
			return new();
		}

		public ResponseModel UpdatePassword(long userId, UserModel userModel)
		{
			try
			{
				var user = DatabaseContext.Users.Where(u => u.UserId == userId).FirstOrDefault();
				if (user != null)
				{
					user.Gender = userModel.Gender;
					user.Address = userModel.Address;
					user.DateCreated = userModel.DateCreated;
					user.Email = userModel.Email;
					user.FirstName = userModel.FirstName;
					user.LastName = userModel.LastName;
					user.Password = userModel.Password;
					user.Dob = userModel.Dob;
					user.Phone = userModel.Phone;
					user.Image = userModel.Image;
					DatabaseContext.Entry<User>(user).State = EntityState.Detached;
					DatabaseContext.Users.Update(user);
					DatabaseContext.SaveChanges();
					return new(true, "Success");
				}
				return new(false, Convert.ToString(userId));
			}
			catch (Exception ex)
			{
				return new(false, ex.Message);
			}
		}

		public ResponseModel UpdateUser(long userId, UserModel userModel)
		{
			try
			{
				var user = DatabaseContext.Users.Where(u => u.UserId == userId).FirstOrDefault();
				if (user != null)
				{
					user.Gender = userModel.Gender;
					user.Address = userModel.Address;
					user.DateCreated = userModel.DateCreated;
					user.Email = userModel.Email;
					user.FirstName = userModel.FirstName;
					user.LastName = userModel.LastName;
					user.Password = Authentication.EncryptPassword(userModel.Password);
					user.Dob = userModel.Dob;
					user.Phone = userModel.Phone;
					user.Image = userModel.Image;
					DatabaseContext.Entry<User>(user).State = EntityState.Detached;
					DatabaseContext.Users.Update(user);
					DatabaseContext.SaveChanges();
					return new(true, "Success");
				}
				return new(false, Convert.ToString(userId));
			}
			catch (Exception ex)
			{
				return new(false, ex.Message);
			}
		}
	}
}
