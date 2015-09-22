using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk
{
    public class SinchFactory
    {
        public static ICallbackResponseFactory CreateCallbackResponseFactory(Locale locale)
        {
            return new CallbackResponseFactory(locale);
        }
        
        public static IApiFactory CreateApiFactory(string key, string secret, string url = "https://api.sinch.com")
        {
            return new ApiFactory(key, secret, url);
        }
    }
}