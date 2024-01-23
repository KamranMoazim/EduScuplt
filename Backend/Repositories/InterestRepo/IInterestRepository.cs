

using Backend.Models;

namespace Backend.Repositories.InterestRepo
{
    public interface IInterestRepository
    {
        Interests GetInterestById(long id);
        Interests GetInterestByName(string name);
        Interests CreateInterest(Interests interest);
        Interests UpdateInterest(Interests interest);
        void DeleteInterest(Interests interest);
        List<Interests> GetStudentsInterests(long studentId);
        List<Interests> UpdateStudentInterests(long studentId, List<Interests> interests);
    }
}