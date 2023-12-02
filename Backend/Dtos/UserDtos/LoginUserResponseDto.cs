
namespace Backend.Dtos.UserDtos
{
    public class LoginUserResponseDto
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}