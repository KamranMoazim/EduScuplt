

using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class VideoComments
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Comment is required.")]
        [StringLength(250, ErrorMessage = "Comment must be at most 250 characters.")]
        public string Comment { get; set; }
        
        public DateTime CommentDate { get; set; }
        public bool IsPublic { get; set; } = false;


        public CourseVideo CourseVideo { get; set; }
        public int CourseVideoId { get; set; }


        public User CommentBy { get; set; }
        public int CommentById { get; set; }

        public User ReplyTo { get; set; }
        public int? ReplyToId { get; set; }


        // public List<Notification> Notifications { get; set; }
    }
}