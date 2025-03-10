using Academy_2025.Data;

namespace Academy_2025.Respositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course? GetById(int id)
        {
            return _context.Courses.FirstOrDefault(course => course.Id == id);
        }

        public void Create(Course data)
        {
            _context.Courses.Add(data);
            _context.SaveChanges();
        }

        public Course? Update(int id, Course data)
        {
            var course = _context.Courses.FirstOrDefault(user => user.Id == id);
            if (course != null)
            {
                course.Name = data.Name;
                course.Description = data.Description;
                course.Author = data.Author;   //<------Author hivatkozás hozzáadás!
                _context.SaveChanges();

                return course;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var course = _context.Courses.FirstOrDefault(course => course.Id == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
