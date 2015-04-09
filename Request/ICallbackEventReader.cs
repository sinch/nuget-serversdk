using Sinch.Callback.Model;

namespace Sinch.Callback.Request
{
    public interface ICallbackEventReader
    {
        ICallbackEvent ReadJson(string json);
        ICallbackEvent ReadModel(CallbackEventModel model);
    }
}