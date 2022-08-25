﻿using BusinessLogic;
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

		[HttpPost]
		[Route("AddUserSkill")]
		public IActionResult AddUserSkill(UserSkill userSkill)
		{
			return Ok(UserSkillService.AddUserSkill(userSkill));
		}

		[HttpPost]
		[Route("GetUserSkillForUser")]
		public IActionResult GetUserSkillForUser(int userId)
		{
			return Ok(UserSkillService.GetUserSkillForUser(userId));
		}

		[HttpPost]
		[Route("DeleteUserSkill")]
		public IActionResult DeleteUserSkill(int id)
		{
			return Ok(UserSkillService.DeleteUserSkill(id));
		}

		[HttpPost]
		[Route("UpdateUserSkill")]
		public IActionResult UpdateUserSkill(int id, UserSkill userSkill)
		{
			return Ok(UserSkillService.UpdateUserSkill(id, userSkill));
		}
	}
}
