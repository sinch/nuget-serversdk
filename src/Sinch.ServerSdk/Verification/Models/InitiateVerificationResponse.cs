
namespace Sinch.ServerSdk.Verification.Models
{
    public class InitiateVerificationResponse
    {
        public string Id { get; set; }
        public SmsVerificationData Sms { get; set; }
        public FlashCallVerificationData FlashCall { get; set; }
        public CalloutVerificationData Callout { get; set; }
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
