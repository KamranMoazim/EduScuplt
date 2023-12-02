

using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class InstructorPayment
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Stripe Payment ID is required.")]
        public string StripePaymentID { get; set; }
        
        public double PaidAmount { get; set; }
        public DateTime PayingDate { get; set; }



        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }
    }
}