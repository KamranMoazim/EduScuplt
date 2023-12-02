

using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Interests
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Interests Title is required.")]
        [StringLength(50, ErrorMessage = "Interests Title must be at most 50 characters.")]
        public string Title { get; set; }

        public List<StudentInterests> StudentInterests { get; set; }
    }
}