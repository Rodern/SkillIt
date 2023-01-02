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
    public class EngagementService : IEngagementService
    {
        private readonly skill_it_dbContext dbContext;
        public EngagementService(skill_it_dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ResponseModel Disengage(Engagement engagement)
        {
            if (engagement == null) return new(false, "EngagementIsNull");
            try
            {
                dbContext.Entry<Engagement>(engagement).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                dbContext.Engagements.Remove(dbContext.Find<Engagement>(engagement.EngagementId));
                dbContext.SaveChanges();
                return new(true, "Success");
            }
            catch (Exception ex)
            {
                return new(false, $"Failed: {ex.Message}");
            }
        }

        public ResponseModel Engage(Engagement engagement)
        {
            if (engagement == null) return new(false, "EngagementIsNull");
            try
            {
                dbContext.Engagements.Add(engagement);
                dbContext.SaveChanges();
                return new(true, "Success");
            }
            catch (Exception ex)
            {
                return new(false, $"Failed: {ex.Message}");
            }
        }

        public ObservableCollection<Engagement> Engagements(long userId)
        {
            return new(dbContext.Engagements.Where(e => e.UserId == userId));
        }

        public ObservableCollection<long> EngagementUserIdList(long userId)
        {
            return new(dbContext.Engagements.Select(e => e.UserId));
        }
    }
}
