namespace Sinch.ServerSdk.Callouts
{
    public interface ICalloutApi
    {
        ICalloutRequest TTSCallout(string to, string message, string from);
        ICalloutRequest ConferenceCallout(string to, string conferenceId, string from, string greeting);
    }
}