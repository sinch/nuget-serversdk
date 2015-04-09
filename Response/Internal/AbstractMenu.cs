namespace Sinch.Callback.Response.Internal
{
    internal class AbstractMenu
    {
        protected AbstractMenu(string prompt, string repeatPrompt, int repeats)
        {
            Prompt = prompt ?? repeatPrompt;
            RepeatPrompt = repeatPrompt ?? prompt;
            Repeats = repeats;
        }

        public string Prompt { get; private set; }
        public string RepeatPrompt { get; private set; }
        public int Repeats { get; private set; }
    }
}