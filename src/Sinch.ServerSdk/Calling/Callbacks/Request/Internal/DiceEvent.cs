using System;

namespace Sinch.ServerSdk.Calling.Callbacks.Request.Internal
{
    internal class DiceEvent : CallingCallbackEvent, IDiceEvent
    {
        public DiceEvent()
        {
            Event = Event.DisconnectedCall;
        }

        public TimeSpan Duration { get; set; }
        public Result Result { get; set; }
        public Reason Reason { get; set; }
        public IMoney Debit { get; set; }
        public IMoney Rate { get; set; }
        public string From { get; set; }
        public IIdentity To { get; set; }
    }
}