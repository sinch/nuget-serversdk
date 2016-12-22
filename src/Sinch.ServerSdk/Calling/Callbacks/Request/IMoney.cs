namespace Sinch.ServerSdk.Calling.Callbacks.Request
{
    public interface IMoney
    {
        decimal Amount { get; }
        string CurrencyId { get; }
    }
}