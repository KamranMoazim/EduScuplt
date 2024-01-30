

using Backend.Dtos.CourseVideoDtos;

namespace Backend.Repositories.CourseVideoRepo
{
    public interface ICourseVideoRepository
    {
        List<CourseVideoDto> GetCourseVideosOfCourse(long courseId);
        CourseVideoDto CreateCourseVideo(CreateCourseVideoDto courseVideo);
        CourseVideoDto UpdateCourseVideo(UpdateCourseVideoDto courseVideo);
        bool DeleteCourseVideoById(long id);
        CourseVideoDto GetCourseVideoById(long id);
    }
}