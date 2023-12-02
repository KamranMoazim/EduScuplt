

using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.NotificationDtos
{
    public class CreateNotificationDto
    {

        public bool IsRead { get; set; } = false;

        [Required(ErrorMessage = "Notification Message is required.")]
        [StringLength(100, ErrorMessage = "Notification Message must be at most 100 characters.")]
        public string Message { get; set; }


        // for whom the notification is
        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }



        [Required(ErrorMessage = "Notification Type is required.")]
        public string NotificationType { get; set; } // e.g., "CommentReply", "Marketing"

        [Required(ErrorMessage = "Related Entity ID is required.")]
        public int? RelatedEntityId { get; set; } // ID of the related entity (e.g., CommentId, MarketingId)

    }
}