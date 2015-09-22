using System;
using System.Net.Http;

namespace Sinch.ServerSdk.WebApiClient
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HttpPatchAttribute : HttpAttribute
    {
        public HttpPatchAttribute(string route)
        {
            Route = route;
        }

        public override HttpMethod Method => new HttpMethod("PATCH");
    }
}