using Newtonsoft.Json;

namespace livechat.Models
{
    public class BaseEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}