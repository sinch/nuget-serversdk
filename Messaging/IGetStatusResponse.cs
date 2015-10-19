namespace Sinch.ServerSdk.Messaging
{
    /// <summary>
    /// The response to a <see cref="ISmsApi.GetSmsStatus(int)"/> request
    /// </summary>
    public interface IGetStatusResponse
    {
        /// <summary>
        /// The status of the Send request. Can be one of:
        /// 
        /// Successful - The message has been delivered to the recipient
        /// Pending - The message is in the process of being delivered
        /// Faulted - The message has not been delivered
        /// Unknown - The provided messageId is not known
        /// </summary>
        string Status { get; }
    }
}