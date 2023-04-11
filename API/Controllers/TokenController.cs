using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PostIT_API.DTOs;
using PostIT_API.EF;
using PostIT_API.Helpers;
using PostIT_Lib.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PostIT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        JwtSettings? _jwtSettings;
        PostITContext _dbContext;
        public TokenController(IConfiguration configuration, PostITContext dbContext)
        {
            _jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult PostLogin(LoginDTO userDTO)
        {
            var user = ValidateUser(userDTO.Username, userDTO.Password);
            if (user != null)
            {
                return Ok(GenerateToken(user));
            }
            return BadRequest();
        }

        private User ValidateUser(string username, string password)
        {
            var hasher = new PasswordHasher<User>();
            var user = _dbContext.User.Where(e=> e.Username == username).FirstOrDefault();
            if (hasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Success)
            {
                return user;
            }
            return null;
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Secret);

            var claims = new[]
            {
                new Claim("UserID", user.Id.ToString()),
                new Claim("Firstname", user.Firstname),
                new Claim("Lastname", user.Lastname),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpPost("Register")]
        public ActionResult Register(UserDTO userDTO)
        {
            var pHasher = new PasswordHasher<User>();

            var user = new User()
            {
                Email = userDTO.Email,
                Firstname = userDTO.Firstname,
                Lastname = userDTO.Lastname,
                Username = userDTO.Username,
                
            };

            user.PasswordHash = pHasher.HashPassword(user, userDTO.Password);

            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
