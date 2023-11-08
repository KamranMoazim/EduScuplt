

namespace Backend.Models
{
    public class CourseVideoLikes
    {
        public int ID { get; set; }
        public bool Liked { get; set; }
        public bool Disliked { get; set; }

        public CourseVideo CourseVideo { get; set; }
        public User User { get; set; }
    }
}