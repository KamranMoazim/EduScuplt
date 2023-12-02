

using Backend.Dtos.CourseDiscountDtos;
using Backend.Dtos.CourseDtos;

namespace Backend.Dtos.StudentPaymentDtos
{
    public class StudentPaymentDto
    {

        public int ID { get; set; }

        public double ActualAmount { get; set; } = 0.0;
        public bool IsDiscounted { get; set; } = false;
        public double DiscountedAmount { get; set; } = 0.0;
        public double PaidAmount { get; set; } = 0.0;
        public DateTime PayingDate { get; set; }
        public bool IsPaid { get; set; } = false;


        public CourseDiscountDto? CourseDiscount { get; set; }

        public CourseInfoDto Course { get; set; }


    }
}