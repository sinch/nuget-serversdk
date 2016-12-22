namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface IConnectMxpSvamletResponse : ISvamletResponse
    {
        IConnectMxpSvamletResponse WithCli(string cli);
        IConnectMxpSvamletResponse WithAnonymousCli();
        IConnectMxpSvamletResponse WithIncomingCli();
        IConnectMxpSvamletResponse WithIndications(string indications);
    }
}