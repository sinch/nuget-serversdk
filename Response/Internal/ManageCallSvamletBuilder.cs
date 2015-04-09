namespace Sinch.Callback.Response.Internal
{
    internal class ManageCallSvamletBuilder : CallerSvamletBuilder, IManageCallSvamletBuilder
    {
        internal ManageCallSvamletBuilder(Locale locale) : base(locale)
        {
        }

        public IManageCallSvamletBuilder SetCookie(string name, string value)
        {
            InternalSetCookie(name,value);
            return this;
        }

        public IManageCallSvamletBuilder EnableBargeHangup()
        {
            Barge = true;
            return this;
        }

        public IManageCallSvamletBuilder Say(string text)
        {
            InternalSay(text);
            return this;
        }

        public IManageCallSvamletBuilder Play(string file)
        {
            InternalPlay(file);
            return this;
        }
    }
}