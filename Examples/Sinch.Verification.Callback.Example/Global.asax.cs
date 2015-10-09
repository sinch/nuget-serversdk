using System.Web;
using System.Web.Http;
using Sinch.ServerSdk;
using Sinch.ServerSdk.Callback.WebApi;

namespace Sinch.Verification.Callback.Example
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var factory = SinchFactory.CreateApiFactory("00000000-0000-0000-0000-000000000000", "AAAAAAAAAAAAAAAAAAAAAA==");
            GlobalConfiguration.Configuration.MessageHandlers.Add(new CallbackMessageHandler(factory));
        }
    }
}