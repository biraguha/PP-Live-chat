using System;
using Newtonsoft.Json;

namespace livechat.ViewModels
{
    public class UserVM
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("username")]
        public string UserName { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }

    }
}