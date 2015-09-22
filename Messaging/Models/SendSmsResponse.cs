namespace Sinch.ServerSdk.Messaging.Models
{
    public class SendSmsResponse
    {
        /// <summary>
        /// Message ID of the SendSms request.  
        /// It can be passed to GetSmsStatus to check the status of the SendSms request.
        /// </summary>
        public int MessageId { get; set; }
    }
}