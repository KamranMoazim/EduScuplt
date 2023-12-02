

namespace Backend.Models
{
    public class Student
    {
        public int Id { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }


        public List<StudentInterests> StudentInterests { get; set; }

        // public List<StudentCourseVideoLikes> StudentCourseVideoLikes { get; set; }

        public List<StudentCourses> StudentCourse { get; set; }

        // public List<CourseProgress> CourseProgress { get; set; }

    }
}