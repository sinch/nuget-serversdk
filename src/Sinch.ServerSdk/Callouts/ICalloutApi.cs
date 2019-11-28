using System;
using Sinch.ServerSdk.Calling.Callbacks.Response;
using Sinch.ServerSdk.IvrMenus;

namespace Sinch.ServerSdk.Callouts
{
    public interface ICalloutApi
    {
        ICalloutRequest TtsCallout(string to, string message, string from);
        ICalloutRequest TtsCallout(string to, string message, string from, string dtmf);
        ICalloutRequest ConferenceCallout(string to, string conferenceId, string from, string greeting);
        ICalloutRequest ConferenceCallout(string to, string conferenceId, string from, string greeting, string dtmf);

        ICalloutRequest MenuCallout(string to, string from, IMenuBuilder menu, string startMenu, TimeSpan? maxDuration);
        ICalloutRequest MenuCallout(string to, string from, IMenuBuilder menu, string startMenu, TimeSpan? maxDuration, string dtmf);

        IMenuBuilder CreateMenuBuilder();

        ICalloutRequest CustomCallout(string ice, string ace, string pie, string dice);
    }
}