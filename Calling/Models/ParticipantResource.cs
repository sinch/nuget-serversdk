using Newtonsoft.Json;

namespace Sinch.ServerSdk.Calling.Models
{
    public class ParticipantResource
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "cli")]
        public string Cli { get; set; }

        [JsonProperty(PropertyName = "callId")]
        public string CallId { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "muted")]
        public bool Muted { get; set; }
    }
}