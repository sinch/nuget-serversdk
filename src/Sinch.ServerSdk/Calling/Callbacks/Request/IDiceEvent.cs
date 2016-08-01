using System;

namespace Sinch.ServerSdk.Calling.Callbacks.Request
{
    public interface IDiceEvent : ICallbackEvent
    {
        TimeSpan Duration { get; }
        Result Result { get; }
        Reason Reason { get; }
        IMoney Debit { get; }
        IMoney Rate { get; }
        string From { get; }
        IIdentity To { get; }
    }
}