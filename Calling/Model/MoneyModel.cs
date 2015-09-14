using Newtonsoft.Json;

namespace Sinch.ServerSdk.Calling.Model
{
    public class MoneyModel
    {
        [JsonProperty(PropertyName = "currencyId")]
        public string CurrencyId { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }
    }
}
