

namespace Backend.Dtos.NotificationDtos
{
    public class NotificationDto
    {
        public int ID { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsRead { get; set; } = false;
        public string Message { get; set; }
        public string NotificationType { get; set; } // e.g., "CommentReply", "Marketing"

    }
}