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
    public class UserAchievementService : IUserAchievementService
    {
        private readonly skill_it_dbContext DatabaseContext;
        public UserAchievementService(skill_it_dbContext skill_It_DbContext)
        {
            DatabaseContext = skill_It_DbContext;
        }
        ObservableCollection<UserAchievement> addToCollection(ObservableCollection<UserAchievement> userAchievements)
        {
            int j = userAchievements.Count;
            for (int i = 0; i < j; i++)
            {
                userAchievements[i].Ach = new Achievement();
                userAchievements[i].Ach = DatabaseContext.Achievements.Where(s => s.AchId == userAchievements[i].AchId).FirstOrDefault();
            }
            return userAchievements;
        }
        public ResponseModel AddUserCerticate(UserAchievement achievement)
        {
            if (achievement == null) return new(false, "AchievementIsNull");
            try
            {
                DatabaseContext.UserAchievements.Add(achievement);
                DatabaseContext.SaveChanges();
                return new(true, "Success");
            }
            catch (Exception ex)
            {
                return new(false, $"Failed: {ex.Message}");
            }
        }

        public ObservableCollection<UserAchievement> GetAchievements()
        {
            return new ObservableCollection<UserAchievement>(addToCollection(new(DatabaseContext.UserAchievements)));
        }

        public ResponseModel RemoveUserAchievement(int achId, long userId)
        {
            UserAchievement achievement = DatabaseContext.UserAchievements.Where(_ => _.AchId == achId && _.UserId == userId).FirstOrDefault();
            if (achievement == null) return new(false, "AchievementIsNull");
            try
            {
                DatabaseContext.Entry<UserAchievement>(achievement).State = EntityState.Deleted;
                DatabaseContext.Entry<Achievement>(DatabaseContext.Find<Achievement>(achievement.AchId)).State = EntityState.Deleted;
                //DatabaseContext.UserAchievements.Update(achievement);
                DatabaseContext.SaveChanges();
                return new(true, "Success");
            }
            catch (Exception ex)
            {
                return new(false, $"Failed: {ex.Message}");
            }
        }

        public ResponseModel UpdateUserAchievement(UserAchievement achievement)
        {
            if (achievement == null) return new(false, "AchievementIsNull");
            try
            {
                DatabaseContext.Entry<UserAchievement>(achievement).State = EntityState.Detached;
                DatabaseContext.Entry<Achievement>(achievement.Ach).State = EntityState.Detached;
                DatabaseContext.UserAchievements.Update(achievement);
                DatabaseContext.Achievements.Update(achievement.Ach);
                DatabaseContext.SaveChanges();
                return new(true, "Success");
            }
            catch (Exception ex)
            {
                return new(false, $"Failed: {ex.Message}");
            }
        }

        public ObservableCollection<UserAchievement> GetUserAchievements(long userId)
        {
            return new ObservableCollection<UserAchievement>(addToCollection(new(DatabaseContext.UserAchievements.Where(_ => _.UserId == userId))));
        }
    }
}
