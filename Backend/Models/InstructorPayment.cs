

using System.ComponentModel.DataAnnotations;
using Backend.Models.HelpingModels;

namespace Backend.Models
{
    public class InstructorPayment : SoftDeletable
    {
        // public int ID { get; set; }

        [Required(ErrorMessage = "Stripe Payment ID is required.")]
        public string StripePaymentID { get; set; }
        
        public double PaidAmount { get; set; }
        public DateTime PayingDate { get; set; }



        public Instructor Instructor { get; set; }
        public long InstructorId { get; set; }
    }
}