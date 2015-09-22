using Newtonsoft.Json;
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Calling.Models
{
    public class CallbackEventModel
    {
        [JsonProperty(PropertyName = "event")]
        public string Event { get; set; }

        [JsonProperty(PropertyName = "callid")]
        public string CallId { get; set; }

        [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public string Timestamp { get; set; }

        [JsonProperty(PropertyName = "reference", NullValueHandling = NullValueHandling.Ignore)]
        public string Reference { get; set; }

        [JsonProperty(PropertyName = "reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; set; }

        [JsonProperty(PropertyName = "result", NullValueHandling = NullValueHandling.Ignore)]
        public string Result { get; set; }

        [JsonProperty(PropertyName = "menuResult", NullValueHandling = NullValueHandling.Ignore)]
        public MenuResultModel MenuResult { get; set; }

        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

        [JsonProperty(PropertyName = "custom", NullValueHandling = NullValueHandling.Ignore)]
        public string Custom { get; set; }

        [JsonProperty(PropertyName = "user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty(PropertyName = "debit", NullValueHandling = NullValueHandling.Ignore)]
        public MoneyModel Debit { get; set; }

        [JsonProperty(PropertyName = "userRate", NullValueHandling = NullValueHandling.Ignore)]
        public MoneyModel Rate { get; set; }

        [JsonProperty(PropertyName = "cookies", NullValueHandling = NullValueHandling.Ignore)]
        public KeyValueModel[] Cookies { get; set; }

        [JsonProperty(PropertyName = "cli", NullValueHandling = NullValueHandling.Ignore)]
        public string Cli { get; set; }

        [JsonProperty(PropertyName = "to", NullValueHandling = NullValueHandling.Ignore)]
        public IdentityModel To { get; set; }

        [JsonProperty(PropertyName = "domain", NullValueHandling = NullValueHandling.Ignore)]
        public string Domain { get; set; }

        [JsonProperty(PropertyName = "applicationKey", NullValueHandling = NullValueHandling.Ignore)]
        public string ApplicationKey { get; set; }

        [JsonProperty(PropertyName = "originationType", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginationType { get; set; }

        [JsonProperty(PropertyName = "duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "from", NullValueHandling = NullValueHandling.Ignore)]
        public string From { get; set; }

        [JsonProperty(PropertyName = "delayed", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Delayed { get; set; }

        [JsonProperty(PropertyName = "errorCode", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ErrorCode { get; set; }

        [JsonProperty(PropertyName = "errorMsg", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMsg { get; set; }

        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}