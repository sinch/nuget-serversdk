using System;
using Sinch.Callback.Request;

namespace Sinch.Callback.Response
{
    public interface ICallerSvamletBuilder<out T> : ISvamletBuilder<T>
    {
        IConnectPstnSvamletResponse ConnectPstn(string destination);
        IConnectMxpSvamletResponse ConnectMxp(string userName);
        IConnectMxpSvamletResponse ConnectMxp(IIdentity identity);
        ISvamletResponse ConnectConference(string conferenceId);
        ISvamletResponse Park(string holdPrompt, TimeSpan timeout);
    }

    public interface IConnectMxpSvamletResponse : ISvamletResponse
    {
        IConnectMxpSvamletResponse WithCli(string cli);
        IConnectMxpSvamletResponse WithAnonymousCli();
    }

    public interface IConnectPstnSvamletResponse : ISvamletResponse
    {
        IConnectPstnSvamletResponse WithDialTimeout(TimeSpan timeout);
        IConnectPstnSvamletResponse WithOptimizedDialTimeout();
        IConnectPstnSvamletResponse WithBridgeTimeout(TimeSpan timeout);
        IConnectPstnSvamletResponse WithCli(string cli);
        IConnectPstnSvamletResponse WithAnonymousCli();
        IConnectPstnSvamletResponse WithCallbacks();
        IConnectPstnSvamletResponse WithoutCallbacks();
    }
}