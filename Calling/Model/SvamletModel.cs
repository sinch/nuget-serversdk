using Newtonsoft.Json;

namespace Sinch.ServerSdk.Calling.Model
{
    public class Svamlet
    {
        [JsonProperty(PropertyName = "instructions", NullValueHandling = NullValueHandling.Ignore)]
        public SvamletInstructionModel[] InstructionsModel { get; set; }

        [JsonProperty(PropertyName = "action", NullValueHandling = NullValueHandling.Ignore)]
        public SvamletActionModel ActionModel { get; set; }
    }
}
