
using System.Security.Claims;
using Backend.Dtos.CourseDtos;
using Backend.Dtos.CourseFoldersDtos;
using Backend.Dtos.CourseVideoDtos;
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
    public class CourseController : ControllerBase
    {
        
        public ICourseRepository CourseRepository { get; set; }
        public ICourseFolderRepository CourseFolderRepository { get; set; }
        public ITagRepository TagRepository { get; set; }
        public ICourseVideoRepository CourseVideoRepository { get; set; }

        public CourseController(
            ICourseRepository courseRepository, 
            ICourseFolderRepository courseFolderRepository, 
            TagRepository tagRepository,
            ICourseVideoRepository courseVideoRepository
            )
        {
            CourseRepository = courseRepository;
            CourseFolderRepository = courseFolderRepository;
            TagRepository = tagRepository;
            CourseVideoRepository = courseVideoRepository;
        }

        [HttpGet("courses")]
        public ActionResult<IEnumerable<Course>> GetAllCourses()
        {
            return Ok(CourseRepository.AllCourses());
        }

        [HttpGet("courses/{tagName}")]
        public ActionResult<IEnumerable<CourseInfoDto>> GetCoursesByTagName(string tagName)
        {
            return Ok(CourseRepository.GetCoursesByTagName(tagName));
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
            
            return Ok(CourseRepository.GetAllCoursesOfInstructor(userId));
        }

        [HttpPost("/courses/instructor-courses/course-approval-request/{courseId}")]
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


        [HttpGet("/courses/students-courses/")]
        [Authorize(Roles = "Student")]
        public ActionResult<CourseInfoDto> GetAllStudentsBoughtCourses()
        {
            IsUserIdAvailable(out int userId);

            return Ok(CourseRepository.GetAllStudentsBoughtCourses(userId));
        }







        [HttpGet("/courses/admin/unapproved/")]
        [Authorize(Roles = "Admin")]
        public ActionResult<CourseInfoDto> GetAllCoursesForAdminApproval()
        {
            IsUserIdAvailable(out int userId);


            return Ok(CourseRepository.GetAllCoursesForAdminApproval());
        }

        [HttpGet("/courses/admin/approve/{courseId}")]
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











        // Course Folders Related Routes

        [HttpGet("/courses/{courseId}/course-folders")]
        public ActionResult<CourseFoldersDto> GetAllCourseFoldersOfCourse(int courseId)
        {
            IEnumerable<CourseFoldersDto> courseFoldersDto = CourseFolderRepository.GetAllCourseFoldersOfCourse(courseId);
            return Ok(courseFoldersDto);
        }

        [HttpPost("/courses/{courseId}/course-folders")]
        public ActionResult<CourseFoldersDto> CreateCourseFolder(int courseId, [FromBody] CreateCourseFoldersDto courseFolder)
        {
            IsUserIdAvailable(out int userId);

            CourseFoldersDto courseFoldersDto = CourseFolderRepository.CreateCourseFolder(courseId, courseFolder);
            return Ok(courseFoldersDto);
        }

        [HttpPut("/courses/course-folders/{courseFolderId}")]
        public ActionResult<CourseFoldersDto> UpdateCourseFolder(int courseFolderId, [FromBody] UpdateCourseInfoDto courseFolder)
        {
            IsUserIdAvailable(out int userId);

            courseFolder.ID = courseFolderId;

            CourseFoldersDto courseFoldersDto = CourseFolderRepository.UpdateCourseFolder(courseFolder);
            return Ok(courseFoldersDto);
        }

        [HttpDelete("/courses/course-folders/{courseFolderId}")]
        public ActionResult<CourseFoldersDto> DeleteCourseFolder(int courseFolderId)
        {
            IsUserIdAvailable(out int userId);

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
        public ActionResult<CourseFoldersDto> AddVideoToCourseFolder(int courseFolderId, int courseVideoId)
        {
            IsUserIdAvailable(out int userId);

            CourseFoldersDto courseFoldersDto = CourseFolderRepository.AddVideoToCourseFolder(courseFolderId, courseVideoId);
            return Ok(courseFoldersDto);
        }

        [HttpPost("/courses/course-folders/remove-video/{courseFolderId}/{courseVideoId}")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CourseFoldersDto> RemoveVideoFromCourseFolder(int courseFolderId, int courseVideoId)
        {
            IsUserIdAvailable(out int userId);

            CourseFoldersDto courseFoldersDto = CourseFolderRepository.RemoveVideoFromCourseFolder(courseFolderId, courseVideoId);
            return Ok(courseFoldersDto);
        }

        [HttpGet("/courses/course-folders/{courseFolderId}")]
        public ActionResult<CourseFoldersDto> GetCourseFolderByIdAlongWithCourseVideos(int courseFolderId)
        {
            CourseFoldersDto courseFoldersDto = CourseFolderRepository.GetCourseFolderByIdAlongWithCourseVideos(courseFolderId);
            return Ok(courseFoldersDto);
        }



        // Course Videos Related Routes

        [HttpPost("/courses/{courseId}/course-videos")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CourseVideoDto> CreateCourseVideo(int courseId, [FromBody] CreateCourseVideoDto courseVideo)
        {
            IsUserIdAvailable(out int userId);

            CourseVideoDto courseVideoDto = CourseVideoRepository.CreateCourseVideo(courseVideo);
            return Ok(courseVideoDto);
        }

        [HttpPut("/courses/course-videos/{courseVideoId}")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CourseVideoDto> UpdateCourseVideo(int courseVideoId, [FromBody] UpdateCourseVideoDto courseVideo)
        {
            IsUserIdAvailable(out int userId);

            courseVideo.ID = courseVideoId;

            CourseVideoDto courseVideoDto = CourseVideoRepository.UpdateCourseVideo(courseVideo);
            return Ok(courseVideoDto);
        }

        [HttpDelete("/courses/course-videos/{courseVideoId}")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<bool> DeleteCourseVideo(int courseVideoId)
        {
            IsUserIdAvailable(out int userId);

            bool isDeleted = CourseVideoRepository.DeleteCourseVideoById(courseVideoId);
            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("/courses/course-videos/{courseVideoId}")]
        public ActionResult<CourseVideoDto> GetCourseVideoById(int courseVideoId)
        {
            CourseVideoDto courseVideoDto = CourseVideoRepository.GetCourseVideoById(courseVideoId);
            return Ok(courseVideoDto);
        }












        // Interest Related Routes





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