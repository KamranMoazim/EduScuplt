using System.ComponentModel.DataAnnotations;
using Backend.Models;


namespace Backend.Dtos
{
    public class UserDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required]
        public string UserType { get; set; }
        // public ProjectEnums.UserType UserType { get; set; }
    }
}