

namespace Backend.Models
{
    public class Admin
    {
        // public int Id { get; set; }

        // [Key]
        public int Id { get; set; }

        // [ForeignKey("UserId")]  // Specify the name of the foreign key property
        public int UserId { get; set; }

        public User User { get; set; }


        public List<Course> Courses { get; set; }

        public List<Instructor> Instructors { get; set; }

        public List<CourseMarketing> CourseMarketings { get; set; }
    }
}