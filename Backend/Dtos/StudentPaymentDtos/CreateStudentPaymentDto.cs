

using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.StudentPaymentDtos
{
    public class CreateStudentPaymentDto
    {


        [Required(ErrorMessage = "Course Discount ID is required.")]
        public int? CourseDiscountId { get; set; }


        [Required(ErrorMessage = "Course ID is required.")]
        public int CourseId { get; set; }


    }
}