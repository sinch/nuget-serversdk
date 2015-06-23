namespace Sinch.Callback.Response.Internal
{
    internal class AbstractMenu
    {
        protected AbstractMenu(Prompt prompt, Prompt repeatPrompt, int repeats)
        {
            Prompt = prompt ?? repeatPrompt;
            RepeatPrompt = repeatPrompt ?? prompt;
            Repeats = repeats;
        }

        public Prompt Prompt { get; protected set; }
        public Prompt RepeatPrompt { get; protected set; }
        public int Repeats { get; protected set; }
    }
}