

namespace Backend.Models
{
    public class Interests
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public List<StudentInterests> StudentInterests { get; set; }
    }
}