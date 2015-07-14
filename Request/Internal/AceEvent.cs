namespace Sinch.Callback.Request.Internal
{
    public class AceEvent : CallingCallbackEvent, IAceEvent
    {
        public AceEvent()
        {
            Event = Event.AnsweredCall;
        }
    }
}