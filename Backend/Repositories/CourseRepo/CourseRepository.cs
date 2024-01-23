

using AutoMapper;
using Backend.Dtos.CourseDtos;
using Backend.Exceptions;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.Courses.Where(c => c.IsApproved).ToList();
        }

        public IEnumerable<CourseInfoDto> GetCoursesByTagName(string tagName)
        {
            Tags? tag = _context.Tags.Where(t => t.Name == tagName).FirstOrDefault();

            if (tag == null)
            {
                throw new NotFoundException("Tag not found");
            }

            return _mapper.Map<IEnumerable<CourseInfoDto>>(_context.Courses.Where(c => c.Tags.Contains(tag)));
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

        public Course UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
            return _context.Courses.FirstOrDefault(c => c.ID == course.ID)!;
        }

        public Course GetCourseById(long id)
        {
            Course? course = _context.Courses.FirstOrDefault(c => c.ID == id);
            if (course == null)
            {
                throw new Exception("Course not found");
            }
            return course;
        }


        public IEnumerable<Course> GetAllCoursesOfInstructor(long instructorId)
        {
            return _context.Courses.Where(c => c.InstructorId == instructorId).ToList();
        }


        public IEnumerable<Course> GetAllStudentsBoughtCourses(long studentId)
        {
            return _context.StudentCourses.Where(sc => sc.StudentId == studentId).Select(sc => sc.Course).ToList();
        }


        public IEnumerable<Course> GetAllCoursesForAdminApproval()
        {
            return _context.Courses.Where(c => c.IsApproved == false).ToList();
        }

        public bool RateCourse(long courseId, long studentId, int rating)
        {
            Course? course = _context.Courses.FirstOrDefault(c => c.ID == courseId);
            if (course == null)
            {
                throw new Exception("Course not found");
            }

            StudentCourses? studentCourse = _context.StudentCourses.FirstOrDefault(sc => sc.CourseId == courseId && sc.StudentId == studentId);
            if (studentCourse == null)
            {
                throw new Exception("Student not found");
            }

            if (rating <= 1 || rating >= 5)
            {
                throw new Exception("Rating must be between 1 and 5");
            }

            studentCourse.Rating = rating;
            _context.SaveChanges();
            return true;
        }

        public StudentCourses BuyCourse(long studentId, long courseId)
        {

            StudentCourses? studentCourse = _context.StudentCourses.FirstOrDefault(sc => sc.CourseId == courseId && sc.StudentId == studentId);
            if (studentCourse != null)
            {
                throw new Exception("Student already bought this course");
            }

            Course? course = _context.Courses.FirstOrDefault(c => c.ID == courseId);
            if (course == null)
            {
                throw new Exception("Course not found");
            }

            StudentCourses newStudentCourse = new StudentCourses
            {
                StudentId = studentId,
                CourseId = courseId
            };

            _context.StudentCourses.Add(newStudentCourse);
            _context.SaveChanges();

            return newStudentCourse;
        }
    }
}