using System.Threading.Tasks;

namespace Sinch.ServerSdk.Calling.Fluent
{
    class ConfigurationApi : IConfigurationApi
    {
        private readonly IConfigurationApiEndpoints _api;

        public ConfigurationApi(IConfigurationApiEndpoints api)
        {
            _api = api;
        }

        public async Task<GetCallbacksResponse> GetCallbackUrl(string applicationKey)
        {
            return await _api.GetCallbacks(applicationKey);
        }

        public async Task<NumbersResponse> GetNumbers()
        {
            return await _api.GetNumbers();
        }

        public async Task UpdateCallbackUrl(string applicationKey, string primaryUrl, string fallbackUrl = "")
        {
            await _api.UpdateCallbacks(applicationKey, new CallbackUrl
            {
                Primary = primaryUrl,
                Fallback = fallbackUrl
            });
        }

        public async Task UpdateNumbers(string[] numbers, string applicationKey, Capabilities capability)
        {
            await _api.UpdateNumbers(new UpdateNumberRequest { 
                ApplicationKey = applicationKey,
                Capability = capability,
                Numbers = numbers

            });
        }
    }

    internal interface IConfigurationApi
    {

        /// <summary>
        /// Update callbacks on your voice application
        /// </summary>
        /// <param name="applicationKey">The applicationKey of the application you want to update callbacks on</param>
        /// <param name="primaryUrl">The primary callback url </param>
        /// <param name="fallbackUrl">The backup callback url if you primary is down</param>
        Task UpdateCallbackUrl(string applicationKey, string primaryUrl, string fallbackUrl = "");

        /// <summary>
        /// Get callback URLs for an application
        /// </summary>
        /// <param name="applicationKey">The applicationKey of the application you want to update callbacks on</param>
        /// <returns>An ongoing task with the response containing the status callback response</returns>
        Task<GetCallbacksResponse> GetCallbackUrl(string applicationKey);


        /// <summary>
        /// Get your Sinch numbers
        /// </summary>
        /// <returns>An ongoing task with the response containing your numbers</returns>
        Task<NumbersResponse> GetNumbers();


        /// <summary>
        /// Update/Move  your Sinch numbers
        /// </summary>
        /// <param name="numbers">Array of the numbers you want to update/move</param>
        /// <param name="applicationKey">The applicationKey of the application you want to update callbacks on</param>
        /// <param name="capability">The application type you want to move the numbers to</param>
        /// <returns>An ongoing task with the response containing your numbers</returns>
        Task UpdateNumbers(string[] numbers, string applicationKey, Capabilities capability);
    }
}