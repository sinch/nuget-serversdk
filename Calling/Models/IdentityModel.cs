using Newtonsoft.Json;

namespace Sinch.ServerSdk.Calling.Models
{
    public class IdentityModel
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty(PropertyName = "verified")]
        public bool? Verified { get; set; }
    }
}