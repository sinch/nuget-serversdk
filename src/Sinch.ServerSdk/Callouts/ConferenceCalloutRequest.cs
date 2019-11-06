using Newtonsoft.Json;
using Sinch.ServerSdk.Callouts;
using Sinch.ServerSdk.Models;

public class ConferenceCalloutRequest : IConferenceCalloutRequest
{
    /// <summary>
    /// The from number in e164 format
    /// </summary>
    [JsonProperty(PropertyName = "cli", NullValueHandling = NullValueHandling.Ignore)]
    public string Cli { get; set; }
/// <summary>
///   Where to connect call to add to conference, usually a PSTN and e164 number
/// </summary>
    [JsonProperty(PropertyName = "destination", NullValueHandling = NullValueHandling.Ignore)]
    public IdentityModel Destination { get; set; }

    /// <summary>
    /// If you want to send a code to the conference, like conference pin, to pause prefix with v for 0.5 seconds. 
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, PropertyName = "dtmf")]
    public string Dtmf { get; set; }

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
    ConferenceCalloutRequest WithAce(bool enableAce) {
        this.EnableAce = enableAce;
        return this;

    }
    ConferenceCalloutRequest WithPie(bool enablePie)
    {
        this.EnablePie = enablePie;
        return this;

    }
    ConferenceCalloutRequest WithDice(bool enableDice)
    {
        this.EnableDice = enableDice;
        return this;

    }

}