

namespace Backend.Dtos.StudentCourseDtos
{
    public class UpdateStudentCourseProgressDto
    {
        public int ID { get; set; }
        public double CourseCompleteProgressPercentage { get; set; } = 0.0;

    }
}