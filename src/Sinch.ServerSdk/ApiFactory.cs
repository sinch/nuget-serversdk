﻿using System;
using Sinch.ServerSdk.ApiFilters;
using Sinch.ServerSdk.Callback;
using Sinch.ServerSdk.Calling;
using Sinch.ServerSdk.Calling.Fluent;
using Sinch.ServerSdk.Callouts;
using Sinch.ServerSdk.Models;
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
        /// Create a Sinch Conference API. Endpoints for ending the conference, as well as getting, muting, unmuting and kicking participants.
        /// </summary>
        IConferenceApi CreateConferenceApi();

        /// <summary>
        /// Createa a callout API to make Text to speech and Conference callouts
        /// </summary>
        /// <returns></returns>
        ICalloutApi CreateCalloutApi();
    }

    internal class ApiFactory : IApiFactory
    {
        private readonly string _key;
        private readonly byte[] _secret;
        private readonly string _url;
        private readonly Locale _locale;
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

            _key = key;

            if (string.IsNullOrWhiteSpace(secret))
                throw new ArgumentNullException(nameof(secret), "Sinch application secret cannot be null.");

            _locale = locale;

            try
            {
                _secret = Convert.FromBase64String(secret.Trim());
            }
            catch (FormatException)
            {
                throw new ArgumentException(
                    "Sinch application secret is in an invalid format.  Confirm the secret is correctly copied from your Sinch developer dashboard.");
            }

            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url), "Sinch API URL cannot be null.");

            if (!Uri.TryCreate(String.Format(url, "calling"), UriKind.Absolute, out _))
                throw new ArgumentException(
                    "Sinch API URL is in an invalid format.  The default URL is https://api.sinch.com");

            _url = url;
        }

        public ICallbackValidator CreateCallbackValidator()
        {
            return new CallbackValidator(_key, _secret);
        }

        public ICalloutApi CreateCalloutApi()
        {
            return new CalloutApi(CreateApiClient<ICalloutApiEndpoints>(String.Format(_url, "calling")), new CallbackResponseFactory(_locale));

        }
        

        public IConferenceApi CreateConferenceApi()
        {
            return new ConferenceApi(CreateApiClient<IConferenceApiEndpoints>(String.Format(_url, "calling")));
        }

        private T CreateApiClient<T>() where T : class
        {
            return CreateApiClient<T>(_url);
        }
        private T CreateApiClient<T>(string url) where T : class
        {
            //var handler = new HttpClientHandler();
            //handler.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
            return new WebApiClientFactory().CreateClient<T>(url, new ApplicationSigningFilter(_key, _secret),
                new RestReplyFilter());
        }
    }
}