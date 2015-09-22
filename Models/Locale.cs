namespace Sinch.ServerSdk.Models
{
    public class Locale 
    {
        public static readonly Locale EnUs = new Locale { Code = "en-US"};

        public string Code { get; private set; }
    }
}
