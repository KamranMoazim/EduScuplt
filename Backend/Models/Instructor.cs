

namespace Backend.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        public string AccountNo { get; set; }
        public string AccountDetails { get; set; }
        public double PendingAmount { get; set; }
        public double WithdrawnAmount { get; set; }
        public double TotalEarnedAmount { get; set; }



        // Admin Related Properties
        public bool IsApproved { get; set; }
        public Admin ApprovedBy { get; set; }
        public int ApprovedById { get; set; }





        public User User { get; set; }
        public int UserId { get; set; }

        public List<Course> Courses { get; set; }

        public List<CourseDiscount> CourseDiscounts { get; set; }

        public List<InstructorPayment> InstructorPayments { get; set; }
    }
}