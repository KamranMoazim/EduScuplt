
using System.Security.Claims;
using Backend.Models;
using Backend.Repositories.CourseFolderRepo;
using Backend.Repositories.CourseRepo;
using Backend.Repositories.CourseVideoRepo;
using Backend.Repositories.InterestRepo;
using Backend.Repositories.TagRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        
        public ICourseRepository CourseRepository { get; set; }
        public ICourseFolderRepository CourseFolderRepository { get; set; }
        public ITagRepository TagRepository { get; set; }
        public ICourseVideoRepository CourseVideoRepository { get; set; }
        public IInterestRepository InterestRepository { get; set; }

        public StudentController(
            ICourseRepository courseRepository, 
            ICourseFolderRepository courseFolderRepository, 
            TagRepository tagRepository,
            ICourseVideoRepository courseVideoRepository,
            IInterestRepository interestRepository
            )
        {
            CourseRepository = courseRepository;
            CourseFolderRepository = courseFolderRepository;
            TagRepository = tagRepository;
            CourseVideoRepository = courseVideoRepository;
            InterestRepository = interestRepository;
        }





        [HttpGet("{studentId}/interests")]
        [Authorize(Roles = "Student")]
        public List<Interests> GetStudentsInterests(long studentId)
        {
            return InterestRepository.GetStudentsInterests(studentId);
        }

        [HttpPut("{studentId}/interests")]
        [Authorize(Roles = "Student")]
        public List<Interests> UpdateStudentInterests(long studentId, List<Interests> interests)
        {
            return InterestRepository.UpdateStudentInterests(studentId, interests);
        }


        [HttpGet("{studentId}/courses")]
        [Authorize(Roles = "Student")]
        public IEnumerable<Course> GetStudentsCourses(long studentId)
        {
            return CourseRepository.GetAllStudentsBoughtCourses(studentId);
        }


        [HttpPut("{studentId}/rate-course/{courseId}")]
        public ActionResult<bool> RateCourse(long studentId, long courseId, [FromBody] int rating)
        {
            return CourseRepository.RateCourse(studentId, courseId, rating);
        }











        private bool IsUserIdAvailable(out int userId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier); // Get the user id from the token
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out userId))
            {
                return true;
            }
            else
            {
                throw new Exception("User Id not found in token");
            }
        }
    }
}