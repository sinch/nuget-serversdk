
namespace Sinch.ServerSdk.Verification
{
    public interface IReportVerificationResponse
    {
        string Id { get; }
        string Method { get; }
        string Status { get; }
        string Reason { get; }
        string Reference { get; }
        string Source { get; }
    }
}
