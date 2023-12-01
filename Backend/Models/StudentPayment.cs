
namespace Backend.Models
{
    public class StudentPayment
    {
        public int ID { get; set; }
        public string StripePaymentID { get; set; }
        public double ActualAmount { get; set; }
        public bool IsDiscounted { get; set; }
        public double DiscountedAmount { get; set; }
        public double PaidAmount { get; set; }
        public DateTime PayingDate { get; set; }


        public CourseDiscount CourseDiscount { get; set; }
        public int CourseDiscountId { get; set; }


        public StudentCourses StudentCourses { get; set; }
        public int StudentCoursesId { get; set; }



        public Course Course { get; set; }
        public int CourseId { get; set; }

        



    }
}