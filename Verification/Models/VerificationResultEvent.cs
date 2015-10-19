using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Verification.Models
{
    /// <summary>
    /// An verification result callback object that is send on completion of a verification
    /// </summary>
    public class VerificationResultEvent
    {
        /// <summary>
        /// The identity of the verification
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The type of callback event: will be "VerificationResultEvent"
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// The verification method: (flashsall, sms, callout)
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// The identity of the number to be verified
        /// </summary>
        public IdentityModel Identity { get; set; }

        /// <summary>
        /// The status of this verification: (PENDING, SUCCESSFUL, FAIL)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The reason why the verification failed. Can be one of:
        /// 
        /// Successful, Denied, Failed pending, Sms delivery failure, Invalid code,
        /// Expired, Failed initiating flashCall, Failed flashCall result
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// The optional reference Id that was supplied with the <see cref="IVerification.Initiate(VerificationMethod)"/> request
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// Free text used to show if the call/sms was intercepted. Typical values are "intercepted" or 'manual"
        /// </summary>
        public string Source { get; set; }
    }
}
