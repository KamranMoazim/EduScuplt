

namespace Backend.Models
{
    public class StudentCourses
    {
        public int ID { get; set; }
        public User Student { get; set; }
        public Course Course { get; set; }
        public DateTime DateJoined { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}