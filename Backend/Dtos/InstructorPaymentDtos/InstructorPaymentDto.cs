

namespace Backend.Dtos.InstructorPaymentDtos
{
    public class InstructorPaymentDto
    {
        public int ID { get; set; }
        public string StripePaymentID { get; set; }
        
        public double PaidAmount { get; set; }
        public DateTime PayingDate { get; set; }

    }
}