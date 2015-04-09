using Newtonsoft.Json;

namespace Sinch.Callback.Model
{
    public class Svamlet
    {
        [JsonProperty(PropertyName = "instructions", NullValueHandling = NullValueHandling.Ignore)]
        public SvamletInstruction[] Instructions { get; set; }
        [JsonProperty(PropertyName = "action", NullValueHandling = NullValueHandling.Ignore)]
        public SvamletAction Action { get; set; }
    }
}
