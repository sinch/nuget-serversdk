using Sinch.ServerSdk.Calling.Callbacks.Request;
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Calling.Callbacks.Response.Internal
{
    internal class IceSvamletBuilder : BridgedCallSvamletBuilders<IIceSvamletBuilder>, IIceSvamletBuilder
    {
        internal IceSvamletBuilder(Locale locale) : base(locale)
        {
        }

        public IIceSvamletBuilder SetCookie(string name, string value)
        {
            InternalSetCookie(name, value);
            return this;
        }

        public IIceSvamletBuilder Say(string text)
        {
            InternalSay(text);
            return this;
        }

        public IIceSvamletBuilder Play(string file)
        {
            InternalPlay(file);
            return this;
        }

        public IIceSvamletBuilder SaySsml(string ssml)
        {
            InternalPlaySsml(ssml);
            return this;
        }

        public IIceSvamletBuilder Answer()
        {
            AddInstruction(new Models.SvamletInstructionModel { Name = "answer" });
            return this;
        }

        public IConnectPstnSvamletResponse ConnectPstn(string number)
        {
            return ConnectPstn(number, "incoming");
        }

        public IConnectMxpSvamletResponse ConnectMxp(string userName)
        {
            return ConnectMxp(userName, "incoming");
        }

        public IConnectSipSvamletResponse ConnectSipDestination(string sipUri)
        {
            return ConnectSip(null, sipUri, "incoming");
        }

        public IConnectSipSvamletResponse ConnectRegisteredSipPeer(string authName)
        {
            return ConnectSip(authName, null, "incoming");
        }

        public IConnectMxpSvamletResponse ConnectMxp(IIdentity identity)
        {
            return ConnectMxp(identity, "incoming");
        }
    }
}