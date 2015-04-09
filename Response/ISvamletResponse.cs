using Sinch.Callback.Model;

namespace Sinch.Callback.Response
{
    public interface ISvamletResponse
    {
        string ContentType { get; }
        int ContentLength { get; }
        string Body { get; }
        Svamlet Model { get; }
    }
}