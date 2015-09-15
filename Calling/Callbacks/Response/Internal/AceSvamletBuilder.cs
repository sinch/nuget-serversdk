using System;

namespace Sinch.ServerSdk.Calling.Callbacks.Response.Internal
{
    internal class AceSvamletBuilder : CallerSvamletBuilder<IAceSvamletBuilder>, IAceSvamletBuilder
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

        public IMenu<IAceSvamletBuilder> BeginMenuDefinition(string menuId, Prompt prompt, TimeSpan? timeout)
        {
            return InternalBeginMenuDefinition(this, menuId, prompt, timeout);
        }

        public IAceSvamletBuilder AddNumberInputMenu(string menuId, Prompt prompt, int maxDigits, Prompt repeatPrompt = null,
            int repeats = 3, TimeSpan? timeout = null)
        {
            InternalAddNumberInputMenu(menuId, prompt, maxDigits, repeatPrompt, repeats, timeout);
            return this;
        }
    }
}