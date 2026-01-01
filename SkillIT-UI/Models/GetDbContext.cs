using SkillIT_Models.DatabaseModels;

namespace SkillIT_UI.Models
{
    public class GetDbContext
    {
        private readonly skill_it_dbContext skill_It_DbContext;
        public GetDbContext(skill_it_dbContext skill_It_DbContext)
        {
            this.skill_It_DbContext = skill_It_DbContext;
        }

        public skill_it_dbContext GetContext()
        {
            return this.skill_It_DbContext;
        }
    }
}
