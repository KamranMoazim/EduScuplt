

using Backend.Dtos.CourseVideoDtos;

namespace Backend.Repositories.CourseVideoRepo
{
    public interface ICourseVideoRepository
    {
        CourseVideoDto CreateCourseVideo(CreateCourseVideoDto courseVideo);
        CourseVideoDto UpdateCourseVideo(UpdateCourseVideoDto courseVideo);
        bool DeleteCourseVideoById(long id);
        CourseVideoDto GetCourseVideoById(long id);
    }
}