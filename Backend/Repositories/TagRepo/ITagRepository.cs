

using Backend.Dtos.CourseDtos;
using Backend.Dtos.TagDtos;
using Backend.Models;

namespace Backend.Repositories.TagRepo
{
    public interface ITagRepository
    {
        CreateTagDto CreateTag(CreateTagDto tagDto);
        bool DeleteTagById(long id);
        TagDto UpdateTag(TagDto tagDto);
        IEnumerable<TagDto> GetAllTags();
        IEnumerable<TagDto> GetCourseTags(long courseId);
        TagDto GetTagById(long id);
    }
}