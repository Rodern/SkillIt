using AutoMapper;
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
        private readonly IMapper _mapper;
        public EngagementController(IEngagementService engagementService, IMapper mapper)
        {
            this.engagementService = engagementService;
            this._mapper = mapper;
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
            var entity = _mapper.Map<SkillIT_Models.Entities.Learning.Engagement>(engagement);
            return Ok(engagementService.Engage(entity));
        }
        [HttpDelete]
        [Route("remove")]
        public IActionResult Remove(Engagement engagement)
        {
            var entity = _mapper.Map<SkillIT_Models.Entities.Learning.Engagement>(engagement);
            return Ok(engagementService.Disengage(entity));
        }
    }
}
