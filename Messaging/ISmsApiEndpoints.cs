using System.Threading.Tasks;
using Sinch.ServerSdk.Messaging.Models;
using Sinch.WebApiClient;

namespace Sinch.ServerSdk.Messaging
{
    public interface ISmsApiEndpoints
    {
        [HttpPost("messaging/v1/sms/{toNumber}")]
        Task<SendSmsResponse> SendSms([ToUri] string toNumber, [ToBody] SendSmsRequest request);

        [HttpGet("messaging/v1/sms/{messageId}")]
        Task<GetSmsStatusResponse> GetSmsStatus([ToUri] int messageId);
    }
}