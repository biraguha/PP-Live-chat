using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using livechat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace livechat.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private HashSet<UserVM> users = new HashSet<UserVM>()
        {
            new UserVM() { Id = 1, UserName = "Admin", Password = "admin" },
            new UserVM() { Id = 2, UserName = "Bob", Password = "bob" },
            new UserVM() { Id = 3, UserName = "Ben", Password = "ben" },
            new UserVM() { Id = 4, UserName = "Boris", Password = "boris" },
            new UserVM() { Id = 5, UserName = "Alexis", Password = "alexis" }
        };

        public AuthController() { }

        [HttpPost("login")]
        public async Task<string> PostAsync(UserVM user)
        {
            await Task.Delay(0);
            UserVM connected = users.FirstOrDefault(u =>
                u.UserName.ToLower() == user.UserName.ToLower() &&
                u.Password.ToLower() == user.Password.ToLower()
            );

            return connected != null ? GenerateToken(connected) : String.Empty;
        }

        private string GenerateToken(UserVM user)
        {
            string content = JsonConvert.SerializeObject(user);
            byte[] toEncode = ASCIIEncoding.ASCII.GetBytes(content);
            return Convert.ToBase64String(toEncode);
        }

        private UserVM DecodeToken(string token)
        {
            byte[] content = Convert.FromBase64String(token);
            string toDecode = ASCIIEncoding.ASCII.GetString(content);
            return JsonConvert.DeserializeObject<UserVM>(toDecode);
        }

    }
}