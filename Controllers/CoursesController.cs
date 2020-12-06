using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCore5Demo.Models;

namespace ASPNETCore5Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ContosoUniversityContext db;

        public CoursesController(ContosoUniversityContext db)
        {
            this.db = db;
        }

        // GET api/Course
        [HttpGet("")]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            return new List<Course> { };
        }

        // GET api/Course/5
        [HttpGet("{id}")]
        public ActionResult<Course> GetCourseById(int id)
        {
            return null;
        }

        // POST api/Course
        [HttpPost("")]
        public void PostCourse(Course value)
        {
        }

        // PUT api/Course/5
        [HttpPut("{id}")]
        public void PutCourse(int id, Course value)
        {
        }

        // DELETE api/Course/5
        [HttpDelete("{id}")]
        public void DeleteCourseById(int id)
        {
        }
    }
}