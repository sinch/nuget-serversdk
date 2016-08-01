namespace Sinch.ServerSdk.Calling.Callbacks.Request
{
    public interface IIdentity
    {
        EndpointType Type { get; }
        string Endpoint { get; }
    }
}
