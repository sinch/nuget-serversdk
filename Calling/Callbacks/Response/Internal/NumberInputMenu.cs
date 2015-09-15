using System;

namespace Sinch.ServerSdk.Calling.Callbacks.Response.Internal
{
    internal class NumberInputMenu : AbstractMenu
    {
        public int MaxDigits { get; private set; }

        internal NumberInputMenu(Prompt prompt, Prompt repeatPrompt, int repeats, int maxDigits, TimeSpan? timeout)
            : base(prompt, repeatPrompt, repeats, timeout)
        {
            MaxDigits = maxDigits;
        }
    }
}