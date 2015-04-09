namespace Sinch.Callback.Request.Internal
{
    internal class PieEvent : CallingCallbackEvent, IPieEvent
    {
        public string Reference { get; set; }
        public string MenuId { get; set; }
        public IMenuResult Result { get; set; }
    }
}