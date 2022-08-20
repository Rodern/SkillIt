using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillItModels.DatabaseModels;

namespace SkillItAPI.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UserSocialController : ControllerBase
	{
		private readonly IUserSocialService UserSocialService;
		public UserSocialController(IUserSocialService userSocialService)
		{
			UserSocialService = userSocialService;
		}

		[HttpGet]
		[Route("GetUserSocials")]
		public IActionResult GetUserSocials()
		{
			return Ok(UserSocialService.GetUserSocials());
		}

		[HttpPost]
		[Route("AddUserSocial")]
		public IActionResult AddUserSocial(UserSocial userSocial)
		{
			return Ok(UserSocialService.AddUserSocial(userSocial));
		}

		[HttpPut]
		[Route("GetUserSocialForUser/{userId:int}")]
		public IActionResult GetUserSocialForUser([FromRoute] int userId)
		{
			return Ok(UserSocialService.GetUserSocialForUser(userId));
		}

		[HttpPut]
		[Route("DeleteUserSocial/{id:int}")]
		public IActionResult DeleteUserSocial([FromRoute] int id)
		{
			return Ok(UserSocialService.DeleteUserSocial(id));
		}

		[HttpPut]
		[Route("UpdateUserSocial/{id:int}")]
		public IActionResult UpdateUserSocial([FromRoute] int id, UserSocial userSocial)
		{
			return Ok(UserSocialService.UpdateUserSocial(id, userSocial));
		}
	}
}
