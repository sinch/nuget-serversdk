using System;
using System.Net.Http;

namespace Sinch.ServerSdk.WebApiClient
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HttpDeleteAttribute : HttpAttribute
    {
        public HttpDeleteAttribute(string route)
        {
            Route = route;
        }

        public override HttpMethod Method => HttpMethod.Delete;
    }
}