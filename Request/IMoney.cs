namespace Sinch.Callback.Request
{
    public interface IMoney
    {
        decimal Amount { get; }
        string CurrencyId { get; }
    }
}