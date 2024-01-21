

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Models.HelpingModels;

namespace Backend.Models
{
    public class User : SoftDeletable
    {
        // public int ID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be at most 50 characters.")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be at most 50 characters.")]
        public string LastName { get; set; }



        [Url(ErrorMessage = "Profile URL must be a valid URL.")]
        public string? ProfileURL { get; set; }



        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }



        [StringLength(500, ErrorMessage = "About must be at most 500 characters.")]
        [DataType(DataType.MultilineText)]
        public string? About { get; set; }



        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }



        [NotMapped] // Exclude this property from being mapped to the database
        public ProjectEnums.UserType UserTypeEnums
        {
            get
            {
                Enum.TryParse(UserType, out ProjectEnums.UserType userTypeEnum);
                return userTypeEnum;
            }
            set
            {
                if (Enum.IsDefined(typeof(ProjectEnums.UserType), value))
                {
                    UserType = value.ToString();
                }
                else
                {
                    throw new ArgumentException("Invalid UserType value");
                }
            }
        }

        // This property will be mapped to the database for UserType
        public string UserType { get; set; }



        // becuase any user can comment on a video , thats why we have to add this property in user model
        // public List<VideoComments> VideoComments { get; set; }
        // public List<Notification> Notifications { get; set; }





        // public List<CourseVideoLikes> CourseVideoLikes { get; set; }
        
        // public List<Interests> Interests { get; set; }
        // public List<Payment> Payments { get; set; }
        
        // public List<StudentCourses> StudentCourse { get; set; }

        // public List<CourseProgress> CourseProgress { get; set; }

    }
}