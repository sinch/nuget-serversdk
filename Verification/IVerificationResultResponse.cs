
namespace Sinch.ServerSdk.Verification
{
    public interface IVerificationResultResponse
    {
        string Id { get; set; }
        string Method { get; set; }
        string Status { get; set; }
        string Reason { get; set; }
        string Reference { get; set; }
        string Source { get; set; }
    }
}
