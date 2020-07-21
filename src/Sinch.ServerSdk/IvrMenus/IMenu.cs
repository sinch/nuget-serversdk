using System.Collections.Generic;
using Sinch.ServerSdk.Calling.Callbacks.Response;

namespace Sinch.ServerSdk.IvrMenus
{
    public interface IMenu
    {
        IMenu AddGotoMenuOption(Dtmf option, string targetMenuId, IDictionary<string,string> cookies = null);
        IMenu AddGotoMenuOption(string option, string targetMenuId, IDictionary<string, string> cookies = null);
        IMenu AddTriggerPieOption(Dtmf option, string result);
        IMenu AddTriggerPieOption(string option, string result);
        IMenu WithRepeatPrompt(Prompt prompt);
        IMenu WithRepeats(int repeats);
        IMenuBuilder EndMenuDefinition();
    }
}