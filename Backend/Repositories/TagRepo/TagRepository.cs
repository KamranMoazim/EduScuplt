

using AutoMapper;
using Backend.Dtos.CourseDtos;
using Backend.Dtos.TagDtos;
using Backend.Exceptions;
using Backend.Models;

namespace Backend.Repositories.TagRepo
{
    public class TagRepository : ITagRepository
    {

        private readonly ProjectAppContext _context;
        private readonly IMapper _mapper;

        public TagRepository(ProjectAppContext _ctx, IMapper map)
        {
            _context = _ctx;
            _mapper = map;
        }

        public CreateTagDto CreateTag(CreateTagDto tagDto)
        {
            Tags tag = _mapper.Map<Tags>(tagDto);

            _context.Tags.Add(tag);
            _context.SaveChanges();

            return _mapper.Map<CreateTagDto>(tag);
        }

        public bool DeleteTagById(long id)
        {

            Tags? tag = _context.Tags.Find(id);

            if (tag == null)
            {
                throw new NotFoundException("Tag not found");
            }

            _context.Tags.Remove(tag);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<TagDto> GetAllTags()
        {
            return _mapper.Map<IEnumerable<TagDto>>(_context.Tags);
        }

        public IEnumerable<TagDto> GetCourseTags(long courseId)
        {
            return _mapper.Map<IEnumerable<TagDto>>(_context.Tags);
        }

        public TagDto GetTagById(long id)
        {
            Tags? tag = _context.Tags.Find(id);

            if (tag == null)
            {
                throw new NotFoundException("Tag not found");
            }

            return _mapper.Map<TagDto>(tag);
        }

        public TagDto UpdateTag(long id, UpdateTagDto tagDto)
        {
            Tags? tag = _context.Tags.Find(id);

            if (tag == null)
            {
                throw new NotFoundException("Tag not found");
            }

            tag.Name = tagDto.Name;

            _context.SaveChanges();

            return _mapper.Map<TagDto>(tag);
        }
    }
}