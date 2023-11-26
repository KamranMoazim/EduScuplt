using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Models;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Utils
{
    public static class AuthUtils
    {
        public static string CreateToken(UserDto user)
        {
            List<Claim> claims = new List<Claim>
            {
                // new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                // new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Email, user.Email),
                // new Claim(ClaimTypes.Role, user.UserType.ToString())
            };

            string token = GenerateToken(claims);

            return token;
        }

        private static string GenerateToken(List<Claim> claims)
        {
            // Create a symmetric security key using a secret key
            // var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("My Name is Kamran Moazim and ..."));

            // Create signing credentials using the key and HmacSha512Signature algorithm
            // var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var keyBytes = new byte[64]; // 512 bits / 8 bits per byte = 64 bytes
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(keyBytes);
            }

            var key = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);


            // Create a JWT with the specified claims, expiration time, and signing credentials
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            // Write the token as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}