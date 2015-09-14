using System;
using Sinch.ServerSdk.Calling.Callbacks.Response;

namespace Sinch.Callback.Response.Internal
{
    internal class IceSvamletBuilder : CallerSvamletBuilder<IIceSvamletBuilder>, IIceSvamletBuilder
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
    }
}