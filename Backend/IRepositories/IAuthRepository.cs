

using Backend.Models;
using Backend.Dtos;

namespace Backend.IRepositories
{
    public interface IAuthRepository
    {
        IEnumerable<UserDto> GetAll();
        UserDto Login(UserDto userDto);
        UserDto Register(UserDto userDto);
    }
}