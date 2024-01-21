

using Backend.Models.HelpingModels;

namespace Backend.Models
{
    public class StudentInterests : SoftDeletable
    {

        // public int Id { get; set; }

        public long StudentId { get; set; }
        public Student Student { get; set; }

        public long InterestId { get; set; }
        public Interests Interest { get; set; }
    }
}