﻿using System;
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

    public interface IConnectConferenceSvamletResponse : ISvamletResponse
    {
        IConnectConferenceSvamletResponse WithMusicOnHold(string moh);
        IConnectConferenceSvamletResponse WithRecording();
        IConnectConferenceSvamletResponse WithoutRecording();
        IConnectConferenceSvamletResponse WithCli(string cli);
    }
}