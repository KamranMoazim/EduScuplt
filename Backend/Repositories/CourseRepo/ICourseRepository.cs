
using Backend.Dtos.CourseDtos;
using Backend.Models;

namespace Backend.Repositories.CourseRepo
{
    public interface ICourseRepository
    {
        Course CreateCourse(CreateCourseInfoDto course);
        IEnumerable<Course> AllCourses();
        Course GetCourseById(int id);
    }
}