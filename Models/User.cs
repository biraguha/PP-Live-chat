using Newtonsoft.Json;

namespace livechat.Models
{
    public class User : BaseEntity
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("fullname")]
        public string FullName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}