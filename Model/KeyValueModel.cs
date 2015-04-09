using Newtonsoft.Json;

namespace Sinch.Callback.Model
{
    public class KeyValueModel
    {
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}