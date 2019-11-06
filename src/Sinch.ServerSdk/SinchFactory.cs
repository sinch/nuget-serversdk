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
        /// <param name="url">
        ///         /// Its different enpints for each region, to initialise with one specific region pass in https://{0}-use1-api.sinch.com 0 will 
        /// https://*-euc1.api.sinch.com/[version]  - Europe
        /// https://*-use1.api.sinch.com/[version]  - United States
        /// https://*-sae1.api.sinch.com/[version]  - South America
        /// https://*-apse1.api.sinch.com/[version] - South East Asia 1
        /// https://*-apse2.api.sinch.com/[version] - South East Asia 2</param>
        /// <returns>An instance of <see cref="IApiFactory"/></returns>
        public static IApiFactory CreateApiFactory(string key, string secret, Locale locale, string url = "https://{0}-use1.api.sinch.com")
        {
            return new ApiFactory(key, secret, locale, url);
        }

        /// <summary>
        /// Creates a factory for creating a Sinch Application API factory.
        /// </summary>
        /// <param name="key">Your application key</param>
        /// <param name="secret">Your application secret</param>
        /// <param name="locale">The locale for the callback response factory. If null defaults to en-US</param>
        /// <param name="url">        /// Its different enpints for each region, to initialise with one specific region pass in https://{0}-use1-api.sinch.com 0 will 
        /// https://*-euc1.api.sinch.com/[version]  - Europe
        /// https://*-use1.api.sinch.com/[version]  - United States
        /// https://*-sae1.api.sinch.com/[version]  - South America
        /// https://*-apse1.api.sinch.com/[version] - South East Asia 1
        /// https://*-apse2.api.sinch.com/[version] - South East Asia 2
        /// </param>
        /// <returns>An instance of <see cref="IApiFactory"/></returns>
        public static IApiFactory CreateApiFactory(string key, string secret, string url = "https://{0}-use1.api.sinch.com")
        {
            return CreateApiFactory(key, secret, Locale.EnUs, url);
        }
    }
}