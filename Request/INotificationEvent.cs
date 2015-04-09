namespace Sinch.Callback.Request
{
    public interface INotificationEvent
    {
        string Type { get; }
        int ErrorCode { get; }
        string ErrorMsg { get; }
    }
}
