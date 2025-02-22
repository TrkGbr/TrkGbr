using Academy_2025.Data;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Academy_2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        public static List<Course>? Courses = new List<Course>();

        public CoursesController()
        {
            Courses = new List<Course>
            {
                new Course { Id = 1, Name = "Math", Description = "Teszt" },
                new Course { Id = 2, Name = "Physics", Description = "Teszt" }
            };
        }

        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }



        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            foreach (var course in Courses)
            {
                if(course.Id == id)
                {
                    return Ok(course);
                }
            }
            return NotFound();
        }

        // POST api/<CourseController>
        [HttpPost]
        public ActionResult Post([FromBody] Course data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Courses.Add(data);

            return NoContent();
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Course data)
        {
            foreach (var course in Courses)
            {
                if (course.Id == id)
                {
                    course.Name = data.Name;
                    course.Description = data.Description;

                    return NoContent();
                }
            }
            return NotFound();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            foreach (var course in Courses)
            {
                if (course.Id == id)
                {
                    Courses.Remove(course);

                    return NoContent();
                }
            }
            return NotFound();
        }
    }
}
