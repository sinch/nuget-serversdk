﻿using Newtonsoft.Json;

namespace Sinch.ServerSdk.Calling.Models
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
