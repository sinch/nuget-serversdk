using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Sinch.ServerSdk.Exceptions;

namespace Sinch.ServerSdk.Callback.WebApi
{
    public class CallbackMessageHandler : DelegatingHandler
    {
        private readonly ICallbackValidator _callbackValidator;

        public CallbackMessageHandler(IApiFactory factory)
        {
            _callbackValidator = factory.CreateCallbackValidator();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var controllerSelector = new DefaultHttpControllerSelector(request.GetConfiguration());
                var descriptor = controllerSelector.SelectController(request);

                if (descriptor.ControllerType.IsDefined(typeof(SinchCallbackAttribute), false))
                    _callbackValidator.Validate(request.RequestUri.AbsolutePath, GetHeaders(request), await request.Content.ReadAsByteArrayAsync());

                (await request.Content.ReadAsStreamAsync()).Seek(0, SeekOrigin.Begin);
                return await base.SendAsync(request, cancellationToken);
            }
            catch (InvalidCallbackException)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        private static Dictionary<string, string> GetHeaders(HttpRequestMessage request)
        {
            var requestHeaders = request.Headers.ToDictionary(kvp => kvp.Key.ToLowerInvariant(), kvp => kvp.Value.FirstOrDefault());
            var contentHeaders = request.Content.Headers.ToDictionary(kvp => kvp.Key.ToLowerInvariant(), kvp => kvp.Value.FirstOrDefault());
            return requestHeaders.Concat(contentHeaders).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}