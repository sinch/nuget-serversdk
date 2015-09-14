using System;
using Sinch.ServerSdk.Calling.Callbacks.Response;

namespace Sinch.Callback.Response.Internal
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