using System;
using Newtonsoft.Json;

namespace livechat.ViewModels
{
    public class UserVM
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("fullname")]
        public string FullName { get; set; }

    }
}