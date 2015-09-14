using Newtonsoft.Json;

namespace Sinch.ServerSdk.Calling.Model
{
    public class IdentityModel
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "endpoint")]
        public string Endpoint { get; set; }
    }
}