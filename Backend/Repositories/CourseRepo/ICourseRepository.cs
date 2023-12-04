
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
        Course GetCourseById(int id);
        IEnumerable<Course> GetAllCoursesOfInstructor(int instructorId);
        IEnumerable<Course> GetAllStudentsBoughtCourses(int studentId);
        IEnumerable<Course> GetAllCoursesForAdminApproval();
    }
}