using Sinch.ServerSdk.Calling.Model;

namespace Sinch.ServerSdk.Calling.Callbacks.Request
{
    public interface ICallbackEventReader
    {
        ICallbackEvent ReadJson(string json);
        ICallbackEvent ReadModel(CallbackEventModel model);
    }
}