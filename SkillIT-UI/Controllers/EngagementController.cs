using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;

namespace SkillItAPI.Controllers
{
    [Authorize]
    [Route("api/Engagement")]
    [ApiController]
    public class EngagementController : ControllerBase
    {
        private readonly IEngagementService engagementService;
        public EngagementController(IEngagementService engagementService)
        {
            this.engagementService = engagementService;
        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get(long userId)
        {
            return Ok(engagementService.Engagements(userId));
        }
        [HttpGet]
        [Route("getList")]
        public IActionResult GetList(long userId)
        {
            return Ok(engagementService.EngagementUserIdList(userId));
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Add(Engagement engagement)
        {
            return Ok(engagementService.Engage(engagement));
        }
        [HttpDelete]
        [Route("remove")]
        public IActionResult Remove(Engagement engagement)
        {
            return Ok(engagementService.Disengage(engagement));
        }
    }
}
