namespace Sinch.ServerSdk.Messaging.Models
{
    /// <summary>
    /// Request for SendSms method
    /// </summary>
    public class SendSmsRequest
    {
        /// <summary>
        /// Displays as the sender's CLI.  (Caller ID)
        /// This is optional.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Text of the SMS
        /// </summary>
        public string Message { get; set; }
    }
}