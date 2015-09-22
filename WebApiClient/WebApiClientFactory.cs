using System;
using System.Net;
using Castle.DynamicProxy;

namespace Sinch.ServerSdk.WebApiClient
{
    public class WebApiClientFactory
    {
        static readonly ProxyGenerator Generator = new ProxyGenerator();

        public T CreateClient<T>(string baseUri, params IActionFilter[] filters) where T : class => Generator.CreateInterfaceProxyWithoutTarget<T>(new WebClientRequestInterceptor<T>(baseUri, filters));

        public T CreateClient<T>(Uri baseUri, params IActionFilter[] filters) where T : class => Generator.CreateInterfaceProxyWithoutTarget<T>(new WebClientRequestInterceptor<T>(baseUri.ToString(), filters));

        public T CreateClient<T>(string baseUri, CookieContainer cookieContainer, params IActionFilter[] filters) where T : class => Generator.CreateInterfaceProxyWithoutTarget<T>(new WebClientRequestInterceptor<T>(baseUri, cookieContainer, filters));

        public T CreateClient<T>(Uri baseUri, CookieContainer cookieContainer, params IActionFilter[] filters) where T : class => Generator.CreateInterfaceProxyWithoutTarget<T>(new WebClientRequestInterceptor<T>(baseUri.ToString(), cookieContainer, filters));
    }
}