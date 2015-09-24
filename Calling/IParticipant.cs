namespace Sinch.ServerSdk.Calling
{
    public interface IParticipant
    {
        string Id { get; }
        string Cli { get; }
        int Duration { get; }
        bool Muted { get; }
    }
}