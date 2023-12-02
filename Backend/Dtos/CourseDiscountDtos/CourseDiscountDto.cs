

namespace Backend.Dtos.CourseDiscountDtos
{
    public class CourseDiscountDto
    {
        public int ID { get; set; }

        public string Code { get; set; }
        public double Discount { get; set; } = 0.0;
        public DateTime ExpirationDate { get; set; }
    }
}