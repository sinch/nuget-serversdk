namespace Sinch.Callback.Request
{
    public interface IPieEvent : ICallbackEvent
    {
        string Reference { get; }
        string MenuId { get; }
        IMenuResult MenuResult { get; }
    }
}