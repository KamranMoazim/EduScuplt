

namespace Backend.Models
{
    public class CourseFolders
    {
        public int ID { get; set; }
        public string FolderName { get; set; }
        
        public Course Course { get; set; }
        public int CourseId { get; set; }

        public List<CourseVideo> CourseVideos { get; set; }
        
    }
}