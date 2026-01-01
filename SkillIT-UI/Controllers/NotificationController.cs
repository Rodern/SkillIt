using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SkillItAPI.Controllers
{
	[Authorize]
	[Route("api/account/notifications")]
	[Route("api/user/notifications")]
	[Route("api/notifications")]
	[ApiController]
	public class NotificationController : Controller
	{
		private readonly INotificationService NotificationService;
		public NotificationController(INotificationService notificationService)
		{
			NotificationService = notificationService;
		}

		[HttpGet]
		[Route("getAccountNotifications")]
		public IActionResult GetAccountNotifications(long accountId)
		{
			return Ok(NotificationService.GetAccountNotifications(accountId));
		}
	}
}
