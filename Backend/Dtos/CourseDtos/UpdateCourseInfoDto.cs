
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.CourseDtos
{
    public class UpdateCourseInfoDto
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

    }
}