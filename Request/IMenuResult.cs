namespace Sinch.Callback.Request
{
    public interface IMenuResult
    {
        MenuResultType Type { get; }
        string Value { get; }
    }
}