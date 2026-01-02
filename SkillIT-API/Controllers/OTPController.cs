using AutoMapper;
using BusinessLogic;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;

namespace SkillItAPI.Controllers
{
    [Authorize]
    [Route("api/otp")]
    [ApiController]
    public class OTPController : Controller
    {
        private readonly IOTPService oTPService_service;
        private readonly IMapper _mapper;
        public OTPController(IOTPService oTPService_service, IMapper mapper)
        {
            this.oTPService_service = oTPService_service;
            this._mapper = mapper;
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
            var entity = _mapper.Map<SkillIT_Models.Entities.Core.Otp>(otp);
            return Ok(oTPService_service.AddOTP(entity));
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
