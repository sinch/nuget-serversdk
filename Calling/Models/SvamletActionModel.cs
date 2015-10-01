using Newtonsoft.Json;
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Calling.Models
{
    public class SvamletActionModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "destination", NullValueHandling = NullValueHandling.Ignore)]
        public IdentityModel Destination { get; set; }

        [JsonProperty(PropertyName = "number", NullValueHandling = NullValueHandling.Ignore)]
        public string Number { get; set; }

        [JsonProperty(PropertyName = "cli", NullValueHandling = NullValueHandling.Ignore)]
        public string Cli { get; set; }

        [JsonProperty(PropertyName = "maxDuration", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MaxDuration { get; set; }

        [JsonProperty(PropertyName = "dialTimeout", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int DialTimeout { get; set; }

        [JsonProperty(PropertyName = "locale", NullValueHandling = NullValueHandling.Ignore)]
        public string Locale { get; set; }

        [JsonProperty(PropertyName = "altLocale", NullValueHandling = NullValueHandling.Ignore)]
        public string AlternativeLocale { get; set; }

        [JsonProperty(PropertyName = "mainMenu", NullValueHandling = NullValueHandling.Ignore)]
        public string MainMenu { get; set; }

        [JsonProperty(PropertyName = "menus", NullValueHandling = NullValueHandling.Ignore)]
        public MenuModel[] Menus { get; set; }

        [JsonProperty(PropertyName = "reference", NullValueHandling = NullValueHandling.Ignore)]
        public string Reference { get; set; }

        [JsonProperty(PropertyName = "conferenceId", NullValueHandling = NullValueHandling.Ignore)]
        public string ConferenceId { get; set; }
        
        [JsonProperty(PropertyName = "suppressCallbacks", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool SuppressCallbacks { get; set; }

        [JsonProperty(PropertyName = "suppressErrorPrompts", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool SuppressErrorPrompts { get; set; }

        [JsonProperty(PropertyName = "introPrompt", NullValueHandling = NullValueHandling.Ignore)]
        public string IntroPrompt { get; set; }

        [JsonProperty(PropertyName = "holdPrompt", NullValueHandling = NullValueHandling.Ignore)]
        public string HoldPrompt { get; set; }

        [JsonProperty(PropertyName = "barge", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Barge { get; set; }

        [JsonProperty(PropertyName = "hangupCause", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int HangupCause { get; set; }

        [JsonProperty(PropertyName = "record", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Record { get; set; }

        [JsonProperty(PropertyName = "moh", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Moh { get; set; }

        [JsonProperty(PropertyName = "indications", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Indications { get; set; }

        [JsonProperty(PropertyName = "_internal", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Internal { get; set; }
    }
}