using System;
using System.Collections.ObjectModel;
using System.Web.Helpers;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;

namespace BusinessLogic
{
	public class UserService: IUserService
	{
		private readonly skill_it_dbContext DatabaseContext;
		private readonly IWebHostEnvironment hostEnvironment;
		private readonly IMailingService MailingService;
		private readonly IOTPService OTPService;
		private readonly IJSRuntime JSRuntime;
		private readonly IAccountService AccountService;
        public AccountStatus AccountStatus = new();
		public UserService(skill_it_dbContext skill_It_DbContext, IWebHostEnvironment webHostEnvironment, IMailingService mailingService, IJSRuntime jSRuntime, IOTPService oTPService, IAccountService accountService)
		{
			this.DatabaseContext = skill_It_DbContext;
			hostEnvironment = webHostEnvironment;
			MailingService = mailingService;
			JSRuntime = jSRuntime;
			OTPService = oTPService;
			AccountService = accountService;
		}
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

		public ResponseModel UpdateProfilePicture(long userId, IFormFile formFile)
		{
			var user = DatabaseContext.Users.FirstOrDefault(u => u.UserId == userId);
			if (user == null) return new(false, "UserNotFound");
			if (formFile == null) return new(false, "FileIsNull");

            string profilesPath = hostEnvironment.WebRootPath + "/site_data/user_profile_pictures/";
			string fileName = $"{user.UserId}_{user.Email}_profileImage.png";
			string fullProfilePath = profilesPath + fileName;
			string profileImageThumbnailPath = profilesPath + $"{fileName}_thumbnail.png";

            using (FileStream fileStream = File.Create(fullProfilePath))
			{
				formFile.CopyTo(fileStream);
                fileStream.Flush();
            }
            using (Image image = Image.Load(fullProfilePath))
            {
                image.Mutate(x => x.Resize(image.Width / 8, image.Height / 8));
                image.SaveAsPng(profileImageThumbnailPath);
            }

			user.ProfileImage = fileName;
			DatabaseContext.SaveChanges();

            return new(true, "Success");
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
						DateCreated = DateTime.UtcNow,
						Email = userModel.Email,
						FirstName = userModel.FirstName,
						LastName = userModel.LastName,
						Password = AuthenticationHelper.EncryptPassword(userModel.Password),
						Dob = userModel.Dob,
						Phone = userModel.Phone,
						Gender = userModel.Gender,
						ProfileImage = userModel.ProfileImage
					};

					Account account = new()
					{
						UserId = user.UserId,
						AccountStatus = "not_verified",
						LoginInfo = JsonConvert.SerializeObject(userModel.LoginInfos),
						LoginAttemp = JsonConvert.SerializeObject(userModel.LoginAttemps),
						AccountType = "user",
						User = user,
						RoleId = 1,
						Role = null,
						Creators = Array.Empty<Creator>(),
						LastLogin = DateTime.UtcNow
					};

					DatabaseContext.Accounts.Add(account);
					DatabaseContext.Users.Add(user);
					DatabaseContext.SaveChanges();

					Otp otp = new()
					{
                        Code = AuthenticationHelper.GenerateOTP(),
						Guid = AuthenticationHelper.GenerateGuid(),
						ExpiryDate = DateTime.UtcNow.AddMonths(2),
						UserId = user.UserId,
						User = null,
					};

					OTPService.AddEmailOTP(otp);
					//Sendmail(user.Email, user.UserId, otp.Guid);

					string emailConfirmationLink = $"{SiteSettings.BaseUrl}/confirm_email/{user.UserId}?guid={otp.Guid}";//$"{SiteSettings.BaseUrl}/confirm_email/{userId}?guid={guid}";
					
					string confirmationEmailTemplate = SiteSettings.GetConfirmEmailTemplate(emailConfirmationLink, "accounthelper@itskills.ovh", SiteSettings.SupportEmail, SiteSettings.BaseUrl);
					string welcomeEmailTemplate = SiteSettings.GetWelcomeEmailTemplate(user.FirstName, SiteSettings.BaseUrl);

					Sentmail confirmationSentmail = new()
					{
						UserId = user.UserId,
						EmailBody = confirmationEmailTemplate,
						DateSent = DateTime.UtcNow,
						EmailType = Account_Status.ConfirmationEmail,
					};
					Sentmail userWelcomeSentmail = new()
					{
						UserId = user.UserId,
						EmailBody = welcomeEmailTemplate,
						DateSent = DateTime.UtcNow,
						EmailType = Account_Status.WelcomeEmail,
					};

					var response = AccountService.CreateSentMail(confirmationSentmail);
					response = AccountService.CreateSentMail(userWelcomeSentmail);

					response = AccountService.SendFirstNotifications(user);

					MailingService.SendMailUsingSendGridAsync(user.Email, $"{user.FirstName} {user.LastName}", $"Welcome {user.FirstName}", welcomeEmailTemplate, SiteSettings.InfoEmail, SiteSettings.InfoEmailName).Wait();
					MailingService.SendMailUsingSendGridAsync(user.Email, $"{user.FirstName} {user.LastName}", "Please confirm your email", confirmationEmailTemplate, SiteSettings.AccountHelperEmail, SiteSettings.AccountHelperEmailName).Wait();

					return new(true, "Success");
				}
				return new(false, "Failed: UserExists");
			}
			catch (Exception ex)
			{
				return new(false, ex.Message);
			}
		}

		public async Task<bool> Sendmail(string email, long userId, string guid)
		{
			string link = $"{SiteSettings.BaseUrl}/confirm_email/{userId}?guid={guid}";//$"{SiteSettings.BaseUrl}/confirm_email/{userId}?guid={guid}";
			string emailTemplate = await JSRuntime.InvokeAsync<string>("getConfirmEmailTemplate", link, "accounthelper@itskills.ovh", email);
			_ = MailingService.SendMail(email, "Please confirm your email", emailTemplate, SiteSettings.AccountHelperEmail);
			JSRuntime.InvokeVoidAsync("alert", emailTemplate);
			return true;
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

		public User GetUser(string email)
		{
			return DatabaseContext.Users.Where(u => u.Email == email).FirstOrDefault();
		}

		public ResponseModel UpdatePassword(long userId, string password)
		{
			try
			{
				User user = DatabaseContext.Users.Where(_ => _.UserId == userId).FirstOrDefault();
				if (user != null)
				{
					/*user.Gender = userModel.Gender;
					user.Address = userModel.Address;
					user.DateCreated = userModel.DateCreated;
					user.Email = userModel.Email;
					user.FirstName = userModel.FirstName;
					user.LastName = userModel.LastName;
					user.Password = userModel.Password;
					user.Dob = userModel.Dob;
					user.Phone = userModel.Phone;
					user.Image = userModel.Image;*/
					user.Password = password;
					DatabaseContext.Entry<User>(user).State = EntityState.Detached;
					DatabaseContext.Users.Update(user);
					DatabaseContext.SaveChanges();
					return new(true, "Success");
				}
				return new(false, Convert.ToString(user.UserId));
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
					user.Password = AuthenticationHelper.EncryptPassword(userModel.Password);
					user.Dob = userModel.Dob;
					user.Phone = userModel.Phone;
					user.ProfileImage = userModel.ProfileImage;
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
