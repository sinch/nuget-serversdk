namespace Sinch.ServerSdk.Calling.Callbacks.Response.Internal
{
    internal class ConnectMxpSvamletResponse : SvamletResponse, IConnectMxpSvamletResponse
    {
        public IConnectMxpSvamletResponse WithCli(string cli)
        {
            Model.Action.Cli = cli;
            return this;
        }

        public IConnectMxpSvamletResponse WithAnonymousCli()
        {
            Model.Action.Cli = "private";
            return this;
        }
    }
}