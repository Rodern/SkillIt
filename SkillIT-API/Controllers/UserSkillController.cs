using BusinessLogic;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillIT_Models.DatabaseModels;

namespace SkillItAPI.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UserSkillController : ControllerBase
	{
		private readonly IUserSkillService UserSkillService;
		public UserSkillController(IUserSkillService userSkillService)
		{
			UserSkillService = userSkillService;
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
			return Ok(UserSkillService.AddUserSkills(userSkills));
		}

		[HttpPost]
		[Route("AddUserSkill")]
		public IActionResult AddUserSkill(UserSkill userSkill)
		{
			return Ok(UserSkillService.AddUserSkill(userSkill));
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
			return Ok(UserSkillService.UpdateUserSkill(id, userSkill));
		}
	}
}
