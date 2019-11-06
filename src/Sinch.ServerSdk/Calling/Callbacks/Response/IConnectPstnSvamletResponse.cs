using System;
using Sinch.ServerSdk.Calling.Models;

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
        IConnectPstnSvamletResponse WithCallTag(CallTag tagType, string value);
        IConnectPstnSvamletResponse WithDTMF(string dtmf);
    }
}