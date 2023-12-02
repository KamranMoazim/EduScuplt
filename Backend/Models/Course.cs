
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Course
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Course Title is required.")]
        [StringLength(100, ErrorMessage = "Course Title must be at most 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Course Description is required.")]
        [StringLength(1000, ErrorMessage = "Course Description must be at most 1000 characters.")]
        public string Description { get; set; }
        public double Price { get; set; } = 0.0;

        [Url(ErrorMessage = "Video URL must be a valid URL.")]
        public string? ThumbnailURL { get; set; }
        public DateTime ReleaseDate { get; set; }




        // Admin Related Properties
        public bool IsApproved { get; set; } = false;
        public Admin? ApprovedBy { get; set; }
        public int? ApprovedById { get; set; }


        // Student Related Properties
        public List<StudentCourses> StudentCourses { get; set; }


        // Instructor Related Properties
        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }
        public List<CourseDiscount> CourseDiscounts { get; set; }


        // Course Folders Related Properties
        public List<CourseFolders> CourseFolders { get; set; }







        public List<Tags> Tags { get; set; }

        public List<CourseVideo> CourseVideos { get; set; }

    }
}