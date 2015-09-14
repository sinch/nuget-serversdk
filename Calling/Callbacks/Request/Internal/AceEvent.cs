namespace Sinch.ServerSdk.Calling.Callbacks.Request.Internal
{
    public class AceEvent : CallingCallbackEvent, IAceEvent
    {
        public AceEvent()
        {
            Event = Event.AnsweredCall;
        }
    }
}