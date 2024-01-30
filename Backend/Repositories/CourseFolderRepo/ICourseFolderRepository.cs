
using Backend.Dtos.CourseDtos;
using Backend.Dtos.CourseFoldersDtos;

namespace Backend.Repositories.CourseFolderRepo
{
    public interface ICourseFolderRepository
    {
        CourseFoldersDto AddVideoToCourseFolder(long courseFolderId, long courseVideoId);
        CourseFoldersDto RemoveVideoFromCourseFolder(long courseFolderId, long courseVideoId);
        CourseFoldersDto CreateCourseFolder(long courseId, CreateCourseFoldersDto courseFolder);
        CourseFoldersDto UpdateCourseFolder(UpdateCourseFolderNameDto courseFolder);
        bool DeleteCourseFolderById(long id);
        IEnumerable<CourseFoldersDto> GetAllCourseFoldersOfCourse(long courseId);
        CourseFoldersDto GetCourseFolderByIdAlongWithCourseVideos(long id);
    }
}