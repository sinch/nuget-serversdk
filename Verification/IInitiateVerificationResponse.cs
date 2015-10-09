
namespace Sinch.ServerSdk.Verification
{
    public interface IInitiateVerificationResponse
    {
        string Id { get; set; }
        ISmsVerificationData Sms { get; set; }
        IFlashCallVerificationData FlashCall { get; set; }
        ICalloutVerificationData Callout { get; set; }
    }

    public interface ISmsVerificationData
    {
        string Template { get; set; }
        int InterceptionTimeout { get; set; }
    }
    public interface IFlashCallVerificationData
    {
        string CliFilter { get; set; }
        int InterceptionTimeout { get; set; }
    }
    public interface ICalloutVerificationData
    {
        int StartPollingAfter { get; set; }
        int StopPollingAfter { get; set; }
        int PollingInterval { get; set; }
    }
}
