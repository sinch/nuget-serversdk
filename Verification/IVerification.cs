using System.Threading.Tasks;

namespace Sinch.ServerSdk.Verification
{
    public interface IVerification : IVerificationWith
    {
        Task<IInitiateVerificationResponse> Initiate(VerificationMethod method);
        Task<IReportVerificationResponse> Report(VerificationMethod method);
        Task<IVerificationResultResponse> Get();
    }

    public interface IVerificationWith
    {
        IVerification WithReference(string reference);
        IVerification WithCustom(string custom);
        IVerification WithCli(string cli);
        IVerification WithCode(string code);
        IVerification WithId(string id);
    }
}
