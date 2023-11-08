

namespace Backend.Models
{
    public class Notification
    {
        public int ID { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsRead { get; set; }
        public User User { get; set; }
        public CourseVideo CourseVideo { get; set; }
        public VideoComments VideoComment { get; set; }
        public ProjectEnums.NotificationType Type { get; set; }

    }
}