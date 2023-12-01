

namespace Backend.Models
{
    public class StudentCourses
    {
        public int ID { get; set; }

        public DateTime CourseStartDate { get; set; }
        public DateTime CourseCompleteDate { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }


        // Course Progress Related Properties
        public double CourseCompleteProgressPercentage { get; set; }
        public DateTime LastProgressDate { get; set; }


        // Payment Related Properties
        public StudentPayment StudentPayment { get; set; }
        public int StudentPaymentId { get; set; }





        public Student Student { get; set; }
        public int StudentId { get; set; }


        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}