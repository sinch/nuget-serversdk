using Sinch.ServerSdk.Calling.Callbacks.Request;

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
        IConnectSipSvamletResponse WithBillingTag(string tag);
    }
}