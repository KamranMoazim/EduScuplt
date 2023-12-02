

using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class CourseFolders
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Folder Name is required.")]
        [StringLength(100, ErrorMessage = "Folder Name must be at most 100 characters.")]
        public string FolderName { get; set; }
        
        public Course Course { get; set; }
        public int CourseId { get; set; }

        public List<CourseVideo> CourseVideos { get; set; }
    }
}