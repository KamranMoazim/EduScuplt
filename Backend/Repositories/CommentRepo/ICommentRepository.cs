

using Backend.Dtos.GenericDTOs;
using Backend.Dtos.VideoCommentsDtos;

namespace Backend.Repositories.CommentRepo
{
    public interface ICommentRepository
    {
        CreateResponseDto CreateComment(CreateVideoCommentsDto createVideoCommentsDto);
        List<VideoCommentsDto> ReadComments(long videoId);
    }
}