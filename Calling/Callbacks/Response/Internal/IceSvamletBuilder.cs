using System;
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

        public IMenu<IIceSvamletBuilder> BeginMenuDefinition(string menuId, Prompt prompt, TimeSpan? timeout)
        {
            return InternalBeginMenuDefinition(this, menuId, prompt, timeout);
        }

        public IIceSvamletBuilder AddNumberInputMenu(string menuId, Prompt prompt, int maxDigits, Prompt repeatPrompt = null,
            int repeats = 3, TimeSpan? timeout = null)
        {
            InternalAddNumberInputMenu(menuId, prompt, maxDigits, repeatPrompt);
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

        public IConnectSipSvamletResponse ConnectSip(IIdentity identity)
        {
            return ConnectSip(identity, "incoming");
        }

        public IConnectMxpSvamletResponse ConnectMxp(IIdentity identity)
        {
            return ConnectMxp(identity, "incoming");
        }
    }
}