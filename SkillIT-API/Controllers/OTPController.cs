using BusinessLogic;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SkillItModels.DatabaseModels;

namespace SkillItAPI.Controllers
{
    [Authorize]
    [Route("api/otp")]
    [ApiController]
    public class OTPController : Controller
    {
        private readonly IOTPService oTPService_service;
        public OTPController(IOTPService oTPService_service)
        {
            this.oTPService_service = oTPService_service;
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("getOtps")]
        public IActionResult GetOTPS()
        {
            return Ok(oTPService_service.GetOTPs());
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("setOtp")]
        public IActionResult Set(Otp otp)
        {
            return Ok(oTPService_service.AddOTP(otp));
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("getOtp/{id}/{userId}")]
        public IActionResult GetOTP([FromRoute] long id, [FromRoute] long userId)
        {
            return Ok(oTPService_service.GetOTP(id, userId));
        }
    }
}
