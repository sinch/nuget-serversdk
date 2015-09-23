using Newtonsoft.Json;

namespace Sinch.ServerSdk.Calling.Models
{
    public class ConferenceCommand
    {
        [JsonProperty(PropertyName = "command")]
        public string Command { get; set; }
    }
}