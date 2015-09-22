using System;
using System.Net.Http;

namespace Sinch.ServerSdk.WebApiClient
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HttpPostAttribute : HttpAttribute
    {
        public HttpPostAttribute(string route)
        {
            Route = route;
        }

        public override HttpMethod Method => HttpMethod.Post;
    }
}