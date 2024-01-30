

using AutoMapper;
using Backend.Dtos.CourseDtos;
using Backend.Dtos.InstructorDtos;
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

        public IEnumerable<CourseInfoDto> AllCourses()
        {
            IEnumerable<Course> courses = _context.Courses.Where(c => c.IsApproved).ToList();

            IEnumerable<CourseInfoDto> enumerable = _mapper.Map<IEnumerable<CourseInfoDto>>(courses);

            // foreach (var item in enumerable)
            // {
            //     Console.WriteLine(item.Title);
            // }

            return enumerable;
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


        public IEnumerable<CourseInfoDto> GetAllCoursesOfInstructor(long instructorId)
        {
            IEnumerable<Course> courses = _context.Courses.Where(c => c.InstructorId == instructorId).ToList();

            return _mapper.Map<IEnumerable<CourseInfoDto>>(courses);
        }


        public IEnumerable<CourseInfoDto> GetAllStudentsBoughtCourses(long studentId)
        {
            IEnumerable<Course> courses = _context.StudentCourses.Where(sc => sc.StudentId == studentId).Select(sc => sc.Course).ToList();

            return _mapper.Map<IEnumerable<CourseInfoDto>>(courses);
        }


        public IEnumerable<CourseInfoDto> GetAllCoursesForAdminApproval()
        {
            IEnumerable<Course> courses = _context.Courses.Where(c => c.IsApproved == false).ToList();

            return _mapper.Map<IEnumerable<CourseInfoDto>>(courses);
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



        public bool AddTagsToCourse(long courseId, List<long> tagdIds)
        {

            Course? course = _context.Courses.FirstOrDefault(c => c.ID == courseId);
            if (course == null)
            {
                throw new NotFoundException("Course not found");
            }

            course.Tags = new List<Tags>();

            foreach (var tagId in tagdIds)
            {
                Tags? tag = _context.Tags.FirstOrDefault(t => t.ID == tagId);
                if (tag == null)
                {
                    throw new NotFoundException("Tag not found");
                }
                course.Tags.Add(tag);
            }

            _context.SaveChanges();
            return true;
        }

        public bool UpdateCourseTags(long courseId, List<long> tagdIds)
        {

            Course? course = _context.Courses.FirstOrDefault(c => c.ID == courseId);
            if (course == null)
            {
                throw new NotFoundException("Course not found");
            }

            course.Tags.Clear();

            course.Tags = new List<Tags>();

            foreach (var tagId in tagdIds)
            {
                Tags? tag = _context.Tags.FirstOrDefault(t => t.ID == tagId);
                if (tag == null)
                {
                    throw new NotFoundException("Tag not found");
                }
                course.Tags.Add(tag);
            }

            _context.SaveChanges();
            return true;
        }

        public bool RemoveCourseTag(long courseId, long tagdIds)
        {

            Course? course = _context.Courses.FirstOrDefault(c => c.ID == courseId);
            if (course == null)
            {
                throw new NotFoundException("Course not found");
            }

            Tags? tag = _context.Tags.FirstOrDefault(t => t.ID == tagdIds);
            if (tag == null)
            {
                throw new NotFoundException("Tag not found");
            }

            course.Tags.Remove(tag);

            _context.SaveChanges();
            return true;
        }

        public IEnumerable<CourseInfoDto> GetCoursesOfMyInterests(long userId)
        {

            Student? student = _context.Student.FirstOrDefault(s => s.ID == userId);
            if (student == null)
            {
                throw new NotFoundException("Student not found");
            }

            List<StudentInterests> studentInterests = _context.StudentInterests.Where(i => i.StudentId == userId).ToList();

            List<string> interests = _context.Interests.Where(i => studentInterests.Any(si => si.InterestId == i.ID)).Select(i => i.Title).ToList();

            List<Tags> tags = _context.Tags.Where(t => interests.Contains(t.Name)).ToList();

            List<Course> courses = _context.Courses.Where(c => c.Tags.Any(t => tags.Contains(t))).ToList();

            return _mapper.Map<IEnumerable<CourseInfoDto>>(courses);
        }
    



























    
        private CourseInfoDto convertCourseToCourseInfoDto(Course course)
        {
            return new CourseInfoDto 
            {
                ID = course.ID,
                Title = course.Title,
                Description = course.Description,
                Price = course.Price,
                ThumbnailURL = course.ThumbnailURL,
                ReleaseDate = course.ReleaseDate
            };;
        }
    }
}