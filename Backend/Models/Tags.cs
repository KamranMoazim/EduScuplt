

using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Tags
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Tag Name is required.")]
        [StringLength(50, ErrorMessage = "Tag Name must be at most 50 characters.")]
        public string Name { get; set; }

        public List<Course> Courses { get; set; }
    }
}