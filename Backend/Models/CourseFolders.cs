

using System.ComponentModel.DataAnnotations;
using Backend.Models.HelpingModels;

namespace Backend.Models
{
    public class CourseFolders : SoftDeletable
    {
        // public int ID { get; set; }

        [Required(ErrorMessage = "Folder Name is required.")]
        [StringLength(100, ErrorMessage = "Folder Name must be at most 100 characters.")]
        public string FolderName { get; set; }
        
        public Course Course { get; set; }
        public long CourseId { get; set; }

        public List<CourseVideo> CourseVideos { get; set; }
    }
}