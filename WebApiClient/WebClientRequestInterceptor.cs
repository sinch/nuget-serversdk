using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Newtonsoft.Json;

namespace Sinch.ServerSdk.WebApiClient
{
    class WebClientRequestInterceptor<TInterface> : IInterceptor
    {
        readonly IActionFilter[] _filters;
        readonly Uri _baseUri;
        readonly CookieContainer _cookieContainer;

        public WebClientRequestInterceptor(string baseUri, IActionFilter[] filters)
        {
            _filters = filters;

            _baseUri = new Uri(baseUri);
        }

        public WebClientRequestInterceptor(string baseUri, CookieContainer cookieContainer, IActionFilter[] filters)
        {
            _filters = filters;

            _baseUri = new Uri(baseUri);
            _cookieContainer = cookieContainer;
        }

        HttpClient CreateHttpClient() => _cookieContainer != null ? new HttpClient(new HttpClientHandler { CookieContainer = _cookieContainer }) : new HttpClient();

        public void Intercept(IInvocation invocation)
        {
            var type = invocation.Method.ReturnType;
            if (type == typeof(Task))
            {
                invocation.ReturnValue = ExecuteTask(invocation);
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Task<>))
            {
                var subType = type.GetGenericArguments()[0];

                var methodInfo = typeof(WebClientRequestInterceptor<TInterface>).GetMethod("ExecuteGenericTask", BindingFlags.Instance | BindingFlags.NonPublic);
                var genericMethod = methodInfo.MakeGenericMethod(subType);

                invocation.ReturnValue = genericMethod.Invoke(this, new object[] { invocation });
            }
            else
                throw new WebApiClientException("ReturnType: " + type + " not supported. Must be Task or Task<>.");
        }

        async Task ExecuteTask(IInvocation invocation)
        {
            var httpRequestMessage = BuildHttpRequestMessage(invocation);

            foreach (var inerceptor in _filters)
                await inerceptor.OnActionExecuting(httpRequestMessage);

            using (var client = CreateHttpClient())
            {
                var response = await client.SendAsync(httpRequestMessage);

                foreach (var inerceptor in _filters)
                    await inerceptor.OnActionExecuted(response);

                if (response.StatusCode == HttpStatusCode.NoContent ||
                    response.StatusCode == HttpStatusCode.OK)
                    return;

                throw new WebApiClientException();
            }
        }

        internal async Task<T> ExecuteGenericTask<T>(IInvocation invocation)
        {
            var httpRequestMessage = BuildHttpRequestMessage(invocation);

            foreach (var inerceptor in _filters)
                await inerceptor.OnActionExecuting(httpRequestMessage);

            using (var client = CreateHttpClient())
            {
                var response = await client.SendAsync(httpRequestMessage);

                foreach (var inerceptor in _filters)
                    await inerceptor.OnActionExecuted(response);

                var value = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<T>(value);

                if (response.StatusCode == HttpStatusCode.NoContent)
                    return default(T);

                throw new WebApiClientException();
            }
        }

        HttpRequestMessage BuildHttpRequestMessage(IInvocation invocation)
        {
            var uriParameters = GetUriParameters(invocation.Method, invocation.Arguments);
            var body = GetBodyParameter(invocation.Method, invocation.Arguments);

            var httpAttribute = invocation.Method.GetCustomAttribute<HttpAttribute>();

            var template = new UriTemplate(httpAttribute.Route);
            var uri = template.BindByName(_baseUri, uriParameters);

            var httpRequestMessage = new HttpRequestMessage(httpAttribute.Method, uri);

            if (body != null)
            {
                var content = JsonConvert.SerializeObject(body);
                httpRequestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }

            return httpRequestMessage;
        }

        static IDictionary<string, string> GetUriParameters(MethodBase methodBase, params object[] arguments)
        {
            var result = new Dictionary<string, string>();
            var parameters = methodBase.GetParameters();

            for (var i = 0; i < arguments.Length; ++i)
            {
                if (parameters[i].GetCustomAttribute<ToBodyAttribute>() != null)
                    continue;

                if (IsSimpleType(arguments[i]))
                {
                    result.Add(parameters[i].Name, string.Format(CultureInfo.InvariantCulture, "{0}", arguments[i]));
                    continue;
                }

                if (parameters[i].GetCustomAttribute<ToUriAttribute>() == null)
                    continue;

                foreach (var property in arguments[i].GetType().GetProperties())
                {
                    result.Add(property.Name,
                        string.Format(CultureInfo.InvariantCulture, "{0}", property.GetValue(arguments[i])));
                }
            }

            return result;
        }

        static object GetBodyParameter(MethodInfo methodBase, IList<object> arguments)
        {
            var parameters = methodBase.GetParameters();

            for (var i = 0; i < arguments.Count; ++i)
            {
                if (parameters[i].GetCustomAttribute<ToBodyAttribute>() != null)
                    return arguments[i];

                if (IsSimpleType(arguments[i]))
                    continue;

                if (parameters[i].GetCustomAttribute<ToUriAttribute>() == null)
                    return arguments[i];
            }

            return null;
        }

        static bool IsSimpleType(object o) => o is string ||
                   o is byte ||
                   o is char ||
                   o is short ||
                   o is ushort ||
                   o is int ||
                   o is uint ||
                   o is long ||
                   o is ulong ||
                   o is decimal ||
                   o is float ||
                   o is Guid;
    }
}