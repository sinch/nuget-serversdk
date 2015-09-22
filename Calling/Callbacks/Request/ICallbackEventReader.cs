using Sinch.ServerSdk.Calling.Models;

namespace Sinch.ServerSdk.Calling.Callbacks.Request
{
    public interface ICallbackEventReader
    {
        ICallbackEvent ReadJson(string json);
        ICallbackEvent ReadModel(CallbackEventModel model);
    }
}