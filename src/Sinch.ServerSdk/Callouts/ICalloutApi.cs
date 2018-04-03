using System;
using Sinch.ServerSdk.Calling.Callbacks.Response;
using Sinch.ServerSdk.IvrMenus;

namespace Sinch.ServerSdk.Callouts
{
    public interface ICalloutApi
    {
        ICalloutRequest TtsCallout(string to, string message, string from);
        ICalloutRequest ConferenceCallout(string to, string conferenceId, string from, string greeting);
        ICalloutRequest MenuCallout(string to, string from, IMenuBuilder menu, string startMenu, TimeSpan maxDuration);
        IMenuBuilder CreateMenuBuilder();
    }
}