namespace Sinch.Callback.Response
{
    public class TtsPrompt : Prompt
    {
        public TtsPrompt(string text)
        {
            Specification = "#tts[" + text + "]";
        }
    }
}
