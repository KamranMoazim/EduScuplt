

using Backend.Dtos.UserDtos;

namespace Backend.Dtos.VideoCommentsDtos
{
    public class VideoCommentsDto
    {
        public string Comment { get; set; }
        
        public DateTime CommentDate { get; set; }

        public UserDto CommentBy { get; set; }
    }
}