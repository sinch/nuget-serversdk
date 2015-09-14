using Newtonsoft.Json;

namespace Sinch.ServerSdk.Calling.Model
{
    public class KeyValueModel
    {
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}