namespace Sinch.ServerSdk.Models
{
    public class Locale 
    {
        public static readonly Locale EnUs = new Locale { Code = "en-US"};
        public static readonly Locale FrFr = new Locale { Code = "fr-FR" };
        public static readonly Locale PlPl = new Locale { Code = "pl-PL" };
        public static readonly Locale EsEs = new Locale { Code = "es-ES" };

        public string Code { get; private set; }
    }
}
