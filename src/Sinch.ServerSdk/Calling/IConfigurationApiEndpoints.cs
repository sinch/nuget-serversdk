using System.Threading.Tasks;
using Sinch.ServerSdk.Calling.Models;
using Sinch.WebApiClient;

namespace Sinch.ServerSdk.Calling
{
    public interface IConfigurationApiEndpoints
    {
        [HttpGet("/v1/configuration/callbacks/applications/{applicationKey}")]
        Task<GetCallbacksResponse> GetCallbacks([ToUri] string applicationKey);

        
        [HttpPost("/v1/configuration/callbacks/applications/{applicationKey}")]
        Task UpdateCallbacks([ToUri] string applicationKey, [ToBody] CallbackUrl callbackUrl);


        [HttpGet("/v1/configuration/numbers/")]
        Task<NumbersResponse> GetNumbers();

        [HttpPost("/v1/configuration/numbers/")]
        Task UpdateNumbers([ToBody] UpdateNumberRequest updateNumbers);



    }
}