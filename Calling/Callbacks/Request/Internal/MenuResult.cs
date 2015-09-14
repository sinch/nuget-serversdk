namespace Sinch.ServerSdk.Calling.Callbacks.Request.Internal
{
    public class MenuResult : IMenuResult
    {
        public MenuResultType Type { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Type + "=" + (Value ?? "<null value>");
        }
    }
}