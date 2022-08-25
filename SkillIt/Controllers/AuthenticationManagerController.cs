using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillItModels.Models;

namespace SkillItAPI.Controllers
{
	[Authorize]
	[Route("api/")]
	[ApiController]
	public class AuthenticationManagerController : ControllerBase
	{
		private readonly IAuthenticationManager authenticationManager;
		public AuthenticationManagerController(IAuthenticationManager authenticationManager)
		{
			this.authenticationManager = authenticationManager;
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("Authenticate")]
		public IActionResult Authenticate(UserCredential userCredential)
		{
			var token = authenticationManager.Authenticate(userCredential);
			if (token == null) return Unauthorized();
			return Ok(token);
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("GenerateCode")]
		public IActionResult GenerateCode(string email)
		{
			return Ok(authenticationManager.GenerateCode(email));
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("Reset")]
		public IActionResult Reset(UserCredential userCredential)
		{
			return Ok(authenticationManager.Reset(userCredential));
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("CheckTokenValidity")]
		public IActionResult _isEmptyOrInvalid(string token)
		{
			return Ok(authenticationManager._isEmptyOrInvalid(token));
		}
	}
}
