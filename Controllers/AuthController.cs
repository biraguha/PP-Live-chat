using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using livechat.Helpers;
using livechat.Services;
using livechat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace livechat.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly AppSettings appSettings;
        private readonly IUserService userService;

        public AuthController(
            IOptions<AppSettings> appSettings,
            IUserService userService)
        {
            this.appSettings = appSettings.Value;
            this.userService = userService;
        }

        [HttpGet("users")]
        public async Task<IEnumerable<UserVM>> GetAllAsync()
        {
            return await userService.GetUsers();
        }

        [HttpGet("user-connected")]
        public async Task<UserVM> GetAsync(string id)
        {
            return await userService.GetUser(id);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<Object> PostAsync(UserFormVM user)
        {
            var userExist = await userService.UserExist(user.UserName, user.Password);

            string token = userExist != null ? GenerateToken(userExist) : String.Empty;
            return new LoginResponseVM() 
            { 
                Success = (userExist != null),
                Token = token,
                UserId = userExist.Id,
                FullName = userExist.FullName
            };
        }

        private string GenerateToken(UserVM user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id),
                    new Claim(ClaimTypes.NameIdentifier, user.FullName)
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