using System;
using System.Collections.Generic;

namespace Sinch.ServerSdk.Calling.Callbacks.Request
{
    public interface ICallbackEvent
    {
        Event Event { get; }
        string CallId { get; }
        DateTime Timestamp { get; }
        int Version { get; }
        string Custom { get; }
        string User { get; }
        IDictionary<string, string> Cookies { get; }
        string ApplicationKey { get; }
    }
}