using System;
using Sinch.ServerSdk.Calling.Models;

namespace Sinch.ServerSdk.IvrMenus
{
    public interface IMenuBuilder
    {
        IMenu BeginMenuDefinition(string menuId, Prompt prompt, TimeSpan? timeout);
        IMenuBuilder AddNumberInputMenu(string menuId, Prompt prompt, int maxDigits, Prompt repeatPrompt = null, int repeats = 3, TimeSpan? timeout = null);
        MenuModel[] Build();
    }
}
