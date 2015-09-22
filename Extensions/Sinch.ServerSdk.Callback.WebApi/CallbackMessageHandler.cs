using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Sinch.ServerSdk.Exceptions;

namespace Sinch.ServerSdk.Callback.WebApi
{
    public class CallbackMessageHandler : DelegatingHandler
    {
        private readonly IApiFactory _factory;

        public CallbackMessageHandler(IApiFactory factory)
        {
            _factory = factory;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                _factory.CreateCallbackValidator().Validate(request.RequestUri.AbsolutePath, GetHeaders(request), await request.Content.ReadAsByteArrayAsync());
            }
            catch (InvalidCallbackException)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            request.Content.ReadAsStreamAsync().Result.Seek(0, SeekOrigin.Begin);
            return await base.SendAsync(request, cancellationToken);
        }
        
        private static Dictionary<string, string> GetHeaders(HttpRequestMessage request)
        {
            var requestHeaders = request.Headers.ToDictionary(kvp => kvp.Key.ToLowerInvariant(), kvp => kvp.Value.FirstOrDefault());
            var contentHeaders = request.Content.Headers.ToDictionary(kvp => kvp.Key.ToLowerInvariant(), kvp => kvp.Value.FirstOrDefault());
            return requestHeaders.Concat(contentHeaders).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}