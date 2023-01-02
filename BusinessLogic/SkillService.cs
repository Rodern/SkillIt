using BusinessLogic.Interfaces;
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
	public class SkillService : ISkillService
	{
		private readonly skill_it_dbContext DatabaseContext;
		public SkillService(skill_it_dbContext databaseContext)
		{
			DatabaseContext = databaseContext;
		}

		public ResponseModel AddSkill(Skill skill)
		{
			try
			{
				Skill this_skill = DatabaseContext.Skills.Where(s => s.SkillId == skill.SkillId).ToList().FirstOrDefault();
				if (this_skill == null)
				{
					DatabaseContext.Skills.Add(skill);
					DatabaseContext.SaveChanges();
					return new(true, "Success");
				}
				return new(false, "SkillExists");
			}
			catch (Exception ex) { return new(false, ex.Message); }
		}

		public ResponseModel DeleteSkill(int id)
		{
			try
			{
				Skill skill = DatabaseContext.Skills.Where(s => s.SkillId == id).FirstOrDefault();
				if (skill == null) return new(false, "NotFound");
				DatabaseContext.Entry<Skill>(skill).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
				DatabaseContext.Skills.Remove(skill);
				DatabaseContext.SaveChanges();
				return new(true, "Success");
			}
			catch (Exception ex)
			{
				return new(false, ex.Message);
			}
		}

		public Skill GetSkill(int id)
		{
			return DatabaseContext.Skills.Where(s => s.SkillId == id).FirstOrDefault();
		}

		public ObservableCollection<Skill> GetSkills()
		{
			return new ObservableCollection<Skill>(DatabaseContext.Skills.ToList());
		}

		public ResponseModel UpdateSkill(int id, Skill skill)
		{
			try
			{
				Skill this_skill = DatabaseContext.Skills.Where(s => s.SkillId == id).ToList().FirstOrDefault();
				if (this_skill == null) return new(false, "NotFound");
				//this_skill.SkillId = skill.SkillId;
				this_skill.Name	= skill.Name;
				this_skill.Level = skill.Level;
				DatabaseContext.Entry<Skill>(this_skill).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
				DatabaseContext.Skills.Update(this_skill);
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
