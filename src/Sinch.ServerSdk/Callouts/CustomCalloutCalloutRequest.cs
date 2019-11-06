using Newtonsoft.Json;

namespace Sinch.ServerSdk.Callouts
{
    public class CustomCalloutCalloutRequest : ICustomCalloutCalloutRequest
    {
        /// <summary>
        /// If you want to send a code to the conference, like conference pin, to pause prefix with v for 0.5 seconds. 
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, PropertyName = "dtmf")]
        public string Dtmf { get; set; }
        [JsonProperty(PropertyName = "ice", NullValueHandling = NullValueHandling.Ignore)]
        public string Ice { get; set; }

        [JsonProperty(PropertyName = "ace", NullValueHandling = NullValueHandling.Ignore)]
        public string Ace { get; set; }

        [JsonProperty(PropertyName = "Pie", NullValueHandling = NullValueHandling.Ignore)]
        public string Pie { get; set; }

        [JsonProperty(PropertyName = "dice", NullValueHandling = NullValueHandling.Ignore)]
        public string Dice { get; set; }

        [JsonProperty(PropertyName = "custom", NullValueHandling = NullValueHandling.Ignore)]
        public string Custom { get; set; }



        
    }
}