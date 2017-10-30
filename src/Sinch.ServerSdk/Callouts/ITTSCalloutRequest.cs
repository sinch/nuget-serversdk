using Sinch.ServerSdk.Models;

public interface ITTSCalloutRequest
{
    string cli { get; set; }
    string custom { get; set; }
    IdentityModel destination { get; set; }
    string domain { get; set; }
    bool enableAce { get; set; }
    bool enableDice { get; set; }
    bool enablePie { get; set; }
    string locale { get; set; }
    string prompts { get; set; }
    string text { get; set; }
}