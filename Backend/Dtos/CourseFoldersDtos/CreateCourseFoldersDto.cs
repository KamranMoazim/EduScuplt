

using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.CourseFoldersDtos
{
    public class CreateCourseFoldersDto
    {

        [Required(ErrorMessage = "Folder Name is required.")]
        [StringLength(100, ErrorMessage = "Folder Name must be at most 100 characters.")]
        public string FolderName { get; set; }
        
        [Required(ErrorMessage = "Course ID is required.")]
        public int CourseId { get; set; }
    }
}