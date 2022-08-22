using Sinch.ServerSdk.Calling.Callbacks.Request;
using Sinch.ServerSdk.Calling.Models;

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
        IConnectConferenceSvamletResponse WithCallTag(CallTag tagType, string value);
        IConnectConferenceSvamletResponse WithDtmfMode(DtmfMode mode);
    }
}