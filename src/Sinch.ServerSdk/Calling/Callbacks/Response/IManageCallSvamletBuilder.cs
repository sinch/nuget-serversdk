namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface IManageCallSvamletBuilder : ICallerSvamletBuilder<IManageCallSvamletBuilder>
    {
        IManageCallSvamletBuilder EnableBargeHangup();
    }
}