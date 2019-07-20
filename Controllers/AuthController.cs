using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using livechat.Helpers;
using livechat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace livechat.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly AppSettings appSettings;

        private HashSet<UserVM> users = new HashSet<UserVM>()
        {
            new UserVM() { Id = 1, UserName = "admin", Password = "admin" },
            new UserVM() { Id = 2, UserName = "bob", Password = "bob" },
            new UserVM() { Id = 3, UserName = "ben", Password = "ben" },
            new UserVM() { Id = 4, UserName = "boris", Password = "boris" },
            new UserVM() { Id = 5, UserName = "alexis", Password = "alexis" }
        };

        public AuthController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        [HttpGet("user-connected")]
        public async Task<UserVM> GetAsync(int id)
        {
            await Task.Delay(0);
            return users.FirstOrDefault(u => u.Id == id);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<string> PostAsync(UserVM user)
        {
            await Task.Delay(0);
            UserVM connected = users.FirstOrDefault(u =>
                u.UserName == user.UserName &&
                u.Password == user.Password
            );

            return connected != null ? GenerateToken(connected) : String.Empty;
        }

        private string GenerateToken(UserVM user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                )
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}