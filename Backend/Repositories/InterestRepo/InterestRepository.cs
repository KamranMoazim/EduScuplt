

using AutoMapper;
using Backend.Models;

namespace Backend.Repositories.InterestRepo
{
    public class InterestRepository : IInterestRepository
    {
        private readonly ProjectAppContext _context;
        private readonly IMapper _mapper;

        public InterestRepository(ProjectAppContext _ctx, IMapper map)
        {
            _context = _ctx;
            _mapper = map;
        }

        public Interests GetInterestById(int id)
        {
            return _context.Interests.FirstOrDefault(i => i.ID == id);
        }

        public Interests GetInterestByName(string name)
        {
            return _context.Interests.FirstOrDefault(i => i.Title == name);
        }

        public Interests CreateInterest(Interests interest)
        {
            _context.Interests.Add(interest);
            _context.SaveChanges();
            return interest;
        }

        public Interests UpdateInterest(Interests interest)
        {
            _context.Interests.Update(interest);
            _context.SaveChanges();
            return interest;
        }

        public void DeleteInterest(Interests interest)
        {
            _context.Interests.Remove(interest);
            _context.SaveChanges();
        }


        public List<Interests> GetStudentsInterests(int studentId)
        {
            List<StudentInterests> studentInterests = _context.StudentInterests.Where(i => i.StudentId == studentId).ToList();
            List<Interests> interests = new List<Interests>();
            foreach (var studentInterest in studentInterests)
            {
                interests.Add(_context.Interests.FirstOrDefault(i => i.ID == studentInterest.InterestId));
            }
            return interests;
        }

        // updated student interests
        public List<Interests> UpdateStudentInterests(int studentId, List<Interests> interests)
        {
            List<StudentInterests> studentInterests = _context.StudentInterests.Where(i => i.StudentId == studentId).ToList();
            foreach (var studentInterest in studentInterests)
            {
                _context.StudentInterests.Remove(studentInterest);
            }
            _context.SaveChanges();
            foreach (var interest in interests)
            {
                _context.StudentInterests.Add(new StudentInterests()
                {
                    StudentId = studentId,
                    InterestId = interest.ID
                });
            }
            _context.SaveChanges();
            return interests;
        }
    }
}