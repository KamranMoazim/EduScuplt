

namespace Backend.Models
{
    public class InstructorPayment
    {
        public int ID { get; set; }
        public string StripePaymentID { get; set; }
        public double PaidAmount { get; set; }
        public DateTime PayingDate { get; set; }



        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }
    }
}