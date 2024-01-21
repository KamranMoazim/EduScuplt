

using System.ComponentModel.DataAnnotations;
using Backend.Models.HelpingModels;

namespace Backend.Models
{
    public class CourseDiscount : SoftDeletable
    {
        // public int ID { get; set; }

        [Required(ErrorMessage = "Discount Code is required.")]
        [StringLength(15, ErrorMessage = "Discount Code must be at most 15 characters.")]
        [MinLength(5, ErrorMessage = "Discount Code must be at least 5 characters.")]
        public string Code { get; set; }
        public double Discount { get; set; } = 0.0;
        public DateTime ExpirationDate { get; set; }


        public Course Course { get; set; }
        public long CourseId { get; set; }

        public Instructor Instructor { get; set; }
        public long InstructorId { get; set; }

    }
}