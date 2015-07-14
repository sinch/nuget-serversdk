namespace Sinch.Callback.Request.Internal
{
    internal class PieEvent : CallingCallbackEvent, IPieEvent
    {
        public PieEvent()
        {
            Event = Event.PromptInput;
        }

        public string Reference { get; set; }
        public string MenuId { get; set; }
        public IMenuResult Result { get; set; }
    }
}