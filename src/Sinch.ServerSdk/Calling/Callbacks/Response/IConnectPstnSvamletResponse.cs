using System;

namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface IConnectPstnSvamletResponse : ISvamletResponse
    {
        IConnectPstnSvamletResponse WithDialTimeout(TimeSpan timeout);
        IConnectPstnSvamletResponse WithBridgeTimeout(TimeSpan timeout);
        IConnectPstnSvamletResponse WithCli(string cli);
        IConnectPstnSvamletResponse WithAnonymousCli();
        IConnectPstnSvamletResponse WithIncomingCli();
        IConnectPstnSvamletResponse WithCallbacks();
        IConnectPstnSvamletResponse WithoutCallbacks();
        IConnectPstnSvamletResponse WithIndications(string indications);
        IConnectPstnSvamletResponse WithRecording();
        IConnectPstnSvamletResponse WithoutRecording();
        IConnectPstnSvamletResponse WithBillingTag(string tag);
    }
}