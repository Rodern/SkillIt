using BusinessLogic.Interfaces;
using SkillIT_Models.Data;
using SkillIT_Models.Entities.Learning;
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
        private readonly ApplicationDbContext dbContext;
        public EngagementService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ResponseModel Disengage(Engagement engagement)
        {
            if (engagement == null) return new(false, "EngagementIsNull");
            try
            {
                dbContext.Entry<Engagement>(engagement).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                dbContext.Engagements.Remove(dbContext.Find<Engagement>(engagement.Id));
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

        public ObservableCollection<long> EngagementCatalogIdList(int catalogId)
        {
            return new(dbContext.Engagements.Select(e => e.CatalogId));
        }

        public ObservableCollection<Engagement> Engagements(long userId)
        {
            return new(dbContext.Engagements.Where(e => e.UserId == userId));
        }

        public ObservableCollection<long> EngagementUserCatalogIdList(int catalogId, long userId)
        {
            return new(dbContext.Engagements.Where(e => e.UserId == userId).Select(e => e.CatalogId));
        }

        public ObservableCollection<long> EngagementUserIdList(long userId)
        {
            return new(dbContext.Engagements.Select(e => e.UserId));
        }
    }
}
