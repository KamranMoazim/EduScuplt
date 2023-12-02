

using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.StudentCourseDtos
{
    public class CreateStudentCourseDto
    {
        [Required(ErrorMessage = "Student Payment Id is required.")]
        public int StudentPaymentId { get; set; }

        [Required(ErrorMessage = "Student Id is required.")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Course Id is required.")]
        public int CourseId { get; set; }
    }
}