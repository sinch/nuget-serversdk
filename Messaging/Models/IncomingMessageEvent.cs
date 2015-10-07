
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Messaging.Models
{
    public class IncomingMessageEvent
    {
        public IdentityModel From { get; set; }
        public IdentityModel To { get; set; }
        public string Message { get; set; }
        public string Event { get; set; }
        public string Timestamp { get; set; }
        public int Version { get; set; }
    }
}