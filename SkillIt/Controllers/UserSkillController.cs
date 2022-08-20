using BusinessLogic;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillItModels.DatabaseModels;

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

		[HttpPut]
		[Route("GetUserSkill/{userId:int}")]
		public IActionResult GetUserSkill([FromRoute] int userId)
		{
			return Ok(UserSkillService.GetUserSkillForUser(userId));
		}

		[HttpPut]
		[Route("DeleteUserSkill/{id:int}")]
		public IActionResult DeleteUserSkill([FromRoute] int id)
		{
			return Ok(UserSkillService.DeleteUserSkill(id));
		}

		[HttpPut]
		[Route("UpdateUserSkill/{id:int}")]
		public IActionResult UpdateUserSkill([FromRoute] int id, UserSkill userSkill)
		{
			return Ok(UserSkillService.UpdateUserSkill(id, userSkill));
		}
	}
}
