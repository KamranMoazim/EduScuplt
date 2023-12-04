
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        [HttpGet("/{videoId}/comments")]
        public IActionResult GetComments(int videoId)
        {
            return Ok($"CommentController {videoId}");
        }

        [HttpPost("/{videoId}/comments")]
        public IActionResult PostComment(int videoId, [FromBody] string comment)
        {
            return Ok($"CommentController {videoId}");
        }
    }
}