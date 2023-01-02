using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using BusinessLogic.Interfaces;

namespace SkillItAPI.Controllers
{
    [Authorize]
    [Route("api/achievements")]
    [ApiController]
    public class AchievementController : Controller
    {
        private readonly IUserAchievementService userAchievementService;
        public AchievementController(IUserAchievementService userAchievementService)
        {
            this.userAchievementService = userAchievementService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("add")]
        public IActionResult Add(UserAchievement userAchievement)
        {
            return Ok(userAchievementService.AddUserCerticate(userAchievement));
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("update")]
        public IActionResult Update(UserAchievement userAchievement)
        {
            return Ok(userAchievementService.UpdateUserAchievement(userAchievement));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            return Ok(userAchievementService.GetAchievements());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public IActionResult Get(long userId)
        {
            return Ok(userAchievementService.GetUserAchievements(userId));
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(int achId, long userId)
        {
            return Ok(userAchievementService.RemoveUserAchievement(achId, userId)); ;
        }
    }
}
