

using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.InstructorPaymentDtos
{
    public class CreateInstructorPaymentDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Stripe Payment ID is required.")]
        public string StripePaymentID { get; set; }

        public double PaidAmount { get; set; }
        public DateTime PayingDate { get; set; }

        [Required(ErrorMessage = "Instructor Id is required.")]
        public int InstructorId { get; set; }

    }
}