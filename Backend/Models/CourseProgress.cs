

namespace Backend.Models
{
    public class CourseProgress
    {
        public int ID { get; set; }
        public Course Course { get; set; }
        public StudentCourses StudentCourses { get; set; }
        public double Progress { get; set; }
        public DateTime LastProgressDate { get; set; }
    }
}