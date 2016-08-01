using System.Threading.Tasks;

namespace Sinch.ServerSdk.Messaging
{
    /// <summary>
    /// Provides methods that issue an asynchronous Send Sms request with optional Caller Id
    /// </summary>
    public interface ISms : ISmsSend, ISmsWithCli { }

    /// <summary>
    /// Adds method for sending an Sms
    /// </summary>
    public interface ISmsSend
    {
        /// <summary>
        /// Issue an asynchronous Send request
        /// </summary>
        /// <returns>A task representing the response of the Send request</returns>
        /// <remarks>Use <see cref="ISmsApi.GetSmsStatus(int)"/> to get the ongoing status of the Send request</remarks>
        Task<ISendSmsResponse> Send();
    }

    /// <summary>
    /// Adds the ability to include the Caller Id with sent messages
    /// </summary>
    public interface ISmsWithCli
    {
        /// <summary>
        /// Add the cli to the sent message
        /// </summary>
        /// <param name="from">The Caller Id to be displayed as the 'from' field</param>
        /// <returns>The current Sms request object</returns>
        ISmsSend WithCli(string from);
    }
}