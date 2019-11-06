using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Callouts
{
    public interface ITtsCalloutRequest
    {
        string Cli { get; set; }
        string Custom { get; set; }
        IdentityModel Destination { get; set; }
        string Dtmf { get; set; }
        string Domain { get; set; }
        bool EnableAce { get; set; }
        bool EnableDice { get; set; }
        bool EnablePie { get; set; }
        string Locale { get; set; }
        string Prompts { get; set; }
        string Text { get; set; }
        
    }
}