

using Backend.Dtos.TagDtos;

namespace Backend.Repositories.TagRepo
{
    public interface ITagRepo
    {
        CreateTagDto CreateTag(CreateTagDto tagDto);
        bool DeleteTagById(int id);
        TagDto UpdateTag(TagDto tagDto);
        IEnumerable<TagDto> GetAllTags();
        TagDto GetTagById(int id);
    }
}