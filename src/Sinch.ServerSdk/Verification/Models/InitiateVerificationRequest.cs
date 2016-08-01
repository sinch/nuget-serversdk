using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Verification.Models
{
    public class InitiateVerificationRequest
    {
        public IdentityModel Identity { get; set; }
        public string Method { get; set; }
        public string Reference { get; set; }
        public string Custom { get; set; }
    }
}
