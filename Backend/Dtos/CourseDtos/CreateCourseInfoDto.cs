

using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.CourseDtos
{
    public class CreateCourseInfoDto
    {

        [Required(ErrorMessage = "Course Title is required.")]
        [StringLength(100, ErrorMessage = "Course Title must be at most 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Course Description is required.")]
        [StringLength(1000, ErrorMessage = "Course Description must be at most 1000 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Course Price is required.")]
        [Range(50, 1000, ErrorMessage = "Course Price must be between 50 and 1000.")]
        public double Price { get; set; } = 0.0;

        [Url(ErrorMessage = "Thumbnail URL must be a valid URL.")]
        public string? ThumbnailURL { get; set; }



        // Instructor Related Properties
        // [Required(ErrorMessage = "Instructor ID is required.")]
        public int InstructorId { get; set; }
    }
}