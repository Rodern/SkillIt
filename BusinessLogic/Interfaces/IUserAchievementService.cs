using SkillItModels.DatabaseModels;
using SkillItModels.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserAchievementService
    {
        ObservableCollection<UserAchievement> GetAchievements();
        ObservableCollection<UserAchievement> GetUserAchievements(long userId);
        ResponseModel AddUserCerticate(UserAchievement certificate);
        ResponseModel RemoveUserAchievement(int achId, long userId);
        ResponseModel UpdateUserAchievement(UserAchievement certificate);
    }
}

