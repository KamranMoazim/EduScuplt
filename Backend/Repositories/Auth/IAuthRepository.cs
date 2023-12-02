

using Backend.Models;
using Backend.Dtos.UserDtos;

namespace Backend.Repositories.Auth
{
    public interface IAuthRepository
    {
        IEnumerable<User> GetAll();
        User GetUser(int userId);
        User GetUserByEmail(string email);
        User Login(LoginUserDto userDto);
        User Register(CreateUserDto userDto);
    }
}