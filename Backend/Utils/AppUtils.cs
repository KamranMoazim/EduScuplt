
using System.Text.RegularExpressions;
using Backend.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Backend.Utils
{
    public static class AppUtils
    {
        public static bool IsStrongPassword(string password)
        {
            // Define the Regex pattern for a strong password
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+])[A-Za-z\d!@#$%^&*()_+]{8,}$";

            // Use Regex.IsMatch to check if the password matches the pattern
            return Regex.IsMatch(password, pattern);
        }

    }
}