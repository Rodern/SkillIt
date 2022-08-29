using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillItModels.DatabaseModels;
using SkillItModels.Models;

namespace SkillItAPI.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService userService;
		public UserController(IUserService userService)
		{
			this.userService = userService;
		}

		[HttpGet]
		[Route("GetAllUsers")]
		public IActionResult GetAllUsers()
		{
			var data = userService.GetAllUsers();
			return Ok(data);
		}

		[HttpPost]
		[Route("GetUser")]
		public IActionResult GetUser(long id)
		{
			var data = userService.GetUser(id);
			return Ok(data);
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("CheckEmailExistence")]
		public IActionResult CheckEmailExistence(string email)
		{
			return Ok(userService.CheckEmailExistence(email));
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("AddUser")]
		public IActionResult AddUser(UserModel user)
		{
			var data = userService.AddUser(user);
			return Ok(data);
		}

		[HttpPost]
		[Route("UpdateUser")]
		public IActionResult UpdateUser(long id, UserModel user)
		{
			var data = userService.UpdateUser(id, user);
			return Ok(data);
		}
	}
}
