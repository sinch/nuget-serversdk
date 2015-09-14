using System;
using Sinch.ServerSdk.Calling.Callbacks.Response;

namespace Sinch.Callback.Response.Internal
{
    internal class AbstractMenu
    {
        protected AbstractMenu(Prompt prompt, Prompt repeatPrompt, int repeats, TimeSpan? timeout)
        {
            Prompt = prompt ?? repeatPrompt;
            RepeatPrompt = repeatPrompt ?? prompt;
            Repeats = repeats;
            Timeout = timeout ?? TimeSpan.FromSeconds(5);

            if(Timeout > TimeSpan.FromSeconds(30))
                throw new BuilderException("Timeout can be max 30 seconds");

            if (Timeout < TimeSpan.FromSeconds(1))
                throw new BuilderException("Timeout can be min 1 second");
        }

        public Prompt Prompt { get; protected set; }
        public Prompt RepeatPrompt { get; protected set; }
        public int Repeats { get; protected set; }
        public TimeSpan Timeout { get; private set; }
    }
}