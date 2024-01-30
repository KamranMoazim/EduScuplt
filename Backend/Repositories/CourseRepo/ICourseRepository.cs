
using Backend.Dtos.CourseDtos;
using Backend.Models;

namespace Backend.Repositories.CourseRepo
{
    public interface ICourseRepository
    {
        Course CreateCourse(CreateCourseInfoDto course);
        Course UpdateCourse(Course course);
        IEnumerable<CourseInfoDto> AllCourses();
        Course GetCourseById(long id);
        IEnumerable<CourseInfoDto> GetCoursesOfMyInterests(long userId);

        bool RateCourse(long courseId, long studentId, int rating);
        IEnumerable<CourseInfoDto> GetAllCoursesOfInstructor(long instructorId);
        IEnumerable<CourseInfoDto> GetAllStudentsBoughtCourses(long studentId);
        IEnumerable<CourseInfoDto> GetAllCoursesForAdminApproval();

        IEnumerable<CourseInfoDto> GetCoursesByTagName(string tagName);
        bool AddTagsToCourse(long courseId, List<long> tagdIds);
        bool UpdateCourseTags(long courseId, List<long> tagdIds);
        bool RemoveCourseTag(long courseId, long tagdIds);

        // StudentCourse
        StudentCourses BuyCourse(long studentId, long courseId);
    }
}