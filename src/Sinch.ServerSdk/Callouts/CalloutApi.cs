using Sinch.ServerSdk.IvrMenus;
using System;
using System.Globalization;

namespace Sinch.ServerSdk.Callouts
{
    public class CalloutApi : ICalloutApi
    {
        private readonly CallbackResponseFactory _responseFactory;
        private readonly CalloutRequest _request;
        private readonly ICalloutApiEndpoints _apiEndpoints;

        internal CalloutApi(ICalloutApiEndpoints calloutApiEndpoints, CallbackResponseFactory responseFactory)
        {
            _responseFactory = responseFactory;
            _request = new CalloutRequest(_apiEndpoints = calloutApiEndpoints);
        }

        public ICalloutRequest TtsCallout(string to, string message, string from, string dtmf)
        {
            return TtsCallout(To.Number(to), message, from, dtmf);
        }

        public ICalloutRequest TtsCallout(string to, string message, string from)
        {
            return TtsCallout(To.Number(to), message, from, "");
        }

        public ICalloutRequest TtsCallout(To to, string message, string from)
        {
            return TtsCallout(to, message, from, "");
        }

        public ICalloutRequest TtsCallout(To to, string message, string from, string dtmf)
        {
            var request = _request;
            request.Method = "ttsCallout";

            request.TtsCallout = new TtsCalloutRequest
            {
                Dtmf = dtmf,
                Cli = @from,
                Domain = to.Domain,
                Destination = to.ToIdentity(),
                Prompts = "#tts[" + message + "]"
            };

            return request;
        }

        public ICalloutRequest ConferenceCallout(string to, string conferenceId, string from, string greeting, string dtmf)
        {
            return ConferenceCallout(To.Number(to), conferenceId, from, greeting, dtmf);
        }

        public ICalloutRequest ConferenceCallout(string to, string conferenceId, string from, string greeting)
        {
            return ConferenceCallout(To.Number(to), conferenceId, from, greeting, "");
        }

        public ICalloutRequest ConferenceCallout(To to, string conferenceId, string from, string greeting)
        {
            return ConferenceCallout(to, conferenceId, from, greeting, "");
        }

        public ICalloutRequest ConferenceCallout(To to, string conferenceId, string from, string greeting, string dtmf)
        {
            var request = _request;
            request.Method = "conferenceCallout";

            request.ConferenceCallout = new ConferenceCalloutRequest
            {
                Dtmf = dtmf,
                ConferenceId = conferenceId,
                Cli = @from,
                Domain = to.Domain,
                Destination = to.ToIdentity(),
                Greeting = greeting
            };

            return request;
        }

        public ICalloutRequest MenuCallout(string to, string from, IMenuBuilder menu, string startMenu, TimeSpan? maxDuration)
        {
            return MenuCallout(to, from, menu, startMenu, maxDuration, "");
        }

        public ICalloutRequest MenuCallout(string to, string @from, IMenuBuilder menu, string startMenu, TimeSpan? maxDuration = null, string dtmf = "")
        {
            TimeSpan waittime = (maxDuration == null ? TimeSpan.FromSeconds(10) : (TimeSpan)maxDuration);

            var request = _request;
            request.Method = "customCallout";

            request.CustomCallout = new CustomCalloutCalloutRequest
            {
                Ice = _responseFactory.CreateIceSvamletBuilder().ConnectPstn(to).WithDTMF(dtmf).WithCli(@from).WithBridgeTimeout(waittime).Body,
                Ace = _responseFactory.CreateAceSvamletBuilder().RunMenu(startMenu, menu).Body,
                Dice = _responseFactory.CreateDiceResponse().Build().Body
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

        public ICallStatusReportRequest ReportCallStatus(string callId, CallStatusReport report)
        {
            if (callId == null)
                throw new ArgumentNullException(nameof(callId));

            if (string.Empty.Equals(callId))
                throw new ArgumentException("Invalid callId specified", nameof(callId));

            if (report == null)
                throw new ArgumentNullException(nameof(report));

            if (report.Details?.Length > 64)
                throw new ArgumentException("Details property value is too long. Maximum 64 characters allowed.");

            return new CallStatusReportRequest(_apiEndpoints, callId, new CallStatusReportModel
            {
                Details = report.Details,
                Status = report.Status.ToString()
            });
        }
    }
}
