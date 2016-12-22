namespace Sinch.ServerSdk.Calling.Callbacks.Request.Internal
{
    internal class NotificationEvent : CallingCallbackEvent, INotificationEvent
    {
        public NotificationEvent()
        {
            Event = Event.Notification;
        }

        public string Type { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMsg { get; set; }
    }
}
