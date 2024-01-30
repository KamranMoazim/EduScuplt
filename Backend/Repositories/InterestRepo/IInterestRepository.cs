

using Backend.Dtos.InterestDtos;
using Backend.Models;

namespace Backend.Repositories.InterestRepo
{
    public interface IInterestRepository
    {
        Interests GetInterestById(long id);
        Interests GetInterestByName(string name);
        Interests CreateInterest(CreateInterestDto interest);
        Interests UpdateInterest(long interestId, UpdateInterestDto interest);
        void DeleteInterest(long interestId);
        List<InterestDto> GetStudentsInterests(long studentId);
        List<InterestDto> UpdateStudentInterests(long studentId, List<InterestDto> interests);
    }
}