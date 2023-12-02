

using Backend.Dtos.CourseVideoDtos;

namespace Backend.Dtos.CourseFoldersDtos
{
    public class CourseFoldersDto
    {
        public int ID { get; set; }

        public string FolderName { get; set; }

        public List<CourseVideoDto> CourseVideos { get; set; }
    }
}