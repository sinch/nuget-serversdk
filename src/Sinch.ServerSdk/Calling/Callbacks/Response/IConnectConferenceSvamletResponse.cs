namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface IConnectConferenceSvamletResponse : ISvamletResponse
    {
        IConnectConferenceSvamletResponse WithMusicOnHold(string moh);
        IConnectConferenceSvamletResponse WithRecording();
        IConnectConferenceSvamletResponse WithoutRecording();
        IConnectConferenceSvamletResponse WithCli(string cli);
        IConnectConferenceSvamletResponse WithEnterAndLeaveSounds();
        IConnectConferenceSvamletResponse WithoutEnterAndLeaveSounds();
        IConnectConferenceSvamletResponse WithTwoParts();
        IConnectConferenceSvamletResponse WithMultiParts();
    }
}