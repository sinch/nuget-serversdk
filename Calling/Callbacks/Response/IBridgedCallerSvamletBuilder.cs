using System;
using Sinch.ServerSdk.Calling.Callbacks.Request;

namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface IBridgedCallSvamletBuilder<T> : ICallerSvamletBuilder<T>
    {
        IConnectPstnSvamletResponse ConnectPstn(string number);
        IConnectMxpSvamletResponse ConnectMxp(string userName);
        IConnectMxpSvamletResponse ConnectMxp(IIdentity identity);
        IMenu<T> BeginMenuDefinition(string menuId, Prompt prompt, TimeSpan? timeout);
        T AddNumberInputMenu(string menuId, Prompt prompt, int maxDigits, Prompt repeatPrompt = null, int repeats = 3, TimeSpan? timeout = null);
        ISvamletResponse RunMenu(string menuId);
    }
}