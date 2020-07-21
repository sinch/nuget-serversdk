using System;
using System.Collections.Generic;
using Sinch.ServerSdk.Calling.Callbacks.Response;
using Sinch.ServerSdk.Callouts;

namespace Sinch.ServerSdk.IvrMenus
{
    internal class Menu : AbstractMenu, IMenu
    {
        private readonly IMenuBuilder _builder;

        public IDictionary<MenuOption,Tuple<string,IDictionary<string,string>>> GotoMenuOptions { get;  }
        public IDictionary<MenuOption, string> ReturnOptions { get; }

        internal Menu(IMenuBuilder builder, Prompt prompt, Prompt repeatPrompt, int repeats, TimeSpan? timeout)
            : base(prompt, repeatPrompt, repeats, timeout)
        {
            _builder = builder;

            GotoMenuOptions = new Dictionary<MenuOption, Tuple<string, IDictionary<string, string>>>();
            ReturnOptions = new Dictionary<MenuOption, string>();
        }

        public IMenu AddGotoMenuOption(Dtmf option, string targetMenuId, IDictionary<string, string> cookies = null)
        {
            return AddGotoMenuOption((MenuOption)option, targetMenuId, cookies);
        }

        public IMenu AddGotoMenuOption(string option, string targetMenuId, IDictionary<string,string> cookies = null)
        {
            return AddGotoMenuOption((MenuOption)option, targetMenuId, cookies);
        }

        private IMenu AddGotoMenuOption(MenuOption option, string targetMenuId, IDictionary<string, string> cookies = null)
        {
            CheckClash(option);
            GotoMenuOptions[option] = new Tuple<string, IDictionary<string, string>>(targetMenuId, cookies);

            return this;
        }

        private void CheckClash(MenuOption option)
        {
            if(GotoMenuOptions.ContainsKey(option) || ReturnOptions.ContainsKey(option))
                throw new BuilderException("Option '" + option + "' already defined");
        }

        public IMenu AddTriggerPieOption(Dtmf option, string result)
        {
            return AddTriggerPieOption((MenuOption)option, result);
        }

        public IMenu AddTriggerPieOption(string option, string result)
        {
            return AddTriggerPieOption((MenuOption) option, result);
        }

        public IMenu AddTriggerPieOption(MenuOption option, string result)
        {
            CheckClash(option);
            ReturnOptions[option] = result;
            return this;
        }

        public IMenu WithRepeatPrompt(Prompt prompt)
        {
            RepeatPrompt = prompt;
            return this;
        }

        public IMenu WithRepeats(int repeats)
        {
            Repeats = repeats;
            return this;
        }

        public IMenuBuilder EndMenuDefinition()
        {
            return _builder;
        }
    }

    internal class MenuOption
    {
        private readonly Dtmf? _dtmf;
        private readonly string _input;

        public MenuOption(Dtmf dtmf)
        {
            _dtmf = dtmf;
            _input = null;
        }

        public MenuOption(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            _dtmf = input.TryMapToDtmf();
            // if dtmf is successfully parsed, treat this option as dtmf
            // reasoning is that input is always populated with the same value
            // as the dtmf, but if dtmf is missing, then only input is used
            _input = _dtmf == null ? input : null;
        }

        public override int GetHashCode()
        {
            return _input?.GetHashCode() ?? _dtmf.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MenuOption other))
                return false;

            return 
                (other._input != null && _input != null && _input.Equals(other._input)) ||
                (other._input == null && _input == null && _dtmf.Equals(other._dtmf));
        }

        public string Dtmf
        {
            get
            {
                if (_dtmf == null)
                    return null;

                return TypeMapper.Singleton.AsString((Dtmf) _dtmf);
            }
        }

        public string Input => Dtmf ?? _input;

        public override string ToString()
        {
            return Input;
        }

        public static implicit operator MenuOption(string input)
        {
            return new MenuOption(input);
        }

        public static implicit operator MenuOption(Dtmf dtmf)
        {
            return new MenuOption(dtmf);
        }
    }

    internal static class StringExtensions
    {
        public static Dtmf? TryMapToDtmf(this string value)
        {
            if (value == null || value.Length != 1)
                return null;

            var digit = value[0];

            if (digit == '*')
                return Dtmf.Asterisk;

            if (digit == '#')
                return Dtmf.Hash;

            return byte.TryParse(value, out var dtmf) ? (Dtmf) dtmf : default(Dtmf?);
        }
    }
}