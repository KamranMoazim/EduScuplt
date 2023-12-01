using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Auth
{
    public static class AuthUtils
    {

        // private readonly UserManager<User> userManager;
        // private readonly RoleManager<IdentityRole> roleManager;
        // private readonly IConfiguration _configuration;

        // public AuthUtils(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        // {
        //     this.userManager = userManager;
        //     this.roleManager = roleManager;
        //     _configuration = configuration;
        // }



        public static string CreateToken(User user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                // new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // new Claim(ClaimTypes.Role, user.UserType.ToString())
                new Claim(ClaimTypes.Role, user.UserType)
            };

            Console.WriteLine("UserType: " + user.UserType.ToString());

            // var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM"));

            // var tokenDescriptor = new JwtSecurityToken(
            //     // issuer: _configuration["JWT:ValidIssuer"],
            //     // audience: _configuration["JWT:ValidAudience"],
            //     issuer: "http://localhost:61955",
            //     audience: "http://localhost:4200",
            //     expires: DateTime.Now.AddDays(3),
            //     claims: authClaims,
            //     signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            // );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(authClaims),
                IssuedAt = DateTime.UtcNow,
                Issuer = "http://localhost:61955",
                Audience = "http://localhost:4200",
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature),
            };
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // var token = new System.IdentityModel.Tokens.JwtSecurityToken(jwt);

            return tokenHandler.WriteToken(token);
        }


    }
}