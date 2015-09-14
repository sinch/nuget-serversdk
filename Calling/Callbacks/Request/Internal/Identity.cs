namespace Sinch.ServerSdk.Calling.Callbacks.Request.Internal
{
    public class Identity : IIdentity
    {
        public EndpointType Type { get; set; }
        public string Endpoint { get; set; }

        public override string ToString()
        {
            return Type + "=" + (Endpoint ?? "<null value>");
        }
    }
}
