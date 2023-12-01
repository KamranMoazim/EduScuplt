

namespace Backend.Models
{
    public class StudentInterests
    {

        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int InterestId { get; set; }
        public Interests Interest { get; set; }
    }
}