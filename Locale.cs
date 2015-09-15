namespace Sinch.ServerSdk
{
    public class Locale
    {
        public static readonly Locale EnUs = new Locale("en-US");

        public Locale(string code)
        {
            Code = code;
        }

        public string Code { get; private set; }
    }
}
