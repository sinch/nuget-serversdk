namespace Sinch.Callback.Request.Internal
{
    internal class NotificationEvent : CallingCallbackEvent, INotificationEvent
    {
        public string Type { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMsg { get; set; }
    }
}
