

using System.ComponentModel.DataAnnotations;
using Backend.Models.HelpingModels;

namespace Backend.Models
{
    public class CourseVideo : SoftDeletable
    {
        // public int ID { get; set; }

        [Required(ErrorMessage = "Video Title is required.")]
        [StringLength(250, ErrorMessage = "Video Title must be at most 250 characters.")]
        public string Title { get; set; }

        [Url(ErrorMessage = "Video URL must be a valid URL.")]
        public string VideoURL { get; set; }

        [Url(ErrorMessage = "Thumbnail URL must be a valid URL.")]
        public string ThumbnailURL { get; set; }


        public Course Course { get; set; }
        public long CourseId { get; set; }



        public CourseFolders CourseFolders { get; set; }
        public long? CourseFoldersId { get; set; }


        // public List<StudentCourseVideoLikes> StudentCourseVideoLikes { get; set; }

        public List<VideoComments> VideoComments { get; set; }

    }
}