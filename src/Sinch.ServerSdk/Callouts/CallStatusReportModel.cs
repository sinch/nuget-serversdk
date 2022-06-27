using Newtonsoft.Json;

namespace Sinch.ServerSdk.Callouts
{
    public class CallStatusReportModel
    {
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "details", NullValueHandling = NullValueHandling.Ignore)]
        public string Details { get; set; }
    }
}
