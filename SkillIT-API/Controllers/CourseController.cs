using BusinessLogic;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;

namespace SkillIT_API.Controllers
{
    [Authorize]
    [Route("api/course")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseService courseService;
        public CourseController(ICourseService service)
        {
            courseService = service;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getCourses")]
        public IActionResult GetCourses()
        {
            var data = courseService.GetCourses();
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getAllChapters")]
        public IActionResult GetCourseChapters()
        {
            var data = courseService.GetCourseChapters();
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("getCourseChapters")]
        public IActionResult GetCourseChapters(int courseId)
        {
            var data = courseService.GetCourseChapters(courseId);
            return Ok(data);
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("getAllLessons")]
        public IActionResult GetLessons()
        {
            var data = courseService.GetCourseLessons();
            return Ok(data);
        }
    }
}
