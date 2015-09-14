using Sinch.ServerSdk.Calling.Callbacks.Request;
using Sinch.ServerSdk.Calling.Callbacks.Response;

namespace Sinch.ServerSdk
{
    public interface ISinchFactory
    {
        IIceSvamletBuilder CreateIceSvamletBuilder();
        IAceSvamletBuilder CreateAceSvamletBuilder();
        IManageCallSvamletBuilder CreateManageCallSvamletBuilder();
        ISvamletResponse CreateDiceResponse();
        ISvamletResponse CreateNotificationResponse();

        ICallbackEventReader CreateEventReader();
    }
}