

using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.InterestDtos
{
    public class UpdateInterestDto
    {

        [Required(ErrorMessage = "Interests Title is required.")]
        [StringLength(50, ErrorMessage = "Interests Title must be at most 50 characters.")]
        public string Title { get; set; }
    }
}