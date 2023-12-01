
namespace Backend.Dtos
{
    public class LoginUserResponseDto
    {
        public string Token { get; set; }
        public ResponseUserDto User { get; set; }
    }
}