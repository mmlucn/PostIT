using PostIT_API.EF;
using MauiLib.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;

namespace PostIT_API.Helpers
{
    public class UserHandler
    {
        public PostITContext _context { get; set; }
        public UserHandler(PostITContext context) 
        {
            _context = context;
        }
        public User GetUser(HttpContext httpContext)
        {
            if (httpContext != null)
            {
                var token = httpContext.Request.Headers.Authorization.First().Split(' ')[1];
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);
                var userid = jwtToken.Claims.First(e => e.Type == "UserID").Value;
                var user = _context.User.First(e => e.Id.ToString() == userid);
                
                return user;
            }

            return null;
        }
    }
}
