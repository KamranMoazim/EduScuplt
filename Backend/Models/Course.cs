
namespace Backend.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsPublic { get; set; }
        public string ThumbnailURL { get; set; }
        public DateTime ReleaseDate { get; set; }


        // Admin Related Properties
        public bool IsApproved { get; set; }
        public Admin ApprovedBy { get; set; }
        public int ApprovedById { get; set; }


        // Student Related Properties
        public List<StudentCourses> StudentCourses { get; set; }


        // Instructor Related Properties
        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }
        public List<CourseDiscount> CourseDiscounts { get; set; }



        public List<Tags> Tags { get; set; }

        public List<CourseVideo> CourseVideos { get; set; }

        // public List<Payment> Payments { get; set; }


        // public List<CourseProgress> CourseProgress { get; set; }

    }
}