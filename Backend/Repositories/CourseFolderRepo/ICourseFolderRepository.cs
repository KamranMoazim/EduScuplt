
using Backend.Dtos.CourseDtos;
using Backend.Dtos.CourseFoldersDtos;

namespace Backend.Repositories.CourseFolderRepo
{
    public interface ICourseFolderRepository
    {
        CourseFoldersDto AddVideoToCourseFolder(int courseFolderId, int courseVideoId);
        CourseFoldersDto RemoveVideoFromCourseFolder(int courseFolderId, int courseVideoId);
        CourseFoldersDto CreateCourseFolder(int courseId, CreateCourseFoldersDto courseFolder);
        CourseFoldersDto UpdateCourseFolder(UpdateCourseInfoDto courseFolder);
        bool DeleteCourseFolderById(int id);
        IEnumerable<CourseFoldersDto> GetAllCourseFoldersOfCourse(int courseId);
    }
}