
using System.Security.Claims;
using Backend.Dtos.CourseDtos;
using Backend.Dtos.GenericDTOs;
using Backend.Models;
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

        public CourseController(ICourseRepository courseRepository)
        {
            CourseRepository = courseRepository;
        }

        [HttpGet("courses")]
        public ActionResult<IEnumerable<Course>> GetAllCourses()
        {
            return Ok(CourseRepository.AllCourses());
        }



        [HttpGet("/courses/{id}")]
        public ActionResult<CourseInfoDto> GetSingleCourse(int id)
        {
            Console.WriteLine("Hello");
            Console.WriteLine(id);

            return Ok(CourseRepository.GetCourseById(id));
        }

        [HttpPost("create-course")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<CreateResponseDto> CreateCourse([FromBody] CreateCourseInfoDto courseDto)
        {

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                Console.WriteLine(userId);
                courseDto.InstructorId = userId;
                CourseRepository.CreateCourse(courseDto);
            }
            else
            {
                return Unauthorized();
            }
            
            CreateResponseDto createResponseDto = new CreateResponseDto
            {
                Status = "Success",
                Message = "Course created successfully"
            };

            return Ok(createResponseDto);
        }
    }
}