using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IEngagementService
    {
        ResponseModel Engage(Engagement engagement);
        ResponseModel Disengage(Engagement engagement);
        ObservableCollection<Engagement> Engagements(long userId);
        ObservableCollection<long> EngagementUserIdList(long userId);
    }
}
