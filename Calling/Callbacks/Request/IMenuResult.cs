namespace Sinch.ServerSdk.Calling.Callbacks.Request
{
    public interface IMenuResult
    {
        MenuResultType Type { get; }
        string Value { get; }
    }
}