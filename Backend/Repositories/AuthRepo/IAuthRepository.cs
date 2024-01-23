

using Backend.Models;
using Backend.Dtos.UserDtos;
using Backend.Interfaces;

namespace Backend.Repositories.AuthRepo
{
    public interface IAuthRepository 
    // : IRepository<User>
    {
        // IEnumerable<User> GetAll();
        IEnumerable<User> Get();
        // User GetUser(int userId);
        User Get(long userId);
        bool ResetUserPassword(string email);
        User GetUserByEmail(string email);
        User Login(LoginUserDto userDto);
        User Register(CreateUserDto userDto);
    }
}