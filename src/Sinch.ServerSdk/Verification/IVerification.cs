using System.Threading.Tasks;

namespace Sinch.ServerSdk.Verification
{
    /// <summary>
    /// A verification object that can be used to initiate/report/get a Sinch verification
    /// </summary>
    public interface IVerification : IVerificationWith
    {
        /// <summary>
        /// Asynchronously issue an initiate verification request
        /// </summary>
        /// <param name="method">The verification method: (sms, flashcall, callout)</param>
        /// <returns>An ongoing task containing the response to the Initiate request</returns>
        /// <remarks>
        /// You can include additional information to this request via <see cref="IVerificationWith.WithReference(string)"/> and
        /// <see cref="IVerificationWith.WithCustom(string)"/>
        /// </remarks>
        Task<IInitiateVerificationResponse> Initiate(VerificationMethod method);

        /// <summary>
        /// Asynchronously issue a report verification request
        /// </summary>
        /// <param name="method">The verification method: (sms, flashcall, callout)</param>
        /// <returns>An ongoing task containing the response to the Report request</returns>
        /// <remarks>
        /// You can include additional information with this request via <see cref="IVerificationWith.WithCli(string)"/> or
        /// <see cref="IVerificationWith.WithCode(string)"/>. For flashcall and callout verifications the Cli is required. For 
        /// Sms verifications the Code is required
        /// </remarks>
        Task<IReportVerificationResponse> Report(VerificationMethod method);

        /// <summary>
        /// Asynchronously issue a get verification request
        /// </summary>
        /// <returns>An ongoing task containing the response to the Get request</returns>
        /// <remarks>
        /// You can include additional information with this request via <see cref="IVerificationWith.WithId(string)"/> or
        /// <see cref="IVerificationWith.WithReference(string)"/>. If you specify both Id and Reference the Id will be used.
        /// Both Id and Reference can be omitted if you used <see cref="IVerificationApi.Verification(string)"/> to create your
        /// verification object but either will override the number if specified.
        /// </remarks>
        Task<IVerificationResultResponse> Get();
    }

    /// <summary>
    /// Provides methods that add additional data to a verification request
    /// </summary>
    public interface IVerificationWith
    {
        /// <summary>
        /// Include a custom reference to the verification request. Used with <see cref="IVerification.Report(VerificationMethod)"/> or
        /// <see cref="IVerification.Get"/> requests
        /// </summary>
        /// <param name="reference">A custom reference string</param>
        /// <returns>The current verification request object</returns>
        IVerification WithReference(string reference);

        /// <summary>
        /// Add a custom string to the verification request. Used with a <see cref="IVerification.Initiate(VerificationMethod)"/> request
        /// </summary>
        /// <param name="custom">A custom string</param>
        /// <returns>The current verification request object</returns>
        IVerification WithCustom(string custom);

        /// <summary>
        /// Add the Caller Id in a <see cref="IVerification.Report(VerificationMethod)"/> request. This is required for flashcall and callout
        /// verifications
        /// </summary>
        /// <param name="cli">The Caller Id</param>
        /// <returns>The current verification request object</returns>
        IVerification WithCli(string cli);

        /// <summary>
        /// The verification code used in a <see cref="IVerification.Report(VerificationMethod)"/> request for Sms verifications.
        /// </summary>
        /// <param name="code">The verification code</param>
        /// <returns>The current verification request object</returns>
        IVerification WithCode(string code);

        /// <summary>
        /// The identity of the verification used in a <see cref="IVerification.Get"/> request. This value can be obtained via
        /// <see cref="IInitiateVerificationResponse.Id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The current verification request object</returns>
        IVerification WithId(string id);
    }
}
