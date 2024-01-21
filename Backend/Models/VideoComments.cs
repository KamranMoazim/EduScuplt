

using System.ComponentModel.DataAnnotations;
using Backend.Models.HelpingModels;

namespace Backend.Models
{
    public class VideoComments : SoftDeletable
    {
        // public int ID { get; set; }

        [Required(ErrorMessage = "Comment is required.")]
        [StringLength(250, ErrorMessage = "Comment must be at most 250 characters.")]
        public string Comment { get; set; }
        
        public DateTime CommentDate { get; set; }
        public bool IsPublic { get; set; } = false;

        public CourseVideo CourseVideo { get; set; }
        public long CourseVideoId { get; set; }


        public User CommentBy { get; set; }
        public long CommentById { get; set; }

        public User ReplyTo { get; set; }
        public long? ReplyToId { get; set; }


        // public List<Notification> Notifications { get; set; }
    }
}