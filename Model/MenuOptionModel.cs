using Newtonsoft.Json;

namespace Sinch.Callback.Model
{
    public class MenuOptionModel
    {
        [JsonProperty(PropertyName = "dtmf", NullValueHandling = NullValueHandling.Ignore)]
        public string Digit { get; set; }

        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        [JsonProperty(PropertyName = "add", NullValueHandling = NullValueHandling.Ignore)]
        public KeyValueModel[] AddToContext { get; set; }
    }
}