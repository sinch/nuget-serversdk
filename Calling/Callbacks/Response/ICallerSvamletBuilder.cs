using System;
using Sinch.ServerSdk.Calling.Callbacks.Request;

namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface ICallerSvamletBuilder<out T> : ISvamletBuilder<T>
    {
        IConnectPstnSvamletResponse ConnectPstn(string number);
        IConnectMxpSvamletResponse ConnectMxp(string userName);
        IConnectMxpSvamletResponse ConnectMxp(IIdentity identity);
        IConnectConferenceSvamletResponse ConnectConference(string conferenceId);
        IConnectConferenceSvamletResponse ConnectConference(string conferenceId, bool enableRecord);

        ISvamletResponse Park(string holdPromptFile, TimeSpan timeout);
        ISvamletResponse ParkWithTts(string holdPromptText, TimeSpan timeout);

        ISvamletResponse RunMenu(string menuId);
        IMenu<T> BeginMenuDefinition(string menuId, Prompt prompt, TimeSpan? timeout);
        T AddNumberInputMenu(string menuId, Prompt prompt, int maxDigits, Prompt repeatPrompt = null, int repeats = 3, TimeSpan? timeout = null);
    }
}