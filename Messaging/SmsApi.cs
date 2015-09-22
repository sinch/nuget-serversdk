using System.Threading.Tasks;
using Sinch.ServerSdk.Messaging.Models;

namespace Sinch.ServerSdk.Messaging
{
    public interface ISmsApi
    {
        Sms Sms(string to, string message);
        Task<GetSmsStatusResponse> GetSmsStatus(int messageId);
    }

    class SmsApi : ISmsApi
    {
        private readonly ISmsApiEndpoints _smsApiEndpoints;
        
        public SmsApi(ISmsApiEndpoints smsApiEndpoints)
        {
            _smsApiEndpoints = smsApiEndpoints;
        }

        public Sms Sms(string to, string message)
        {
            return new Sms(_smsApiEndpoints, to, message);
        }

        public Task<GetSmsStatusResponse> GetSmsStatus(int messageId)
        {
            return _smsApiEndpoints.GetSmsStatus(messageId);
        }
    }
}