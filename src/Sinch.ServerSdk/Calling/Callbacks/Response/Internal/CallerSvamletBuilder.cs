using System;
using Sinch.ServerSdk.Calling.Models;
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Calling.Callbacks.Response.Internal
{
    internal class CallerSvamletBuilder<T> : SvamletBuilder where T : ICallerSvamletBuilder<T>
    {
        internal CallerSvamletBuilder(Locale locale)
            : base(locale)
        {
        }

        public IConnectConferenceSvamletResponse ConnectConference(string conferenceId)
        {
            return ConnectConference(conferenceId, false);
        }

        public IConnectConferenceSvamletResponse ConnectConference(string conferenceId, bool enableRecord)
        {
            if (string.IsNullOrEmpty(conferenceId))
                throw new BuilderException("Conference id must be supplied");

            if (conferenceId.Length > 128)
                throw new BuilderException("Conference id too long (max 128 characters)");

            SetAction(new SvamletActionModel
            {
                Name = "connectconf",
                ConferenceId = conferenceId,
                Locale = Locale.Code,
                Record = enableRecord
            });

            return Build<ConnectConferenceSvamletResponse>();
        }

        public ISvamletResponse Park(string holdPrompt, TimeSpan timeout)
        {
            if (string.IsNullOrEmpty(holdPrompt))
                throw new BuilderException("A hold prompt must be supplied");

            if (timeout.TotalSeconds < 60 && timeout.TotalSeconds > 600)
                throw new BuilderException("The timeout must be between 1 and 10 minutes");

            SetAction(new SvamletActionModel
            {
                Name = "park",
                HoldPrompt = holdPrompt,
                Locale = Locale.Code,
                DialTimeout = (int) timeout.TotalSeconds
            });

            return Build();
        }

        public ISvamletResponse ParkWithTts(string holdPromptText, TimeSpan timeout)
        {
            if (string.IsNullOrEmpty(holdPromptText))
                throw new BuilderException("A hold prompt must be supplied");

            if (timeout.TotalSeconds < 60 && timeout.TotalSeconds > 600)
                throw new BuilderException("The timeout must be between 1 and 10 minutes");

            SetAction(new SvamletActionModel
            {
                Name = "park",
                HoldPrompt = "tts#[" + holdPromptText + "]",
                Locale = Locale.Code,
                DialTimeout = (int) timeout.TotalSeconds
            });

            return Build();
        }
   }
}