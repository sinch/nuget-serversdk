
namespace Sinch.ServerSdk.Verification.Models
{
    public class VerificationRequestEventResponse
    {
        public class SmsData
        {
            public string Code { get; set; }
        }
        public class FlashCallData
        {
            public string Cli { get; set; }
        }
        public class CalloutData
        {
            public string Locale { get; set; }
            public string TtsMenu { get; set; }
            public string WavFile { get; set; }
            public string Pin { get; set; }
            public int Timeout { get; set; }
        }

        public string Action { get; set; }
        public SmsData Sms { get; set; }
        public FlashCallData FlashCall { get; set; }
        public CalloutData Callout { get; set; }
    }
}
