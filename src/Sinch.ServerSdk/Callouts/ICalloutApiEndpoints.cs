using System.Threading.Tasks;
using Sinch.ServerSdk.Callouts;
using Sinch.WebApiClient;

public interface ICalloutApiEndpoints
{
    [HttpPost("calling/v1/callouts")]
    Task<CalloutResponse> Callout([ToBody] CalloutRequest request);
}