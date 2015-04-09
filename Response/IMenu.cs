using System.Collections.Generic;

namespace Sinch.Callback.Response
{
    public interface IMenu<out T>
    {
        IMenu<T> AddGotoMenuOption(Dtmf option, string targetMenuId, IDictionary<string,string> cookies = null);
        IMenu<T> AddTriggerPieOption(Dtmf option, string result);
        T EndMenuDefinition();
    }
}