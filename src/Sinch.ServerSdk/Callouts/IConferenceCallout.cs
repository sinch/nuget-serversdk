using Sinch.ServerSdk.Models;

public interface IConferenceCalloutRequest
{
    string cli { get; set; }
    string conferenceId { get; set; }
    string custom { get; set; }
    IdentityModel destination { get; set; }
    string domain { get; set; }
    bool enableAce { get; set; }
    bool enableDice { get; set; }
    bool enablePie { get; set; }
    string greeting { get; set; }
    string locale { get; set; }
}