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

        public IConnectMxpSvamletResponse WithIncomingCli()
        {
            Model.Action.Cli = "incoming";
            return this;
        }

        public IConnectMxpSvamletResponse WithIndications(string indications)
        {
            Model.Action.Indications = indications;
            return this;
        }

        public IConnectMxpSvamletResponse WithRecording()
        {
            Model.Action.Record = true;
            return this;
        }

        public IConnectMxpSvamletResponse WithoutRecording()
        {
            Model.Action.Record = false;
            return this;
        }

        public IConnectMxpSvamletResponse WithBillingTag(string tag)
        {
            Model.Action.BillingTag = tag;
            return this;
        }
    }
}