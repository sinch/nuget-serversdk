using Newtonsoft.Json;

namespace Sinch.ServerSdk.Calling.Models
{
    public class GetConferenceResponse
    {
        [JsonProperty(PropertyName = "participants")]
        public ParticipantResource[] Participants { get; set; }
    }
}