
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Messaging.Models
{
    /// <summary>
    /// An incoming Sms callback event
    /// </summary>
    public class IncomingMessageEvent
    {
        /// <summary>
        /// The identity of the sender
        /// </summary>
        public IdentityModel From { get; set; }

        /// <summary>
        /// The identity of the recipient
        /// </summary>
        public IdentityModel To { get; set; }

        /// <summary>
        /// The message text
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The event type: will be "incomingSms"
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// The timestamp of the sent message represented by a string in ISO 8601 format
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Currently always 1
        /// </summary>
        public int Version { get; set; }
    }
}