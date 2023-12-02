

using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.StudentInterestsDtos
{
    public class CreateStudentInterestsDto
    {
        [Required(ErrorMessage = "Student Id is required")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Interest Id is required")]
        public int InterestId { get; set; }
    }
}