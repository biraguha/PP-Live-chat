
using Newtonsoft.Json;

namespace livechat.ViewModels
{
    public class LoginResponseVM
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("userid")]
        public string UserId { get; set; }

        [JsonProperty("fullname")]
        public string FullName { get; set; }
    }
}