namespace Sinch.ServerSdk.Calling.Callbacks.Request
{
    public interface  ICli
    {
        CliMode Mode { get; }
        string Numeric { get; }
        string AlphaNumeric { get; }
        string Full { get; }
    }
}
