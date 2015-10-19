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
        /// <summary>
        /// Creates a callback event reader
        /// </summary>
        /// <returns></returns>
        ICallbackEventReader CreateEventReader();

        /// <summary>
        /// Creates an ICE svamlet builder
        /// </summary>
        /// <returns></returns>
        IIceSvamletBuilder CreateIceSvamletBuilder();

        /// <summary>
        /// Creates and ACE svamlet builder
        /// </summary>
        /// <returns></returns>
        IAceSvamletBuilder CreateAceSvamletBuilder();

        /// <summary>
        /// Creates a manage call svamlet builder
        /// </summary>
        /// <returns></returns>
        IManageCallSvamletBuilder CreateManageCallSvamletBuilder();

        /// <summary>
        /// Creates a DICE svamlet response
        /// </summary>
        /// <returns></returns>
        ISvamletResponse CreateDiceResponse();

        /// <summary>
        /// Creates a notification svamlet response
        /// </summary>
        /// <returns></returns>
        ISvamletResponse CreateNotificationResponse();
    }

    class CallbackResponseFactory : ICallbackResponseFactory
    {
        private readonly Locale _locale;

        internal CallbackResponseFactory(Locale locale)
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