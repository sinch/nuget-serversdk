namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public class Locale
    {
        public static readonly Locale EnUs = new Locale("en-US");
        public static readonly Locale SvSe = new Locale("sv-SE");

        public Locale(string code)
        {
            Code = code;
        }

        public string Code { get; private set; }
    }
}
