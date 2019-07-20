using System;
using Newtonsoft.Json;

namespace livechat.ViewModels
{
    public class MessageFormVM
    {
        [JsonProperty("conversation")]
        public int Conversation { get; set; }

        [JsonProperty("author")]
        public int Author { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

    }
}