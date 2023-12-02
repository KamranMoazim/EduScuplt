

using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.CourseVideoDtos
{
    public class UpdateCourseVideoDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Video Title is required.")]
        [StringLength(250, ErrorMessage = "Video Title must be at most 250 characters.")]
        public string Title { get; set; }

        [Url(ErrorMessage = "Video URL must be a valid URL.")]
        public string VideoURL { get; set; }

        [Url(ErrorMessage = "Thumbnail URL must be a valid URL.")]
        public string ThumbnailURL { get; set; }

        [Required(ErrorMessage = "Course ID is required.")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course Folder ID is required.")]
        public int? CourseFoldersId { get; set; }

    }
}