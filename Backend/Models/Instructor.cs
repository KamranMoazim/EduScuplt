

using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Instructor
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Account Number is required.")]
        [StringLength(50, ErrorMessage = "Account Number must be at most 50 characters.")]
        public string? AccountNo { get; set; }

        public string? AccountDetails { get; set; }
        public double PendingAmount { get; set; } = 0;
        public double WithdrawnAmount { get; set; } = 0;
        public double TotalEarnedAmount { get; set; } = 0;



        // Admin Related Properties
        public bool IsApproved { get; set; } = false;
        public Admin ApprovedBy { get; set; }
        public int? ApprovedById { get; set; }





        public User User { get; set; }
        public int UserId { get; set; }

        public List<Course> Courses { get; set; }

        public List<CourseDiscount> CourseDiscounts { get; set; }

        public List<InstructorPayment> InstructorPayments { get; set; }
    }
}