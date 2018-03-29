using System.Linq;

namespace Sinch.ServerSdk.IvrMenus
{
    public abstract class Prompt
    {
        public string Specification { get; protected set; }

        private static Prompt Convert(string text)
        {
            if(text.StartsWith("$"))
                return new PromptFile(text.Substring(1));

            return new TtsPrompt(text);
        }

        public static implicit operator Prompt(string text)
        {
            if (text.Contains(';'))
                return new PromptChain(text.Split(';').Select(Convert));

            return Convert(text);
        }
    }
}