using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using static System.Net.Mime.MediaTypeNames;

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
		public IActionResult AddUser(string userJson, IFormFile image)
		{
			if (userJson.Length <= 0 || image == null) return BadRequest();
            UserModel userModel = JsonConvert.DeserializeObject<UserModel>(userJson);
            userModel.Image = ImageUpload.GetBytes(image);
            return Ok(userService.AddUser(userModel));
		}

		[HttpPut]
		[Route("UpdateUser")]
		public IActionResult UpdateUser(string userJson, IFormFile image)
        {
            if (userJson.Length <= 0 || image == null) return BadRequest();
            UserModel userModel = JsonConvert.DeserializeObject<UserModel>(userJson);
			userModel.Image = ImageUpload.GetBytes(image);
			return Ok(userService.UpdateUser(userModel.UserId, userModel));
		}
	}
}
