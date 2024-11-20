using Sinch.ServerSdk.ApiFilters;
using Sinch.ServerSdk.Callback;
using Sinch.ServerSdk.Calling;
using Sinch.ServerSdk.Calling.Fluent;
using Sinch.ServerSdk.Callouts;
using Sinch.ServerSdk.Messaging;
using Sinch.ServerSdk.Messaging.Fluent;
using Sinch.ServerSdk.Models;
using Sinch.ServerSdk.Verification;
using Sinch.ServerSdk.Verification.Fluent;
using Sinch.WebApiClient;
using System;
using System.Text;

namespace Sinch.ServerSdk
{
    /// <summary>
    /// Factory object that will create ready-to-use Sinch Product API request objects on a per-application basis
    /// </summary>
    public interface IApiFactory
    {
        /// <summary>
        /// Create a validator that checks the integrity of callbacks from the Sinch server.
        /// </summary>
        ICallbackValidator CreateCallbackValidator();

        /// <summary>
        /// Create a Sinch SMS API. Provides endpoints for sending SMS's using Sinch.
        /// </summary>
        ISmsApi CreateSmsApi();

        /// <summary>
        /// Create a Sinch Conference API. Endpoints for ending the conference, as well as getting, muting, unmuting and kicking participants.
        /// </summary>
        IConferenceApi CreateConferenceApi();

        /// <summary>
        /// Create a Sinch Verification API. Provides endpoints for using Sinch Verification operations.
        /// </summary>
        IVerificationApi CreateVerificationApi();

        /// <summary>
        /// Createa a callout API to make Text to speech and Conference callouts
        /// </summary>
        /// <returns></returns>
        ICalloutApi CreateCalloutApi();
    }

    internal class ApiFactory : IApiFactory
    {
        private readonly string _url;
        private readonly Locale _locale;
        private readonly ICallbackValidator _callbackValidator;

        private readonly Func<IActionFilter> _signingFilterFactory;

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="secret"></param>
        /// <param name="locale"></param>
        /// <param name="url">
        /// Its different enpints for each region, to initialise with one specific region pass in https://{0}-use1-api.sinch.com 0 will 
        /// https://*-euc1.api.sinch.com/[version]  - Europe
        /// https://*-use1.api.sinch.com/[version]  - United States
        /// https://*-sae1.api.sinch.com/[version]  - South America
        /// https://*-apse1.api.sinch.com/[version] - South East Asia 1
        /// https://*-apse2.api.sinch.com/[version] - South East Asia 2
        /// </param>
        internal ApiFactory(string key, string secret, Locale locale, string url = "https://{0}-use1-api.sinch.com")
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key), "Sinch application key cannot be null.");

            if (!Guid.TryParse(key.Trim(), out var guid))
                throw new ArgumentException(
                    "Sinch application key is in an invalid format.  Confirm the key is correctly copied from your Sinch developer dashboard.");

            if (guid.Equals(Guid.Empty))
                throw new ArgumentException(
                    "Replace the Sinch application key with the one copied from your Sinch developer dashboard.");

            if (string.IsNullOrWhiteSpace(secret))
                throw new ArgumentNullException(nameof(secret), "Sinch application secret cannot be null.");

            _locale = locale;
            
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url), "Sinch API URL cannot be null.");

            if (!Uri.TryCreate(String.Format(url, "calling"), UriKind.Absolute, out _))
                throw new ArgumentException(
                    "Sinch API URL is in an invalid format.  The default URL is https://api.sinch.com");

            _url = url;

            byte[] secretKey = ParseSecretKey(secret);

            _signingFilterFactory = 
                () => new ApplicationSigningFilter(key, secretKey);

            _callbackValidator = new CallbackValidator(key, secretKey);
        }

        private byte[] ParseSecretKey(string secret)
        {
            try
            {
                return Convert.FromBase64String(secret.Trim());
            }
            catch (FormatException)
            {
                throw new ArgumentException(
                    "Sinch application secret is in an invalid format.  Confirm the secret is correctly copied from your Sinch developer dashboard.");
            }
        }

        internal ApiFactory(SinchAccessCredentials credentials, Locale locale, string url = "https://{0}-use1-api.sinch.com")
        {
            if (credentials == null)
                throw new ArgumentNullException(nameof(credentials));

            _locale = locale ?? throw new ArgumentNullException(nameof(locale));

            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url), "Sinch API URL cannot be null.");

            _url = url;

            _signingFilterFactory = () => new AccessCredentialsSigningFilter(credentials);

            _callbackValidator = new CallbackValidator(
                credentials.AccessKeyId, Encoding.ASCII.GetBytes(credentials.KeySecret));
        }

        public ICallbackValidator CreateCallbackValidator()
        {
            return _callbackValidator;
        }

        public ISmsApi CreateSmsApi()
        {
            return new SmsApi(CreateApiClient<ISmsApiEndpoints>(_url));
        }

        public ICalloutApi CreateCalloutApi()
        {
            return new CalloutApi(CreateApiClient<ICalloutApiEndpoints>(String.Format(_url, "calling")), new CallbackResponseFactory(_locale));

        }

        public IConferenceApi CreateConferenceApi()
        {
            return new ConferenceApi(CreateApiClient<IConferenceApiEndpoints>(String.Format(_url, "calling")));
        }

        public IVerificationApi CreateVerificationApi()
        {
            return new VerificationApi(CreateApiClient<IVerificationApiEndpoints>("https://verificationapi-v1.sinch.com/verification/v1"));
        }

        private T CreateApiClient<T>() where T : class
        {
            return CreateApiClient<T>(_url);
        }

        private T CreateApiClient<T>(string url) where T : class =>
            new WebApiClientFactory().CreateClient<T>(url, _signingFilterFactory(),
                new RestReplyFilter());
    }
}