
using Backend.Models.HelpingModels;

namespace Backend.Models
{
    public class Student : SoftDeletable
    {
        // public int Id { get; set; }

        // [Key]
        // public int Id { get; set; }

        // [ForeignKey("UserId")]  // Specify the name of the foreign key property
        public long UserId { get; set; }

        public User User { get; set; }


        public List<StudentInterests> StudentInterests { get; set; }

        // public List<StudentCourseVideoLikes> StudentCourseVideoLikes { get; set; }

        public List<StudentCourses> StudentCourse { get; set; }

        // public List<CourseProgress> CourseProgress { get; set; }

    }
}