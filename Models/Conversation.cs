using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace livechat.Models
{
    public class Conversation : BaseEntity
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("update_at")]
        public DateTime UpdateAt { get; set; }

        // Remove Hashset
        [JsonProperty("authors")]
        public HashSet<string> Authors { get; set; }

        [JsonProperty("messages")]
        public IEnumerable<Message> Messages { get; set; }
    }
}