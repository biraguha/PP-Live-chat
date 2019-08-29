using System;
using Newtonsoft.Json;

namespace livechat.ViewModels
{
    public class MessageFormVM
    {
        [JsonProperty("conversation")]
        public int ConversationId { get; set; }

        [JsonProperty("author")]
        public int Author { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

    }
}