namespace Sinch.ServerSdk.Callouts
{
    public interface ICustomCalloutCalloutRequest
    {
        string Ice { get; set; }
        string Ace { get; set; }
        string Dice { get; set; }
        string Pie { get; set; }
        string Custom { get; set; }
    }
}