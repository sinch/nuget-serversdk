using System.Threading.Tasks;
using Sinch.ServerSdk.Messaging.Models;
using Sinch.WebApiClient;
using SendSmsResponse = Sinch.ServerSdk.Messaging.V2.Models.SendSmsResponse;

namespace Sinch.ServerSdk.Messaging.V2
{
    /// <summary>
    /// Interface defining the Sinch SMS REST API
    /// </summary>
    public interface ISmsApiEndpoints
    {
        [HttpPost("messaging/v1/sms/{+toNumber}")]
        Task<SendSmsResponse> SendSms([ToUri] string toNumber, [ToBody] SendSmsRequest request);

        [HttpGet("messaging/v1/sms/{messageId}")]
        Task<GetStatusResponse> GetSmsStatus([ToUri] string messageId);
    }
}