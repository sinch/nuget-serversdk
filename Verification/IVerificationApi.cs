
namespace Sinch.ServerSdk.Verification
{
    public interface IVerificationApi
    {
        IVerification Verification();
        IVerification Verification(string endpoint);
    }
}
