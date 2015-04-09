namespace Sinch.Callback.Response
{
    public interface IIceSvamletBuilder : ICallerSvamletBuilder<IIceSvamletBuilder>
    {
        ISvamletResponse RunMenu(string menuId);
        IMenu<IIceSvamletBuilder> BeginMenuDefinition(string menuId, string prompt, string repeatPrompt = null, int repeats = 3);
        IIceSvamletBuilder AddNumberInputMenu(string menuId, string prompt, int maxDigits, string repeatPrompt = null, int repeats = 3);
    }
}