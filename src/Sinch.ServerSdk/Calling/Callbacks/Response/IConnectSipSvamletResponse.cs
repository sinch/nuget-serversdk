using Sinch.ServerSdk.Calling.Models;

namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface IConnectSipSvamletResponse : ISvamletResponse
    {
        IConnectSipSvamletResponse WithCli(string cli);
        IConnectSipSvamletResponse WithExtension(string extension);
        IConnectSipSvamletResponse WithAnonymousCli();
        IConnectSipSvamletResponse WithIncomingCli();
        IConnectSipSvamletResponse WithIndications(string indications);
        IConnectSipSvamletResponse WithRecording();
        IConnectSipSvamletResponse WithoutRecording();
        IConnectSipSvamletResponse WithCallbacks();
        IConnectSipSvamletResponse WithoutCallbacks();
        IConnectSipSvamletResponse WithCallTag(CallTag tagType, string value);
    }
}