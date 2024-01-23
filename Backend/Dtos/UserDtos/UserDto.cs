

namespace Backend.Dtos.UserDtos
{
    public class UserDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string About { get; set; }
        public string ProfileURL { get; set; }
    }
}