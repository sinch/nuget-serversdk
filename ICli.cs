using Sinch.Callback.Request;

namespace Sinch.Callback
{
    public interface  ICli
    {
        CliMode Mode { get; }
        string Numeric { get; }
        string AlphaNumeric { get; }
        string Full { get; }
    }
}
