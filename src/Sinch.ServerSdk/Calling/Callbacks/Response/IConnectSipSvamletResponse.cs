namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface IConnectSipSvamletResponse : ISvamletResponse
    {
        IConnectSipSvamletResponse WithCli(string cli);
        IConnectSipSvamletResponse WithAccount(string account);
        IConnectSipSvamletResponse WithAnonymousCli();
        IConnectSipSvamletResponse WithIncomingCli();
        IConnectSipSvamletResponse WithIndications(string indications);
    }
}