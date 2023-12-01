

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Backend.Models
{
    public class User
    // : IdentityUser<int>
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileURL { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public string PhoneNumber { get; set; }


        // public ProjectEnums.UserType UserType { get; set; }
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

        public List<CourseVideoLikes> CourseVideoLikes { get; set; }
        public List<VideoComments> VideoComments { get; set; }
        
        public List<Interests> Interests { get; set; }
        public List<Payment> Payments { get; set; }
        
        public List<StudentCourses> StudentCourse { get; set; }

        public List<CourseProgress> CourseProgress { get; set; }
        public List<Notification> Notifications { get; set; }

    }
}