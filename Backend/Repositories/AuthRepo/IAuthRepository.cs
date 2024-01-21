

using Backend.Models;
using Backend.Dtos.UserDtos;
using Backend.Interfaces;

namespace Backend.Repositories.AuthRepo
{
    public interface IAuthRepository : IRepository<User>
    {
        // IEnumerable<User> GetAll();
        // User GetUser(int userId);
        User GetUserByEmail(string email);
        User Login(LoginUserDto userDto);
        User Register(CreateUserDto userDto);
    }
}