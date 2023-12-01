using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.IRepositories;
using Backend.Models;
using Backend.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Backend.Utils;
using Backend.Exceptions;
using System.Security.Claims;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        public IAuthRepository AuthRepository { get; set; }

        public AuthController(IAuthRepository authRepository)
        {
            AuthRepository = authRepository;
        }

        [HttpGet("/users")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            return Ok(AuthRepository.GetAll());
        }


        [HttpPost("/register")]
        [AllowAnonymous]
        public ActionResult<CreateResponseDto> Register([FromBody] CreateUserDto userDto)
        {

            User user = AuthRepository.Register(userDto);

            CreateResponseDto createResponseDto = new CreateResponseDto
            {
                Status = "Success",
                Message = "User created successfully"
            };

            return Ok(createResponseDto);
        }
        

        [HttpPost("/login")]
        [AllowAnonymous]
        public ActionResult<LoginUserResponseDto> Login( [FromBody] LoginUserDto userDto)
        {
            User user = AuthRepository.Login(userDto);

            // string token = new AuthUtils(userManager, roleManager, _configuration).CreateToken(user);
            string token = AuthUtils.CreateToken(user);

            LoginUserResponseDto loginUserResponseDto = new LoginUserResponseDto
            {
                Token = token,
                User = new ResponseUserDto
                {
                    Id = user.ID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                }
            };

            return Ok(loginUserResponseDto);
        }


        [HttpGet("/me")]
        [Authorize]
        public ActionResult<ResponseUserDto> GetMe()
        {
            try
            {
                // Retrieve user information from the JWT token
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                
                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                {
                    // Fetch the user from your repository or database based on the user ID
                    var user = AuthRepository.GetUser(userId);

                    // Create the response DTO
                    var responseUserDto = new ResponseUserDto
                    {
                        Id = user.ID,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email
                    };

                    return Ok(responseUserDto);
                }
                else
                {
                    // If the user ID is not present or invalid, return an unauthorized result
                    return Unauthorized("Invalid user ID");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                Console.WriteLine($"An error occurred while fetching user details: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpGet("/student")]
        // [Role("Student")]
        [Authorize(Roles = "Student")]
        // [Authorize(Policy = "StudentPolicy")]
        public ActionResult<string> StudentAccess()
        {
            return Ok("Hi Student");
        }

        [HttpGet("/test")]
        [Authorize(Roles = "Student")]
        public IActionResult Test()
        {

            return Ok("Test");
        }

        [HttpGet("/instructor")]
        // [Role("Instructor")]
        [Authorize(Roles = "Instructor")]
        public ActionResult<string> InstructorAccess()
        {
            return Ok("Hi Instructor");
        }


        [HttpGet("/public")]
        // [Role("Public")]
        [AllowAnonymous]
        public ActionResult<string> PublicAccess()
        {
            return Ok("Hi Public");
        }
    }
}