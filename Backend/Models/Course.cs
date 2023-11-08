
namespace Backend.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public List<Tags> Tags { get; set; }

        public List<CourseVideo> CourseVideos { get; set; }

        public List<Payment> Payments { get; set; }

        public Instructor Instructor { get; set; }

        public List<CourseDiscount> CourseDiscounts { get; set; }

        public List<StudentCourses> StudentCourses { get; set; }

        public List<CourseProgress> CourseProgress { get; set; }

    }
}