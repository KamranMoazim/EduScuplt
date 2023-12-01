

namespace Backend.Models
{
    public class CourseVideo
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string VideoURL { get; set; }
        public string ThumbnailURL { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }


        public List<StudentCourseVideoLikes> StudentCourseVideoLikes { get; set; }

        public List<VideoComments> VideoComments { get; set; }




    }
}