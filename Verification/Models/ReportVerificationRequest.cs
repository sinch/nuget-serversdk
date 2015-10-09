

namespace Sinch.ServerSdk.Verification.Models
{
    public class ReportVerificationRequest
    {
        public string Method { get; set; }
        public SmsVerificationReportData Sms { get; set; }
        public FlashCallVerificationReportData FlashCall { get; set; }
    }

    public class SmsVerificationReportData
    {
        public string Code { get; set; }
        public string Cli { get; set; }
    }
    public class FlashCallVerificationReportData
    {
        public string Cli { get; set; }
    }
}
