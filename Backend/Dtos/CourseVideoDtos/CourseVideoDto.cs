

using Backend.Dtos.VideoCommentsDtos;

namespace Backend.Dtos.CourseVideoDtos
{
    public class CourseVideoDto
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public string VideoURL { get; set; }
        public string ThumbnailURL { get; set; }

        public List<VideoCommentsDto> VideoComments { get; set; }
    }
}