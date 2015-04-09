using Newtonsoft.Json;

namespace Sinch.Callback.Model
{
    public class MenuResultModel
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "menuId")]
        public string MenuId { get; set; }
    }
}
