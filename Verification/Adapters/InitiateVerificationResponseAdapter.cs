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

        public string Id { get { return _initiateVerificationResponse.Id; } }

        public ISmsVerificationData Sms { get { return _initiateVerificationResponse.Sms; } }
        public IFlashCallVerificationData FlashCall { get { return _initiateVerificationResponse.FlashCall; } }   
        public ICalloutVerificationData Callout { get { return _initiateVerificationResponse.Callout; } }
    }
}
