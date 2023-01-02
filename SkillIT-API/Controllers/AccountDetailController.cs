using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillIT_Models.DatabaseModels;

namespace SkillItAPI.Controllers
{
	[Authorize]	
	[Route("api/[controller]")]
	[ApiController]
	public class AccountDetailController : ControllerBase
	{
		private readonly IAccountDetailService AccountDetailService;
		public AccountDetailController(IAccountDetailService accountDetailService)
		{
			this.AccountDetailService = accountDetailService;
		}

		[HttpPost]
		[Route("AddAccountDetail")]
		public IActionResult AddAccountDetail(AccountDetail accountDetail)
		{
			return Ok(AccountDetailService.AddAccountDetail(accountDetail));
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("GetAccountDetail")]
		public IActionResult GetAccountDetail(long userId)
		{
			return Ok(AccountDetailService.GetAccountDetail(userId));
		}

		[HttpGet]
		[Route("GetAccountDetails")]
		public IActionResult GetAccountDetails()
		{
			return Ok(AccountDetailService.GetAllAccountDetails());
		}

		[HttpPost]
		[Route("UpdateAccountDetail")]
		public IActionResult UpdateAccountDetail(long id, long id2, AccountDetail accountDetail)
		{
			return Ok(AccountDetailService.UpdateAccountDetail(id, id2, accountDetail));
		}
	}
}
