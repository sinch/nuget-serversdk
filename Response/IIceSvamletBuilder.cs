using System;

namespace Sinch.Callback.Response
{
    public interface IIceSvamletBuilder : ICallerSvamletBuilder<IIceSvamletBuilder>
    {
        ISvamletResponse RunMenu(string menuId);
        IMenu<IIceSvamletBuilder> BeginMenuDefinition(string menuId, Prompt prompt, TimeSpan? timeout);
        IIceSvamletBuilder AddNumberInputMenu(string menuId, Prompt prompt, int maxDigits, Prompt repeatPrompt = null, int repeats = 3, TimeSpan? timeout = null);
    }
}