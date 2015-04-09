namespace Sinch.Callback.Response
{
    public interface IManageCallSvamletBuilder : ICallerSvamletBuilder<IManageCallSvamletBuilder>
    {
        IManageCallSvamletBuilder EnableBargeHangup();
    }
}