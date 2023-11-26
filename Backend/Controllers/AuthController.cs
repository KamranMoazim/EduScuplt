using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.IRepositories;
using Backend.Models;
using Backend.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public IAuthRepository AuthRepository { get; set; }

        public AuthController(IAuthRepository authRepository)
        {
            AuthRepository = authRepository;
        }

        [HttpGet("/users")]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            return Ok(AuthRepository.GetAll());
        }


        [HttpPost("/register")]
        public ActionResult<UserDto> Register([FromBody] UserDto userDto)
        {
            UserDto user = AuthRepository.Register(userDto);

            return Ok(user);
        }
        

        [HttpPost("/login")]
        public ActionResult<string> Login( [FromBody] UserDto userDto)
        {
            UserDto user = AuthRepository.Login(userDto);

            if (user == null)
            {
                return BadRequest("Invalid credentials");
            }

            string token = AuthUtils.CreateToken(user);

            return Ok(token);
        }
    }
}