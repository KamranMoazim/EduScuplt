

using AutoMapper;
using Backend.Models;

namespace Backend.Repositories.InstructorRepo
{
    public class InstructorRepository: IInstructorRepository
    {
        private readonly ProjectAppContext _context;
        private readonly IMapper _mapper;

        public InstructorRepository(ProjectAppContext _ctx, IMapper map)
        {
            _context = _ctx;
            _mapper = map;
        }

        public Instructor GetInstructorById(int id)
        {
            return _context.Instructors.FirstOrDefault(i => i.Id == id);
        }

        public Instructor GetInstructorByUserId(int userId)
        {
            return _context.Instructors.FirstOrDefault(i => i.UserId == userId);
        }

        public Instructor CreateInstructor(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
            return instructor;
        }

        public Instructor UpdateInstructor(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            _context.SaveChanges();
            return instructor;
        }

        public void DeleteInstructor(Instructor instructor)
        {
            _context.Instructors.Remove(instructor);
            _context.SaveChanges();
        }

        public List<Instructor> GetAllInstructors()
        {
            return _context.Instructors.ToList();
        }


    }
}