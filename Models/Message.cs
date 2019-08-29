using System;
using Newtonsoft.Json;

namespace livechat.Models
{
    public class Message : BaseEntity
    {
        [JsonProperty("author")]
        public string AuthorId { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}