using Sinch.Callback.Model;
using Sinch.Callback.Request;
using Sinch.Callback.Response;

namespace Sinch.Callback
{
    public interface ICallbackFactory
    {
        IIceSvamletBuilder CreateIceSvamletBuilder();
        IAceSvamletBuilder CreateAceSvamletBuilder();
        IManageCallSvamletBuilder CreateManageCallSvamletBuilder();
        ISvamletResponse CreateDiceResponse();
        ISvamletResponse CreateNotificationResponse();

        ICallbackEventReader CreateEventReader();
    }
}