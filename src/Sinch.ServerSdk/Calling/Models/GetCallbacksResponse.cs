namespace Sinch.ServerSdk.Calling
{
    public class GetCallbacksResponse
    {
        public CallbackUrl Url { get; set;}

    }
    public class CallbackUrl
    {
        public string Primary { get; set; }
        public string Fallback { get; set; }
    }
}