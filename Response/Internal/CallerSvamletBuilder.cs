using System;
using System.Linq;
using Sinch.Callback.Model;
using Sinch.Callback.Request;
using Sinch.Callback.Request.Internal;

namespace Sinch.Callback.Response.Internal
{
    internal class CallerSvamletBuilder : SvamletBuilder
    {
        internal CallerSvamletBuilder(Locale locale)
            : base(locale)
        {
        }

        public IConnectPstnSvamletResponse ConnectPstn(string destination)
        {
            if (!string.IsNullOrEmpty(destination))
            {
                if (!destination.StartsWith("+"))
                    throw new BuilderException("Phone number should start with a '+'");

                if (destination.Length < 7)
                    throw new BuilderException("Phone number too short");

                if (destination.Length > 17)
                    throw new BuilderException("Phone number too long");

                if (destination.Substring(1).Any(c => !char.IsDigit(c)))
                    throw new BuilderException("Phone numbers should only have digits after '+'");
            }

            SetAction(new SvamletAction
            {
                Name = "connectpstn",
                MaxDuration = (int) TimeSpan.FromMinutes(240).TotalSeconds,
                DialTimeout = 0,
                Cli = "private",
                Locale = Locale.Code,
                Destination = new IdentityModel
                {
                    Type = "number",
                    Endpoint = destination
                },
                SuppressCallbacks = false
            });

            return Build<ConnectPstnSvamletResponse>();
        }

        public IConnectMxpSvamletResponse ConnectMxp(IIdentity destination)
        {
            if (destination == null || string.IsNullOrEmpty(destination.Endpoint))
                throw new BuilderException("No destionation given");

            if (destination.Endpoint.Length > 128)
                throw new BuilderException("Destination too long");

            IdentityModel destinationModel;

            if(!TypeMapper.Singleton.TryConvert(destination, out destinationModel))
                throw new BuilderException("Cannot interpres destination");

            SetAction(new SvamletAction
            {
                Name = "connectmxp",
                Cli = "private",
                Locale = Locale.Code,
                Destination = destinationModel
            });

            return Build<ConnectMxpSvamletResponse>();
        }

        public IConnectMxpSvamletResponse ConnectMxp(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                if (userName.Length > 128)
                    throw new BuilderException("User name too long");
            }

            SetAction(new SvamletAction
            {
                Name = "connectmxp",
                Cli = "private",
                Locale = Locale.Code,
                Destination = new IdentityModel
                {
                    Type = "username",
                    Endpoint = userName
                }
            });

            return Build<ConnectMxpSvamletResponse>();
        }

        public IConnectConferenceSvamletResponse ConnectConference(string conferenceId)
        {
            return ConnectConference(conferenceId, false);
        }

        public IConnectConferenceSvamletResponse ConnectConference(string conferenceId, bool enableRecord)
        {
            if (string.IsNullOrEmpty(conferenceId))
                throw new BuilderException("Conference id must be supplied");
            
            if(conferenceId.Length > 128)
                throw new BuilderException("Conference id too long (max 128 characters)");

            SetAction(new SvamletAction
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

            SetAction(new SvamletAction
            {
                Name = "park",
                HoldPrompt = holdPrompt,
                Locale = Locale.Code,
                DialTimeout = (int) timeout.TotalSeconds
            });

            return Build();
        }
    }
}