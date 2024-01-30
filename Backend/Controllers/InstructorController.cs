
using System.Security.Claims;
using Backend.Dtos.CourseDtos;
using Backend.Dtos.GenericDTOs;
using Backend.Models;
using Backend.Repositories.CourseFolderRepo;
using Backend.Repositories.CourseRepo;
using Backend.Repositories.CourseVideoRepo;
using Backend.Repositories.TagRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructorController : ControllerBase
    {
        
        public ICourseRepository CourseRepository { get; set; }
        public ICourseFolderRepository CourseFolderRepository { get; set; }
        public ITagRepository TagRepository { get; set; }
        public ICourseVideoRepository CourseVideoRepository { get; set; }

        public InstructorController(
            ICourseRepository courseRepository, 
            ICourseFolderRepository courseFolderRepository, 
            ITagRepository tagRepository,
            ICourseVideoRepository courseVideoRepository
            )
        {
            CourseRepository = courseRepository;
            CourseFolderRepository = courseFolderRepository;
            TagRepository = tagRepository;
            CourseVideoRepository = courseVideoRepository;
        }






        [HttpGet("instructor-courses/")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CourseInfoDto> GetAllCoursesOfInstructor()
        {
            IsUserIdAvailable(out int userId);
            
            return Ok(CourseRepository.GetAllCoursesOfInstructor(userId));
        }

        [HttpPost("instructor-courses/course-approval-request/{courseId}")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CreateResponseDto> GetAllCoursesOfInstructor(int courseId)
        {
            IsUserIdAvailable(out int userId);

            Course course = CourseRepository.GetCourseById(courseId);
            course.IsApproved = false;
            course.ApprovedById = null;
            course.ReleaseDate = DateTime.Now;
            CourseRepository.UpdateCourse(course);

            CreateResponseDto createResponseDto = new CreateResponseDto
            {
                Status = "Success",
                Message = "Course Approval Requested successfully"
            };

            return Ok(createResponseDto);
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