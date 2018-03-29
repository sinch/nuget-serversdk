using System;
using System.Collections.Generic;
using Sinch.ServerSdk.Calling.Callbacks.Response;

namespace Sinch.ServerSdk.IvrMenus
{
    internal class Menu : AbstractMenu, IMenu
    {
        private readonly IMenuBuilder _builder;

        public IDictionary<Dtmf,Tuple<string,IDictionary<string,string>>> GotoMenuOptions { get;  }
        public IDictionary<Dtmf,string> ReturnOptions { get; }

        internal Menu(IMenuBuilder builder, Prompt prompt, Prompt repeatPrompt, int repeats, TimeSpan? timeout)
            : base(prompt, repeatPrompt, repeats, timeout)
        {
            _builder = builder;

            GotoMenuOptions = new Dictionary<Dtmf, Tuple<string, IDictionary<string, string>>>();
            ReturnOptions = new Dictionary<Dtmf, string>();
        }

        public IMenu AddGotoMenuOption(Dtmf option, string targetMenuId, IDictionary<string,string> cookies = null)
        {
            CheckClash(option);
            GotoMenuOptions[option] = new Tuple<string, IDictionary<string, string>>(targetMenuId,cookies);
            return this;
        }

        private void CheckClash(Dtmf option)
        {
            if(GotoMenuOptions.ContainsKey(option) || ReturnOptions.ContainsKey(option))
                throw new BuilderException("Option '" + option + "' already defined");
        }

        public IMenu AddTriggerPieOption(Dtmf option, string result)
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
}