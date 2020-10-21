namespace Sinch.ServerSdk.Messaging.V2.Models
{
    public class SendSmsResponse : ISendSmsResponse
    {
        /// <summary>
        /// Message ID of the SendSms request.  
        /// It can be passed to GetSmsStatus to check the status of the SendSms request.
        /// </summary>
        public string MessageId { get; set; }
    }
}