using Newtonsoft.Json;

namespace Sinch.ServerSdk.Calling.Models
{
    public class SvamletModel
    {
        [JsonProperty(PropertyName = "instructions", NullValueHandling = NullValueHandling.Ignore)]
        public SvamletInstructionModel[] Instructions { get; set; }

        [JsonProperty(PropertyName = "action", NullValueHandling = NullValueHandling.Ignore)]
        public SvamletActionModel Action { get; set; }
    }
}
