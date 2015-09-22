using Sinch.ServerSdk.Calling.Models;

namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface ISvamletResponse
    {
        string ContentType { get; }
        int ContentLength { get; }
        string Body { get; }
        SvamletModel Model { get; }
    }
}