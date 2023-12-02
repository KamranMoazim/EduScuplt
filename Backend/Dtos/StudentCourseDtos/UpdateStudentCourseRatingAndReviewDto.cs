

using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.StudentCourseDtos
{
    public class UpdateStudentCourseRatingAndReview
    {
        public int ID { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int? Rating { get; set; }

        [StringLength(250, ErrorMessage = "Review must be at most 250 characters.")]
        public string? Review { get; set; }

    }
}