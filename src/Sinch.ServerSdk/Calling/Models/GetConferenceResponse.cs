using Newtonsoft.Json;

namespace Sinch.ServerSdk.Calling.Models
{
    public class GetConferenceResponse 
    {
        [JsonProperty(PropertyName = "participants")]
        public ParticipantModel[] Participants { get; set; }
    }
}