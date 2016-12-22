using Newtonsoft.Json;

namespace Sinch.ServerSdk.Models
{
    public class KeyValueModel
    {
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}