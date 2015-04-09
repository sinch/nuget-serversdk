namespace Sinch.Callback.Response.Internal
{
    internal class AceSvamletBuilder : SvamletBuilder, IAceSvamletBuilder
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

    }
}