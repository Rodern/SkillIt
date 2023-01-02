using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;

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
		[Route("CreateOTP/{email}")]
		public IActionResult GenerateCode([FromRoute] string email, long otpId)
		{
			return Ok(authenticationManager.GenerateCode(email, otpId));
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("Reset")]
		public IActionResult Reset(ResetModel resetModel)
		{
			return Ok(authenticationManager.Reset(resetModel));
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("CheckTokenValidity")]
		public IActionResult IsEmptyOrInvalid(string token)
		{
			return Ok(authenticationManager._isEmptyOrInvalid(token));
		}
	}
}
