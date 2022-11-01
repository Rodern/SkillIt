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
	public class SocialService : ISocialService
	{
		private readonly SkillItModels.DatabaseModels.skillit_dbContext DatabaseContext;
		public SocialService(SkillItModels.DatabaseModels.skillit_dbContext skill_It_DbContext)
		{
			this.DatabaseContext = skill_It_DbContext;
		}
		public ResponseModel AddSocial(Social social)
		{
			try
			{
				var this_social = DatabaseContext.Socials.Where(s => s.SocialId == social.SocialId).FirstOrDefault();
				if (this_social == null)
				{
					DatabaseContext.Socials.Add(social);
					DatabaseContext.SaveChanges();
					return new(true, "Success");
				}
				return new(false, "SocialExists");
			}
			catch (Exception ex)
			{
				return new(false, ex.Message);
			}
		}

		public ResponseModel DeleteSocial(int id)
		{
			try
			{
				var social = DatabaseContext.Socials.Where(s => s.SocialId == id).FirstOrDefault();
				DatabaseContext.Entry<Social>(social).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
				DatabaseContext.Socials.Remove(social);
				DatabaseContext.SaveChanges();
				return new(true, "Success");
			}
			catch (Exception ex)
			{
				return new(false, ex.Message);
			}
		}

		public Social GetSocial(int id)
		{
			return DatabaseContext.Socials.Where(s => s.SocialId == id).ToList().FirstOrDefault();
		}

		public ObservableCollection<Social> GetSocials()
		{
			return new ObservableCollection<Social>(DatabaseContext.Socials.ToList());
		}

		public ResponseModel UpdateSocial(int id, Social social)
		{
			try
			{
				var this_social = DatabaseContext.Socials.Where(s => s.SocialId == id).FirstOrDefault();
				if (this_social == null)
				{
					return new(false, "NotFound");
				}
				this_social.Name = social.Name;
				this_social.Link = social.Link;
				DatabaseContext.Entry<Social>(this_social).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
				DatabaseContext.Update(this_social);
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
