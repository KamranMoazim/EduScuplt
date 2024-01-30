
using System.Security.Claims;
using Backend.Dtos.CourseDtos;
using Backend.Models;
using Backend.Repositories.CourseFolderRepo;
using Backend.Repositories.CourseRepo;
using Backend.Repositories.CourseVideoRepo;
using Backend.Repositories.InstructorRepo;
using Backend.Repositories.TagRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {


        public ICourseRepository CourseRepository { get; set; }
        public IInstructorRepository InstructorRepository { get; set; }
        public ICourseFolderRepository CourseFolderRepository { get; set; }
        public ITagRepository TagRepository { get; set; }
        public ICourseVideoRepository CourseVideoRepository { get; set; }

        public AdminController(
            ICourseRepository courseRepository, 
            IInstructorRepository instructorRepository,
            ICourseFolderRepository courseFolderRepository, 
            ITagRepository tagRepository,
            ICourseVideoRepository courseVideoRepository
            )
        {
            CourseRepository = courseRepository;
            InstructorRepository = instructorRepository;
            CourseFolderRepository = courseFolderRepository;
            TagRepository = tagRepository;
            CourseVideoRepository = courseVideoRepository;
        }




        [HttpGet("courses/unapproved/")]
        [Authorize(Roles = "Admin")]
        public ActionResult<CourseInfoDto> GetAllCoursesForAdminApproval()
        {
            IsUserIdAvailable(out int userId);


            return Ok(CourseRepository.GetAllCoursesForAdminApproval());
        }

        [HttpPost("courses/approve/{courseId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<CourseInfoDto> ApproveCourse(int courseId)
        {
            IsUserIdAvailable(out int userId);

            Course course = CourseRepository.GetCourseById(courseId);
            course.IsApproved = true;
            course.ApprovedById = userId;
            course.ReleaseDate = DateTime.Now;
            CourseRepository.UpdateCourse(course);
            return Ok(course);
        }





        [HttpGet("instructors/unapproved/")]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<Instructor>> GetAllInstructorsForAdminApproval()
        {
            IsUserIdAvailable(out int userId);


            return Ok(InstructorRepository.GetAllInstructorsForAdminApproval());
        }

        [HttpPost("instructors/approve/{courseId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Instructor> ApproveInstructor(int courseId)
        {
            IsUserIdAvailable(out int userId);

            Instructor instructor = InstructorRepository.GetInstructorById(courseId);
            instructor.IsApproved = true;
            instructor.ApprovedById = userId;
            InstructorRepository.UpdateInstructor(instructor);

            return Ok(instructor);
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