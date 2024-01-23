
using Backend.Dtos.CourseDtos;
using Backend.Models;

namespace Backend.Repositories.CourseRepo
{
    public interface ICourseRepository
    {
        Course CreateCourse(CreateCourseInfoDto course);
        Course UpdateCourse(Course course);
        IEnumerable<Course> AllCourses();
        IEnumerable<CourseInfoDto> GetCoursesByTagName(string tagName);
        Course GetCourseById(long id);
        bool RateCourse(long courseId, long studentId, int rating);
        IEnumerable<Course> GetAllCoursesOfInstructor(long instructorId);
        IEnumerable<Course> GetAllStudentsBoughtCourses(long studentId);
        IEnumerable<Course> GetAllCoursesForAdminApproval();

        // StudentCourse
        StudentCourses BuyCourse(long studentId, long courseId);
    }
}