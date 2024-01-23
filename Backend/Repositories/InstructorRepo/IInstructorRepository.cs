

using Backend.Models;

namespace Backend.Repositories.InstructorRepo
{
    public interface IInstructorRepository
    {
        Instructor GetInstructorById(long id);

        Instructor GetInstructorByUserId(long userId);

        Instructor CreateInstructor(Instructor instructor);

        Instructor UpdateInstructor(Instructor instructor);

        void DeleteInstructor(Instructor instructor);

        List<Instructor> GetAllInstructors();


    }
}