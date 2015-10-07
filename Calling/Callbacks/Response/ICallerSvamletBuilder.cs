using System;

namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface ICallerSvamletBuilder<out T> : ISvamletBuilder<T>
    {
        IConnectConferenceSvamletResponse ConnectConference(string conferenceId);
        IConnectConferenceSvamletResponse ConnectConference(string conferenceId, bool enableRecord);

        ISvamletResponse Park(string holdPromptFile, TimeSpan timeout);
        ISvamletResponse ParkWithTts(string holdPromptText, TimeSpan timeout);
    }
}