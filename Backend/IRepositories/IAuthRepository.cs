

using Backend.Models;
using Backend.Dtos;

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