
using System.Security.Claims;
using Backend.Repositories.CourseFolderRepo;
using Backend.Repositories.CourseRepo;
using Backend.Repositories.CourseVideoRepo;
using Backend.Repositories.TagRepo;
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
            TagRepository tagRepository,
            ICourseVideoRepository courseVideoRepository
            )
        {
            CourseRepository = courseRepository;
            CourseFolderRepository = courseFolderRepository;
            TagRepository = tagRepository;
            CourseVideoRepository = courseVideoRepository;
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