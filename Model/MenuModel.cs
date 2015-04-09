using Newtonsoft.Json;

namespace Sinch.Callback.Model
{
    public class MenuModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "options", NullValueHandling = NullValueHandling.Ignore)]
        public MenuOptionModel[] Options { get; set; }

        [JsonProperty(PropertyName = "maxDigits", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MaxDigits { get; set; }

        [JsonProperty(PropertyName = "repeats", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Repeats { get; set; }

        [JsonProperty(PropertyName = "repeatPrompt", NullValueHandling = NullValueHandling.Ignore)]
        public string RepeatPrompt { get; set; }

        [JsonProperty(PropertyName = "mainPrompt", NullValueHandling = NullValueHandling.Ignore)]
        public string MainPrompt { get; set; }

        [JsonProperty(PropertyName = "repeatText", NullValueHandling = NullValueHandling.Ignore)]
        public string RepeatText { get; set; }

        [JsonProperty(PropertyName = "mainText", NullValueHandling = NullValueHandling.Ignore)]
        public string MainText { get; set; }
    }
}