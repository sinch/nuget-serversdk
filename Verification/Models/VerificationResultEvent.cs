using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Verification.Models
{
    public class VerificationResultEvent
    {
        public string Id { get; set; }
        public string Event { get; set; }
        public string Method { get; set; }
        public IdentityModel Identity { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public string Reference { get; set; }
        public string Source { get; set; }
    }
}
