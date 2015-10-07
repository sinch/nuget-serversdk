using Sinch.ServerSdk.Calling.Callbacks.Request;

namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface IBridgedCallSvamletBuilder<T> : ICallerSvamletBuilder<T>
    {
        IConnectPstnSvamletResponse ConnectPstn(string number);
        IConnectMxpSvamletResponse ConnectMxp(string userName);
        IConnectMxpSvamletResponse ConnectMxp(IIdentity identity);
    }
}