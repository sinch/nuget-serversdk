using System.Threading.Tasks;
using Sinch.ServerSdk.Models;
using Sinch.ServerSdk.Verification.Models;
using Sinch.WebApiClient;

namespace Sinch.ServerSdk.Verification
{
    public interface IVerificationApiEndpoints
    {
        [HttpPost("verification/v1/verifications")]
        Task<InitiateVerificationResponse> InitiateVerification([ToBody] InitiateVerificationRequest request);

        [HttpPut("verification/v1/verifications/{type}/{endpoint}")]
        Task<ReportVerificationResponse> ReportVerification([ToUri] IdentityModel identity, [ToBody] ReportVerificationRequest request);

        [HttpGet("verification/v1/verifications/{type}/{endpoint}")]
        Task<VerificationResultResponse> GetVerification([ToUri] IdentityModel identity);

        [HttpGet("verification/v1/verifications/id/{id}")]
        Task<VerificationResultResponse> GetVerificationById([ToUri] string id);

        [HttpGet("verification/v1/verifications/reference/{reference}")]
        Task<VerificationResultResponse> GetVerificationByReference([ToUri] string reference);
    }
}
