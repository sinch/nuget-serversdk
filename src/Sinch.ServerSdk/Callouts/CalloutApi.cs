using System;
using System.Collections.Generic;
using System.Text;
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Callouts
{
    public class CalloutApi : ICalloutApi
    {

        private readonly ICalloutApiEndpoints _calloutApiEndpoints;
        private CalloutRequest _request;

        internal CalloutApi(ICalloutApiEndpoints calloutApiEndpoints)
        {
            _calloutApiEndpoints= calloutApiEndpoints;
            _request = new CalloutRequest(calloutApiEndpoints);
        }


        public ICalloutRequest TTSCallout(string to, string message, string from)
        {
            var request = _request;
            request.method = "ttsCallout";
            request.ttsCallout = new TTSCalloutRequest();
            request.ttsCallout.cli = from;
            request.ttsCallout.destination = new IdentityModel()
            {
                Endpoint = to,
                Type = "number"
            };
            request.ttsCallout.prompts ="#tts[" + message + "]";
            return request;

        }

        public ICalloutRequest ConferenceCallout(string to, string conferenceId, string from, string greeting)
        {
            var request = _request;
            request.method = "conferenceCallout";
            request.conferenceCallout = new ConferenceCalloutRequest();
            request.conferenceCallout.conferenceId = conferenceId;
            request.conferenceCallout.cli = from;
            request.conferenceCallout.destination = new IdentityModel()
            {
                Type = "number",
                Endpoint = to
            };
            request.conferenceCallout.greeting = greeting;
            return request;
        }
        
    }
}
