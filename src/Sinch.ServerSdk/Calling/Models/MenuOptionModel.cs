using Newtonsoft.Json;
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Calling.Models
{
    public class MenuOptionModel
    {
        [JsonProperty(PropertyName = "dtmf", NullValueHandling = NullValueHandling.Ignore)]
        public string Digit { get; set; }

        [JsonProperty(PropertyName = "input", NullValueHandling = NullValueHandling.Ignore)]
        public string Input { get; set; }

        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        [JsonProperty(PropertyName = "add", NullValueHandling = NullValueHandling.Ignore)]
        public KeyValueModel[] AddToContext { get; set; }
    }
}