using System;
using System.Collections.Generic;
using System.Linq;
using Sinch.ServerSdk.Calling.Callbacks.Request;
using Sinch.ServerSdk.Calling.Callbacks.Request.Internal;
using Sinch.ServerSdk.Calling.Callbacks.Response;
using Sinch.ServerSdk.Calling.Model;

namespace Sinch.Callback.Response.Internal
{
    internal class CallerSvamletBuilder<T> : SvamletBuilder where T : ICallerSvamletBuilder<T>
    {
        private readonly IDictionary<string, Menu<T>> _menus = new Dictionary<string, Menu<T>>();
        private readonly IDictionary<string, NumberInputMenu> _numberInputMenus = new Dictionary<string, NumberInputMenu>();
        private static TypeMapper Mapper { get; } = new TypeMapper();

        internal CallerSvamletBuilder(Locale locale)
            : base(locale)
        {
        }

        public IConnectPstnSvamletResponse ConnectPstn(string number)
        {
            if (!string.IsNullOrEmpty(number))
            {
                if (!number.StartsWith("+"))
                    throw new BuilderException("Phone number should start with a '+'");

                if (number.Length < 7)
                    throw new BuilderException("Phone number too short");

                if (number.Length > 17)
                    throw new BuilderException("Phone number too long");

                if (number.Substring(1).Any(c => !char.IsDigit(c)))
                    throw new BuilderException("Phone numbers should only have digits after '+'");
            }

            SetAction(new SvamletActionModel
            {
                Name = "connectpstn",
                MaxDuration = (int) TimeSpan.FromMinutes(240).TotalSeconds,
                DialTimeout = 0,
                Cli = "private",
                Locale = Locale.Code,
                Destination = new IdentityModel
                {
                    Type = "number",
                    Endpoint = number
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

            if (!TypeMapper.Singleton.TryConvert(destination, out destinationModel))
                throw new BuilderException("Cannot interpres destination");

            SetAction(new SvamletActionModel
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

            SetAction(new SvamletActionModel
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


        public ISvamletResponse RunMenu(string menuId)
        {
            if (!_menus.ContainsKey(menuId) && !_numberInputMenus.ContainsKey(menuId))
                throw new BuilderException("Menu '" + menuId + "' is not defined");

            SetAction(new SvamletActionModel
            {
                Name = "runmenu",
                Locale = Locale.Code,
                MainMenu = menuId,
                Menus = _menus.Select(m =>
                {
                    var menu = new MenuModel
                    {
                        Id = m.Key,
                        MainPrompt = m.Value.Prompt.Specification,
                        RepeatPrompt = m.Value.RepeatPrompt.Specification,
                        Repeats = m.Value.Repeats,
                        TimeoutMills = (int) m.Value.Timeout.TotalMilliseconds
                    };

                    var options = m.Value.GotoMenuOptions.Select(mo => new MenuOptionModel()
                    {
                        Action = "menu(" + mo.Value.Item1 + ")",
                        AddToContext =
                            mo.Value.Item2 != null
                                ? mo.Value.Item2.Select(c => new KeyValueModel {Key = c.Key, Value = c.Value}).ToArray()
                                : null,
                        Digit = Mapper.AsString(mo.Key)
                    }).Union(m.Value.ReturnOptions.Select(ro => new MenuOptionModel()
                    {
                        Action = "return(" + ro.Value + ")",
                        Digit = Mapper.AsString(ro.Key),
                    }));

                    menu.Options = options.ToArray();

                    return menu;

                }).Union(_numberInputMenus.Select(i =>
                {
                    var menu = new MenuModel
                    {
                        Id = i.Key,
                        MainPrompt = i.Value.Prompt.Specification,
                        RepeatPrompt = i.Value.RepeatPrompt.Specification,
                        Repeats = i.Value.Repeats,
                        MaxDigits = i.Value.MaxDigits,
                        TimeoutMills = (int) i.Value.Timeout.TotalMilliseconds
                    };

                    return menu;
                })).ToArray()
            });

            return Build();
        }

        protected IMenu<T> InternalBeginMenuDefinition(T builder, string menuId, Prompt prompt, TimeSpan? timeout = null)
        {
            CheckMenuId(menuId);

            var menu = new Menu<T>(builder, prompt, null, 3, timeout);
            _menus[menuId] = menu;
            return menu;
        }

        private void CheckMenuId(string menuId)
        {
            if (string.IsNullOrEmpty(menuId))
                throw new BuilderException("Menu ID cannot be empty");

            if (menuId.Length > 64)
                throw new BuilderException("Menu ID cannot be longer than 64 chars");

            if (_numberInputMenus.ContainsKey(menuId) || _menus.ContainsKey(menuId))
                throw new BuilderException("Menu '" + menuId + "' already defined");
        }

        protected void InternalAddNumberInputMenu(string menuId, Prompt prompt, int maxDigits,
            Prompt repeatPrompt = null,
            int repeats = 3, TimeSpan? timeout = null)
        {
            CheckMenuId(menuId);

            var menu = new NumberInputMenu(prompt, repeatPrompt, repeats, maxDigits, timeout);
            _numberInputMenus[menuId] = menu;
        }
    }
}