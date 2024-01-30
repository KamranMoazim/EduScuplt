

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Dtos.CourseFoldersDtos
{
    public class UpdateCourseFolderNameDto
    {
        
        // [Required(ErrorMessage = "Course Folder ID is required.")]
        [JsonIgnore]
        public long ID { get; set; }


        [Required(ErrorMessage = "Folder Name is required.")]
        [StringLength(100, ErrorMessage = "Folder Name must be at most 100 characters.")]
        public string FolderName { get; set; }
        
        // [Required(ErrorMessage = "Course ID is required.")]
        [JsonIgnore]
        public long CourseId { get; set; }
    }
}