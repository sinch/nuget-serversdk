﻿using System;
using Sinch.ServerSdk.ApiFilters;
using Sinch.ServerSdk.Callback;
using Sinch.ServerSdk.Calling;
using Sinch.ServerSdk.Calling.Fluent;
using Sinch.ServerSdk.Messaging;
using Sinch.ServerSdk.Messaging.Fluent;
using Sinch.ServerSdk.Verification;
using Sinch.ServerSdk.Verification.Fluent;
using Sinch.WebApiClient;

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
    }

    internal class ApiFactory : IApiFactory
    {
        private readonly string _key;
        private readonly byte[] _secret;
        private readonly string _url;

        internal ApiFactory(string key, string secret, string url = "https://api.sinch.com")
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key), "Sinch application key cannot be null.");

            Guid guid;
            if (!Guid.TryParse(key.Trim(), out guid))
                throw new ArgumentException("Sinch application key is in an invalid format.  Confirm the key is correctly copied from your Sinch developer dashboard.");

            if (guid.Equals(Guid.Empty))
                throw new ArgumentException("Replace the Sinch application key with the one copied from your Sinch developer dashboard.");

            _key = key;

            if (string.IsNullOrWhiteSpace(secret))
                throw new ArgumentNullException(nameof(secret), "Sinch application secret cannot be null.");

            try
            {
                _secret = Convert.FromBase64String(secret.Trim());
            }
            catch (FormatException)
            {
                throw new ArgumentException("Sinch application secret is in an invalid format.  Confirm the secret is correctly copied from your Sinch developer dashboard.");
            }

            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url), "Sinch API URL cannot be null.");

            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
                throw new ArgumentException("Sinch API URL is in an invalid format.  The default URL is https://api.sinch.com");

            _url = url;
        }

        public ICallbackValidator CreateCallbackValidator()
        {
            return new CallbackValidator(_key, _secret);
        }

        public ISmsApi CreateSmsApi()
        {
            return new SmsApi(CreateApiClient<ISmsApiEndpoints>());
        }

        public IConferenceApi CreateConferenceApi()
        {
            return new ConferenceApi(CreateApiClient<IConferenceApiEndpoints>());
        }

        public IVerificationApi CreateVerificationApi()
        {
            return new VerificationApi(CreateApiClient<IVerificationApiEndpoints>());
        }

        private T CreateApiClient<T>() where T : class
        {
            return new WebApiClientFactory().CreateClient<T>(_url, new ApplicationSigningFilter(_key, _secret), new RestReplyFilter());
        }
    }
}