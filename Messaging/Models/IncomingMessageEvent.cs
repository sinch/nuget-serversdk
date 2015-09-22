
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Messaging.Models
{
    public class IncomingMessageEvent
    {
        public Identity From { get; set; }
        public Identity To { get; set; }
        public string Message { get; set; }
        public string Event { get; set; }
        public string Timestamp { get; set; }
        public int Version { get; set; }
    }
}