using System.Threading.Tasks;

namespace Sinch.ServerSdk.Messaging.V2
{
    /// <summary>
    /// Provides methods to interact with the Sinch Sms Product
    /// </summary>
    public interface ISmsApi
    {
        /// <summary>
        /// Create an Sms ready to send via <see cref="ISmsSend.Send"/>
        /// </summary>
        /// <param name="to">The number of the recipient of this Sms. Must be a valid number in international format (eg. "+46700123456")</param>
        /// <param name="message">The message text to send</param>
        /// <returns>An instance of <see cref="ISms"/> used for issuing the Send request</returns>
        ISms Sms(string to, string message);

        /// <summary>
        /// Asynchronously gets the ongoing status of a given Send request
        /// </summary>
        /// <param name="messageId">The Id of the sent message specified in <see cref="ISendSmsResponse.MessageId"/></param>
        /// <returns>An ongoing task with the response containing the status of the Send request</returns>
        Task<IGetStatusResponse> GetSmsStatus(string messageId);
    }
}