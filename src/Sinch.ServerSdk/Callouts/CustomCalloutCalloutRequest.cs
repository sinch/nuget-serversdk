using Newtonsoft.Json;

namespace Sinch.ServerSdk.Callouts
{
    public class CustomCalloutCalloutRequest : ICustomCalloutCalloutRequest
    {
        [JsonProperty(PropertyName = "ice", NullValueHandling = NullValueHandling.Ignore)]
        public string Ice { get; set; }

        [JsonProperty(PropertyName = "ace", NullValueHandling = NullValueHandling.Ignore)]
        public string Ace { get; set; }

        [JsonProperty(PropertyName = "dice", NullValueHandling = NullValueHandling.Ignore)]
        public string Dice { get; set; }

        [JsonProperty(PropertyName = "custom", NullValueHandling = NullValueHandling.Ignore)]
        public string Custom { get; set; }
    }
}