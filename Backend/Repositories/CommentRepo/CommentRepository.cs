

using AutoMapper;
using Backend.Dtos.GenericDTOs;
using Backend.Dtos.VideoCommentsDtos;
using Backend.Models;

namespace Backend.Repositories.CommentRepo
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ProjectAppContext _context;
        private readonly IMapper _mapper;

        public CommentRepository(ProjectAppContext _ctx, IMapper map)
        {
            _context = _ctx;
            _mapper = map;
        }

        public CreateResponseDto CreateComment(CreateVideoCommentsDto createVideoCommentsDto)
        {

            VideoComments videoComments = _mapper.Map<VideoComments>(createVideoCommentsDto);

            _context.VideoComments.Add(videoComments);
            _context.SaveChanges();

            return new CreateResponseDto
            {
                Status = "Success",
                Message = "Comment Created Successfully."
            };
        }

        public List<VideoCommentsDto> ReadComments(long videoId)
        {
            List<VideoComments> videoComments = _context.VideoComments.Where(x => x.CourseVideoId == videoId).ToList();

            List<VideoCommentsDto> videoCommentsDto = _mapper.Map<List<VideoCommentsDto>>(videoComments);

            return videoCommentsDto;
        }
    }
}