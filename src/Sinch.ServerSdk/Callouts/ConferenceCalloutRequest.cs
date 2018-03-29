using Newtonsoft.Json;
using Sinch.ServerSdk.Callouts;
using Sinch.ServerSdk.Models;

public class ConferenceCalloutRequest : IConferenceCalloutRequest
{
    [JsonProperty(PropertyName = "cli", NullValueHandling = NullValueHandling.Ignore)]
    public string Cli { get; set; }
    [JsonProperty(PropertyName = "destination", NullValueHandling = NullValueHandling.Ignore)]
    public IdentityModel Destination { get; set; }
    [JsonProperty(PropertyName = "domain", NullValueHandling = NullValueHandling.Ignore)]
    public string Domain { get; set; }
    [JsonProperty(PropertyName = "custom", NullValueHandling = NullValueHandling.Ignore)]
    public string Custom { get; set; }
    [JsonProperty(PropertyName = "locale", NullValueHandling = NullValueHandling.Ignore)]
    public string Locale { get; set; }
    [JsonProperty(PropertyName = "greeting", NullValueHandling = NullValueHandling.Ignore)]
    public string Greeting { get; set; }
    [JsonProperty(PropertyName = "conferenceId", NullValueHandling = NullValueHandling.Ignore)]
    public string ConferenceId { get; set; }
    [JsonProperty(PropertyName = "enableDice", NullValueHandling = NullValueHandling.Ignore)]
    public bool EnableDice { get; set; }
    [JsonProperty(PropertyName = "enableAce", NullValueHandling = NullValueHandling.Ignore)]
    public bool EnableAce { get; set; }
    [JsonProperty(PropertyName = "enablePie", NullValueHandling = NullValueHandling.Ignore)]
    public bool EnablePie { get; set; }
}