using System;

namespace Sinch.ServerSdk.IvrMenus
{
    internal class NumberInputMenu : AbstractMenu
    {
        public int MaxDigits { get; }

        internal NumberInputMenu(Prompt prompt, Prompt repeatPrompt, int repeats, int maxDigits, TimeSpan? timeout)
            : base(prompt, repeatPrompt, repeats, timeout)
        {
            MaxDigits = maxDigits;
        }
    }
}