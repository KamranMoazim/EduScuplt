

using System.ComponentModel.DataAnnotations;
using Backend.Models.HelpingModels;

namespace Backend.Models
{
    public class Tags : SoftDeletable
    {
        // public int ID { get; set; }

        [Required(ErrorMessage = "Tag Name is required.")]
        [StringLength(50, ErrorMessage = "Tag Name must be at most 50 characters.")]
        public string Name { get; set; }

        public List<Course> Courses { get; set; }
    }
}