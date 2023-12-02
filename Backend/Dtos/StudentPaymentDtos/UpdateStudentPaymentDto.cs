

using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.StudentPaymentDtos
{
    public class UpdateStudentPaymentDto
    {

        [Required(ErrorMessage = "Stripe Payment ID is required.")]
        public string StripePaymentID { get; set; }

        public bool IsPaid { get; set; } = false;

    }
}