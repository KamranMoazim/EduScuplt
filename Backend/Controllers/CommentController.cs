
using Backend.Dtos.GenericDTOs;
using Backend.Dtos.VideoCommentsDtos;
using Backend.Repositories.CommentRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        
        public ICommentRepository CommentRepository { get; set; }

        public CommentController(ICommentRepository commentRepository)
        {
            CommentRepository = commentRepository;
        }

        [HttpGet("{videoId}")]
        [Authorize]
        public ActionResult<List<VideoCommentsDto>> GetComments(int videoId)
        {

            return CommentRepository.ReadComments(videoId).Count > 0 ? Ok(CommentRepository.ReadComments(videoId)) : NotFound("No comments found");
        }

        [HttpPost("{videoId}")]
        [Authorize]
        public ActionResult<CreateResponseDto> PostComment(int videoId, [FromBody] CreateVideoCommentsDto comment)
        {
            comment.CourseVideoId = videoId;

            return Ok(CommentRepository.CreateComment(comment));
        }
    }
}