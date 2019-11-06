using Newtonsoft.Json;
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Callouts
{
    public class TtsCalloutRequest : ITtsCalloutRequest
    {
        /// <summary>
        /// The from number in e164 format
        /// </summary>
        [JsonProperty(PropertyName = "cli", NullValueHandling = NullValueHandling.Ignore)]
        public string Cli { get; set; }
        [JsonProperty(PropertyName = "destination", NullValueHandling = NullValueHandling.Ignore)]
        public IdentityModel Destination { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, PropertyName = "dtmf")]
        public string Dtmf { get; set; }
        [JsonProperty(PropertyName = "domain", NullValueHandling = NullValueHandling.Ignore)]
        public string Domain { get; set; }
        [JsonProperty(PropertyName = "custom", NullValueHandling = NullValueHandling.Ignore)]
        public string Custom { get; set; }
        [JsonProperty(PropertyName = "locale", NullValueHandling = NullValueHandling.Ignore)]
        public string Locale { get; set; }
        [JsonProperty(PropertyName = "text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "prompts", NullValueHandling = NullValueHandling.Ignore)]
        public string Prompts { get; set; }
        [JsonProperty(PropertyName = "enableDice", NullValueHandling = NullValueHandling.Ignore)]
        public bool EnableDice { get; set; }
        [JsonProperty(PropertyName = "enableAce", NullValueHandling = NullValueHandling.Ignore)]
        public bool EnableAce { get; set; }
        [JsonProperty(PropertyName = "enablePie", NullValueHandling = NullValueHandling.Ignore)]
        public bool EnablePie { get; set; }

    

        public ITtsCalloutRequest AddPrompt(string promptName)
        {
            Prompts += ";" + promptName;
            return this;
        }
    
        public ITtsCalloutRequest AddText(string text)
        {
            Prompts += ";" + text;
            return this;
        }
    }
}
