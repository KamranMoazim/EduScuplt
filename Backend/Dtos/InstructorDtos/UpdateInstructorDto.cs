

using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.InstructorDtos
{
    public class UpdateInstructorDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Account Number is required.")]
        [StringLength(50, ErrorMessage = "Account Number must be at most 50 characters.")]
        public string? AccountNo { get; set; }

        public string? AccountDetails { get; set; }

    }
}