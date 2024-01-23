
using Backend.Dtos.CourseFoldersDtos;
using Backend.Dtos.InstructorDtos;
using Backend.Dtos.TagDtos;

namespace Backend.Dtos.CourseDtos
{
    public class CourseInfoDto
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; } = 0.0;
        public string? ThumbnailURL { get; set; }
        public DateTime ReleaseDate { get; set; }


        // Instructor Related Properties
        public InstructorDto Instructor { get; set; }
        public int InstructorId { get; set; }


        // Course Folders Related Properties
        public List<CourseFoldersDto> CourseFolders { get; set; }

        public List<TagDto> Tags { get; set; }
    }
}