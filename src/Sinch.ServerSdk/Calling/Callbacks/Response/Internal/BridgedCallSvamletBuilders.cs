using System;
using System.Linq;
using Sinch.ServerSdk.Calling.Callbacks.Request;
using Sinch.ServerSdk.Calling.Callbacks.Request.Internal;
using Sinch.ServerSdk.Calling.Models;
using Sinch.ServerSdk.IvrMenus;
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Calling.Callbacks.Response.Internal
{
    internal class BridgedCallSvamletBuilders<T> : CallerSvamletBuilder<T> where T : IBridgedCallSvamletBuilder<T>
    {
        private TypeMapper Mapper { get; } = new TypeMapper();

        internal BridgedCallSvamletBuilders(Locale locale)
            : base(locale)
        {
        }

        protected IConnectPstnSvamletResponse ConnectPstn(string number, string defaultCli)
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
                MaxDuration = (int)TimeSpan.FromMinutes(240).TotalSeconds,
                DialTimeout = 0,
                Cli = defaultCli,
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

        protected IConnectMxpSvamletResponse ConnectMxp(IIdentity destination, string defaultCli)
        {
            if (string.IsNullOrEmpty(destination?.Endpoint))
                throw new BuilderException("No destination given");

            if (destination.Endpoint.Length > 128)
                throw new BuilderException("Destination too long");

            if (!TypeMapper.Singleton.TryConvert(destination, out var destinationModel))
                throw new BuilderException("Cannot interpret destination");

            SetAction(new SvamletActionModel
            {
                Name = "connectmxp",
                Cli = defaultCli,
                Locale = Locale.Code,
                Destination = destinationModel
            });

            return Build<ConnectMxpSvamletResponse>();
        }

        protected IConnectSipSvamletResponse ConnectSip(string authName, string destination, string defaultCli)
        {
            IdentityModel identity = null;

            if (!string.IsNullOrEmpty(destination))
            {
                if(!destination.Contains("@"))
                    throw new BuilderException("Sip-URI should contain an '@'-sign");

                identity = new IdentityModel
                {
                    Endpoint = destination.Replace("sip:", string.Empty),
                    Type = "sip"
                };
            }

            SetAction(new SvamletActionModel
            {
                Name = "connectsip",
                Cli = defaultCli,
                Account = authName,
                Locale = Locale.Code,
                Destination = identity
            });

            return Build<ConnectSipSvamletResponse>();
        }

        protected IConnectMxpSvamletResponse ConnectMxp(string userName, string defaultCli)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                if (userName.Length > 128)
                    throw new BuilderException("User name too long");
            }

            SetAction(new SvamletActionModel
            {
                Name = "connectmxp",
                Cli = defaultCli,
                Locale = Locale.Code,
                Destination = new IdentityModel
                {
                    Type = "username",
                    Endpoint = userName
                }
            });

            return Build<ConnectMxpSvamletResponse>();
        }

        public ISvamletResponse RunMenu(string menuId, IMenuBuilder menuBuilder)
        {
            return RunMenu(menuId, false, menuBuilder);
        }

        public ISvamletResponse RunMenu(string menuId, bool enableVoice, IMenuBuilder menuBuilder)
        {
            var menus = menuBuilder.Build().ToDictionary(m => m.Id, m => m);

            if (!menus.ContainsKey(menuId))
                throw new BuilderException("Menu '" + menuId + "' is not defined");

            if (!enableVoice)
            {
                foreach(var menu in menus)
                    if (menu.Value.Options != null)
                        foreach (var option in menu.Value.Options)
                        {
                            if (option.Input != null && option.Digit == null)
                                throw new BuilderException("Menus with voice option disabled only support DTMF input");

                            option.Input = null;
                        }
            }

            SetAction(new SvamletActionModel
            {
                Name = "runmenu",
                Locale = Locale.Code,
                MainMenu = menuId,
                Menus = menus.Values.ToArray(),
                EnableVoice = enableVoice ? true : default(bool?) // avoid including the property in the serialized version if false
            });

            return Build();
        }
    }
}
