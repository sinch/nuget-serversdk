namespace Sinch.ServerSdk.Messaging.V2
{
    /// <summary>
    /// The response to a <see cref="ISmsSend.Send"/> request
    /// </summary>
    public interface ISendSmsResponse
    {
        /// <summary>
        /// The id of the Send request. Use this value with <see cref="ISmsApi.GetSmsStatus(string)"/> to retrieve
        /// the status of the Send request
        /// </summary>
        string MessageId { get; }
    }
}
