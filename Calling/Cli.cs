using Sinch.ServerSdk.Calling.Callbacks.Request;

namespace Sinch.ServerSdk.Calling
{
    internal class Cli : ICli
    {
        public CliMode Mode { get; set; }
        public string Numeric { get; set; }
        public string AlphaNumeric { get; set; }
        public string Full { get; set; }

        public override string ToString()
        {
            return Full;
        }
    }
}
