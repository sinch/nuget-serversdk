using Sinch.ServerSdk.Models;
using Sinch.WebApiClient;
using System;
using System.Threading.Tasks;






public class ConferenceCalloutRequest : IConferenceCalloutRequest
{
    public string cli { get; set; }
    public IdentityModel destination { get; set; }
    public string domain { get; set; }
    public string custom { get; set; }
    public string locale { get; set; }
    public string greeting { get; set; }
    public string conferenceId { get; set; }
    public bool enableDice { get; set; }
    public bool enableAce { get; set; }
    public bool enablePie { get; set; }
}