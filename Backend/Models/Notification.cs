

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Models.HelpingModels;

namespace Backend.Models
{
    public class Notification : SoftDeletable
    {
        // public int ID { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsRead { get; set; } = false;

        [Required(ErrorMessage = "Notification Message is required.")]
        [StringLength(100, ErrorMessage = "Notification Message must be at most 100 characters.")]
        public string Message { get; set; }


        // for whom the notification is
        public User User { get; set; }
        public long UserId { get; set; }



        [NotMapped] // Exclude this property from being mapped to the database
        public ProjectEnums.NotificationType NotificationTypeEnums
        {
            get
            {
                Enum.TryParse(NotificationType, out ProjectEnums.NotificationType notificationTypeEnum);
                return notificationTypeEnum;
            }
            set
            {
                if (Enum.IsDefined(typeof(ProjectEnums.NotificationType), value))
                {
                    NotificationType = value.ToString();
                }
                else
                {
                    throw new ArgumentException("Invalid NotificationType value");
                }
            }
        }
        public string NotificationType { get; set; } // e.g., "CommentReply", "Marketing"
        public long? RelatedEntityId { get; set; } // ID of the related entity (e.g., CommentId, MarketingId)


        [ForeignKey(nameof(RelatedEntityId))]
        public VideoComments VideoComments { get; set; } // Assuming VideoComments is a related entity


        [ForeignKey(nameof(RelatedEntityId))]
        public CourseMarketing CourseMarketing { get; set; } // Assuming Marketing is a related entity


    }
}