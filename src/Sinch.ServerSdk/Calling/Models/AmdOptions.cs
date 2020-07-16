using Newtonsoft.Json;

namespace Sinch.ServerSdk.Calling.Models
{
    public class AmdOptions
    {
        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }
    }
}
