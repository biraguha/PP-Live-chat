using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace livechat.ViewModels
{
    public class ConversationVM
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("recipient")]
        public string Recipient { get; set; }

        // [JsonProperty("users")]
        // public IEnumerable<MessageVM> Users { get; set; }

        [JsonProperty("messages")]
        public List<MessageVM> Messages { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("update_at")]
        public DateTime UpdateAt { get; set; }

    }
}