

namespace Backend.Models
{
    public class CourseDiscount
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public double Discount { get; set; }
        public DateTime ExpirationDate { get; set; }


        public Course Course { get; set; }
        public int CourseId { get; set; }

        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }

    }
}