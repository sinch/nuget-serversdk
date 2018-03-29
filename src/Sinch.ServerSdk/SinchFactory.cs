using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk
{
    /// <summary>
    /// Entry-point in to the SinchServerSdk. Used to create callback response factories and Api factories for issuing requests
    /// to the Sinch Products
    /// </summary>
    public class SinchFactory
    {
        /// <summary>
        /// Creates a factory for creating callback responses. 
        /// </summary>
        /// <param name="locale">The locale for the callback response factory. If null defaults to en-US</param>
        /// <returns>An instance of <see cref="ICallbackResponseFactory"/></returns>
        public static ICallbackResponseFactory CreateCallbackResponseFactory(Locale locale)
        {
            return new CallbackResponseFactory(locale);
        }

        /// <summary>
        /// Creates a factory for creating a Sinch Application API factory.
        /// </summary>
        /// <param name="key">Your application key</param>
        /// <param name="secret">Your application secret</param>
        /// <param name="url">The base url to the Sinch Rest APIs</param>
        /// <returns>An instance of <see cref="IApiFactory"/></returns>
        public static IApiFactory CreateApiFactory(string key, string secret, Locale locale, string url = "https://api.sinch.com")
        {
            return new ApiFactory(key, secret, locale, url);
        }

        /// <summary>
        /// Creates a factory for creating a Sinch Application API factory.
        /// </summary>
        /// <param name="key">Your application key</param>
        /// <param name="secret">Your application secret</param>
        /// <param name="locale">The locale for the callback response factory. If null defaults to en-US</param>
        /// <param name="url">The base url to the Sinch Rest APIs</param>
        /// <returns>An instance of <see cref="IApiFactory"/></returns>
        public static IApiFactory CreateApiFactory(string key, string secret, string url = "https://api.sinch.com")
        {
            return CreateApiFactory(key, secret, Locale.EnUs, url);
        }
    }
}