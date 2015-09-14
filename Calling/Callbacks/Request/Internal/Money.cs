namespace Sinch.ServerSdk.Calling.Callbacks.Request.Internal
{
    internal class Money : IMoney
    {
        public decimal Amount { get; set; }
        public string CurrencyId { get; set; }

        public override string ToString()
        {
            return Amount + (CurrencyId ?? "<no currency>");
        }

    }
}
