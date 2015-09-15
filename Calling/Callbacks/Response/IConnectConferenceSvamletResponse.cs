namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface IConnectConferenceSvamletResponse : ISvamletResponse
    {
        IConnectConferenceSvamletResponse WithMusicOnHold(string moh);
        IConnectConferenceSvamletResponse WithRecording();
        IConnectConferenceSvamletResponse WithoutRecording();
        IConnectConferenceSvamletResponse WithCli(string cli);
    }
}