

using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.TagDtos
{
    public class UpdateTagDto
    {
        [Required(ErrorMessage = "Tag Name is required.")]
        [StringLength(50, ErrorMessage = "Tag Name must be at most 50 characters.")]
        public string Name { get; set; }
    }
}