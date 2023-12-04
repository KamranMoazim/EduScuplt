

using Backend.Dtos.CourseVideoDtos;

namespace Backend.Repositories.CourseVideoRepo
{
    public interface ICourseVideoRepository
    {
        CourseVideoDto CreateCourseVideo(CreateCourseVideoDto courseVideo);
        CourseVideoDto UpdateCourseVideo(UpdateCourseVideoDto courseVideo);
        bool DeleteCourseVideoById(int id);
        CourseVideoDto GetCourseVideoById(int id);
    }
}