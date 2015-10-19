
namespace Sinch.ServerSdk.Verification
{
    /// <summary>
    /// The response to a <see cref="IVerification.Get"/> request
    /// </summary>
    public interface IVerificationResultResponse
    {
        /// <summary>
        /// The identity of the verification
        /// </summary>
        string Id { get; }
        
        /// <summary>
        /// The verification method: (flashsall, sms, callout)
        /// </summary>
        string Method { get; }

        /// <summary>
        /// The status of this verification: (PENDING, SUCCESSFUL, FAIL)
        /// </summary>
        string Status { get; }

        /// <summary>
        /// The reason why the verification failed. Can be one of:
        /// 
        /// Successful, Denied, Failed pending, Sms delivery failure, Invalid code,
        /// Expired, Failed initiating flashCall, Failed flashCall result
        /// </summary>
        string Reason { get; }

        /// <summary>
        /// The optional reference Id that was supplied with the <see cref="IVerification.Initiate(VerificationMethod)"/> request
        /// </summary>
        string Reference { get; }

        /// <summary>
        /// Free text used to show if the call/sms was intercepted. Typical values are "intercepted" or 'manual"
        /// </summary>
        string Source { get; }
    }
}
