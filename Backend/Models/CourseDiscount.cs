

using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class CourseDiscount
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Discount Code is required.")]
        [StringLength(15, ErrorMessage = "Discount Code must be at most 15 characters.")]
        [MinLength(5, ErrorMessage = "Discount Code must be at least 5 characters.")]
        public string Code { get; set; }
        public double Discount { get; set; } = 0.0;
        public DateTime ExpirationDate { get; set; }


        public Course Course { get; set; }
        public int CourseId { get; set; }

        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }

    }
}