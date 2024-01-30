

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Dtos.CourseFoldersDtos
{
    public class CreateCourseFoldersDto
    {

        [Required(ErrorMessage = "Folder Name is required.")]
        [StringLength(100, ErrorMessage = "Folder Name must be at most 100 characters.")]
        public string FolderName { get; set; }
        
        [JsonIgnore]
        public int CourseId { get; set; }
    }
}