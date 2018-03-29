using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sinch.ServerSdk.Callouts
{
    public class CalloutRequest : ICalloutRequest
    {
        private readonly ICalloutApiEndpoints _calloutApiEndpoints;

        internal CalloutRequest(ICalloutApiEndpoints calloutApiEndpoints)
        {
            _calloutApiEndpoints = calloutApiEndpoints;
        }

        [JsonProperty(PropertyName = "method", NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; }

        [JsonProperty(PropertyName = "conferenceCallout", NullValueHandling = NullValueHandling.Ignore)]
        public IConferenceCalloutRequest ConferenceCallout { get; set; }

        [JsonProperty(PropertyName = "ttsCallout", NullValueHandling = NullValueHandling.Ignore)]
        public ITtsCalloutRequest TtsCallout { get; set; }

        [JsonProperty(PropertyName = "customCallout", NullValueHandling = NullValueHandling.Ignore)]
        public ICustomCalloutCalloutRequest CustomCallout { get; set; }

        public async Task<CalloutResponse> Call()
        {
            return await _calloutApiEndpoints.Callout(this);
        }
    }
}