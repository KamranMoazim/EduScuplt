

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Student
    {
        // public int Id { get; set; }

        // [Key]
        public int Id { get; set; }

        // [ForeignKey("UserId")]  // Specify the name of the foreign key property
        public int UserId { get; set; }

        public User User { get; set; }


        public List<StudentInterests> StudentInterests { get; set; }

        // public List<StudentCourseVideoLikes> StudentCourseVideoLikes { get; set; }

        public List<StudentCourses> StudentCourse { get; set; }

        // public List<CourseProgress> CourseProgress { get; set; }

    }
}