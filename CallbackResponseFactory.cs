using Sinch.ServerSdk.Calling.Callbacks.Request;
using Sinch.ServerSdk.Calling.Callbacks.Request.Internal;
using Sinch.ServerSdk.Calling.Callbacks.Response;
using Sinch.ServerSdk.Calling.Callbacks.Response.Internal;
using Sinch.ServerSdk.Calling.Models;
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk
{
    public interface ICallbackResponseFactory
    {
        ICallbackEventReader CreateEventReader();
        IIceSvamletBuilder CreateIceSvamletBuilder();
        IAceSvamletBuilder CreateAceSvamletBuilder();
        IManageCallSvamletBuilder CreateManageCallSvamletBuilder();
        ISvamletResponse CreateDiceResponse();
        ISvamletResponse CreateNotificationResponse();
    }

    class CallbackResponseFactory : ICallbackResponseFactory
    {
        private readonly Locale _locale;

        public CallbackResponseFactory(Locale locale)
        {
            _locale = locale ?? Locale.EnUs;
        }

        public ICallbackEventReader CreateEventReader() { return new CallbackEventReader(); }
        public IIceSvamletBuilder CreateIceSvamletBuilder() { return new IceSvamletBuilder(_locale); }
        public IAceSvamletBuilder CreateAceSvamletBuilder() { return new AceSvamletBuilder(_locale); }
        public IManageCallSvamletBuilder CreateManageCallSvamletBuilder() { return new ManageCallSvamletBuilder(_locale); }
        public ISvamletResponse CreateDiceResponse() { return new SvamletResponse { Model = new SvamletModel() }; }
        public ISvamletResponse CreateNotificationResponse() { return new SvamletResponse { Model = new SvamletModel() }; }
    }
}