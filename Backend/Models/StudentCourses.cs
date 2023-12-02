

using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class StudentCourses
    {
        public int ID { get; set; }

        public DateTime CourseStartDate { get; set; }
        public DateTime CourseCompleteDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool IsReviewed { get; set; } = false;



        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int? Rating { get; set; }

        [StringLength(250, ErrorMessage = "Review must be at most 250 characters.")]
        public string? Review { get; set; }


        // Course Progress Related Properties
        public double CourseCompleteProgressPercentage { get; set; } = 0.0;
        public DateTime LastProgressDate { get; set; } = DateTime.Now;


        // Payment Related Properties
        public StudentPayment StudentPayment { get; set; }
        public int StudentPaymentId { get; set; }





        public Student Student { get; set; }
        public int StudentId { get; set; }


        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}