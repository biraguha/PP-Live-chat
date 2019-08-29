using Newtonsoft.Json;

namespace livechat.ViewModels
{
    public class UserFormVM
    {   
        [JsonProperty("username")]
        public string UserName { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}