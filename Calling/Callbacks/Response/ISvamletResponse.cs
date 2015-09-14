using Sinch.ServerSdk.Calling.Model;

namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface ISvamletResponse
    {
        string ContentType { get; }
        int ContentLength { get; }
        string Body { get; }
        Svamlet Model { get; }
    }
}