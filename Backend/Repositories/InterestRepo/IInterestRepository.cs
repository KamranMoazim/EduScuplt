

using Backend.Models;

namespace Backend.Repositories.InterestRepo
{
    public interface IInterestRepository
    {
        Interests GetInterestById(int id);
        Interests GetInterestByName(string name);
        Interests CreateInterest(Interests interest);
        Interests UpdateInterest(Interests interest);
        void DeleteInterest(Interests interest);
        List<Interests> GetStudentsInterests(int studentId);
        List<Interests> UpdateStudentInterests(int studentId, List<Interests> interests);
    }
}