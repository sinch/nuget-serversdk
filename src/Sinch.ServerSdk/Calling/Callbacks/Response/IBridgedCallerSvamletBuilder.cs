using Sinch.ServerSdk.Calling.Callbacks.Request;
using Sinch.ServerSdk.IvrMenus;

namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface IBridgedCallSvamletBuilder<T> : ICallerSvamletBuilder<T>
    {
        IConnectPstnSvamletResponse ConnectPstn(string number);
        IConnectMxpSvamletResponse ConnectMxp(string userName);
        IConnectSipSvamletResponse ConnectSipDestination(string sipUri);
        IConnectSipSvamletResponse ConnectRegisteredSipPeer(string authName);
        IConnectMxpSvamletResponse ConnectMxp(IIdentity identity);
        ISvamletResponse RunMenu(string menuId, IMenuBuilder menuBuilder);
    }
}