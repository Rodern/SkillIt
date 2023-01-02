using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillIT_Models.DatabaseModels;

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

		[HttpPost]
		[Route("GetUserSocialForUser")]
		public IActionResult GetUserSocialForUser(long userId)
		{
			return Ok(UserSocialService.GetUserSocialForUser(userId));
		}

		[HttpDelete]
		[Route("DeleteUserSocial/{id}")]
		public IActionResult DeleteUserSocial([FromRoute] int id)
		{
			return Ok(UserSocialService.DeleteUserSocial(id));
		}

		[HttpPut]
		[Route("UpdateUserSocial/{id}")]
		public IActionResult UpdateUserSocial([FromRoute] int id, UserSocial userSocial)
		{
			return Ok(UserSocialService.UpdateUserSocial(id, userSocial));
		}
	}
}
