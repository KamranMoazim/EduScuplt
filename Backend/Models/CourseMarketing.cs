
using System.ComponentModel.DataAnnotations;
using Backend.Models.HelpingModels;

namespace Backend.Models
{
    public class CourseMarketing : SoftDeletable
    {
        // public int ID { get; set; }

        [Required(ErrorMessage = "Course Description is required.")]
        [StringLength(250, ErrorMessage = "Course Description must be at most 250 characters.")]
        public string CourseDescription { get; set; }

        public Admin Admin { get; set; }
        public long AdminId { get; set; }
    }
}