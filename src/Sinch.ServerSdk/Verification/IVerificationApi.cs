
namespace Sinch.ServerSdk.Verification
{
    /// <summary>
    /// Provides methods to interact with the Sinch Verification Product
    /// </summary>
    public interface IVerificationApi
    {
        /// <summary>
        /// Constructs a verification used to <see cref="IVerification.Get"/> the status of an ongoing verification
        /// </summary>
        /// <returns>An instance of <see cref="IVerification"/> used to get Sinch verifications</returns>
        /// <remarks>
        /// This verification can only be used for <see cref="IVerification.Get"/> requests, which must be built with either
        /// <see cref="IVerificationWith.WithId(string)"/> or <see cref="IVerificationWith.WithReference(string)"/>
        /// </remarks>
        IVerification Verification();

        /// <summary>
        /// Constructs a verification used to <see cref="IVerification.Initiate(VerificationMethod)"/>, <see cref="IVerification.Report(VerificationMethod)"/>,
        /// or <see cref="IVerification.Get"/> a Sinch verification
        /// </summary>
        /// <param name="number">The number to be verified. Must be a valid number in international format (eg. "+46700123456")</param>
        /// <returns>An instance of <see cref="IVerification"/> used to initiate, report, and get Sinch verifications</returns>
        IVerification Verification(string number);
    }
}
