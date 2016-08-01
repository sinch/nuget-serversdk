namespace Sinch.ServerSdk.Calling.Callbacks.Response.Internal
{
    internal class ConnectSipSvamletResponse : SvamletResponse, IConnectSipSvamletResponse
    {
        public IConnectSipSvamletResponse WithCli(string cli)
        {
            Model.Action.Cli = cli;
            return this;
        }

        public IConnectSipSvamletResponse WithAccount(string account)
        {
            Model.Action.Account = account;
            return this;
        }

        public IConnectSipSvamletResponse WithAnonymousCli()
        {
            Model.Action.Cli = "private";
            return this;
        }

        public IConnectSipSvamletResponse WithIncomingCli()
        {
            Model.Action.Cli = "incoming";
            return this;
        }

        public IConnectSipSvamletResponse WithIndications(string indications)
        {
            Model.Action.Indications = indications;
            return this;
        }
    }
}