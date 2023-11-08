
namespace Backend.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public User Student { get; set; }
        public Course Course { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}