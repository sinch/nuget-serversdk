using Sinch.Callback.Response;

namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public class TtsPrompt : Prompt
    {
        public TtsPrompt(string text)
        {
            Specification = "#tts[" + text + "]";
        }
    }
}
