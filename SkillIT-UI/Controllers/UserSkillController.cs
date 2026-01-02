using AutoMapper;
using BusinessLogic;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;

namespace SkillItAPI.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UserSkillController : ControllerBase
	{
		private readonly IUserSkillService UserSkillService;
		private readonly IMapper _mapper;
		public UserSkillController(IUserSkillService userSkillService, IMapper mapper)
		{
			UserSkillService = userSkillService;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("GetUserSkills")]
		public IActionResult GetUserSkills()
		{
			return Ok(UserSkillService.GetUserSkills());
		}

		[HttpPost]
		[Route("AddUserSkills")]
		public IActionResult AddUserSkills(List<UserSkill> userSkills)
		{
			var entities = _mapper.Map<List<SkillIT_Models.Entities.Core.UserSkill>>(userSkills);
			return Ok(UserSkillService.AddUserSkills(entities));
		}

		[HttpPost]
		[Route("AddUserSkill")]
		public IActionResult AddUserSkill(UserSkill userSkill)
		{
			var entity = _mapper.Map<SkillIT_Models.Entities.Core.UserSkill>(userSkill);
			return Ok(UserSkillService.AddUserSkill(entity));
		}

		[HttpPost]
		[Route("GetUserSkillForUser")]
		public IActionResult GetUserSkillForUser(long userId)
		{
			return Ok(UserSkillService.GetUserSkillForUser(userId));
		}

		[HttpDelete]
		[Route("DeleteUserSkill/{id}")]
		public IActionResult DeleteUserSkill([FromRoute] int id)
		{
			return Ok(UserSkillService.DeleteUserSkill(id));
		}

		[HttpPut]
		[Route("UpdateUserSkill/{id}")]
		public IActionResult UpdateUserSkill([FromRoute] int id, UserSkill userSkill)
		{
			var entity = _mapper.Map<SkillIT_Models.Entities.Core.UserSkill>(userSkill);
			return Ok(UserSkillService.UpdateUserSkill(id, entity));
		}
	}
}
