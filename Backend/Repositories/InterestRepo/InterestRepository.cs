

using AutoMapper;
using Backend.Dtos.InterestDtos;
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

        public Interests GetInterestById(long id)
        {
            return _context.Interests.FirstOrDefault(i => i.ID == id);
        }

        public Interests GetInterestByName(string name)
        {
            return _context.Interests.FirstOrDefault(i => i.Title == name);
        }

        public Interests CreateInterest(CreateInterestDto interest)
        {
            Interests newInterest = _mapper.Map<Interests>(interest);
            _context.Interests.Add(newInterest);
            _context.SaveChanges();
            return newInterest;
        }

        public Interests UpdateInterest(long interestId, UpdateInterestDto interest)
        {
            Interests interestToUpdate = _context.Interests.FirstOrDefault(i => i.ID == interestId);
            if (interestToUpdate == null)
            {
                return null;
            }
            _mapper.Map(interest, interestToUpdate);
            _context.SaveChanges();
            return interestToUpdate;
        }

        public void DeleteInterest(long interestId)
        {
            Interests interestToDelete = _context.Interests.FirstOrDefault(i => i.ID == interestId);
            if (interestToDelete == null)
            {
                return;
            }
            _context.Interests.Remove(interestToDelete);
            _context.SaveChanges();
        }


        public List<InterestDto> GetStudentsInterests(long studentId)
        {
            List<StudentInterests> studentInterests = _context.StudentInterests.Where(i => i.StudentId == studentId).ToList();
            List<Interests> interests = new List<Interests>();
            foreach (var studentInterest in studentInterests)
            {
                interests.Add(_context.Interests.FirstOrDefault(i => i.ID == studentInterest.InterestId));
            }

            List<InterestDto> interestDtos = _mapper.Map<List<InterestDto>>(interests);

            return interestDtos;
        }

        // updated student interests
        public List<InterestDto> UpdateStudentInterests(long studentId, List<InterestDto> interests)
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