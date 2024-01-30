
using Backend.Dtos.TagDtos;
using Backend.Repositories.CourseRepo;
using Backend.Repositories.TagRepo;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        public ITagRepository TagRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }

        public TagController(ITagRepository tagRepository, ICourseRepository courseRepository)
        {
            TagRepository = tagRepository;
            CourseRepository = courseRepository;
        }

        [HttpGet("tags")]
        public ActionResult<IEnumerable<TagDto>> GetAllTags()
        {
            return Ok(TagRepository.GetAllTags());
        }

        [HttpGet("tags/{id}")]
        public ActionResult<TagDto> GetSingleTag(int id)
        {
            return Ok(TagRepository.GetTagById(id));
        }

        [HttpPost("create-tag")]
        public ActionResult<CreateTagDto> CreateTag([FromBody] CreateTagDto tagDto)
        {
            TagRepository.CreateTag(tagDto);

            return Ok(tagDto);
        }

        [HttpDelete("delete-tag/{tagId}")]
        public ActionResult<bool> DeleteTag(int tagId)
        {
            return NoContent();
        }

        [HttpPut("update-tag/{tagId}")]
        public ActionResult<TagDto> UpdateTag(int tagId, [FromBody] UpdateTagDto tagDto)
        {
            return Ok(TagRepository.UpdateTag(tagId, tagDto));
        }



    }
}