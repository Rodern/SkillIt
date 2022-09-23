using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
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
	public class UserSkillService : IUserSkillService
	{
		private readonly skillit_dbContext DatabaseContext;
		public UserSkillService(skillit_dbContext databaseContext)
		{
			DatabaseContext = databaseContext;
		}

		public ResponseModel AddUserSkills(List<UserSkill> userSkills)
		{
			try
			{
				DatabaseContext.UserSkills.AddRange(userSkills);
				DatabaseContext.SaveChanges();
				return new(true, "Success");
			}
			catch (Exception ex)
			{
				return new(false, ex.Message);
			}
		}

		public ResponseModel AddUserSkill(UserSkill userSkill)
		{
			try
			{
				DatabaseContext.UserSkills.Add(userSkill);
				DatabaseContext.SaveChanges();
				return new(true, "Success");
			}
			catch (Exception ex)
			{
				return new(false, ex.Message);
			}
		}
		List<UserSkill> addSkill(List<UserSkill> userSkills)
		{
			int j = userSkills.Count;
			for (int i = 0; i < j; i++)
			{
				userSkills[i].Skill = new Skill();
				userSkills[i].Skill = DatabaseContext.Skills.Where(s => s.SkillId == userSkills[i].SkillId).FirstOrDefault();
			}
			return userSkills;
		}
		public ResponseModel DeleteUserSkill(int id)
		{
			try
			{
				UserSkill userSkill = DatabaseContext.UserSkills.Find(id);
				Skill skill = DatabaseContext.Skills.Where(s => s.SkillId == userSkill.SkillId).FirstOrDefault();
				DatabaseContext.Entry<UserSkill>(userSkill).State = EntityState.Detached;
				DatabaseContext.Entry<Skill>(skill).State = EntityState.Detached;
				DatabaseContext.UserSkills.Remove(userSkill);
				DatabaseContext.Skills.Remove(skill);
				DatabaseContext.SaveChanges();
				return new(true, "Success");
			}
			catch (Exception ex)
			{
				return new(false, ex.Message);
			}
		}

		public List<UserSkill> GetUserSkillForUser(long userId)
		{
			List<UserSkill> userSkills = new List<UserSkill>(DatabaseContext.UserSkills.Where(s => s.UserId == userId));
			return addSkill(userSkills);
		}

		public ObservableCollection<UserSkill> GetUserSkills()
		{
			return new ObservableCollection<UserSkill>(addSkill(new List<UserSkill>(DatabaseContext.UserSkills)));
		}

		public ResponseModel UpdateUserSkill(int id, UserSkill userSkill)
		{
			try
			{
				UserSkill this_userSkill = DatabaseContext.UserSkills.Where(s => s.UserSkillId == id).FirstOrDefault();
				if (this_userSkill == null) return new(false, $"NotFound {id}");
				//this_userSkill = userSkill;
				DeleteUserSkill(id);
				AddUserSkill(userSkill);
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
