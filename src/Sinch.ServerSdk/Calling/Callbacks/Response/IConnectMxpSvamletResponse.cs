using Sinch.ServerSdk.Calling.Models;

namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface IConnectMxpSvamletResponse : ISvamletResponse
    {
        IConnectMxpSvamletResponse WithCli(string cli);
        IConnectMxpSvamletResponse WithAnonymousCli();
        IConnectMxpSvamletResponse WithIncomingCli();
        IConnectMxpSvamletResponse WithIndications(string indications);
        IConnectMxpSvamletResponse WithRecording();
        IConnectMxpSvamletResponse WithoutRecording();
        IConnectMxpSvamletResponse WithCallTag(CallTag tagType, string value);
    }
}