

namespace Backend.Models
{
    public class VideoComments
    {
        public int ID { get; set; }
        public string Comment { get; set; }
        public CourseVideo CourseVideo { get; set; }
        public User CommentBy { get; set; }
        public User ReplyTo { get; set; }
        public DateTime CommentDate { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}