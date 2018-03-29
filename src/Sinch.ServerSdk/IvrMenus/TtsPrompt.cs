namespace Sinch.ServerSdk.IvrMenus
{
    public class TtsPrompt : Prompt
    {
        public TtsPrompt(string text)
        {
            Specification = "#tts[" + text + "]";
        }
    }
}
