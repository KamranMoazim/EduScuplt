

namespace Backend.Models
{
    public class StudentCourseVideoLikes
    {
        public int ID { get; set; }
        public bool IsLiked { get; set; }


        public Student Student { get; set; }
        public int StudentId { get; set; }


        public CourseVideo CourseVideo { get; set; }
        public int CourseVideoId { get; set; }
    }
}