

namespace Backend.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileURL { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public string PhoneNumber { get; set; }
        public ProjectEnums.UserType UserType { get; set; }

        public List<CourseVideoLikes> CourseVideoLikes { get; set; }
        public List<VideoComments> VideoComments { get; set; }
        
        public List<Interests> Interests { get; set; }
        public List<Payment> Payments { get; set; }
        
        public List<StudentCourses> StudentCourse { get; set; }

        public List<CourseProgress> CourseProgress { get; set; }
        public List<Notification> Notifications { get; set; }

    }
}