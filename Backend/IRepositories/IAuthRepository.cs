

using Backend.Models;
using Backend.Dtos;

namespace Backend.IRepositories
{
    public interface IAuthRepository
    {
        IEnumerable<User> GetAll();
        User Login(UserDto userDto);
        User Register(UserDto userDto);
    }
}