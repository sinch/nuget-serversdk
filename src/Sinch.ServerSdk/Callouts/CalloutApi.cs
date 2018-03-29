using System;
using Sinch.ServerSdk.IvrMenus;
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Callouts
{
    public class CalloutApi : ICalloutApi
    {
        private readonly CallbackResponseFactory _responseFactory;
        private readonly CalloutRequest _request;

        internal CalloutApi(ICalloutApiEndpoints calloutApiEndpoints, CallbackResponseFactory responseFactory)
        {
            _responseFactory = responseFactory;
            _request = new CalloutRequest(calloutApiEndpoints);
        }

        public ICalloutRequest TtsCallout(string to, string message, string from)
        {
            var request = _request;
            request.Method = "ttsCallout";

            request.TtsCallout = new TtsCalloutRequest
            {
                Cli = @from,
                Destination = new IdentityModel()
                {
                    Endpoint = to,
                    Type = "number"
                },
                Prompts = "#tts[" + message + "]"
            };

            return request;
        }

        public ICalloutRequest ConferenceCallout(string to, string conferenceId, string from, string greeting)
        {
            var request = _request;
            request.Method = "conferenceCallout";

            request.ConferenceCallout = new ConferenceCalloutRequest
            {
                ConferenceId = conferenceId,
                Cli = @from,
                Destination = new IdentityModel()
                {
                    Type = "number",
                    Endpoint = to
                },
                Greeting = greeting
            };

            return request;
        }

        public ICalloutRequest MenuCallout(string to, string @from, IMenuBuilder menu, string startMenu, TimeSpan maxDuration)
        {
            var request = _request;
            request.Method = "customCallout";

            request.CustomCallout = new CustomCalloutCalloutRequest
            {
                Ice = _responseFactory.CreateIceSvamletBuilder().ConnectPstn(to).WithCli(@from).WithBridgeTimeout(maxDuration).Body,
                Ace = _responseFactory.CreateAceSvamletBuilder().RunMenu(startMenu, menu).Body,
                Dice = _responseFactory.CreateDiceResponse().Body
            };

            return request;
        }

        public IMenuBuilder CreateMenuBuilder()
        {
            return new MenuBuilder();
        }

    }
}
