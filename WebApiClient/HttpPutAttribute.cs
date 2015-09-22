using System;
using System.Net.Http;

namespace Sinch.ServerSdk.WebApiClient
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HttpPutAttribute : HttpAttribute
    {
        public HttpPutAttribute(string route)
        {
            Route = route;
        }

        public override HttpMethod Method => HttpMethod.Put;
    }
}