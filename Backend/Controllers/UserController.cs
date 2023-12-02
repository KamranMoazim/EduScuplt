
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        
        [HttpGet("/approve-instructor")]
        public ActionResult<string> InstructorAccess()
        {
            return Ok("Hi Instructor");
        }
        
    }
}