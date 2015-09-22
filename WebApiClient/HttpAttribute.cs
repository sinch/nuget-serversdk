using System;
using System.Net.Http;

namespace Sinch.ServerSdk.WebApiClient
{
    public abstract class HttpAttribute : Attribute
    {
        public abstract HttpMethod Method { get; }
        public string Route { get; set; }
    }
}