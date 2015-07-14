using System;
using System.Collections.Generic;

namespace Sinch.Callback.Request.Internal
{
    public class CallingCallbackEvent : ICallbackEvent
    {
        public Event Event { get; protected set; }
        public string CallId { get; set; }
        public DateTime Timestamp { get; set; }
        public int Version { get; set; }
        public string Custom { get; set; }
        public string User { get; set; }
        public IDictionary<string,string> Cookies { get; set; }
        public string ApplicationKey { get; set; }

        public override string ToString()
        {
            return Event + "@" + Timestamp;
        }
    }
}