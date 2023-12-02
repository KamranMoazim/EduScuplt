

using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.VideoCommentsDtos
{
    public class CreateVideoCommentsDto
    {
        [Required(ErrorMessage = "Comment is required.")]
        [StringLength(250, ErrorMessage = "Comment must be at most 250 characters.")]
        public string Comment { get; set; }


        [Required(ErrorMessage = "On which Video You made this Comment? CourseVideoId is required.")]
        public int CourseVideoId { get; set; }

        [Required(ErrorMessage = "Who made this Comment? CommentById is required.")]
        public int CommentById { get; set; }

        public int? ReplyToId { get; set; }
    }
}