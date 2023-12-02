
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.CourseDiscountDtos
{
    public class CreateCourseDiscountDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Discount Code is required.")]
        [StringLength(15, ErrorMessage = "Discount Code must be at most 15 characters.")]
        [MinLength(5, ErrorMessage = "Discount Code must be at least 5 characters.")]
        public string Code { get; set; }
        public double Discount { get; set; } = 0.0;
        public DateTime ExpirationDate { get; set; }


        [Required(ErrorMessage = "Course ID is required.")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Instructor ID is required.")]
        public int InstructorId { get; set; }
    }
}