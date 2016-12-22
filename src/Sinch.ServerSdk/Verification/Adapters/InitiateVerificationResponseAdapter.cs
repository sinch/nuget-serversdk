using Sinch.ServerSdk.Verification.Models;

namespace Sinch.ServerSdk.Verification.Adapters
{
    internal class InitiateVerificationResponseAdapter : IInitiateVerificationResponse
    {
        private readonly InitiateVerificationResponse _initiateVerificationResponse;

        public InitiateVerificationResponseAdapter(InitiateVerificationResponse initiateVerificationResponse)
        {
            _initiateVerificationResponse = initiateVerificationResponse;
        }

        public string Id => _initiateVerificationResponse.Id;

        public ISmsVerificationData Sms => _initiateVerificationResponse.Sms;
        public IFlashCallVerificationData FlashCall => _initiateVerificationResponse.FlashCall;
        public ICalloutVerificationData Callout => _initiateVerificationResponse.Callout;
    }
}
