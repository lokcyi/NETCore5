using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCore5Demo.Models;
using Omu.ValueInjecter;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCore5Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ContosoUniversityContext db;
        public CourseController(ContosoUniversityContext db)
        {
            this.db = db;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            return db.Courses.ToList();
        }

        [HttpGet("credits/{credit}")]
        public ActionResult<IEnumerable<Course>> GetCoursesByCredit(int credit) {
             return db.Courses.Where(p => p.Credits == credit).ToList();       
        }

        //// GET api/course
        //[HttpGet("")]
        //public ActionResult<IEnumerable<string>> Getstrings()
        //{

        //    return new List<string> { };
        //}

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourseById(int id)
        {
            return db.Courses.Find(id);
        }

        [HttpPost("")]
        public ActionResult<Course> PostCourse(Course model)
        {
            db.Courses.Add(model);
            db.SaveChanges();

            return Created("/api/Course/" + model.CourseId, model);
        }

        [HttpPut("{id}")]
        public IActionResult PutCourse(int id, CourseUpdateModel model)
        {
            var c = db.Courses.Find(id);
            // c.Credits = model.Credits;
            // c.Title = model.Title;
            c.InjectFrom(model);
            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Course> DeleteCourseById(int id)
        {
            var c = db.Courses.Find(id);
            db.Courses.Remove(c);

            db.SaveChanges();

            return Ok(c);
        }
        
    }
}