using System.Threading.Tasks;

namespace Sinch.ServerSdk.Messaging.Fluent
{
    class SmsApi : ISmsApi
    {
        private readonly ISmsApiEndpoints _smsApiEndpoints;
        
        public SmsApi(ISmsApiEndpoints smsApiEndpoints)
        {
            _smsApiEndpoints = smsApiEndpoints;
        }

        public ISms Sms(string to, string message)
        {
            return new Sms(_smsApiEndpoints, to, message);
        }

        public async Task<IGetStatusResponse> GetSmsStatus(int messageId)
        {
            return await _smsApiEndpoints.GetSmsStatus(messageId).ConfigureAwait(false);
        }
    }
}