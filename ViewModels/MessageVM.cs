using System;
using Newtonsoft.Json;

namespace livechat.ViewModels
{
    public class MessageVM
    {
        // public string Type { get; set; }
        // public string Payload { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("author")]
        public int Author { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        // [JsonProperty("update_at")]
        // public DateTime UpdateAt { get; set; }
    }
}