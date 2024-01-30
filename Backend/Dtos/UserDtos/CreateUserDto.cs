

using System.ComponentModel.DataAnnotations;
using Backend.Models;

namespace Backend.Dtos.UserDtos
{
    public class CreateUserDto
    {

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be at most 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be at most 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }


        // [Required(ErrorMessage = "UserType is required.")]
        // public string UserType { get; set; }
        [Required(ErrorMessage = "UserType is required.")]
        [EnumDataType(typeof(ProjectEnums.UserType), ErrorMessage = "Invalid UserType value., It can be only Instructor, Student, Admin")]
        public string UserType { get; set; }
    }
}