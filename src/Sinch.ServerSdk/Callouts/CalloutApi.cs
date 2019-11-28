using System;
using Sinch.ServerSdk.Calling.Callbacks.Response;
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

        public ICalloutRequest TtsCallout(string to, string message, string from, string dtmf)
        {
            var request = _request;
            request.Method = "ttsCallout";

            request.TtsCallout = new TtsCalloutRequest
            {
                Dtmf = dtmf,
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
        public ICalloutRequest TtsCallout(string to, string message, string from)
        {
            return TtsCallout(to, message, from, "");
        }

     

        public ICalloutRequest ConferenceCallout(string to, string conferenceId, string from, string greeting, string dtmf)
        {
            var request = _request;
            request.Method = "conferenceCallout";

            request.ConferenceCallout = new ConferenceCalloutRequest
            {
                Dtmf = dtmf,
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

      

        public ICalloutRequest ConferenceCallout(string to, string conferenceId, string from, string greeting)
        {
            return ConferenceCallout(to, conferenceId, from, greeting, "");
        }
        public ICalloutRequest MenuCallout(string to, string from, IMenuBuilder menu, string startMenu, TimeSpan? maxDuration)
        {
            return MenuCallout(to, from, menu, startMenu, maxDuration, "");
        }
        public ICalloutRequest MenuCallout(string to, string @from, IMenuBuilder menu, string startMenu, TimeSpan? maxDuration = null, string dtmf="")
        {
            TimeSpan waittime = (maxDuration == null ? TimeSpan.FromSeconds(10) : (TimeSpan)maxDuration);

            var request = _request;
            request.Method = "customCallout";
            
            request.CustomCallout = new CustomCalloutCalloutRequest
            {
                Ice = _responseFactory.CreateIceSvamletBuilder().ConnectPstn(to).WithDTMF(dtmf).WithCli(@from).WithBridgeTimeout(waittime).Body,
                Ace = _responseFactory.CreateAceSvamletBuilder().RunMenu(startMenu, menu).Body,
                Dice = _responseFactory.CreateDiceResponse().Body
            };

            return request;
        }

        public IMenuBuilder CreateMenuBuilder()
        {
            return new MenuBuilder();
        }
        
        public ICalloutRequest CustomCallout(string ice, string ace, string pie, string dice)
        {
            var request = _request;
            request.Method = "customCallout";

            request.CustomCallout = new CustomCalloutCalloutRequest
            {
                Ice = ice,
                Ace = ace,
                Pie = pie,
                Dice = dice
            };

            return request;
        }
    }
}
