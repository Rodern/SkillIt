using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillIT_Models.DatabaseModels;

namespace SkillItAPI.Controllers
{
	[Authorize]	
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService AccountService;
		public AccountController(IAccountService accountService)
		{
			this.AccountService = accountService;
		}

		[HttpPost]
		[Route("AddAccount")]
		public IActionResult AddAccount(Account account)
		{
			return Ok(AccountService.AddAccount(account));
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("GetAccount")]
		public IActionResult GetUserAccount(long userId)
		{
			return Ok(AccountService.GetUserAccount(userId));
		}

		[HttpGet]
		[Route("GetAccounts")]
		public IActionResult GetAccounts()
		{
			return Ok(AccountService.GetAllAccounts());
		}

		[HttpPost]
		[Route("UpdateAccount")]
		public IActionResult UpdateAccount(long id, long id2, Account account)
		{
			return Ok(AccountService.UpdateAccount(id, id2, account));
		}
	}
}
