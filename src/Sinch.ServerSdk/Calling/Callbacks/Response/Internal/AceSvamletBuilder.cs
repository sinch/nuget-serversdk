using System;
using Sinch.ServerSdk.Calling.Callbacks.Request;
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Calling.Callbacks.Response.Internal
{
    internal class AceSvamletBuilder : BridgedCallSvamletBuilders<IAceSvamletBuilder>, IAceSvamletBuilder
    {
        internal AceSvamletBuilder(Locale locale)
            : base(locale)
        {
        }

        public IAceSvamletBuilder SetCookie(string name, string value)
        {
            InternalSetCookie(name,value);
            return this;
        }

        public IAceSvamletBuilder Say(string text)
        {
            InternalSay(text);
            return this;
        }

        public IAceSvamletBuilder Play(string file)
        {
            InternalPlay(file);
            return this;
        }

        public IAceSvamletBuilder SaySsml(string ssml)
        {
            InternalPlaySsml(ssml);
            return this;
        }

        public IConnectPstnSvamletResponse ConnectPstn(string number)
        {
            return ConnectPstn(number, "private");
        }

        public IConnectMxpSvamletResponse ConnectMxp(string userName)
        {
            return ConnectMxp(userName, "private");
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
            return ConnectMxp(identity, "private");
        }
    }
}