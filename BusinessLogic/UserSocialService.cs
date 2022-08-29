using BusinessLogic.Interfaces;
using SkillItModels.DatabaseModels;
using SkillItModels.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class UserSocialService : IUserSocialService
	{
		private readonly skillit_dbContext DatabaseContext;
		public UserSocialService(skillit_dbContext databaseContext)
		{
			DatabaseContext = databaseContext;
		}

		public ResponseModel AddUserSocial(UserSocial userSocial)
		{
			try
			{
				DatabaseContext.UserSocials.Add(userSocial);
				DatabaseContext.SaveChanges();
				return new(true, "Success");
			}
			catch(Exception ex)
			{
				return new(false, ex.Message);
			}
		}
		List<UserSocial> addSocial(List<UserSocial> userSocials)
		{
			int j = userSocials.Count;
			for (int i = 0; i < j; i++)
			{
				userSocials[i].Social = new Social();
				userSocials[i].Social = DatabaseContext.Socials.Where(s => s.SocialId == userSocials[i].SocialId).FirstOrDefault();
			}
			return userSocials;
		}
		public ResponseModel DeleteUserSocial(int id)
		{
			try
			{
				UserSocial userSocial = DatabaseContext.UserSocials.Where(us => us.UserSocialId == id).FirstOrDefault();
				//Social social = DatabaseContext.Socials.Where(s => s.SocialId == userSocial.SocialId).FirstOrDefault();
				DatabaseContext.UserSocials.Remove(userSocial);
				//DatabaseContext.Socials.Remove(social);
				DatabaseContext.SaveChanges();
				return new(true, "Success");
			}
			catch (Exception ex)
			{
				return new(false, ex.Message);
			}
		}

		public List<UserSocial> GetUserSocialForUser(long userId)
		{
			List<UserSocial> userSocials = new List<UserSocial>(DatabaseContext.UserSocials.Where(s => s.UserId == userId));
			return addSocial(userSocials);
		}

		public ObservableCollection<UserSocial> GetUserSocials()
		{
			return new ObservableCollection<UserSocial>(addSocial(new List<UserSocial>(DatabaseContext.UserSocials)));
		}

		public ResponseModel UpdateUserSocial(int id, UserSocial userSocial)
		{
			try
			{
				UserSocial this_userSocial = DatabaseContext.UserSocials.Where(s => s.UserSocialId == id).FirstOrDefault();
				if (this_userSocial == null) return new(false, "NotFound");
				//this_userSocial = userSocial;
				DeleteUserSocial(id);
				AddUserSocial(userSocial);
				DatabaseContext.SaveChanges();
				return new(true, "Success");
			}
			catch (Exception ex)
			{
				return new(false, ex.Message);
			}
		}
	}
}
