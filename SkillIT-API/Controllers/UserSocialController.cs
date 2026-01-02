using AutoMapper;
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
	public class UserSocialController : ControllerBase
	{
		private readonly IUserSocialService UserSocialService;
		private readonly IMapper _mapper;
		public UserSocialController(IUserSocialService userSocialService, IMapper mapper)
		{
			UserSocialService = userSocialService;
			this._mapper = mapper;
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
			var entity = _mapper.Map<SkillIT_Models.Entities.Core.UserSocial>(userSocial);
			return Ok(UserSocialService.AddUserSocial(entity));
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
			var entity = _mapper.Map<SkillIT_Models.Entities.Core.UserSocial>(userSocial);
			return Ok(UserSocialService.UpdateUserSocial(id, entity));
		}
	}
}
