using Sinch.Callback.Model;
using Sinch.Callback.Request;
using Sinch.Callback.Request.Internal;
using Sinch.Callback.Response;
using Sinch.Callback.Response.Internal;

namespace Sinch.Callback
{
    public class CallbackFactory : ICallbackFactory
    {
        private readonly Locale _locale;

        public CallbackFactory(Locale locale)
        {
            _locale = locale ?? Locale.EnUs;
        }

        public ICallbackEventReader CreateEventReader() { return new CallbackEventReader(); }

        public IIceSvamletBuilder CreateIceSvamletBuilder() { return new IceSvamletBuilder(_locale); }
        public IAceSvamletBuilder CreateAceSvamletBuilder() { return new AceSvamletBuilder(_locale); }
        public IManageCallSvamletBuilder CreateManageCallSvamletBuilder() { return new ManageCallSvamletBuilder(_locale); }
        public ISvamletResponse CreateDiceResponse() { return new SvamletResponse { Model = new Svamlet() }; }
        public ISvamletResponse CreateNotificationResponse() {  return new SvamletResponse { Model = new Svamlet()}; }
    }
}