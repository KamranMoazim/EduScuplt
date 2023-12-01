
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Backend.Auth
{
    public class RoleAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _role;

        public RoleAttribute(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            foreach (var claim in user.Claims)
            {
                Console.WriteLine($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
            }

            // Check if the user is authenticated
            // Console.WriteLine("User is authenticated: " + user.Identity.IsAuthenticated);
            // Console.WriteLine("User Role: " + user.Identity.Name);
            Console.WriteLine("User: " + user);

            // Console.WriteLine("User IsAuthenticated: " + context.HttpContext.Items["IsAuthenticated"]);
            // Console.WriteLine("User Email: " + context.HttpContext.Items["Email"]);
            // Console.WriteLine("User Role: " + context.HttpContext.Items["Role"]);
            // Console.WriteLine("Accessd Role: " + _role);
            // Console.WriteLine("User : " + user);
            // Console.WriteLine("User From Middleware : " + context.HttpContext.Items["User"]);


            // if (!user.Identity.IsAuthenticated)
            // // if (context.HttpContext.Items.ContainsKey("Role"))
            // {
            //     context.Result = new UnauthorizedResult();
            //     return;
            // }

            // Check if the user has the required role
            // if (!user.IsInRole(_role))
            // if (!claim.Value == (_role))
            if (context.HttpContext.Items["Role"] != _role)
            {
                context.Result = new ForbidResult();
                return;
            }

            Console.WriteLine($"User has the required role: {_role}");
        }
    }
}