using Newtonsoft.Json;

namespace Sinch.ServerSdk.Models
{
    public class Identity
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "endpoint")]
        public string Endpoint { get; set; }
        
        [JsonProperty(PropertyName = "verified")]
        public bool? Verified { get; set; }
    }
}