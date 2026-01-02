using AutoMapper;
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
        private readonly IMapper _mapper;
        public AchievementController(IUserAchievementService userAchievementService, IMapper mapper)
        {
            this.userAchievementService = userAchievementService;
            this._mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("add")]
        public IActionResult Add(UserAchievement userAchievement)
        {
            var entity = _mapper.Map<SkillIT_Models.Entities.Learning.UserAchievement>(userAchievement);
            return Ok(userAchievementService.AddUserCerticate(entity));
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("update")]
        public IActionResult Update(UserAchievement userAchievement)
        {
            var entity = _mapper.Map<SkillIT_Models.Entities.Learning.UserAchievement>(userAchievement);
            return Ok(userAchievementService.UpdateUserAchievement(entity));
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
