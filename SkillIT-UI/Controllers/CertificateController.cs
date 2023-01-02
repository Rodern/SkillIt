using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;

namespace SkillItAPI.Controllers
{
    [Authorize]
    [Route("api/certs")]
    [ApiController]
    public class CertificateController : Controller
    {
        private readonly IUserCertificateService userCertificateService;
        public CertificateController(IUserCertificateService userCertificateService)
        {
            this.userCertificateService = userCertificateService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("add")]
        public IActionResult Add(UserCertificate userCertificate)
        {
            return Ok(userCertificateService.AddUserCerticate(userCertificate));
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("update")]
        public IActionResult Update(UserCertificate userCertificate)
        {
            return Ok(userCertificateService.UpdateUserCertificate(userCertificate));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            return Ok(userCertificateService.GetCertificates());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public IActionResult Get(long userId)
        {
            return Ok(userCertificateService.GetUserCertificates(userId));
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(int ucId, long userId)
        {
            return Ok(userCertificateService.RemoveUserCertificate(ucId, userId));;
        }
    }
}
