using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace livechat.ViewModels
{
    public class ConversationVM
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        // [JsonProperty("author")]
        // public string Author { get; set; }

        [JsonProperty("recipient")]
        public string Recipient { get; set; }

        [JsonProperty("authors")]
        public IEnumerable<UserVM> Authors { get; set; }

        [JsonProperty("messages")]
        public IEnumerable<MessageVM> Messages { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("update_at")]
        public DateTime UpdateAt { get; set; }

    }
}