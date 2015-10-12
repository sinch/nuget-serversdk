
namespace Sinch.ServerSdk.Verification
{
    public interface IInitiateVerificationResponse
    {
        string Id { get; }
        ISmsVerificationData Sms { get; }
        IFlashCallVerificationData FlashCall { get; }
        ICalloutVerificationData Callout { get; }
    }

    public interface ISmsVerificationData
    {
        string Template { get; }
        int InterceptionTimeout { get; }
    }
    public interface IFlashCallVerificationData
    {
        string CliFilter { get; }
        int InterceptionTimeout { get; }
    }
    public interface ICalloutVerificationData
    {
        int StartPollingAfter { get; }
        int StopPollingAfter { get; }
        int PollingInterval { get; }
    }
}
