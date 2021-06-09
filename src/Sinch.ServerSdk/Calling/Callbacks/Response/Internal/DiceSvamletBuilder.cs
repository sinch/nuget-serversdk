using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Calling.Callbacks.Response.Internal
{
    internal class DiceSvamletBuilder : SvamletBuilder, IDiceSvamletBuilder
    {
        public DiceSvamletBuilder(Locale locale) : base(locale)
        {
        }

        public IDiceSvamletBuilder SetCookie(string name, string value)
        {
            InternalSetCookie(name, value);
            return this;
        }

        public IDiceSvamletBuilder Say(string text)
        {
            InternalSay(text);
            return this;
        }

        public IDiceSvamletBuilder Play(string file)
        {
            InternalPlay(file);
            return this;
        }

        public IDiceSvamletBuilder SaySsml(string ssml)
        {
            InternalPlaySsml(ssml);
            return this;
        }

        public IDiceSvamletBuilder ReportCallStatus(CallStatus status, string details)
        {
            InternalReportCallStatus(status, details);
            return this;
        }
    }
}
