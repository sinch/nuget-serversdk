namespace Sinch.ServerSdk.Calling
{
    public interface IGetConferenceResponse
    {
        IParticipant[] Participants { get; }
    }
}