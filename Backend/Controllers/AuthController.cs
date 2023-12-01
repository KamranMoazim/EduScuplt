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
        public ActionResult<UserDto> Register([FromBody] UserDto userDto)
        {
            User user = AuthRepository.Register(userDto);

            return Ok(user);
        }
        

        [HttpPost("/login")]
        [AllowAnonymous]
        public ActionResult<string> Login( [FromBody] UserDto userDto)
        {
            User user = AuthRepository.Login(userDto);

            if (user == null)
            {
                return BadRequest("Invalid credentials");
            }

            string token = new AuthUtils(userManager, roleManager, _configuration).CreateToken(user);

            return Ok(new
            {
                token,
                user
            });
        }

        [HttpGet("/student")]
        // [Role("Student")]
        [Authorize(Roles = "Student")]
        // [Authorize(Policy = "StudentPolicy")]
        public ActionResult<string> StudentAccess()
        {
            // return Ok("Hi Student");
            // Console.WriteLine("User.Identity.IsAuthenticated: " + User.Identity.IsAuthenticated);
            // Console.WriteLine("User.IsInRole(\"Student\"): " + User.IsInRole("Student"));
            // if (User.Identity.IsAuthenticated && User.IsInRole("Student"))
            // {
            //     return Ok("Hi Student");
            // }
            // else
            // {
            //     // If the user is not authenticated or does not have the required role, return an unauthorized result
            //     return Unauthorized("Unauthorized access");
            // }
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
            if (User.Identity.IsAuthenticated && User.IsInRole("Instructor"))
            {
                return Ok("Hi Instructor");
            }
            else
            {
                // If the user is not authenticated or does not have the required role, return an unauthorized result
                return Unauthorized("Unauthorized access");
            }
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