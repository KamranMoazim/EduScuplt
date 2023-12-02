

using AutoMapper;
using Backend.Dtos.CourseDtos;
using Backend.Models;

namespace Backend.Repositories.CourseRepo
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ProjectAppContext _context;
        private readonly IMapper _mapper;

        public CourseRepository(ProjectAppContext _ctx, IMapper map)
        {
            _context = _ctx;
            _mapper = map;
        }

        public IEnumerable<Course> AllCourses()
        {
            return _context.Courses.ToList();
        }

        public Course CreateCourse(CreateCourseInfoDto course)
        {

            Course newCourse = new Course
            {
                Title = course.Title,
                Description = course.Description,
                Price = course.Price,
                ThumbnailURL = course.ThumbnailURL,
                InstructorId = course.InstructorId
            };

            _context.Courses.Add(newCourse);
            _context.SaveChanges();

            return newCourse;
        }

        public Course GetCourseById(int id)
        {
            Course? course = _context.Courses.FirstOrDefault(c => c.ID == id);
            if (course == null)
            {
                throw new Exception("Course not found");
            }
            return course;
        }
    }
}