
namespace Sinch.ServerSdk.Verification
{
    /// <summary>
    /// The response to a <see cref="IVerification.Initiate(VerificationMethod)"/> request
    /// </summary>
    public interface IInitiateVerificationResponse
    {
        /// <summary>
        /// The identity of the verification. Use this value with <see cref="IVerification.Get().WithId(string)"/> to retrieve the
        /// ongoing status of this verification
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Data associated with this sms verification
        /// </summary>
        ISmsVerificationData Sms { get; }

        /// <summary>
        /// Data associated with this flashcall verification
        /// </summary>
        IFlashCallVerificationData FlashCall { get; }

        /// <summary>
        /// Data associated with this callout verification
        /// </summary>
        ICalloutVerificationData Callout { get; }
    }

    /// <summary>
    /// Sms verification-specific data
    /// </summary>
    public interface ISmsVerificationData
    {
        /// <summary>
        /// The Sms template text that will include the verification code
        /// </summary>
        string Template { get; }

        /// <summary>
        /// The timeout in seconds in which the client should expect a verification sms
        /// </summary>
        int InterceptionTimeout { get; }
    }

    /// <summary>
    /// Flashcall verification-specific data
    /// </summary>
    public interface IFlashCallVerificationData
    {
        /// <summary>
        /// Caller Id filter
        /// </summary>
        string CliFilter { get; }

        /// <summary>
        /// The timeout in seconds in which the client should expect a verification flashcall
        /// </summary>
        int InterceptionTimeout { get; }
    }

    /// <summary>
    /// Callout verification-specific data
    /// </summary>
    public interface ICalloutVerificationData
    {
        /// <summary>
        /// Time in seconds after which polling for verification should begin
        /// </summary>
        int StartPollingAfter { get; }

        /// <summary>
        /// Time in seconds after which polling for verification should end
        /// </summary>
        int StopPollingAfter { get; }

        /// <summary>
        /// Polling interval in seconds while waiting for the client to verify the callout
        /// </summary>
        int PollingInterval { get; }
    }
}
