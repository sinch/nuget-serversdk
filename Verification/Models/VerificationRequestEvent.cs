using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Verification.Models
{
    /// <summary>
    /// An initiate verification request callback object
    /// </summary>
    public class VerificationRequestEvent
    {
        /// <summary>
        /// The identity of the verification
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The type of callback event: will be "VerificationRequestEvent"
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
        /// The cost of this verification
        /// </summary>
        public MoneyModel Price { get; set; }

        /// <summary>
        /// A custom reference string used in this verification
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// A custom string used in this verification
        /// </summary>
        public string Custom { get; set; }
    }
}
