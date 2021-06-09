namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface IDiceSvamletBuilder : ISvamletBuilder<IDiceSvamletBuilder>
    {
        IDiceSvamletBuilder ReportCallStatus(CallStatus status, string details);
    }
}