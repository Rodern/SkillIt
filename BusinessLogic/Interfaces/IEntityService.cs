using SkillIT_Models.Models;

namespace BusinessLogic.Interfaces
{
    public interface IEntityService
    {
        ResponseModel AddEntity<T>(T entity) where T : class;
        ResponseModel DeleteEntity<T>(int id) where T : class;
        ResponseModel DeleteEntity<T>(long id) where T : class;
        ResponseModel UpdateEntity<T>(T entity) where T : class;
    }
}