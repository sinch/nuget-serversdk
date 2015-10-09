using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Verification.Models
{
    public class VerificationRequestEvent
    {
        public string Id { get; set; }
        public string Event { get; set; }
        public string Method { get; set; }
        public IdentityModel Identity { get; set; }
        public MoneyModel Price { get; set; }
        public string Reference { get; set; }
        public string Custom { get; set; }
    }
}
