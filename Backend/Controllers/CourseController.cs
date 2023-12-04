
using System.Security.Claims;
using Backend.Dtos.CourseDtos;
using Backend.Dtos.CourseFoldersDtos;
using Backend.Dtos.GenericDTOs;
using Backend.Models;
using Backend.Repositories.CourseFolderRepo;
using Backend.Repositories.CourseRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        
        public ICourseRepository CourseRepository { get; set; }
        public ICourseFolderRepository CourseFolderRepository { get; set; }

        public CourseController(ICourseRepository courseRepository, ICourseFolderRepository courseFolderRepository)
        {
            CourseRepository = courseRepository;
            CourseFolderRepository = courseFolderRepository;
        }

        [HttpGet("courses")]
        public ActionResult<IEnumerable<Course>> GetAllCourses()
        {
            return Ok(CourseRepository.AllCourses());
        }



        [HttpGet("/courses/{id}")]
        public ActionResult<CourseInfoDto> GetSingleCourse(int id)
        {
            return Ok(CourseRepository.GetCourseById(id));
        }

        [HttpPost("create-course")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CreateResponseDto> CreateCourse([FromBody] CreateCourseInfoDto courseDto)
        {

            IsUserIdAvailable(out int userId);

            if (userId == 0)
            {
                return Unauthorized();
            }

            courseDto.InstructorId = userId;
            CourseRepository.CreateCourse(courseDto);


            CreateResponseDto createResponseDto = new CreateResponseDto
            {
                Status = "Success",
                Message = "Course created successfully"
            };

            return Ok(createResponseDto);
        }


        [HttpPut("udpate-course/{courseId}")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CreateResponseDto> UpdateCourse(int courseId, [FromBody] UpdateCourseInfoDto courseDto)
        {

            Course course = CourseRepository.GetCourseById(courseId);

            if (course == null)
            {
                return NotFound();
            }

            course.Title = courseDto.Title;
            course.Description = courseDto.Description;
            course.Price = courseDto.Price;
            course.ThumbnailURL = courseDto.ThumbnailURL;

            CourseRepository.UpdateCourse(course);


            CreateResponseDto createResponseDto = new CreateResponseDto
            {
                Status = "Success",
                Message = "Course Updated successfully"
            };

            return Ok(createResponseDto);

        }


        [HttpGet("/courses/instructor-courses/")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CourseInfoDto> GetAllCoursesOfInstructor()
        {
            IsUserIdAvailable(out int userId);

            if (userId == 0)
            {
                return Unauthorized();
            }
            
            return Ok(CourseRepository.GetAllCoursesOfInstructor(userId));
        }

        [HttpPost("/courses/instructor-courses/course-approval-request/{courseId}")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CreateResponseDto> GetAllCoursesOfInstructor(int courseId)
        {
            IsUserIdAvailable(out int userId);

            if (userId == 0)
            {
                return Unauthorized();
            }

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


        [HttpGet("/courses/students-courses/")]
        [Authorize(Roles = "Student")]
        public ActionResult<CourseInfoDto> GetAllStudentsBoughtCourses()
        {
            IsUserIdAvailable(out int userId);

            if (userId == 0)
            {
                return Unauthorized();
            }

            return Ok(CourseRepository.GetAllStudentsBoughtCourses(userId));
        }

        [HttpGet("/courses/admin/unapproved/")]
        [Authorize(Roles = "Admin")]
        public ActionResult<CourseInfoDto> GetAllCoursesForAdminApproval()
        {
            IsUserIdAvailable(out int userId);

            if (userId == 0)
            {
                return Unauthorized();
            }

            return Ok(CourseRepository.GetAllCoursesForAdminApproval());
        }

        [HttpGet("/courses/admin/approve/{courseId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<CourseInfoDto> ApproveCourse(int courseId)
        {
            IsUserIdAvailable(out int userId);

            if (userId == 0)
            {
                return Unauthorized();
            }

            Course course = CourseRepository.GetCourseById(courseId);
            course.IsApproved = true;
            course.ApprovedById = userId;
            course.ReleaseDate = DateTime.Now;
            CourseRepository.UpdateCourse(course);
            return Ok(course);
        }








        // Course Folders Related Routes

        [HttpGet("/courses/{courseId}/course-folders")]
        public ActionResult<CourseInfoDto> GetAllCourseFoldersOfCourse(int courseId)
        {
            IEnumerable<CourseFoldersDto> courseFoldersDto = CourseFolderRepository.GetAllCourseFoldersOfCourse(courseId);
            return Ok(courseFoldersDto);
        }

        [HttpPost("/courses/{courseId}/course-folders")]
        public ActionResult<CourseInfoDto> CreateCourseFolder(int courseId, [FromBody] CreateCourseFoldersDto courseFolder)
        {
            IsUserIdAvailable(out int userId);

            if (userId == 0)
            {
                return Unauthorized();
            }

            CourseFoldersDto courseFoldersDto = CourseFolderRepository.CreateCourseFolder(courseId, courseFolder);
            return Ok(courseFoldersDto);
        }

        [HttpPut("/courses/course-folders/{courseFolderId}")]
        public ActionResult<CourseInfoDto> UpdateCourseFolder(int courseFolderId, [FromBody] UpdateCourseInfoDto courseFolder)
        {
            IsUserIdAvailable(out int userId);

            if (userId == 0)
            {
                return Unauthorized();
            }

            courseFolder.ID = courseFolderId;

            CourseFoldersDto courseFoldersDto = CourseFolderRepository.UpdateCourseFolder(courseFolder);
            return Ok(courseFoldersDto);
        }

        [HttpDelete("/courses/course-folders/{courseFolderId}")]
        public ActionResult<CourseInfoDto> DeleteCourseFolder(int courseFolderId)
        {
            IsUserIdAvailable(out int userId);

            if (userId == 0)
            {
                return Unauthorized();
            }

            bool isDeleted = CourseFolderRepository.DeleteCourseFolderById(courseFolderId);
            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("/courses/course-folders/add-video/{courseFolderId}/{courseVideoId}")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CourseInfoDto> AddVideoToCourseFolder(int courseFolderId, int courseVideoId)
        {
            IsUserIdAvailable(out int userId);

            if (userId == 0)
            {
                return Unauthorized();
            }

            CourseFoldersDto courseFoldersDto = CourseFolderRepository.AddVideoToCourseFolder(courseFolderId, courseVideoId);
            return Ok(courseFoldersDto);
        }

        [HttpPost("/courses/course-folders/remove-video/{courseFolderId}/{courseVideoId}")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CourseInfoDto> RemoveVideoFromCourseFolder(int courseFolderId, int courseVideoId)
        {
            IsUserIdAvailable(out int userId);

            if (userId == 0)
            {
                return Unauthorized();
            }

            CourseFoldersDto courseFoldersDto = CourseFolderRepository.RemoveVideoFromCourseFolder(courseFolderId, courseVideoId);
            return Ok(courseFoldersDto);
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
                userId = 0;
                return false;
            }
        }

    }
}