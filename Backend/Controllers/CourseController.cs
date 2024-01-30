
using System.Security.Claims;
using Backend.Dtos.CourseDtos;
using Backend.Dtos.CourseFoldersDtos;
using Backend.Dtos.CourseVideoDtos;
using Backend.Dtos.GenericDTOs;
using Backend.Dtos.InstructorDtos;
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
    public class CourseController : ControllerBase
    {
        
        public ICourseRepository CourseRepository { get; set; }
        public ICourseFolderRepository CourseFolderRepository { get; set; }
        public ITagRepository TagRepository { get; set; }
        public ICourseVideoRepository CourseVideoRepository { get; set; }
        public IInstructorRepository InstructorRepository { get; set; }

        public CourseController(
            ICourseRepository courseRepository, 
            ICourseFolderRepository courseFolderRepository, 
            ITagRepository tagRepository,
            ICourseVideoRepository courseVideoRepository,
            IInstructorRepository instructorRepository
            )
        {
            CourseRepository = courseRepository;
            CourseFolderRepository = courseFolderRepository;
            TagRepository = tagRepository;
            CourseVideoRepository = courseVideoRepository;
            InstructorRepository = instructorRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseInfoDto>> GetAllCourses()
        {
            return Ok(CourseRepository.AllCourses());
        }

        [HttpGet("tag/{tagName}")]
        public ActionResult<IEnumerable<CourseInfoDto>> GetCoursesByTagName(string tagName)
        {
            return Ok(CourseRepository.GetCoursesByTagName(tagName));
        }



        [HttpGet("{id}")]
        public ActionResult<CourseInfoDto> GetSingleCourse(int id)
        {
            var course = CourseRepository.GetCourseById(id);
            var instructor = InstructorRepository.GetInstructorById(course.InstructorId);

            var courseInfoDto = new CourseInfoDto 
            {
                ID = course.ID,
                Title = course.Title,
                Description = course.Description,
                Price = course.Price,
                ThumbnailURL = course.ThumbnailURL,
                ReleaseDate = course.ReleaseDate,
                Instructor = new InstructorDto 
                {
                    AccountNo = instructor.AccountNo,
                    AccountDetails = instructor.AccountDetails,
                },
                Tags = TagRepository.GetCourseTags(course.ID).ToList(),
                CourseFolders = CourseFolderRepository.GetAllCourseFoldersOfCourse(course.ID).ToList()
            };


            return Ok(courseInfoDto);
        }

        [HttpPost]
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


        [HttpPut("{courseId}")]
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



















        // [HttpGet("/courses/instructor-courses/")]
        // [Authorize(Roles = "Instructor")]
        // public ActionResult<CourseInfoDto> GetAllCoursesOfInstructor()
        // {
        //     IsUserIdAvailable(out int userId);
            
        //     return Ok(CourseRepository.GetAllCoursesOfInstructor(userId));
        // }

        // [HttpPost("/courses/instructor-courses/course-approval-request/{courseId}")]
        // [Authorize(Roles = "Instructor")]
        // public ActionResult<CreateResponseDto> GetAllCoursesOfInstructor(int courseId)
        // {
        //     IsUserIdAvailable(out int userId);

        //     Course course = CourseRepository.GetCourseById(courseId);
        //     course.IsApproved = false;
        //     course.ApprovedById = null;
        //     course.ReleaseDate = DateTime.Now;
        //     CourseRepository.UpdateCourse(course);

        //     CreateResponseDto createResponseDto = new CreateResponseDto
        //     {
        //         Status = "Success",
        //         Message = "Course Approval Requested successfully"
        //     };

        //     return Ok(createResponseDto);
        // }


        // [HttpGet("student-courses/")]
        // [Authorize(Roles = "Student")]
        // public ActionResult<CourseInfoDto> GetAllStudentsBoughtCourses()
        // {
        //     IsUserIdAvailable(out int userId);

        //     return Ok(CourseRepository.GetAllStudentsBoughtCourses(userId));
        // }







        // [HttpGet("/courses/admin/unapproved/")]
        // [Authorize(Roles = "Admin")]
        // public ActionResult<CourseInfoDto> GetAllCoursesForAdminApproval()
        // {
        //     IsUserIdAvailable(out int userId);


        //     return Ok(CourseRepository.GetAllCoursesForAdminApproval());
        // }

        // [HttpGet("/courses/admin/approve/{courseId}")]
        // [Authorize(Roles = "Admin")]
        // public ActionResult<CourseInfoDto> ApproveCourse(int courseId)
        // {
        //     IsUserIdAvailable(out int userId);

        //     Course course = CourseRepository.GetCourseById(courseId);
        //     course.IsApproved = true;
        //     course.ApprovedById = userId;
        //     course.ReleaseDate = DateTime.Now;
        //     CourseRepository.UpdateCourse(course);
        //     return Ok(course);
        // }











        // Course Folders Related Routes

        [HttpGet("{courseId}/course-folders")]
        public ActionResult<CourseFoldersDto> GetAllCourseFoldersOfCourse(int courseId)
        {
            IEnumerable<CourseFoldersDto> courseFoldersDto = CourseFolderRepository.GetAllCourseFoldersOfCourse(courseId);
            return Ok(courseFoldersDto);
        }

        [HttpPost("{courseId}/course-folders")]
        public ActionResult<CourseFoldersDto> CreateCourseFolder(int courseId, [FromBody] CreateCourseFoldersDto courseFolder)
        {
            IsUserIdAvailable(out int userId);

            courseFolder.CourseId = courseId;

            CourseFoldersDto courseFoldersDto = CourseFolderRepository.CreateCourseFolder(courseId, courseFolder);
            return Ok(courseFoldersDto);
        }

        [HttpPut("{courseId}/course-folders/{courseFolderId}")]
        public ActionResult<CourseFoldersDto> UpdateCourseFolder(int courseId, int courseFolderId, [FromBody] UpdateCourseFolderNameDto courseFolder)
        {
            IsUserIdAvailable(out int userId);

            courseFolder.CourseId = courseId;
            courseFolder.ID = courseFolderId;

            CourseFoldersDto courseFoldersDto = CourseFolderRepository.UpdateCourseFolder(courseFolder);
            return Ok(courseFoldersDto);
        }

        [HttpDelete("{courseId}/course-folders/{courseFolderId}")]
        public ActionResult<CourseFoldersDto> DeleteCourseFolder(int courseId, int courseFolderId)
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

        [HttpPost("{courseId}/course-folders/add-video/{courseFolderId}/{courseVideoId}")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CourseFoldersDto> AddVideoToCourseFolder(int courseId, int courseFolderId, int courseVideoId)
        {
            IsUserIdAvailable(out int userId);

            CourseFoldersDto courseFoldersDto = CourseFolderRepository.AddVideoToCourseFolder(courseFolderId, courseVideoId);
            return Ok(courseFoldersDto);
        }

        [HttpPost("{courseId}/course-folders/remove-video/{courseFolderId}/{courseVideoId}")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CourseFoldersDto> RemoveVideoFromCourseFolder(int courseId, int courseFolderId, int courseVideoId)
        {
            IsUserIdAvailable(out int userId);

            CourseFoldersDto courseFoldersDto = CourseFolderRepository.RemoveVideoFromCourseFolder(courseFolderId, courseVideoId);
            return Ok(courseFoldersDto);
        }

        [HttpGet("{courseId}/course-folders/{courseFolderId}")]
        public ActionResult<CourseFoldersDto> GetCourseFolderByIdAlongWithCourseVideos(int courseId, int courseFolderId)
        {
            CourseFoldersDto courseFoldersDto = CourseFolderRepository.GetCourseFolderByIdAlongWithCourseVideos(courseFolderId);
            return Ok(courseFoldersDto);
        }









        // Course Videos Related Routes

        [HttpGet("{courseId}/course-videos")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CourseVideoDto> GetCourseVideo(int courseId)
        {
            IsUserIdAvailable(out int userId);

            return Ok(CourseVideoRepository.GetCourseVideosOfCourse(courseId));
        }

        [HttpPost("{courseId}/course-videos")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CourseVideoDto> CreateCourseVideo(int courseId, [FromBody] CreateCourseVideoDto courseVideo)
        {
            IsUserIdAvailable(out int userId);

            courseVideo.CourseId = courseId;

            CourseVideoDto courseVideoDto = CourseVideoRepository.CreateCourseVideo(courseVideo);
            return Ok(courseVideoDto);
        }

        [HttpPut("{courseId}/course-videos/{courseVideoId}")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CourseVideoDto> UpdateCourseVideo(int courseId, int courseVideoId, [FromBody] UpdateCourseVideoDto courseVideo)
        {
            IsUserIdAvailable(out int userId);

            courseVideo.ID = courseVideoId;
            courseVideo.CourseId = courseId;

            CourseVideoDto courseVideoDto = CourseVideoRepository.UpdateCourseVideo(courseVideo);
            return Ok(courseVideoDto);
        }

        [HttpDelete("{courseId}/course-videos/{courseVideoId}")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<bool> DeleteCourseVideo(int courseId, int courseVideoId)
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

        [HttpGet("{courseId}/course-videos/{courseVideoId}")]
        public ActionResult<CourseVideoDto> GetCourseVideoById(int courseId, int courseVideoId)
        {
            CourseVideoDto courseVideoDto = CourseVideoRepository.GetCourseVideoById(courseVideoId);
            return Ok(courseVideoDto);
        }

















        // Course Tags Related Routes

        [HttpPost("{courseId}/course-tags")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CourseVideoDto> AddCourseTags(int courseId, [FromBody] List<long> tagsList)
        {
            IsUserIdAvailable(out int userId);

            CourseRepository.AddTagsToCourse(courseId, tagsList);
            return Ok();
        }

        [HttpPut("{courseId}/course-tags")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CourseVideoDto> UpdateCourseTag(int courseId, [FromBody] List<long> tagsList)
        {
            IsUserIdAvailable(out int userId);

            CourseRepository.UpdateCourseTags(courseId, tagsList);
            return Ok();
        }

        [HttpDelete("{courseId}/course-tags/{tagId}")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<bool> RemvoeCourseTag(int courseId, int tagId)
        {
            IsUserIdAvailable(out int userId);

            bool isDeleted = CourseRepository.RemoveCourseTag(courseId, tagId);
            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }







        // get courses of my interests
        [HttpGet("my-interests-courses")]
        public ActionResult<IEnumerable<CourseInfoDto>> GetCoursesOfMyInterests()
        {
            IsUserIdAvailable(out int userId);

            return Ok(CourseRepository.GetCoursesOfMyInterests(userId));
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