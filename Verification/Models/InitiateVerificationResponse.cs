
namespace Sinch.ServerSdk.Verification.Models
{
    public class InitiateVerificationResponse : IInitiateVerificationResponse
    {
        public string Id { get; set; }
        public ISmsVerificationData Sms { get; set; }
        public IFlashCallVerificationData FlashCall { get; set; }
        public ICalloutVerificationData Callout { get; set; }
    }

    public class SmsVerificationData : ISmsVerificationData
    {
        public string Template { get; set; }
        public int InterceptionTimeout { get; set; }
    }

    public class FlashCallVerificationData : IFlashCallVerificationData
    {
        public string CliFilter { get; set; }
        public int InterceptionTimeout { get; set; }
    }

    public class CalloutVerificationData : ICalloutVerificationData
    {
        public int StartPollingAfter { get; set; }
        public int StopPollingAfter { get; set; }
        public int PollingInterval { get; set; }
    }
}
