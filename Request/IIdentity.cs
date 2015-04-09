namespace Sinch.Callback.Request
{
    public interface IIdentity
    {
        EndpointType Type { get; }
        string Endpoint { get; }
    }
}
