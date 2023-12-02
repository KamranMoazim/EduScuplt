
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class StudentPayment
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "Stripe Payment ID is required.")]
        public string? StripePaymentID { get; set; }

        public double ActualAmount { get; set; } = 0.0;
        public bool IsDiscounted { get; set; } = false;
        public double DiscountedAmount { get; set; } = 0.0;
        public double PaidAmount { get; set; } = 0.0;
        public DateTime PayingDate { get; set; }
        public bool IsPaid { get; set; } = false;


        public CourseDiscount CourseDiscount { get; set; }
        public int? CourseDiscountId { get; set; }


        // [ForeignKey(nameof(StudentCourses))]
        // [ForeignKey("StudentCourses")]
        // public StudentCourses StudentCourses { get; set; }
        // public int StudentCoursesId { get; set; }



        public Course Course { get; set; }
        public int CourseId { get; set; }

    }
}