﻿namespace Sinch.ServerSdk.Calling.Callbacks.Request.Internal
{
    internal class PieEvent : CallingCallbackEvent, IPieEvent
    {
        public PieEvent()
        {
            Event = Event.PromptInput;
        }

        public string Reference { get; set; }
        public string MenuId { get; set; }
        public IMenuResult MenuResult { get; set; }
    }
}