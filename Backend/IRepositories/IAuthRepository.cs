

using Backend.Models;
using Backend.Dtos.UserDtos;

namespace Backend.IRepositories
{
    public interface IAuthRepository
    {
        IEnumerable<User> GetAll();
        User GetUser(int userId);
        User Login(LoginUserDto userDto);
        User Register(CreateUserDto userDto);
    }
}