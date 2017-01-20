using Sinch.ServerSdk.Calling.Callbacks.Response;

namespace Sinch.ServerSdk.Models
{
    public class Locale 
    {
        public static readonly Locale EnUs = new Locale { Code = "en-US" };
        public static readonly Locale FrFr = new Locale { Code = "fr-FR" };
        public static readonly Locale PlPl = new Locale { Code = "pl-PL" };
        public static readonly Locale EsEs = new Locale { Code = "es-ES" };
        public static readonly Locale ItIt = new Locale { Code = "it-IT" };
        public static readonly Locale NbNo = new Locale { Code = "nb-NO" };
        public static readonly Locale DeDe = new Locale { Code = "de-DE" };
        public static readonly Locale DaDk = new Locale { Code = "da-DK" };
        public static readonly Locale FiFi = new Locale { Code = "fi-FI" };
        public static readonly Locale PtPt = new Locale { Code = "pt-PT" };
        public static readonly Locale RuRu = new Locale { Code = "ru-RU" };

        public static Locale CreateCustomLocale(string languageCode, string countryCode)
        {
            if(string.IsNullOrEmpty(languageCode))
                throw new BuilderException("Need to supply language code");

            if (string.IsNullOrEmpty(countryCode))
                throw new BuilderException("Need to supply country code");

            return new Locale
            {
                Code = $"{languageCode}-{countryCode}"
            };
        }

        public string Code { get; private set; }
    }
}
