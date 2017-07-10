using System.Threading.Tasks;

namespace Sinch.ServerSdk.Callouts
{
    public class CalloutRequest : ICalloutRequest
    {
        private readonly ICalloutApiEndpoints _calloutApiEndpoints;

        internal CalloutRequest(ICalloutApiEndpoints calloutApiEndpoints)
        {
            _calloutApiEndpoints = calloutApiEndpoints;
        }
        public string method { get; set; }
        public IConferenceCalloutRequest conferenceCallout { get; set; }
        public ITTSCalloutRequest ttsCallout { get; set; }

        public async Task<CalloutResponse> Call()
        {
            return await _calloutApiEndpoints.Callout(this);
        }

    }
}