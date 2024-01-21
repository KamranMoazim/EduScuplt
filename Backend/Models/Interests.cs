

using System.ComponentModel.DataAnnotations;
using Backend.Models.HelpingModels;

namespace Backend.Models
{
    public class Interests : SoftDeletable
    {
        // public int ID { get; set; }

        [Required(ErrorMessage = "Interests Title is required.")]
        [StringLength(50, ErrorMessage = "Interests Title must be at most 50 characters.")]
        public string Title { get; set; }

        public List<StudentInterests> StudentInterests { get; set; }
    }
}